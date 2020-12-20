using System;
using System.Collections.Generic;
using System.Threading;

namespace Module15
{
    /// <summary>
    /// Виды доставки заказа
    /// </summary>
    public enum DeliveryType
    {
        /// <summary>
        /// Доставка в магазин
        /// </summary>
        ShopDelivery = 0,

        /// <summary>
        /// Доставка курьером на дом
        /// </summary>
        HomeDelivery = 1,

        /// <summary>
        /// Доставка в постамат
        /// </summary>
        PickPointDelivery = 2
    }

    /// <summary>
    /// Вспомогательный класс для работы с видами доставки
    /// </summary>
    public static class DeliveryTypeHelper
    {
        /// <summary>
        /// Получение строкового представления вида доставки по его коду
        /// </summary>
        public static string DeliveryTypeToString(DeliveryType type) => type switch
        {
            DeliveryType.ShopDelivery => "В магазин",
            DeliveryType.HomeDelivery => "Курьером",
            DeliveryType.PickPointDelivery => "Постамат",
            _ => throw new ArgumentException()
        };

        /// <summary>
        /// Получение кода вида доставки по его строковому представлению
        /// </summary>
        public static DeliveryType StringToDeliveryType(string typeName) => typeName.ToLower() switch
        {
            "в магазин" => DeliveryType.ShopDelivery,
            "курьером" => DeliveryType.HomeDelivery,
            "постамат" => DeliveryType.PickPointDelivery,
            _ => default
        };

        /// <summary>
        /// Получение списка всех видов доставки
        /// </summary>
        public static List<string> GetDeliveryTypeList()
        {
            var types = new List<string>();

            foreach (var type in Enum.GetValues(typeof(DeliveryType)))
                types.Add(DeliveryTypeToString((DeliveryType)type));

            return types;
        }
    }

    /// <summary>
    /// Фабричный класс для создания способа доставки
    /// </summary>
    public static class DeliveryFactory
    {
        /// <summary>
        /// Создание доставки
        /// </summary>
        /// <param name="type">Вид доставки</param>
        /// <param name="GetPostamatId">Функция получения номера постамата для соотвествующего вида доставки</param>
        public static Delivery CreateDelivery(string type, Func<long> GetPostamatId)
        {
            var dtype = DeliveryTypeHelper.StringToDeliveryType(type);

            Delivery delivery = dtype switch
            {
                DeliveryType.ShopDelivery => new ShopDelivery(),
                DeliveryType.HomeDelivery => new HomeDelivery(),
                DeliveryType.PickPointDelivery => new PickPointDelivery(GetPostamatId),
                _ => null
            };

            if (delivery == null)
                return delivery;

            delivery.DeliveryDetails();
            return delivery;
        }
    }

    /// <summary>
    /// Информация о способе доставки заказа
    /// </summary>
    public abstract class Delivery
    {
        /// <summary>
        /// Вид доставки
        /// </summary>
        public abstract DeliveryType Type { get; }

        /// <summary>
        /// Уточнение деталей доставки в зависимости от конкретного способа
        /// </summary>
        public abstract void DeliveryDetails();

        /// <summary>
        /// Представление процесса доставки заказа получателю
        /// </summary>
        public virtual void ProcessDelivery()
        {
            ConsoleHelper.ShopSay("Заказ получен службой доставки");
            Thread.SpinWait(500);
            ConsoleHelper.ShopSay("Заказ отправлен");
            Thread.SpinWait(1000);
        }
    }

    /// <summary>
    /// Доставка на дом получателю
    /// </summary>
    class HomeDelivery : Delivery
    {
        /// <summary>
        /// Адрес получаетля
        /// </summary>
        public BaseAddress CustomerAddress;

        public override DeliveryType Type => DeliveryType.HomeDelivery;

        public override void DeliveryDetails()
        {
            ConsoleHelper.ShopSay("Укажите адрес доставки:");

            // Чтоб не мучиться, адрес хардкодим
            //CustomerAddress = ConsoleHelper.CustomerAnswer();
            CustomerAddress = Address.address2;
            Console.WriteLine(CustomerAddress);
        }

        public override void ProcessDelivery()
        {
            base.ProcessDelivery();

            ConsoleHelper.ShopSay($"Заказ доставлен в пункт выдачи");
            ConsoleHelper.ShopSay($"Заказ отправлен с курьером по адресу {CustomerAddress}");
            Thread.SpinWait(1000);
            ConsoleHelper.ShopSay("Заказ получен");
        }
    }

    /// <summary>
    /// Доставка в постамат
    /// </summary>
    class PickPointDelivery : Delivery
    {
        /// <summary>
        /// Идентификатор постамата для доставки
        /// </summary>
        private long PointId;

        /// <summary>
        /// Функция для получения номера постамата в зависимоисти от магазина
        /// </summary>
        private readonly Func<long> SetPostamat;
        public override DeliveryType Type => DeliveryType.PickPointDelivery;

        public PickPointDelivery(Func<long> setPostamat)
        {
            SetPostamat = setPostamat;
        }

        public override void DeliveryDetails()
        {
            if (SetPostamat == null)
            {
                ConsoleHelper.ShopSay("Магазин не поддерживает доставку в постаматы");
                return;
            }

            PointId = SetPostamat();
            ConsoleHelper.ShopSay($"Заказ будет доставлен в постамат {PointId}");
        }

        public override void ProcessDelivery()
        {
            base.ProcessDelivery();
            ConsoleHelper.ShopSay($"Заказ доставлен в постамат {PointId}");
        }
    }

    /// <summary>
    /// Доставка в магазин
    /// </summary>
    class ShopDelivery : Delivery
    {
        /// <summary>
        /// Адрес магазина
        /// </summary>
        public BaseAddress ShopAddress;
        public override DeliveryType Type => DeliveryType.ShopDelivery;

        public override void DeliveryDetails()
        {
            ConsoleHelper.ShopSay("Укажите адрес пункта выдачи:");

            // Чтоб не мучиться, адрес хардкодим
            //ShopAddress = ConsoleHelper.CustomerAnswer();
            ShopAddress = Address.address1;
            Console.WriteLine(ShopAddress);
        }

        public override void ProcessDelivery()
        {
            base.ProcessDelivery();
            ConsoleHelper.ShopSay($"Заказ доставлен в пункт выдачи {ShopAddress}");
            ConsoleHelper.ShopSay($"Заказ выполнен.");
        }
    }
}
