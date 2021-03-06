﻿using System;
using System.Collections.Generic;

namespace Module15
{
    public static class ConsoleHelper
    {
        public static ConsoleColor ShopColor = ConsoleColor.Yellow;
        public static ConsoleColor CustomerColor = ConsoleColor.White;

        public static void ShopSay(string say)
        {
            var prevColor = Console.ForegroundColor;

            Console.ForegroundColor = ShopColor;
            Console.WriteLine(say);
            Console.ForegroundColor = prevColor;
        }

        public static string CustomerAnswer()
        {
            var prevColor = Console.ForegroundColor;

            Console.ForegroundColor = CustomerColor;
            string answer = Console.ReadLine();
            Console.ForegroundColor = prevColor;

            return answer;
        }
    }

    /// <summary>
    /// Абстрактный адрес
    /// </summary>
    public abstract class BaseAddress
    {
        public static bool operator ==(BaseAddress address1, BaseAddress address2) 
            => address1.Equals(address2);

        public static bool operator !=(BaseAddress address1, BaseAddress address2) 
            => !(address1 == address2);
    }

    /// <summary>
    /// "Служба доставки" так сказать...
    /// </summary>
    public static class SimpleDeliveryService
    {
        public static List<IRecipientStore> ShopsPool = new();

        public static void SendShopDelivery(IOrderDelivery order)
        {
            if (order.Delivery.Type == DeliveryType.ShopDelivery)
                foreach (var shop in ShopsPool)
                    if (shop.Address == (order.Delivery as ShopDelivery)?.ShopAddress)
                    {
                        shop.DeliverOrder(order as Order);
                        break;
                    }
        }
    }

    /// <summary>
    /// Адрес
    /// </summary>
    public class Address : BaseAddress
    {
        // Чтоб не мучиться, адреса хардкодим
        public static Address address1 = new Address { City = "City 17", Street = "ул. Непрямая", House = "1П/2Ж"};
        public static Address address2 = new Address { City = "Город-которого-нет", Street = "ул. Уличная", House = "256" };

        public string City { get; set; }
        public string Street { get; set; }
        public string House { get; set; }

        public static bool operator ==(Address address1, Address address2)
        {
            if (object.ReferenceEquals(address1, address2))
                return true;

            return
                address1.City == address2.City &&
                address1.Street == address2.Street &&
                address1.House == address2.House;
        }

        public static bool operator !=(Address address1, Address address2)
            => !(address1 == address2);

        public override string ToString()
            => $"г.{City}, {Street}, д.{House}";
    }

}
