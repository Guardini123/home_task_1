using System;

namespace DiscountСalculator
{
    public class Product : IDiscount
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int typeDiscount { get; set; }
        public int DiscountValue { get; set; }
        public DateTime? StartSellDate { get; set; }
        public DateTime? EndSellDate { get; set; }
        public int priseCard { get; set; }
        public DateTime? startCard { get; set; }
        public DateTime? endCard { get; set; }
        public int priseDelta { get; set; }
        
        public int CalculateDiscountPrice()
        {
            int pr = -1;
            if(typeDiscount == 1)
            {
                if (startCard.HasValue && endCard.HasValue && startCard <= DateTime.UtcNow && endCard >= DateTime.UtcNow)
                {
                    pr = Price - priseCard;
                    if (pr < 0)
                    {
                        pr = 0;
                    }
                }
            } else if (typeDiscount == 2) {
                if (DiscountValue != 0 && StartSellDate.HasValue && EndSellDate.HasValue && StartSellDate <= DateTime.UtcNow && EndSellDate >= DateTime.UtcNow)
                {
                    pr = Price - (Price * DiscountValue / 100);
                }
            } else if (typeDiscount == 3) {
                pr = Price - priseDelta;
            }
            return pr;
        }

        public string GetSellInformation()
        {
        string answer = " ";
        if (typeDiscount == 1) {
            if (CalculateDiscountPrice() != -1 && startCard.HasValue && endCard.HasValue)
            {
                answer = $"Ваша подарочная карта активна." + $"Стоимость со скидкой - {CalculateDiscountPrice()} р.";
            } else {
                answer = $"Ваша подарочная карта не активна." + $"Стоимость - {Price} р.";
            }
        } else 
        if (typeDiscount == 2) {
            if (DiscountValue != 0 && StartSellDate.HasValue && EndSellDate.HasValue && StartSellDate <= DateTime.UtcNow && EndSellDate >= DateTime.UtcNow)
            {
                answer = $"На данный товар действует скидка {DiscountValue}% в период с {StartSellDate.Value.ToShortDateString()} по {EndSellDate.Value.ToShortDateString()}. " + $"Сумма с учётом скидки - {CalculateDiscountPrice()}р.";
            } else {
                answer = "В настоящий момент на данный товар нет скидок.";
            }
        } else
        if (typeDiscount == 3) {
            answer = $"Стоимость с учётом скидки - {CalculateDiscountPrice()} р.";
        }
            return answer;
        }
    }        
}
