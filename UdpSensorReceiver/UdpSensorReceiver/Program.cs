using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace UdpSensorReceiver
{
    class Program
    {
        static void Main(string[] args)
        {

            UdpClient udpSensor = new UdpClient(7000);
            

            //Creates an IPEndPoint to record the IP Address and port number of the sender.  
            IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any,3333);



            while (true)
            {
                Byte[] datagramRecieved = udpSensor.Receive(ref RemoteIpEndPoint);
                string message = Encoding.ASCII.GetString(datagramRecieved,0 , datagramRecieved.Length);

                string[] formattetstrings = message.Split('\n');

                string CO = formattetstrings[3];
                string NOX = formattetstrings[4];

                string[] coString = CO.Split(':');
                string[] noxString = NOX.Split(':');

                int noxValue;
                double coValue;

                Int32.TryParse(noxString[1], out noxValue);
                double.TryParse(coString[1], out coValue);

                Console.WriteLine("current CO: " + coValue);
                Console.WriteLine("Current NOX: " + noxValue);
                

                //foreach (var line in formattetstrings)
                //{
                //    Console.WriteLine(line);
                //    Console.WriteLine();
                //}



            }

        }
    }
}
