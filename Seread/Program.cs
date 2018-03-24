using System;
using System.IO.Ports;
namespace Seread
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            String temp;
            int baudRate = 9600;
            Console.WriteLine("Welcome to seRead, a serial monitor in c#");
            Console.WriteLine("Please enter your com port name usually like COMx on windows or /dev/cu.xxxx on mac/unix");
            String cport = Console.ReadLine();
            Console.WriteLine("Please enter the baud rate, usually 9600");
            try {baudRate = int.Parse(Console.ReadLine()); }
            catch (FormatException) { Console.WriteLine("Input was not in the correct format, please enter only numbers");
                Console.ReadKey();
                return;
            }
            SerialPort serial = new SerialPort();
            serial.PortName = cport;
            serial.BaudRate = baudRate;
            try { serial.Open(); }
            catch (Exception)
            {
                Console.WriteLine("Opening serial port failed");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Opening serial port, good luck");
            Console.WriteLine("If you don't see any output soon, you may have specified the wrong baud rate");
            Console.WriteLine("and press ^c to exit at any time");
            System.Threading.Thread.Sleep(2000);
            try
            {
                while (true)
                {

                    temp = serial.ReadLine();
                    if (temp.Equals("")) { }
                    else { Console.WriteLine(temp); }

                }
            }
            catch (Exception)
            {
                Console.WriteLine("Port closed unexpectedly");
                Console.ReadKey();
                return;
            }
        }
    }
}
