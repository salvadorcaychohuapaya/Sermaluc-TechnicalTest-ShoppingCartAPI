using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Domain
{
    public class AttributeDefinition
    {
        public long AttributeId { get; set; }
        public string Name { get; set; } = "";
        public int DefaultQuantity { get; set; }
        public int MaxQuantity { get; set; }
        public decimal PriceImpactAmount { get; set; }
        public bool IsRequired { get; set; }
    }
}
