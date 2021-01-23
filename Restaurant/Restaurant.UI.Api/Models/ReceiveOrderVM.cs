using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.UI.Api.Models
{
    public class ReceiveOrderVM
    {
        public int PointOfSaleId { get; set; }
        public int MealId { get; set; }
    }
}
