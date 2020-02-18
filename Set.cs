using System;
using System.Collections.Generic;
using System.IO;

namespace Task2
{
    /// <summary>
    /// Класс Набор - реализация Товара
    /// </summary>
    public class Set : Goods
    {
        public List<Product> set { get; set; }

        /// <summary>
        /// Конструктор класса Set
        /// </summary>
        /// <param name="name">название</param>
        /// <param name="price">цена</param>
        /// <param name="set"> список - перечень продуктов</param>
        public Set(string name, double price, List<Product> set)
        {
            this.name = name;
            this.price = price;
            this.set = set;
        }
        /// <summary>
        /// Конструктор, который считывает из файла значения name,price и всех Product набора
        /// </summary>
        /// <param name="streamReader">StreamReader, с помощью которого нужно считывать информацию из файла</param>
        public Set(StreamReader streamReader)
        {
            this.name = streamReader.ReadLine();
            this.price = double.Parse(streamReader.ReadLine());
            List<Product> list = new List<Product>();
            while (streamReader.ReadLine().Equals("P"))
            {
                list.Add(new Product(streamReader));
            }

            this.set = list;
        }
        /// <summary>
        /// Этот метод выводит в консоль информацию о наборе
        /// </summary>
        public override void printInformation()
        {
            Console.WriteLine("Set name: " + this.name);
            Console.WriteLine("Price: " + this.price);
            Console.WriteLine("Products: ");
            for (int i = 1; i <= set.Count; i++)
            {
                Console.WriteLine(i + ". " + set[i-1].name);
            }

            Console.WriteLine();
        }
        /// <summary>
        /// Этот метод проверяет, соответствует ли набор сроку годности на текущую дату
        /// </summary>
        /// <returns>true, если все продукты в наборе не просрочены, в противном случае - false</returns>
        public override bool isFresh()
        {
            foreach (Product prod in set)
            {
                if (!prod.isFresh())
                {
                    return false;
                }
            }

            return true;
        }
    }
}