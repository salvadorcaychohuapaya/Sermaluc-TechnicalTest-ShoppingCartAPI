using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Domain
{
    public class QuantityInformation
    {
        public int GroupAttributeQuantity { get; set; }
        public string VerifyValue { get; set; } = "EQUAL_THAN";
    }
}
