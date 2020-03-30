using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Notpad
{
    class Program
    {
        static void Main(string[] args)
        {
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("File Operations");
                Console.WriteLine("Choose Your options");
                Console.WriteLine("1. Copy a file");
                Console.WriteLine("2.Rename a file");
                Console.WriteLine("3.Concatenate two files");
                Console.WriteLine("4.Create a file ");
                Console.WriteLine("5.Display contents of a file");

                string caseSwitch = Console.ReadLine();
                switch (caseSwitch)
                {
                    case "1":
                        copy();
                        flag = true;
                        break;

                    case "2":
                        rename();
                        flag = true;
                        break;
                    case "3":
                        merge();
                        flag = true;
                        break;
                    case "4":
                        newfile();
                        flag = true;
                        break;
                    case "5":
                        Display();
                        flag = true;
                        break;


                    default:
                        flag = true;
                        break;
                }
                Console.ReadLine();
            }
        }
        static void newfile()
            {
            Console.WriteLine("Write File Content here");
            string[] names = new string[] { Console.ReadLine() };
            Console.WriteLine("Write File Name");
            string file = Console.ReadLine();

            using (StreamWriter sw = new StreamWriter(file+".txt"))
            {

                foreach (string s in names)
                {
                    sw.WriteLine(s);
                }
                
            }

            // Read and show each line from the file.
            string line = "";
            using (StreamReader sr = new StreamReader(file + ".txt"))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }

            }
            Console.WriteLine("New File is created successfully");
        }

    
        static void Display()
        {
            string line = "";
            Console.WriteLine("enter file name");
            string hello = Console.ReadLine();
            string filePath = @"D:\" + hello + ".txt";
            using (StreamReader sr = new StreamReader(filePath))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }

            }
        }
        static void rename()
        {
            Console.WriteLine("enter file name");
            string hello = Console.ReadLine();
            string filePath = @"D:\" + hello + ".txt";
            List<string> lines = File.ReadAllLines(filePath).ToList();
            Console.WriteLine("Write File Name");
            string file = Console.ReadLine();
            var newFilePath = Path.Combine(Path.GetDirectoryName(filePath), file + Path.GetExtension(filePath));
            System.IO.File.Move(filePath, newFilePath);
            Console.WriteLine("Rename File  successfully");
        }

        static void copy()
        {
            Console.WriteLine("enter file name");
            string hello = Console.ReadLine();
            string filePath = @"D:\" + hello+".txt";
            List<string> lines = File.ReadAllLines(filePath).ToList();
            Console.WriteLine("Write File Name");
            string file = Console.ReadLine();

            using (StreamWriter sw = new StreamWriter(file + ".txt"))
            {

                foreach (string s in lines)
                {
                    sw.WriteLine(s);
                }
            }
            Console.WriteLine("File is Copied successfully");
        }
        static void merge()
        { 
        Console.WriteLine("enter file name");
            string hello = Console.ReadLine();
        string filePath = @"D:\" + hello + ".txt";
        List<string> lines = File.ReadAllLines(filePath).ToList();

        string one = Console.ReadLine();
        Console.WriteLine("enter another file name");
            string hello2 = Console.ReadLine();
        string filePath2 = @"D:\" + hello2 + ".txt";
        List<string> lines2 = File.ReadAllLines(filePath2).ToList();


        string one2 = Console.ReadLine();

        var newList = lines.Concat(lines2);
            Console.WriteLine("Write File Name");
            string file = Console.ReadLine();

            using (StreamWriter sw = new StreamWriter(file + ".txt"))
            {

                foreach (string s in newList)
                {
                    sw.WriteLine(s);
                }
            }
            Console.WriteLine(" successfully mearge two files");
        }
    }
}
