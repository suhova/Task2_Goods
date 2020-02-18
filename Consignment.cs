using System;
using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;

namespace Task2
{
    /// <summary>
    /// Класс Партия - реализация Товара
    /// </summary>
    public class Consignment : Goods
    {
        public Consignment()
        {
        }

        [XmlAttribute] public int amount { get; set; }
        [XmlAttribute] public DateTime productionDate { get; set; }
        [XmlAttribute] public int shelfLife { get; set; }

        /// <summary>
        /// Конструктор класса Consignment
        /// </summary>
        /// <param name="name">название</param>
        /// <param name="price">цена</param>
        /// <param name="amount">количество штук</param>
        /// <param name="year">год производства</param>
        /// <param name="month">месяц производства</param>
        /// <param name="day">день производства</param>
        /// <param name="shelfLife">срок годности в днях</param>
        public Consignment(string name, double price, int amount, int year, int month, int day, int shelfLife)
        {
            this.name = name;
            this.price = price;
            this.amount = amount;
            this.productionDate = new DateTime(year, month, day);
            this.shelfLife = shelfLife;
        }

        /// <summary>
        /// Конструктор, который считывает из файла значения name,price,amount,day,month,year и shelfLife, чтобы создать новый Consignment
        /// </summary>
        /// <param name="streamReader">StreamReader, с помощью которого нужно считывать информацию из файла</param>
        public Consignment(StreamReader streamReader)
        {
            this.name = streamReader.ReadLine();
            this.price = double.Parse(streamReader.ReadLine());
            this.amount = int.Parse(streamReader.ReadLine());
            var day = int.Parse(streamReader.ReadLine());
            var month = int.Parse(streamReader.ReadLine());
            var year = int.Parse(streamReader.ReadLine());
            this.productionDate = new DateTime(year, month, day);
            this.shelfLife = int.Parse(streamReader.ReadLine());
        }

        /// <summary>
        /// Этот метод выводит в консоль информацию о партии
        /// </summary>
        public override void printInformation()
        {
            Trace.WriteLine("Consignment.printInformation");
            Console.WriteLine("Сonsignment name: " + this.name);
            Console.WriteLine("Amount: " + this.amount);
            Console.WriteLine("Price: " + this.price);
            Console.WriteLine("Production date: " + this.productionDate.ToShortDateString());
            Console.WriteLine("Shelf life: " + shelfLife + " days \n");
        }

        /// <summary>
        /// Этот метод проверяет, соответствует ли партия сроку годности на текущую дату
        /// </summary>
        /// <returns>true, если партия не просрочена, в противном случае - false</returns>
        public override bool isFresh()
        {
            Trace.WriteLine("Consignment.isFresh");
            return productionDate.AddDays(shelfLife) >= DateTime.Today;
        }
    }
}