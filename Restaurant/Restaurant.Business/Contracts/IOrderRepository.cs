using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Business.Contracts
{
    public interface IOrderRepository
    {
        Task<int> Insert(int pointOfSaleId, int mealId);
        Task SendOrderToKitchen(int orderId);
        Task<bool> PointOfExists(int pointOfSaleId);
        Task<bool> MealExists(int mealId);
    }
}
