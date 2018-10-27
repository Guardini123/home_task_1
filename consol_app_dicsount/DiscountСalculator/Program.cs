using System;

namespace DiscountСalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            int answer_main = 1;
            while (answer_main == 1) {
                Console.WriteLine("Вы хотите добавить новый продукт? 1 - да, 2 - нет");

                int.TryParse(Console.ReadLine(), out answer_main);
                if (answer_main == 1)
                {
                    CreateProduct();
                }

                Console.ReadLine();
            }
        }

        private static void CreateProduct()
        {
            var product = new Product();

            Console.WriteLine("Введите название продукта");

            product.Name = Console.ReadLine();

            Console.WriteLine("Введите стоимость продукта");

            int.TryParse(Console.ReadLine(), out var price);

            while (price == 0)
            {
                Console.WriteLine("Стоимость продукта не была введена или она была введена с ошибкой. Пожалуйста, введите стоимость продукта ещё раз");

                int.TryParse(Console.ReadLine(), out price);
            }

            product.Price = price;

            Console.WriteLine("Введите тип скидки на товар : " + $"\n   1 - скидочная карта" + $"\n   2 - % от стоимости" + $"\n  3 - сумма от стоимости");

            int.TryParse(Console.ReadLine(), out var discountType);

            product.typeDiscount = discountType;

            if (discountType == 1)
            {
                Console.WriteLine("Введите кол-во денег на карте : ");

                int.TryParse(Console.ReadLine(), out var cardPrice);

                while (cardPrice < 0)
                {
                    Console.WriteLine("Значение денег на карте было введено не верно. Оно не может быть отрицательным.");

                    int.TryParse(Console.ReadLine(), out cardPrice);
                }

                product.priseCard = cardPrice;

                Console.WriteLine("Введите дату начала действия карты");

                DateTime.TryParse(Console.ReadLine(), out var cardStart);

                if (cardStart != DateTime.MinValue)
                {
                    product.startCard = cardStart;
                }

                Console.WriteLine("Введите дату окончания действия карты");

                DateTime.TryParse(Console.ReadLine(), out var cardEnd);

                if (cardEnd != DateTime.MinValue)
                {
                    product.endCard = cardEnd;
                }
            }
            else if (discountType == 2)
            {
                Console.WriteLine("Введите значение скидки на товар (в % от общей стоимости)");

                int.TryParse(Console.ReadLine(), out var discountValue);

                while (discountValue > 100)
                {
                    Console.WriteLine("Значение скидки не может быть больше 100");

                    int.TryParse(Console.ReadLine(), out discountValue);
                }

                product.DiscountValue = discountValue;

                Console.WriteLine("Введите дату начала действия скидки");

                DateTime.TryParse(Console.ReadLine(), out var startSellDate);

                if (startSellDate != DateTime.MinValue)
                {
                    product.StartSellDate = startSellDate;
                }

                Console.WriteLine("Введите дату окончания действия скидки");

                DateTime.TryParse(Console.ReadLine(), out var endSellDate);

                if (endSellDate != DateTime.MinValue)
                {
                    product.EndSellDate = endSellDate;
                }
            } else if (discountType == 3) {
                Console.WriteLine("Введите цену, которой равна скидка : ");

                int.TryParse(Console.ReadLine(), out var deltaPrice);

                while (deltaPrice > price)
                {
                    Console.WriteLine("Скидка была введена с ошибкой. Значение не может быть больше цены товара.");

                    int.TryParse(Console.ReadLine(), out deltaPrice);
                }

                product.priseDelta = deltaPrice;
            }
            Console.WriteLine($"Вы успешно добавили новый продукт: {product.Name}, стоимость - {product.Price}р. {product.GetSellInformation()}");
        }
    }
}
