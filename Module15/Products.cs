using System;
using System.Collections.Generic;
using System.Text;

namespace Module15
{
    /// <summary>
    /// Товар
    /// </summary>
    public abstract class Product
    {
        /// <summary>
        /// Наименование товара
        /// </summary>
        public string Name;

        /// <summary>
        /// Артикул
        /// </summary>
        public object VendorCode;

        /// <summary>
        /// Цена
        /// </summary>
        public double Price;

        public override string ToString()
            => $"[{Name}] - {Price}";
    }

    /// <summary>
    /// Товарная группа инструменты
    /// </summary>
    public class Tools : Product
    {
    }

    /// <summary>
    /// Товарная группа гаджеты
    /// </summary>
    public class Gadget : Product
    {
        public string Class;
        public bool CheckWork() => true;
    }

    /// <summary>
    /// Товарная группа продовольствие
    /// </summary>
    public class Food : Product
    {
        public bool CheckOverdue() => false;
    }
}
