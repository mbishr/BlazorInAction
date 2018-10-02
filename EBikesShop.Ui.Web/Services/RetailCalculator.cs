namespace EBikesShop.Ui.Web.Services
{
    public class RetailCalculator
    {
        public decimal CalculateTotalPrice(int items, decimal pricePerItem, decimal taxRate)
        {
            var price = SubstractDiscount(items * pricePerItem);
            return AddTax(price, taxRate);
        }

        private decimal AddTax(decimal price, decimal taxRate)
        {
            var tax = price * taxRate / 100m;
            return price + tax;
        }

        private decimal SubstractDiscount(decimal price)
        {
            var discountRate = GetDiscountRate(price);
            var discount = price * discountRate / 100m;
            return price - discount;
        }

        private decimal GetDiscountRate(decimal price)
        {
            var discountRate = 0m;
            if (price >= 50000m)
            {
                discountRate = 15m;
            }
            else if (price >= 10000m)
            {
                discountRate = 10m;
            }
            else if (price >= 7000m)
            {
                discountRate = 7m;
            }
            else if (price >= 5000m)
            {
                discountRate = 5m;
            }
            else if (price >= 1000m)
            {
                discountRate = 3m;
            }
            return discountRate;
        }
    }
}
