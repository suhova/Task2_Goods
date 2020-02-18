namespace Task2
{
    /// <summary>
    /// Класс - абстракия над товаром 
    /// </summary>
    public abstract class Goods
    {
        public string name;
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