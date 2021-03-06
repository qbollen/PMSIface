﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using Utils;
using System.Data.OleDb;
using Model;
using System.Collections;
namespace PMSInterface
{
    public partial class FrmMain : Form
    {
        Thread serverThread;
        //TcpClient clientTcp;
        private string[] Data = new string[8];
        SqlHelper sqlHelper = new SqlHelper();
        public static ConnSta CurrConnSta = ConnSta.NULL;
        private static ConnSta CurrInterfaceConnSta = ConnSta.NULL;
        public static FrmWorkStation frmWorkstation;
        private FrmCommunicationLog frmCommLog;
        public delegate void UpdateHandler(Workstation workstation);
        public event UpdateHandler UpdateEvent;
        public delegate void LogHandler(string text);
        public event LogHandler LogEvent;
        public static Dictionary<string, string> InstructMap;
        public static Dictionary<TcpClient,string> ClientList = new Dictionary<TcpClient,string>();
        private BollenSocket InterfaceClient;
        private bool IsReceive;
        public static string CheckOutType, CheckOutTime;
        public static decimal AutoConnTime;
        public static bool IsAutoConn;
        private string Auth_Code;
        private string Building_Addr;
        public static DateTime Registe;
        public static bool Valid = true;
        public static bool IsClose = false;
        public static bool La = false;
        public FrmMain()
        {
            InitializeComponent();         
        }

        #region 自定义方法
        public void UpdateView(Workstation workstation)
        {
            if (UpdateEvent != null)
            {
                UpdateEvent(workstation);
            }
        }

        public void CommLog(string text)
        {
            if (LogEvent != null)
            {
                LogEvent(text);
            }
        }

        bool lSendA = true;
        bool lReceiveA = false;
        private void ConnectTuInterface()
        {
            if (lSendA && ((this.transLeftA.Left) -= 2) > 0)
            {
                lReceiveA = false;
                this.transRightA.Left = 0;
                this.transRightA.Visible = false;
            }
            else
            {
                lReceiveA = true;
                this.transRightA.Visible = true;
            }

            if (lReceiveA && ((this.transRightA.Left) += 2) < this.transAreaA.Width - this.transRightA.Width)
            {
                lSendA = false;
                this.transLeftA.Left = this.transAreaA.Width - this.transLeftA.Width;
                this.transLeftA.Visible = false;
            }
            else
            {
                lSendA = true;
                this.transLeftA.Visible = true;
            }
        }

        bool lSendB = true;
        bool lReceiveB = false;
        private void ConnectTuClient()
        {
            if (lSendB && ((this.transLeftB.Left) -= 2) > 0)
            {
                lReceiveB = false;
                this.transRightB.Left = 0;
                this.transRightB.Visible = false;
            }
            else
            {
                lReceiveB = true;
                this.transRightB.Visible = true;
            }

            if (lReceiveB && ((this.transRightB.Left) += 2) < this.transAreaB.Width - this.transRightB.Width)
            {
                lSendB = false;
                this.transLeftB.Left = this.transAreaB.Width - this.transLeftB.Width;
                this.transLeftB.Visible = false;
            }
            else
            {
                lSendB = true;
                this.transLeftB.Visible = true;
            }
        }

        public delegate void ArouseDelegate(string keycoder, string workstation);
        private void Listener()
        {
            sqlHelper.CurrConn = Utils.DbType.Local;
            int port = Convert.ToInt32(sqlHelper.ExecuteScalar("select keyport from Interface", null));
            if (port == 0)
            {
                CurrConnSta = ConnSta.NoPort;
                return;
            }
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, port);
            BollenSocket serverSocket = new BollenSocket(endPoint);
            if (serverSocket.Listen())
            {
                while (Valid)
                {
                    CurrConnSta = ConnSta.Listen;
                    try
                    {
                        TcpClient clientTcp = serverSocket.TCPListener.AcceptTcpClient();
                        ThreadPool.QueueUserWorkItem(new WaitCallback(ReceiveData), clientTcp);
                    }
                    catch
                    {
                        //listening error.
                        break;
                    }
                }
            }
        }

