using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace TestTcpListener
{
    class LocalTcpListener
    {
        private int ourPort;

        private Thread ourWorker = null;

        private TcpListener ourListener = null;

        private bool ourRunning = true;

        private List<SocketEchoer> ourConnections = [];

        public LocalTcpListener(int myPort)
        {
        }

        public void Start()
        {
            ourListener = new TcpListener(IPAddress.Any, ourPort);

            ourWorker = new Thread(RunWorker);
        }

        public void Stop()
        {
            ourListener.Stop();
        }

        private void RunWorker(object myParameter)
        {
            try
            {
                ourListener.Start();
                while (ourRunning)
                {
                    var connection = ourListener.AcceptSocket();
                    if (connection != null)
                    {
                        ourRunning = false;
                    }
                    else
                    {
                        // Spin a worker to handle interactions on this thread.
                        var echoer = new SocketEchoer(connection);
                        ourConnections.Add(echoer);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
