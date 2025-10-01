using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Domain
{
    public class CartItem
    {
        public Guid ItemId { get; set; } = Guid.NewGuid();
        public int ProductId { get; set; }
        public string Name { get; set; } = "";
        public decimal BasePrice { get; set; }
        public int Quantity { get; set; } = 1;
        public List<SelectedGroup> SelectedGroups { get; set; } = new();
        public decimal Total => (BasePrice + SelectedGroups.Sum(g => g.TotalImpact)) * Quantity;
    }
}