        private void ReceiveData(object state)
        {
            TcpClient client = (TcpClient)state/*clientTcp*/;
            NetworkStream ns = client.GetStream();
            //byte[] buffer = new byte[1024];
            IPEndPoint clientEndPoint = (IPEndPoint)client.Client.RemoteEndPoint;
            IPHostEntry clientHostEntry = Dns.GetHostEntry(clientEndPoint.Address.ToString());
            string clientHostName = clientHostEntry.HostName;
            string serverHostName = Dns.GetHostName();

            SocketEntity entity = new SocketEntity(
                Command.IF, new string[]{}, serverHostName, clientHostName); 
            BollenSocket.Send(ns, entity);

            string keycoder = string.Empty;
            while (Valid)
            {
                CurrConnSta = ConnSta.Connected;
                try
                {
                    entity = BollenSocket.Receive(ns);
                    if (entity == null)
                    {
                        continue;
                    }
                   
                    switch (entity.Cmd)
                    {
                        case Command.RQ:
                            keycoder = entity.Data[0];
                            ClientList.Add(client, keycoder);
                            this.UpdateView(new Workstation { KeyCoder = keycoder, WorkstationName = clientHostName });
                            break;
                        case Command.KA:
                            string answer;
                            if (entity.Data[0] == "Success")
                            {
                                answer = InstructMap["Success"];
                                //delete blacklist;
                                DeleteBlackList(entity.Data[1]);
                                //save issue records
                                IssueRecEntity recEntity = Manage.GetRecEntity(entity.Data[2]);
                                if (recEntity != null)
                                {
                                    UpdateRoomData(recEntity.RoomNumber, "2", recEntity.GuestName, 
                                        recEntity.ArrivalDate, recEntity.DepartureDate);
                                    recEntity.Workstation = entity.Data[3];
                                    recEntity.OperateTime = entity.Data[4];
                                    InsertIssueRec(recEntity);
                                }
                                else
                                {
                                    this.CommLog("Issue record save failed");
                                } 
                              

                            }
                            else
                            {
                                answer = InstructMap["Failure"];
                            }

                            if (InterfaceClient == null)
                            {
                                this.CommLog("PMS interface is broken");
                                break;
                            }

                            answer = answer.Replace("*", keycoder);

                            try
                            {
                                BollenSocket.Write(InterfaceClient.NetStream,Encoding.UTF8.GetBytes(answer));
                            }
                            catch
                            {
                                break;
                            }
                            break;
                        default:
                            break;
                    }
                }
                catch
                {
                    //error process.
                    try
                    {
                        ClientList.Remove(client);
                    }
                    catch
                    {

                    }
                    break;
                }
            }
            if (keycoder != string.Empty)
            {
                frmWorkstation.SafeDel(keycoder);
            }

            if (ClientList.Count == 0)
            {
                CurrConnSta = ConnSta.Listen;
            }
        }

        private void StartListen()
        {
            serverThread = new Thread(new ThreadStart(Listener));
            serverThread.Name = "Server Listener";
            serverThread.IsBackground = true;
            serverThread.Start();
        }

        private void Hint(Label label, string content, bool hint,
            Panel panel, bool anim,System.Windows.Forms.Timer timer)
        {
            label.Text = content;
            label.Visible = hint;

            panel.Visible = anim;
            timer.Enabled = anim;
        }

        private bool DeleteBlackList(string cardNo)
        {
            sqlHelper.CurrConn = Utils.DbType.Remote;
            string sql = "DELETE FROM blacklist WHERE Black_CardNo=@CardNo";
            OleDbParameter[] parms = new OleDbParameter[]
            {
                new OleDbParameter("@CardNo",OleDbType.VarWChar)
            };
            parms[0].Value = cardNo;
            try
            {
                sqlHelper.ExecuteNonQuery(sql, parms);
            }
            catch
            {
                return false;
            }

            return true;
        }

