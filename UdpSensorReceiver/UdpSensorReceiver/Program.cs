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

            UdpClient udpSensor = new UdpClient(6789);
            

            //Creates an IPEndPoint to record the IP Address and port number of the sender.  
            IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any,6789);

            while (true)
            {
                Byte[] datagramRecieved = udpSensor.Receive(ref RemoteIpEndPoint);
                string message = Encoding.ASCII.GetString(datagramRecieved,0 , datagramRecieved.Length);

                Console.WriteLine(message);

            
                Console.WriteLine(message);
            }
        }
    }
}
