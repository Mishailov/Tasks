using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SixthTask
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Write password \n");
            if(!Int32.TryParse(Console.ReadLine(), out int password))
            {
                Console.WriteLine("Uncorrect value");
                return;
            }

            using(FileStream fileStream = new FileStream(@"test.txt", FileMode.Open))
            {
                Stream stream = new OverrideStream(fileStream);

                DecoratedStream decoratedStream = new DecoratedStream(stream);

                if (!decoratedStream.IsPasswordCorrect(password))
                {
                    Console.WriteLine("Uncorrect password");
                    return;
                }

                bool status = true;
                while (status)
                {
                    Console.WriteLine("1 - Read \n" +
                        "2 - Write \n" +
                        "3 - Percent of read \n" +
                        "4 - Exit \n");

                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            {
                                if (!decoratedStream.CanRead)
                                {
                                    Console.WriteLine("cant read");
                                    break;
                                }

                                byte[] array = new byte[fileStream.Length];
                                decoratedStream.TenPercent += Message;
                                decoratedStream.Read(array, 0, array.Length);
                                Console.WriteLine(System.Text.Encoding.Default.GetString(array));

                                break;
                            }
                        case "2":
                            {
                                if (!decoratedStream.CanWrite)
                                {
                                    Console.WriteLine("cant write");
                                    break;
                                }

                                Console.WriteLine("write some contents \n");
                                string text = Console.ReadLine();
                                byte[] array = System.Text.Encoding.Default.GetBytes(text);
                                decoratedStream.Write(array, 0, array.Length);
                                Console.WriteLine("Write done");

                                break;
                            }
                        case "3":
                            {
                                byte[] array = new byte[fileStream.Length];
                                Console.WriteLine($"All bytes length {array.Length} \n" +
                                    $"Write bytes length u wanna read");

                                if(!Int32.TryParse(Console.ReadLine(), out int length))
                                {
                                    Console.WriteLine("Uncorrect value");
                                    break;
                                }

                                if(length > array.Length)
                                {
                                    Console.WriteLine("input bytes length more than all bytes length");
                                    break;
                                }

                                Console.WriteLine($"Percent of read: {decoratedStream.PercentageOfRead(length)}");

                                break;
                            }
                        default:
                            status = false;
                            break;
                    }
                }
                
                decoratedStream.Close();
                stream.Close();
            }
        }

        private static void Message(string message)
        {
            Console.WriteLine(message);
        }
    }
}
