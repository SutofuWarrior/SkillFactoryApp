using System;

namespace Module15
{
    class Program
    {
        static void Main()
        {
            var tools = new Tools[]
            {
                new Tools { Name = "Молоток", Price = 10.34, VendorCode = "M-0001" },
                new Tools { Name = "Пила", Price = 14.99, VendorCode = "П-0027" },
                new Tools { Name = "Отвертка", Price = 8.85, VendorCode = "О-0502" },
                new Tools { Name = "Линейка", Price = 3.40, VendorCode = "Л-0031" }
            };

            var toolsShop = new Shop<Tools>("\"Инструменты дяди Миши\"", Address.address1, tools);

            var food = new Food[]
            {
                new Food { Name = "Кофе", Price = 53.00, VendorCode = 11 },
                new Food { Name = "Чай", Price = 28.40, VendorCode = 22 },
                new Food { Name = "Шоколад", Price = 41.99, VendorCode = 33 },
                new Food { Name = "Консервы мясные", Price = 38.90, VendorCode = 44 }
            };

            var foodShop = new Shop<Food>("\"Гастроном №5\"", Address.address2, food);

            SimpleDeliveryService.ShopsPool.Add(toolsShop);
            SimpleDeliveryService.ShopsPool.Add(foodShop);

            toolsShop.CustomerInteraction();
            //foodShop.CustomerInteraction();

            Console.WriteLine("Press any key for exit...");
            Console.ReadKey();
        }
    }
}
