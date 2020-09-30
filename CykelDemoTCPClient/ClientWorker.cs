using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace CykelDemoTCPClient
{
    public class ClientWorker
    {
        public void Start()
        {
            //client opretter forbindelse til serveren
            TcpClient socket = new TcpClient("localhost",4646);


            StreamReader sr = new StreamReader(socket.GetStream());
            StreamWriter sw = new StreamWriter(socket.GetStream());

            string strSomsendes = "cykel";
            sw.WriteLine(strSomsendes);
            sw.Flush();

            string strRetur = sr.ReadLine();
            Console.WriteLine($"Tilbage fra Server : {strRetur}");

            socket.Close();

        }

    }
}
