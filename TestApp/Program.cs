using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarSaver;
//using HarSaver.Models;
using System.Drawing;
using System.IO;
namespace TestApp
{
    class Program
    {
        static void Save(string floderPath, string har)
        {
            var saver = new Saver();
            saver.Load(har);
            saver.SaveInFloder(floderPath);

            Console.WriteLine("All files {0}", saver.FileLoad);
            Console.WriteLine("Load Failed {0}", saver.FailedLoadCount);
            TryToReload(saver);
        }
        static void TryToReload(Saver saver)
        {

            Console.WriteLine("Try to reload? y/n");
            if (Console.ReadKey().KeyChar == 'n')
                return;
            foreach (var url in saver.TryToReload())
            {
                Console.WriteLine(url);
                //Console.ReadKey();
            }
            Console.WriteLine("All files {0}", saver.FileLoad);
            Console.WriteLine("Load Failed {0}", saver.FailedLoadCount);
            Console.WriteLine("1. Try reload\n2. New file\n3. Exit");
            switch (Console.ReadKey().KeyChar)
            {
                default:
                    return;
                case '1':
                    TryToReload(saver);
                    break;
                case '2':
                    Start();
                    break;
            }
        }
        static void Start()
        {
            Console.WriteLine("Type path to .har file");
            string harPath = Console.ReadLine();//"D:\\Work\\localhost.har";
            Console.WriteLine("Type path to save content");
            string floderPath = Console.ReadLine();//"D:\\Temp\\";
            string har = File.ReadAllText(harPath);
            Save(floderPath, har);
        }
        static void Main(string[] args)
        {
            Start();
        }
    }
}
