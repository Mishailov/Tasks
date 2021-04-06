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
                        ReadingCmd();
                        break;
                    }
                case "2":
                    {
                        ReadingFile();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("default");
                        break;
                    }
            }
        }

        static void ReadingCmd()
        {
            List<string> cmdContent = new List<string>();
            Console.WriteLine("Write coordinates");
            Console.WriteLine("To finish typing - enter an empty line");
            while (true)
            {
                string coordinate = Console.ReadLine();
                if(string.IsNullOrEmpty(coordinate))
                {
                    break;
                }
                cmdContent.Add(coordinate);
            }

            foreach (var item in cmdContent)
            {
                string[] allCoordinates = item.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                if(allCoordinates.Length == 2)
                {
                    float x = float.Parse(allCoordinates[0].Replace('.', ','));
                    float y = float.Parse(allCoordinates[1].Replace('.', ','));
                    Console.WriteLine("X: " + x + " " + "Y: " + y);
                }
            }
        }

        static void ReadingFile()
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

            foreach (var item in fileContent)
            {
                string[] coordinate = item.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                if (coordinate.Length == 2)
                {
                    float x = float.Parse(coordinate[0].Replace('.', ','));
                    float y = float.Parse(coordinate[1].Replace('.', ','));
                    Console.WriteLine("X: " + x + " " + "Y: " + y);
                }
            }
        }
    }
}
