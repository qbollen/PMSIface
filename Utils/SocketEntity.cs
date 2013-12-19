using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utils
{
    [Serializable]
    public class SocketEntity
    {
        private Command _command;
        private string[] _data;
        private string _serverIP;
        private string _clientIP;

        /// <summary>
        /// 通讯实体
        /// </summary>
        /// <param name="command"></param>
        /// <param name="data"></param>
        /// <param name="server_ip"></param>
        /// <param name="client_ip"></param>
        public SocketEntity(
            Command command,
            string[] data,
            string server_ip,
            string client_ip
            )
        {
            _command = command;
            _data = data;
            _serverIP = server_ip;
            _clientIP = client_ip;
        }

        public Command Cmd
        {
            get { return _command; }
            set { _command = value; }
        }

        public string[] Data
        {
            get { return _data; }
            set { _data = value; }
        }

        public string ServerIP
        {
            get { return _serverIP; }
            set { _serverIP = value; }
        }

        public string ClientIP
        {
            get { return _clientIP; }
            set { _clientIP = value; }
        }
    }

    [Serializable]
    public enum Command
    {
        NULL,
        IF, /*info*/
        KR, /*Key request*/
        KD, /*Key delete*/
        KA, /*Key Answer*/
        RQ  /*request*/
    }
}
