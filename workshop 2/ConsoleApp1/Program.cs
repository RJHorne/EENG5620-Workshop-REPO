
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleApp1
{


    class SerialPortProgram
    {
        private SerialPort port = new SerialPort("COM3",9600, Parity.None, 8, StopBits.One);

        int command = 1;

        public static void Main()
        {
            new SerialPortProgram();
        }


        public void ledcommand()
        {
            while (port.IsOpen)
            {
                ConsoleKey choice;
                try
                {
                    choice = Console.ReadKey(true).Key;
                    switch (choice)
                    {
                        // 1 up key
                        case ConsoleKey.UpArrow:
                            command = command + 1;
                            Console.WriteLine("Increase LED BRIGHTNESS");
                            break;
                        //2 down key
                        case ConsoleKey.DownArrow:
                            command = command - 1;
                            Console.WriteLine("Decrease LED BRIGHTNESS");
                            break;
                        case ConsoleKey.LeftArrow:
                            command = 0;
                            Console.WriteLine("Min LED BRIGHTNESS");
                            break;
                        case ConsoleKey.RightArrow:
                            command = 9;
                            Console.WriteLine("Max LED BRIGHTNESS");
                            break;
                        case ConsoleKey.R:
                            port.Write("r");
                            Console.WriteLine("RED LED ");
                            break;
                        case ConsoleKey.Y:
                            port.Write("y");
                            Console.WriteLine("YELLOW LED ");
                            break;
                        case ConsoleKey.G:
                            port.Write("g");
                            Console.WriteLine("GREEN LED ");
                            break;
                        case ConsoleKey.T:
                            port.Write("t");
                            break;

                    }
                    if (command < 0)
                    {
                        command = 0;
                        Console.WriteLine("Minimum Reached");
                    }
                    if (command > 9)
                    {
                        Console.WriteLine("Maximum Reached");
                            command = 9;
                      
                    }
                }
                catch
                {
                    Console.WriteLine("Something has gone wrong...");
                }

                port.Write(command.ToString());
                Thread.Sleep(100);              
                    
            }
        }

        private SerialPortProgram()
        {

            Console.WriteLine("command Control");       
            port.Open();
            ledcommand();                                 
        }
    }
}
