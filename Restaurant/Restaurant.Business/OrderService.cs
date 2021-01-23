using Restaurant.Business.Contracts;
using Restaurant.Business.DTO;
using System;
using System.Threading.Tasks;

namespace Restaurant.Business
{
    public class OrderService
    {
        IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<OrderCreatedDTO> ReceiveOrder(int pointOfSaleId, int mealId)
        {
            bool pointOfSaleExists = await _orderRepository.PointOfExists(pointOfSaleId);
            if (!pointOfSaleExists)
                throw new Exception("Point of sale not found");

            bool mealsExists = await _orderRepository.MealExists(mealId);
            if (!mealsExists)
                throw new Exception("Meal not found");

            int orderId = await _orderRepository.Insert(pointOfSaleId, mealId);
            await _orderRepository.SendOrderToKitchen(orderId);

            return new OrderCreatedDTO { OrderId = orderId };
        }
    }
}
