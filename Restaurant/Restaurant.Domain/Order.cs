using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Domain
{
    public class Order
    {
        public int OrderId { get; set; }
        public int PointOfSaleId { get; set; }
        public int MealId { get; set; }
    }
}
