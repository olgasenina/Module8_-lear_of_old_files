using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Module8_Сlear_of_old_files
{
    public static class DirectoryWork //ClearFiles
    {
        static TimeSpan interval = TimeSpan.FromMinutes(30); // Для представления временного интервала в 30 минут используйте TimeSpan.FromMinutes(30).

        /// <summary>
        /// Чистит нужную нам папку от файлов и папок, которые не использовались более 30 минут
        /// </summary>
        /// <param name="d"></param>
        public static void DeleteOldFiles(DirectoryInfo d)
        {
            if (d.Exists)
            {
                FileInfo[] fis = d.GetFiles(); // список файлов
                
                foreach (FileInfo fi in fis)
                {
                    string fName = fi.FullName; // Полное наименование файла

                    if (DateTime.Now > fi.LastWriteTime + interval) // Текущая дата больше даты последнего изменения + 30 минут
                    {
                        try
                        {
                            fi.Delete(); // Удаляем файл
                            Console.WriteLine("Файл {0}. Удален.", fName);
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine("При удалении файла {0} произошла ошибка:", fName);
                            Console.WriteLine(e.Message);
                        }
                    }
                }

                // Каталоги

                DirectoryInfo[] dis = d.GetDirectories(); // Получим все директории каталога

                foreach (DirectoryInfo di in dis)
                {
                    string dName = di.FullName; // Полное наименование каталога

                    if (DateTime.Now > di.LastWriteTime + interval)
                    {
                        try
                        {
                            di.Delete(true); // Удаление со всем содержимым
                            Console.WriteLine("Каталог {0}. Удален.", dName);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("При удалении каталога {0} произошла ошибка:", dName);
                            Console.WriteLine(e.Message);
                        }

                    }
                    else
                    {
                        // Рекурсия. Посмотрим, может внутри есть старые файлы
                        DeleteOldFiles(di);
                    }
                }
            }
            else
            {
                Console.WriteLine("Указанный каталог не найден!");
            }
        }
    }
}
