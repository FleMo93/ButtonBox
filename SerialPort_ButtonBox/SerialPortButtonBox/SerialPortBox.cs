using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SerialPortButtonBox
{
    public enum ButtonState { Up, Down }

    public class ButtonEventArgs : EventArgs
    {
        public string Name { get; private set; }
        public ButtonState State { get; private set; }

        internal ButtonEventArgs(string name, ButtonState state)
        {
            Name = name;
            State = state;
        }
    }

    public class SerialPortBox
    {
        public delegate void ButtonHandler(object sender, ButtonEventArgs buttonEvent);
        public event ButtonHandler OnButtonDown;
        public event ButtonHandler OnButtonUp;
        public event ButtonHandler OnButtonChange;

        public string Id { get; private set; }
        public string ComPortName
        {
            get
            {
                return port.PortName;
            }
        }

        private SerialPort port;
        private bool readPorts = true;
        Thread thread;

        internal SerialPortBox(string id, SerialPort port)
        {
            Id = id;
            this.port = port;
            thread = new Thread(() => Read(port));
            thread.Start();
        }

        public void Stop()
        {
            readPorts = false;
            thread.Abort();
        }

        void Read(SerialPort port)
        {
            while (readPorts)
            {
                try
                {
                    var msg = port.ReadLine();
                    if (msg.StartsWith("btn1.down"))
                    {
                        var args = new ButtonEventArgs("btn1", ButtonState.Down);
                        OnButtonDown?.Invoke(this, args);
                        OnButtonChange?.Invoke(this, args);
                    }
                    else if (msg.StartsWith("btn1.up"))
                    {
                        var args = new ButtonEventArgs("btn1", ButtonState.Up);
                        OnButtonUp?.Invoke(this, args);
                        OnButtonChange?.Invoke(this, args);
                    }
                }
                catch (TimeoutException e) { }
            }
        }
    }
}