        private bool InsertIssueRec(IssueRecEntity entity)
        {
            string sql = "insert into IssueRec (RoomNumber,KeyCount,KeyType,OperateTime,"
            + "Workstation,KeyCoder,GuestName,ArrivalDate,DepartureDate) "
            + "values (@RoomNumber,@KeyCount,@KeyType,@OperateTime,"
            + "@Workstation,@KeyCoder,@GuestName,@ArrivalDate,@DepartureDate)";
            OleDbParameter[] parms = new OleDbParameter[]
            {
                new OleDbParameter("@RoomNumber",OleDbType.VarWChar),
                new OleDbParameter("@KeyCount",OleDbType.VarWChar),
                new OleDbParameter("@KeyType",OleDbType.VarWChar),
                new OleDbParameter("@OperateTime",OleDbType.VarWChar),
                new OleDbParameter("@Workstation",OleDbType.VarWChar),
                new OleDbParameter("@KeyCoder",OleDbType.VarWChar),
                new OleDbParameter("@GuestName",OleDbType.VarWChar),
                new OleDbParameter("@ArrivalDate",OleDbType.VarWChar),
                new OleDbParameter("@DepartureDate",OleDbType.VarWChar)
            };
            parms[0].Value = entity.RoomNumber;
                parms[1].Value = entity.KeyCount;
                    parms[2].Value = entity.KeyType;
                        parms[3].Value = entity.OperateTime;
                            parms[4].Value = entity.Workstation;
                                parms[5].Value = entity.KeyCoder;
                                    parms[6].Value = entity.GuestName;
                                        parms[7].Value = entity.ArrivalDate;
                                            parms[8].Value = entity.DepartureDate;
            sqlHelper.CurrConn = Utils.DbType.Local;
            try
            {
                sqlHelper.ExecuteNonQuery(sql, parms);
            }
            catch { return false; }
            
            return true;
        }

        private bool UpdateRoomData(string roomNumber,string roomSta,string guestName,
            string checkIn, string checkOut)
        {
            string sql = "Update room Set room_sta=@roomSta,UserName=@UserName,CheckIn=@CheckIn,"
             + "CheckOut=@CheckOut Where val(Room_name)=@roomNumber";
            OleDbParameter[] parms = new OleDbParameter[]
            {
                new OleDbParameter("@roomSta",OleDbType.VarWChar),
                new OleDbParameter("@UserName",OleDbType.VarWChar),
                new OleDbParameter("@CheckIn",OleDbType.VarWChar),
                new OleDbParameter("@CheckOut",OleDbType.VarWChar),
                new OleDbParameter("@roomNumber",OleDbType.Integer),
            };
            parms[0].Value = roomSta;
            parms[1].Value = guestName;
            parms[2].Value = checkIn;
            parms[3].Value = checkOut;
            parms[4].Value = Convert.ToInt32(roomNumber);
            sqlHelper.CurrConn = Utils.DbType.Remote;
            try
            {
                sqlHelper.ExecuteNonQuery(sql, parms);
            }
            catch { return false; }

            return true;
        }

