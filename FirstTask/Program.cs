using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FirstTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1 - write to console \n2 - reading file");
            switch (Console.ReadLine())
            {
                case "1":
                    {
                        Coordinate coordinate = new Coordinate(ReadingCmd());
                        if (coordinate.ParseResult())
                        {
                            Console.WriteLine(coordinate.ToString());
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Faild parsing");
                            break;
                        }

                    }
                case "2":
                    {
                        Coordinate coordinate = new Coordinate(ReadingFile());
                        if (coordinate.ParseResult())
                        {
                            Console.WriteLine(coordinate.ToString());
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Faild parsing");
                            break;
                        }
                    }
                default:
                    {
                        Console.WriteLine("default");
                        break;
                    }
            }
        }

        static List<string> ReadingCmd()
        {
            List<string> cmdContent = new List<string>();
            Console.WriteLine("Write coordinates");
            Console.WriteLine("To finish typing - enter an empty line");
            while (true)
            {
                string coordinate = Console.ReadLine();
                if (string.IsNullOrEmpty(coordinate))
                {
                    break;
                }
                cmdContent.Add(coordinate);
            }

            return cmdContent;
        }

        static List<string> ReadingFile()
        {
            List<string> fileContent = new List<string>();

            try
            {
                using (StreamReader reader = new StreamReader("note.txt", UTF8Encoding.Default))
                {
                    while (!reader.EndOfStream)
                    {
                        fileContent.Add(reader.ReadLine());
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("None file for reading!" + ex);
            }

            return fileContent;
        }
    }
}
