using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;

namespace Utils
{
    public class BollenSocket
    {
        private IPEndPoint _endPoint;
        private TcpClient _tcpClient;
        private TcpListener _tcpListener;
        private NetworkStream _ns;
        private bool _alive;

        public BollenSocket(IPEndPoint endpoint)
        {
            _endPoint = endpoint;
        }

        public TcpListener TCPListener
        {
            get { return _tcpListener; }
        }

        public TcpClient TCPClient
        {
            get { return _tcpClient; }
        }

        public NetworkStream NetStream
        {
            get { return _ns; }
        }

        public bool Listen()
        {
            try
            {
                _tcpListener = new TcpListener(_endPoint);
                _tcpListener.Start();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public bool Connect()
        {
            _tcpClient = new TcpClient();
            try
            {
                _tcpClient.Connect(_endPoint);
                _ns = _tcpClient.GetStream();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public bool Alive
        {
            get { return _tcpClient.Connected; }
        }

        public static void Send(NetworkStream ns, SocketEntity data)
        {
            IFormatter formatter = new SoapFormatter();
            MemoryStream mem = new MemoryStream();
            formatter.Serialize(mem, data);
            byte[] buffer = mem.GetBuffer();
            int memsize = (int)mem.Length;
            byte[] size = BitConverter.GetBytes(memsize);
            ns.Write(size, 0, 4);
            ns.Write(buffer,0,memsize);
            ns.Flush();
            mem.Close();
        }

        public static void Write(NetworkStream ns, byte[] data)
        {
            ns.Write(data, 0, data.Length);
            ns.Flush();
        }

        public static SocketEntity Receive(NetworkStream ns)
        {
            MemoryStream mem = new MemoryStream();
            SocketEntity entity;
            byte[] data = new byte[4];
            int revc = ns.Read(data, 0, 4);
            int size = BitConverter.ToInt32(data, 0);

            if (size > 0)
            {
                data = new byte[4096];
                revc = ns.Read(data, 0, size);
                mem.Write(data, 0, revc);
               
                IFormatter formatter = new SoapFormatter();
                mem.Position = 0;
                entity = (SocketEntity)formatter.Deserialize(mem);
                mem.Close();
            }
            else
            {
                entity = null;
            }

            return entity;
        }

        public static byte[] Read(NetworkStream ns, out int size)
        {
            byte[] data = new byte[1024];
            size = ns.Read(data, 0, data.Length);
            return data;
        }

        public bool Disconnect()
        {
            if (_tcpClient.Connected)
            {
                try
                {
                    _ns.Close();
                    _ns.Dispose();
                    _tcpClient.Close();
                    _tcpClient.Client.Shutdown(SocketShutdown.Both);
                    _tcpClient.Client.Close();
                }
                catch
                {
                    return false;
                }
            }

            return true;
        }
    }
}