        delegate void SetConnectButtonTextHandler(string text);
        private void SetConnectButtonText(string text)
        {
            if (this.btnConnToPMS.InvokeRequired)
            {
                SetConnectButtonTextHandler d = new SetConnectButtonTextHandler(SetConnectButtonText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.btnConnToPMS.Text = text;
            }
        }

        public void Fidelio_Key_Send(NetworkStream ns)
        {
            string vDa = string.Format("{0:yyMMdd}", DateTime.Now);
            string vTI = string.Format("{0:HHmmss}", DateTime.Now);
            ArrayList list = new ArrayList();

            string ReturnStr;

            ReturnStr = "LD|DA" + vDa + "|TI" + vTI + "|V#2.02|IFDL|RT16|";  // -> LD 连接描述   101012添加了RT16
            list.Add(ReturnStr);

            ReturnStr = "LR|RIKR|FLWSKCRNKTK#GAGDGNTI|";  // -> LR 请求制卡所需要的信息
            list.Add(ReturnStr);

            ReturnStr = "LR|RIKA|FLWSKCAS|";              // -> LR 返回制卡信息
            list.Add(ReturnStr);

            ReturnStr = "LR|RIKD|FLWSKCRN|";              // -> LR 注销卡信息
            list.Add(ReturnStr);

            ReturnStr = "LA|DA" + vDa + "|TI" + vTI + "|";  // -> LA
            list.Add(ReturnStr);

            foreach (string cmd in list)
            {
                BollenSocket.Write(ns, Encoding.UTF8.GetBytes(InstructMap["PR"] + cmd + InstructMap["SU"]));
                Thread.Sleep(30);
            }
        }

        public void ConnectToInterface()
        {
            sqlHelper.CurrConn = Utils.DbType.Local;
            string sql = "select IP, IfPort from Interface";
            DataRow row = sqlHelper.ExecuteDataSet(sql, null,null).Tables[0].Rows[0];
            if (row == null)
                return;
            string ip = row["IP"].ToString();
            int port = Convert.ToInt32(row["IfPort"]);
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ip), port);
            InterfaceClient = new BollenSocket(endPoint);
            try
            {
                if (InterfaceClient.Connect())
                {
                    
                    while (Valid && IsReceive)
                    {
                        CurrInterfaceConnSta = ConnSta.Connected;
                        int size;
                        byte[] buffer = BollenSocket.Read(InterfaceClient.NetStream, out size);
  
                        if (size == 0)
                        {
                            break;
                        }
                        string rec = Encoding.UTF8.GetString(buffer, 0, size);
                        this.CommLog(rec + "  <- From Pms");

                        //去掉消息前，后缀
                        rec = rec.Replace(InstructMap["PR"],"");
                        rec = rec.Replace(InstructMap["SU"],"");

                        Dictionary<string, string> newInstruct = InstructTransform(rec);
                        if (newInstruct == null)
                        {
                            this.CommLog("Instruct map is empty,Pls configure interface specification.");
                            continue;
                        }
                        string kc, err;
                        Command cmd;
                        if (!VerifyInstruct(newInstruct, out kc, out cmd, out err))
                        {
                            this.CommLog(err);
                            continue;
                        }

                        TcpClient host = null;
                        foreach (TcpClient tcpClient in ClientList.Keys)
                        {
                            if (ClientList[tcpClient] == kc)
                            {
                                host = tcpClient;
                            }
                        }

                        if (host == null)
                        {
                            this.CommLog("[ " + kc + " ]corresponding host not found");
                            continue;
                        }

                        NetworkStream stream = host.GetStream();

                        switch (cmd)
                        {
                            case Command.KR: //issue card
                                PackageInstruct(newInstruct);
                                BollenSocket.Send(stream, new SocketEntity(cmd, Data, "", ""));
                                break;
                            case Command.KD: //delete card
                                BollenSocket.Send(stream, new SocketEntity(cmd, new string[] { }, "", ""));
                                break;
                            case Command.KG: //read card
                                BollenSocket.Send(stream, new SocketEntity(cmd, new string[] { Auth_Code }, "", ""));
                                break;
                            default:
                                break;
                        }                       
                    }
                }
            }
            catch
            {   
            }
            InterfaceClient = null;
            CurrInterfaceConnSta = ConnSta.Disconnect;
            SetConnectButtonText("Connect");
        }

        public Dictionary<string,string> InstructTransform(string orgInst)
        {
            if (InstructMap == null)
            {            
                return null;
            }

            string[] original = 
               orgInst.Split(new char[] { InstructMap["Separator"][0]}, StringSplitOptions.RemoveEmptyEntries);
            if (original == null)
            {
               return null;
            }

            Dictionary<string, string> newInstruct = new Dictionary<string, string>();
            foreach (string key in InstructMap.Keys)
            {
                if (key.Length != 2)
                    continue;

                string instructMapValue = InstructMap[key];
                if (instructMapValue == string.Empty)
                {
                    newInstruct.Add(key, "");
                    continue;
                }

                string foundKey = string.Empty;
                foreach (string v in original)
                {
                    string V = v.Trim().ToUpper();
                    if (V.Contains(instructMapValue))
                    {
                        foundKey = V;
                        break;
                    }
                }

                if (foundKey != string.Empty)
                {
                    string insVal = foundKey.Replace(instructMapValue, "");
                    if (insVal == string.Empty)
                    {
                        insVal = "True";
                    }
                    newInstruct.Add(key,insVal);
                }
                else
                {
                    newInstruct.Add(key, "");
                }
            }
            
            return newInstruct;
        }

        private bool VerifyInstruct(Dictionary<string, string> newInstruct, out string kc,
            out Command command, out string err)
        {
            bool chkKR = false, chkKD = false;

            if (newInstruct["KR"] == "True")
            {
                command = Command.KR;
                chkKR = true;
            }
            else if (newInstruct["KG"] == "True")
            {
                command = Command.KG;
            }
            else if (newInstruct["KD"] == "True")
            {
                command = Command.KD;
                chkKD = true;
            }
            else
            {
                err = "Key instruct is not found";
                command = Command.NULL;
                kc = string.Empty;
                return false;
            }

            string keycoder = newInstruct["KC"];
            if (keycoder == string.Empty)
            {
                kc = string.Empty;
                err = "Key coder from PMS is empty";
                return false;
            }

            kc = keycoder;

            if (chkKR == true || chkKD == true)
            {
                string roomNumber = newInstruct["RN"];
                if (roomNumber == string.Empty)
                {
                    err = "Room number cannot be empty";
                    return false;
                }
                else
                {
                    string sql = "select room_name from room where val(room_name)="
                        + Convert.ToInt32(roomNumber).ToString();
                    sqlHelper.CurrConn = Utils.DbType.Remote;
                    if (sqlHelper.ExecuteScalar(sql, null) == null)
                    {
                        err = "Room number is not found";
                        return false;
                    }
                }
            }

            if (chkKR == true)
            {

                if (newInstruct["AD"] == string.Empty)
                {
                    err = "Arrival date cannot be empty";
                    return false;
                }

                if (newInstruct["DD"] == string.Empty)
                {
                    err = "Departure date cannot be empty";
                    return false;
                }

                if (CheckOutType == "interface" && newInstruct["CT"] == string.Empty)
                {
                    err = "You choose check-out type is interface,so check-out time cannot be empty";
                    return false;
                }
            }

            err = "";
            return true;
        }

        private void InitData()
        {
            Data[0] = Guid.NewGuid().ToString();
            Data[1] = "1";
            Data[2] = Auth_Code;
            Data[3] = "00";
            Data[4] = "0000";
            Data[5] = "0";
            Data[6] = "yyyy-MM-dd hh:mm:ss";
            Data[7] = "yyyy-MM-dd hh:mm:ss";

        }

        private void PackageInstruct(Dictionary<string, string> newInstruct)
        {
            /* Data Struct
             * data[0] Guid
             * data[1] key count
             * data[2] auth
             * data[3] building
             * data[4] room
             * data[5] commdoors
             * data[6] arrival
             * data[7] departure
             */

            InitData();

            //发卡次数
            string keycount = newInstruct["KT"];
            if (keycount != string.Empty)
            {
                Data[1] = keycount;
            }

            //------初始化发卡数据-----

            //楼号
            Data[3] = Building_Addr;

            //房号
            string room = newInstruct["RN"];
            Data[4] = room;

            //VIP功能；
            Data[5] = newInstruct["CD"];

            //卡开始时间
            string dateFormat = InstructMap["Date"];
            string timeFormat = InstructMap["Time"];
            string sDateTime = newInstruct["AD"] + "000000";
            string format = dateFormat + "HHmmss";
                        
            DateTime dateTimeA = DateTime.ParseExact(sDateTime, format, 
                        System.Globalization.CultureInfo.InvariantCulture);

            Data[6] = string.Format("{0:yyyy-MM-dd hh:mm:ss}", dateTimeA);

            //卡结束时间
            string outTime;
            switch (CheckOutType)
            {                    
                case "customize":
                    outTime = CheckOutTime;
                    timeFormat = "HH:mm:ss";
                    break;
                case "interface":
                    outTime = newInstruct["CT"];
                    break;
                default:
                    outTime = "235959";
                    timeFormat = "HHmmss";
                    break;
            }

            sDateTime = newInstruct["DD"] + outTime;
            DateTime dateTimeB = DateTime.ParseExact(sDateTime, dateFormat + timeFormat,
                System.Globalization.CultureInfo.InvariantCulture);

            Data[7] = string.Format("{0:yyyy-MM-dd hh:mm:ss}", dateTimeB);

            IssueRecEntity entity = new IssueRecEntity();
            entity.RoomNumber = room;
            entity.KeyCount = Data[1];
            entity.KeyType = "New Key";
            entity.OperateTime = "";
            entity.Workstation = "";
            entity.KeyCoder = newInstruct["KC"];
            entity.GuestName = newInstruct["GN"];
            entity.ArrivalDate = Data[6];
            entity.DepartureDate = Data[7];
            Manage.InsertRecEntity(Data[0], entity);
        }

        private string[] GenerateCardNumber()
        {
            Random rnd = new Random();
            string[] RndKey = new string[6];
            for (int i = 0; i < RndKey.Length; i++ )
                RndKey[i] = rnd.Next(1, 9).ToString();

            return RndKey;
        }

        #endregion

        private void toolStripButtonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripButtonAbout_Click(object sender, EventArgs e)
        {
            FrmAbout frmAbout = new FrmAbout();
            frmAbout.ShowDialog();
        }

        private void toolStripButtonSetup_Click(object sender, EventArgs e)
        {
            
        }

        private void interfaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmInterface frmInterface = new FrmInterface();
            frmInterface.ShowDialog();
        }

        private void roomConfigureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRoomConfigure frmRoomConfigure = new FrmRoomConfigure();
            frmRoomConfigure.ShowDialog();
        }

        private void issuingCardLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmIssuingCardLog frmIssuingCardLog = new FrmIssuingCardLog();
            frmIssuingCardLog.ShowDialog();
        }

        delegate void ShowLogWindowHandler();
        private void ShowLogWindow()
        {
            if (frmCommLog.InvokeRequired)
            {
                ShowLogWindowHandler d = new ShowLogWindowHandler(ShowLogWindow);
                this.Invoke(d);
            }
            else
            {
                frmCommLog.TopMost = true;
                frmCommLog.Visible = true;
            }
        }
        private void communicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void toolStripButtonRegister_Click(object sender, EventArgs e)
        {
            FrmRegister frmRegister = new FrmRegister();
            frmRegister.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmInterfaceSpecification frmIfSpec = new FrmInterfaceSpecification();
            frmIfSpec.ShowDialog();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            FrmLock frmLock = new FrmLock();
            frmLock.ShowDialog();
        }     

        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.transLeftA.Left = this.transAreaA.Width - this.transLeftA.Width;
            this.transLeftA.Visible = true;
            this.transRightA.Left = 0;
            this.transRightA.Visible = false;

            this.transLeftB.Left = this.transAreaB.Width - this.transLeftB.Width;
            this.transLeftB.Visible = true;
            this.transRightB.Left = 0;
            this.transRightB.Visible = false;

            this.toolStripStatusLabelUser.Text = "Operator: " + global::PMSInterface.Program._username;
            frmWorkstation = FrmWorkStation.getFrmWorkstation();
            frmWorkstation.Visible = false;

            frmCommLog = FrmCommunicationLog.getCommunicationLog();
            frmCommLog.MdiParent = this;
            frmCommLog.Left = 10;
            frmCommLog.Top = this.Height - frmCommLog.Height - 130;
            frmCommLog.Visible = true;

            UpdateEvent += new UpdateHandler(frmWorkstation.add);
            LogEvent += new LogHandler(frmCommLog.safeAdd);

            Safe safe = new Safe();
            Registe = safe.GetDateTimeFromDecrypt(true);

            StartListen();

            string specName;
            InstructMap = MyXml.GetInstructMap(out specName);
            if (InstructMap == null)
                return;
            
        }


        private void FrmMain_Resize(object sender, EventArgs e)
        {
            this.connectSta.Left = this.Width / 2 - this.connectSta.Width / 2;
            if (frmCommLog != null)
            {
                frmCommLog.Left = 10;
                frmCommLog.Top = this.Height - frmCommLog.Height - 130;
            }
        }

        private void timerListen_Tick(object sender, EventArgs e)
        {
            if (!Valid)
            {
                return;
            }
            if (Registe < DateTime.Now)
            {
                Valid = false;
                CurrConnSta = ConnSta.DisListen;
                this.btnConnToPMS.Enabled = false;
                FrmRegister frmRegiste = new FrmRegister();
                frmRegiste.ShowDialog();
            }
            else
            {
                Valid = true;
                if (CurrConnSta == ConnSta.DisListen)
                {
                    CurrConnSta = ConnSta.Ready;
                }
                this.btnConnToPMS.Enabled = true;
            }
       
            switch (CurrConnSta)
            {
                case ConnSta.Listen:
                    Hint(this.lblListen, "Listening...", true, this.transAreaB,
                        false, this.timerConnectClient);
                    break;
                case ConnSta.Connected:
                    Hint(this.lblListen, "", false, this.transAreaB, true,
                        this.timerConnectClient);
                    break;
                case ConnSta.NoPort:
                case ConnSta.DisListen:
                    Hint(this.lblListen, "Don't listen", true, this.transAreaB,
                        false, this.timerConnectClient);
                    break;
                case ConnSta.Ready:
                    StartListen();
                    break;
                default:
                    break;
            }

            switch (CurrInterfaceConnSta)
            {
                case ConnSta.Connected:
                    Hint(this.lblRequest, "", false, this.transAreaA,
                        true, this.timerConnectInterface);
                    break;
                case ConnSta.Disconnect:
                case ConnSta.NULL:
                    Hint(this.lblRequest, "Pending", true, this.transAreaA,
                        false, this.timerConnectInterface);
                    break;
                default:
                    break;
            }
        }      

        private void timerConnectClient_Tick(object sender, EventArgs e)
        {
            ConnectTuClient();
        }

        private void btnConnToPMS_Click(object sender, EventArgs e)
        {
            string operate = this.btnConnToPMS.Text;
            switch (operate)
            {
                case "Connect":
                        La = true;
                        string sql;
                        try
                        {
                            sql = "select CheckOutType, CheckOutTime, AutoConnect, ConnectTime from Interface";
                            sqlHelper.CurrConn = Utils.DbType.Local;
                            DataRow row = sqlHelper.ExecuteDataSet(sql, null).Tables[0].Rows[0];
                            CheckOutType = row["CheckOutType"].ToString();
                            CheckOutTime = row["CheckOutTime"].ToString();
                            IsAutoConn = Convert.ToBoolean(row["AutoConnect"]);
                            AutoConnTime = Convert.ToDecimal(row["ConnectTime"]);
                            if (CheckOutType == string.Empty)
                            {
                                MessageBox.Show("Check-out Type no configuration", "hint", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            sql = "select auth_code from syspar";
                            sqlHelper.CurrConn = Utils.DbType.Remote;
                            Auth_Code = sqlHelper.ExecuteScalar(sql, null).ToString();

                            sql = "select building_addr from building";
                            Building_Addr = sqlHelper.ExecuteScalar(sql, null).ToString();
                            if (Building_Addr == string.Empty)
                            {
                                MessageBox.Show("Building Address no configuration", "hint", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Read data error,Pls configure parameter. " + ex.Message, "hint", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        IsReceive = true;
                        Thread startConnect = new Thread(new ThreadStart(ConnectToInterface));
                        startConnect.Name = "Request Connect";
                        startConnect.IsBackground = true;
                        startConnect.Start();

                        this.timerAutoConnect.Enabled = true;
                        this.btnConnToPMS.Text = "Disconnect";
                        break;
                case "Disconnect":
                        La = false;
                        IsReceive = false;
                        try
                        {
                            InterfaceClient.Disconnect();
                        }
                        catch { }
                        this.btnConnToPMS.Text = "Connect";
                        break;
                default:
                        break;
            }
        }

        private void toolStripMenuItemUserManager_Click(object sender, EventArgs e)
        {
            FrmUsers frmUser = new FrmUsers();
            frmUser.ShowDialog();
        }

        private void timerConnectInterface_Tick(object sender, EventArgs e)
        {
            ConnectTuInterface();
        }

        private void toolStripMenuItemWs_Click(object sender, EventArgs e)
        {
            frmWorkstation.TopMost = true;
            frmWorkstation.Visible = true;
        }

        private void timerAutoConnect_Tick(object sender, EventArgs e)
        {
            this.timerAutoConnect.Interval = (int)AutoConnTime * 1000;
            if (this.btnConnToPMS.Text == "Connect" && IsAutoConn)
            {
                btnConnToPMS_Click(null, null);                
            }
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            IsClose = true;
            e.Cancel = false;
        }
    }

    public enum ConnSta
    {
        NULL,
        Listen,
        DisListen,
        Ready,
        NoPort,
        Connected,
        Disconnect
    }

    public class Workstation
    {

        public string KeyCoder { get; set; }
        public string WorkstationName { get; set; }
    }
}
