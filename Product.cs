using System;
using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;

namespace Task2
{
    /// <summary>
    /// Класс Продукт - реализация Товара
    /// </summary>
    [Serializable]
    public class Product : Goods
    {
        public Product()
        {
        }

        [XmlAttribute] public DateTime productionDate { get; set; }
        [XmlAttribute] public int shelfLife { get; set; }

        /// <summary>
        /// Конструктор класса Product
        /// </summary>
        /// <param name="name">название</param>
        /// <param name="price">цена</param>
        /// <param name="year">год производства</param>
        /// <param name="month">месяц производства</param>
        /// <param name="day">день производства</param>
        /// <param name="shelfLife">срок годности в днях</param>
        public Product(string name, double price, int year, int month, int day, int shelfLife)
        {
            this.name = name;
            this.price = price;
            this.productionDate = new DateTime(year, month, day);
            this.shelfLife = shelfLife;
        }

        /// <summary>
        /// Конструктор, который считывает из файла значения name,price,day,month,year и shelfLife, чтобы создать новый Product
        /// </summary>
        /// <param name="streamReader">StreamReader, с помощью которого нужно считывать информацию из файла</param>
        public Product(StreamReader streamReader)
        {
            this.name = streamReader.ReadLine();
            this.price = double.Parse(streamReader.ReadLine());
            var day = int.Parse(streamReader.ReadLine());
            var month = int.Parse(streamReader.ReadLine());
            var year = int.Parse(streamReader.ReadLine());
            this.productionDate = new DateTime(year, month, day);
            this.shelfLife = int.Parse(streamReader.ReadLine());
        }

        /// <summary>
        /// Этот метод выводит в консоль информацию о продукте
        /// </summary>
        public override void printInformation()
        {
            Trace.WriteLine("Product.printInformation");
            Console.WriteLine("Product name: " + this.name);
            Console.WriteLine("Price: " + this.price);
            Console.WriteLine("Production date: " + this.productionDate.ToShortDateString());
            Console.WriteLine("Shelf life: " + shelfLife + " days \n");
        }

        /// <summary>
        /// Этот метод проверяет, соответствует ли продукт сроку годности на текущую дату
        /// </summary>
        /// <returns>true, если продукт не просрочен, в противном случае - false</returns>
        public override bool isFresh()
        {
            Trace.WriteLine("Product.isFresh");
            return productionDate.AddDays(shelfLife) >= DateTime.Today;
        }
    }
}