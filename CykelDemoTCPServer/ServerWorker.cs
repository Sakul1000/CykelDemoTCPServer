using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using CykelLib;
using Newtonsoft.Json;


namespace CykelDemoTCPServer
{
    public class ServerWorker
    {
        private static List<Cykel> cykels = new List<Cykel>()
        {
            new Cykel(1,"gul",5000,25),
            new Cykel(2,"grøn",5500,24)
        };

        public void Start()
        {
            //server oprettes                 
            TcpListener server = new TcpListener(IPAddress.Loopback, 4646);
            server.Start();

            while (true)
            {
                // venter klienten laver et opkald
                TcpClient socket = server.AcceptTcpClient();
                Task.Run((() =>
                {
                    TcpClient temsocket = socket;
                    DoClient(temsocket);
                }));

            }


        }

        private void DoClient(TcpClient socket)
        {
            //net stream
            NetworkStream ns = socket.GetStream();
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            sw.AutoFlush = true;
            //læser teksten fra klient 
            string str = sr.ReadLine();
            string json = JsonConvert.SerializeObject(cykels);
            string str2;




            if (str == "HentAlle")
            {
                sw.WriteLine(json);
            }

            else if (str == "Hent")
            {
                str2 = sr.ReadLine();
                var id = Convert.ToInt32(str2);
                sw.WriteLine(JsonConvert.SerializeObject(cykels.Find(c => c.Id == id)));
            }

            else if (str == "Gem")
            {
                sw.WriteLine("{\"Id\":1,\"Farve\":\"gul\",\"Pris\":5000,\"Gear\":25}");
                str2 = sr.ReadLine();
                Cykel nyCykel = JsonConvert.DeserializeObject<Cykel>(str2);
                cykels.Add(nyCykel);
            }




            //// skriver tilbage til client 
            //sw.WriteLine(str);
            //sw.WriteLine(str2);
            //sw.Flush();
        }
    }
}
