using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Domain
{
    public class Cart
    {
        private readonly List<CartItem> _items = new();
        public IReadOnlyCollection<CartItem> Items => _items.AsReadOnly();

        public void AddItem(CartItem item) => _items.Add(item);
        public void RemoveItem(Guid itemId) => _items.RemoveAll(i => i.ItemId == itemId);
        public CartItem? GetItem(Guid itemId) => _items.FirstOrDefault(i => i.ItemId == itemId);
        public decimal Total() => _items.Sum(i => i.Total);
    }
}
