using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Domain
{
    public class SelectedGroup
    {
        public string GroupAttributeId { get; set; } = "";
        public List<SelectedAttribute> Attributes { get; set; } = new();
        public decimal TotalImpact => Attributes.Sum(a => a.PriceImpactAmount * a.Quantity);
    }
}
