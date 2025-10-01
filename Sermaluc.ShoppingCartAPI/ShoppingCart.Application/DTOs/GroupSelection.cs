using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Application.DTOs
{
    public class GroupSelection
    {
        public string GroupAttributeId { get; set; } = "";
        public List<AttributeSelection> Attributes { get; set; } = new();
    }
}
