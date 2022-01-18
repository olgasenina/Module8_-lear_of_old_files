using System;
using System.IO;

namespace Module8_Сlear_of_old_files
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Укажите путь к каталогу ");

            DirectoryInfo dirInfo = new DirectoryInfo(Console.ReadLine());

            DirectoryWork.DeleteOldFiles(dirInfo);

            Console.ReadKey();
        }
    }
}
