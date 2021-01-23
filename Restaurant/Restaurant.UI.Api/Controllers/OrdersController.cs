using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Restaurant.Business;
using Restaurant.UI.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.UI.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {

        private readonly OrderService _orderService;

        public OrdersController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        [Route("receive")]
        public async Task<IActionResult> ReceiveOrder(ReceiveOrderVM order)
        {
            try
            {
                var result = await _orderService.ReceiveOrder(order.PointOfSaleId, order.MealId);
                return Created($"orders/{result.OrderId}", result.OrderId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
