using Restaurant.Business.Contracts;
using Restaurant.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Data
{
    public class OrderRepository : IOrderRepository
    {
        private readonly List<Order> orders = new List<Order>();
        private readonly Queue<int> kitchenOrders = new Queue<int>();

        private readonly List<PointOfSale> pointOfSales = new List<PointOfSale>
        {
            new PointOfSale() { PointOfSaleId = 1, Name = "Point 1" },
            new PointOfSale() { PointOfSaleId = 2, Name = "Point 2" },
            new PointOfSale() { PointOfSaleId = 3, Name = "Point 3" }
        };

        private readonly List<Meal> meals = new List<Meal>
        {
            new Meal() { MealId = 1, Name = "Meal 1", },
            new Meal() { MealId = 2, Name = "Meal 2" },
            new Meal() { MealId = 3, Name = "Meal 3" }
        };

        public async Task<int> Insert(int pointOfSaleId, int mealId)
        {
            var order = new Order
            {
                OrderId = orders.Count + 1,
                MealId = mealId,
                PointOfSaleId = pointOfSaleId
            };

            orders.Add(order);

            return order.OrderId;
        }

        public async Task<bool> MealExists(int mealId)
        {
            return meals.Any(x => x.MealId == mealId);
        }

        public async Task<bool> PointOfExists(int pointOfSaleId)
        {
            return pointOfSales.Any(x => x.PointOfSaleId == pointOfSaleId);
        }

        public async Task SendOrderToKitchen(int orderId)
        {
            kitchenOrders.Enqueue(orderId);
        }
    }
}
