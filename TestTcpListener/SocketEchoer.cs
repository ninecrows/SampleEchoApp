using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TestTcpListener
{
    class SocketEchoer
    {
        private Socket ourSocket;
        private Thread ourThread;
        private bool ourRunning = true;

        public SocketEchoer(Socket mySocket)
        {
            ourSocket = mySocket;
            ourThread = new Thread(Worker);
        }

        private void Worker(object myParameters)
        {
            while (ourRunning)
            {
                 
            }
        }
    }
}
