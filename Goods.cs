using System.Xml.Serialization;

namespace Task2
{
    /// <summary>
    /// Класс - абстракия над товаром 
    /// </summary>
    [XmlInclude(typeof(Product)),XmlInclude(typeof(Set)),XmlInclude(typeof(Consignment))]
    public abstract class Goods
    {
        [XmlAttribute]
        public string name;
        [XmlAttribute]
        public double price;
        /// <summary>
        /// Этот абстрактный метод выводит в консоль информацию о товаре
        /// </summary>
        public abstract void printInformation();
        /// <summary>
        /// Этот абстрактный метод проверяет, соответствует ли набор сроку годности на текущую дату
        /// </summary>
        /// <returns>true, если товар не просрочен, в противном случае - false</returns>
        public abstract bool isFresh();
    }
}