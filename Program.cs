using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;

namespace Task2
{
    /// <summary>
    /// Класс, создающий базу (массив) из n товаров, который выводит полную информацию из базы
    /// а также список просроченных товаров (на момент текущей даты)
    /// </summary>
    /// <remarks>
    /// Ввод: input.txt
    /// </remarks>
    class Program
    {
        /// <summary>
        /// Точка входа в программу
        /// </summary>
        static void Main(string[] args)
        {
            Trace.Indent();
            createInput();
            using (StreamReader streamReader = new StreamReader(@"input.txt"))
           {
               int n = int.Parse(streamReader.ReadLine());
               Goods[] goods = new Goods[n];
               for (int i = 0; i < n; i++)
               {
                   switch (streamReader.ReadLine())
                   {
                       case "P":
                           goods[i] = new Product(streamReader);
                           break;
                       case "C":
                           goods[i] = new Consignment(streamReader);
                           break;
                       case "S":
                           goods[i] = new Set(streamReader);
                           break;
                       default:
                           throw new ArgumentException();
                   }
               }

               foreach (var good in goods)
               {
                   Console.WriteLine("*******************************");
                   good.printInformation();
               }
               printExpiredGoods(goods);
               serializeGoods(goods);
               Trace.Flush();
           }
        }
        /// <summary>
        /// Создание файла input.txt с тестовыми данными
        /// </summary>
        private static void createInput()
        {
            Trace.WriteLine("Main.createInput");
            using (StreamWriter streamWriter = new StreamWriter(@"input.txt"))
            {
                streamWriter.WriteLine("4\r\nP\r\nprod1\r\n12,2\r\n11\r\n09\r\n1999\r\n5");
                streamWriter.WriteLine("P\r\nprod2\r\n2000\r\n7\r\n01\r\n2020\r\n100");
                streamWriter.WriteLine("S\r\nset1\r\n15");
                streamWriter.WriteLine("P\r\np1\r\n12,2\r\n11\r\n09\r\n1999\r\n5");
                streamWriter.WriteLine("P\r\np2\r\n2000\r\n7\r\n01\r\n2020\r\n100");
                streamWriter.WriteLine("P\r\np2\r\n12,2\r\n11\r\n09\r\n1999\r\n5");
                streamWriter.WriteLine("@\r\nC\r\ncon1\r\n4000\r\n6\r\n20\r\n12\r\n2019\r\n330");
            }
        }
        /// <summary>
        /// Вывод в консоль списка просроченных товаров
        /// </summary>
        /// <param name="goods">Массив товаров</param>
        private static void printExpiredGoods(Goods[] goods)
        {
            Trace.WriteLine("Main.printExpiredGoods");
            List<string> list = new List<string>();
            foreach (var good in goods)
            {
                if(!good.isFresh()) list.Add(good.name);
            }

            if (list.Count == 0)
            {
                Console.WriteLine("No expired goods \n");
            }
            else
            {
                Console.WriteLine("Expired goods:");
                foreach (var item in list)
                {
                    Console.WriteLine(item);
                }
            }
        }
        /// <summary>
        /// Сериализация товаров в файл output.txt
        /// </summary>
        /// <param name="goods">Массив товаров</param>
        private static void serializeGoods(Goods[] goods)
        {
            Trace.WriteLine("Main.serializeMyObjects");
            XmlSerializer serializer = new XmlSerializer(typeof(Goods));
            using (StreamWriter streamWriter = new StreamWriter(@"output.txt"))
            {
                foreach (var item in goods)
                {
                    serializer.Serialize(streamWriter, item);
                }
            }
        }
    }
}
