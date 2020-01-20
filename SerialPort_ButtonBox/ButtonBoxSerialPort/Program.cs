using SerialPortButtonBox;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WindowsInput;
using WindowsInput.Native;

namespace ButtonBoxSerialPort
{
    class Program
    {
        static InputSimulator inputSimulator;
        static void Main(string[] args)
        {
            inputSimulator = new InputSimulator();
            var boxes = SerialPortDetector.GetSerialPortBoxes();
            Console.WriteLine("Ready");

            foreach (var box in boxes)
            {
                box.OnButtonChange += Box_OnButtonChange;
            }

            Console.ReadLine();
            foreach (var box in boxes)
            {
                box.Stop();
            }
        }

        private static void Box_OnButtonChange(object sender, ButtonEventArgs buttonEvent)
        {
            if (buttonEvent.State == ButtonState.Down)
            {
                inputSimulator.Keyboard.KeyDown(VirtualKeyCode.VK_N);
            }
            else if (buttonEvent.State == ButtonState.Up)
            {
                inputSimulator.Keyboard.KeyUp(VirtualKeyCode.VK_N);
            }
        }
    }
}
