using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Domain
{
    public class GroupDefinition
    {
        public string GroupAttributeId { get; set; } = "";
        public string? Description { get; set; }
        public QuantityInformation QuantityInformation { get; set; } = new();
        public List<AttributeDefinition> Attributes { get; set; } = new();
    }
}
