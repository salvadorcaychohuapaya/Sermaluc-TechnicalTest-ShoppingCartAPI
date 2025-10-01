using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Domain
{
    public class SelectedAttribute
    {
        public long AttributeId { get; set; }
        public int Quantity { get; set; }
        public decimal PriceImpactAmount { get; set; }
    }
}
