using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialPortButtonBox
{
    public class SerialPortDetector
    {
        private static List<SerialPortBox> connectedBoxes = new List<SerialPortBox>();

        public static SerialPortBox[] GetSerialPortBoxes()
        {
            var ports = new List<SerialPortBox>();

            foreach (var portName in SerialPort.GetPortNames())
            {
                if(connectedBoxes.Find((a) => a.ComPortName == portName) != null)
                {
                    continue;
                }

                if (portName != "COM4") { continue; }

                var port = new SerialPort(portName, 9600);
                Console.WriteLine("Read port: " + portName);

                try
                {
                    port.Open();
                    port.WriteLine("a");

                    var answer = port.ReadLine().Trim('\r');

                    if (answer.StartsWith("box"))
                    {
                        var portBox = new SerialPortBox(answer.Substring(3), port);
                        ports.Add(portBox);
                        connectedBoxes.Add(portBox);
                    }
                }
                catch (Exception e) { }
            }

            return ports.ToArray();
        }
    }
}
