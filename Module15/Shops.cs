using System;
using System.Collections.Generic;
using System.Linq;

namespace Module15
{
    /// <summary>
    /// Интерфейс точки доставки заказа
    /// </summary>
    public interface IRecipientStore
    {
        public BaseAddress Address { get; }

        /// <summary>
        /// Доставка заказа в точку
        /// </summary>
        /// <param name="order">Заказ</param>
        public void DeliverOrder(Order order);
    }

    /// <summary>
    /// Магазин
    /// </summary>
    /// <typeparam name="TProduct">Обобщение товара</typeparam>
    public class Shop<TProduct> : IRecipientStore
        where TProduct : Product
    {
        private static int NextOrderNumber = 0;

        private readonly string Name;
        public BaseAddress Address { get; }
        private readonly TProduct[] productList;
        private readonly List<Order> OrderStorage = new();

        public Shop(string name, BaseAddress address, TProduct[] products)
        {
            Name = name;
            Address = address;
            productList = products;
        }

        /// <summary>
        /// Взаимодействие с покупателем
        /// </summary>
        public void CustomerInteraction()
        {
            bool exitShop = false;

            while (!exitShop)
            {
                ShowMenu();

                if (!int.TryParse(ConsoleHelper.CustomerAnswer(), out int input))
                    continue;

                switch (input)
                {
                    case 1:
                        var order = MakeAnOrder();

                        if (order.OrderList.Count != 0)
                            SendOrder(order);
                        else
                        {
                            ConsoleHelper.ShopSay("Корзина пуста");
                            Console.ReadKey();
                        }
                        break;

                    case 2:
                        Console.Clear();
                        exitShop = true;
                        break;

                    case 3:
                        order = OrderStorage.FirstOrDefault();
                        ConsoleHelper.ShopSay($"Выдан заказ {order}");
                        OrderStorage.Remove(order);
                        Console.ReadKey();
                        break;

                    default:
                        break;
                }
            }
        }

        private void ShowMenu()
        {
            Console.Clear();

            ConsoleHelper.ShopSay($"Добро пожаловать в магазин {Name}!");
            ConsoleHelper.ShopSay("У нас есть все что вам нужно.");

            ConsoleHelper.ShopSay("1 - Сделать заказ");
            ConsoleHelper.ShopSay("2 - Выйти из магазина");
            ConsoleHelper.ShopSay("3 - Получить заказ");
        }

        private Order MakeAnOrder()
        {
            var order = OrderHelper.CreateOrder(productList, GetOrderNumber, GetPostamatId);

            ConsoleHelper.ShopSay($"Принят заказ {order.Number} на сумму {order.GetTotalPrice()}");
            return order;
        }

        private void SendOrder(Order order)
        {
            ConsoleHelper.ShopSay($"Заказ {order.Number} отправлен.");
            order.Delivery.ProcessDelivery();
            SimpleDeliveryService.SendShopDelivery(order);

            Console.ReadKey();
        }

        private int GetOrderNumber() => ++NextOrderNumber;

        private long GetPostamatId() => new Random().Next(10, 50);

        public void DeliverOrder(Order order)
        {
            OrderStorage.Add(order);
        }
    }

    internal static class OrderExtension
    {
        public static double GetTotalPrice(this Order order)
            => order.OrderList.Sum(product => product.Price);
    }
}
