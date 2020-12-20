using System;
using System.Collections.Generic;
using System.Linq;

namespace Module15
{
    public interface IOrderDelivery
    {
        Delivery Delivery { get; }
    }

    /// <summary>
    /// Заказ
    /// </summary>
    public class Order : IOrderDelivery
    {
        private readonly IList<Product> mOrderList;

        public string Customer { get; }
        public int Number { get; }
        public string Description { get; }

        /// <summary>
        /// Вид доставки
        /// </summary>
        public Delivery Delivery { get; }

        /// <summary>
        /// Список заказанных товаров
        /// </summary>
        public IReadOnlyList<Product> OrderList => mOrderList.ToList().AsReadOnly();

        public Order(string customer, string description, int number, IList<Product> orders, Delivery delivery)
        {
            Customer = customer;
            Description = description;
            Number = number;
            mOrderList = orders;
            Delivery = delivery;
        }

        public override string ToString()
            => $"№ {Number} для {Customer}";
    }

    /// <summary>
    /// Вспомогательный класс для реализации функционала работы с заказами
    /// </summary>
    public static class OrderHelper
    {
        /// <summary>
        /// Создание заказа
        /// </summary>
        /// <param name="shopProducts">Ассортимент товаров на продажу</param>
        /// <param name="GetOrderNumber">Функция для получения номера заказа</param>
        /// <param name="GetPostamatId">Функция для получения ИД постамата</param>
        /// <returns>Заказ <see cref="Order"/></returns>
        public static Order CreateOrder(IList<Product> shopProducts, Func<int> GetOrderNumber, Func<long> GetPostamatId)
        {
            var productPool = new List<Product>();

            while(true)
            {
                Console.Clear();

                if (productPool.Count > 0)
                {
                    ConsoleHelper.ShopSay($"Товар добавлен: {productPool[^1].Name}");
                    Console.WriteLine();
                }

                ConsoleHelper.ShopSay("Выберите товар:");

                for (int i = 0; i < shopProducts.Count; i++)
                    ConsoleHelper.ShopSay($"{i} - {shopProducts[i]}");

                ConsoleHelper.ShopSay("end - оформить заказ");

                string input = ConsoleHelper.CustomerAnswer();

                if (input == "end")
                    break;

                if (!uint.TryParse(input, out uint code) || code >= shopProducts.Count)
                    continue;

                productPool.Add(shopProducts[(int)code]);
            }

            ConsoleHelper.ShopSay("Введите ваше имя: ");
            string name = ConsoleHelper.CustomerAnswer();

            ConsoleHelper.ShopSay("Введите описание заказа: ");
            string description = ConsoleHelper.CustomerAnswer();

            Delivery delivery = null;

            while (delivery == null)
            {
                ConsoleHelper.ShopSay("Выберите тип доставки:");
                IList<string> deliveryTypes = DeliveryTypeHelper.GetDeliveryTypeList();

                for (int i = 0; i < deliveryTypes.Count; i++)
                    ConsoleHelper.ShopSay($"{i} - {deliveryTypes[i]}");

                if (!uint.TryParse(ConsoleHelper.CustomerAnswer(), out uint code) || code >= deliveryTypes.Count)
                {
                    ConsoleHelper.ShopSay("Неверный тип доставки");
                    continue;
                }

                delivery = DeliveryFactory.CreateDelivery(deliveryTypes[(int)code], GetPostamatId);
            }

            return new Order(name, description, GetOrderNumber(), productPool.ToArray(), delivery);
        }
    }
}
