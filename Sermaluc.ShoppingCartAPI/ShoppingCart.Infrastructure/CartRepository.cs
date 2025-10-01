using ShoppingCart.Application.Interfaces;
using ShoppingCart.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Infrastructure
{
    public class CartRepository : ICartRepository
    {
        private static readonly Cart _cart = new();

        public async Task<Guid> AddAsync(CartItem item)
        {
            _cart.AddItem(item);
            return await Task.FromResult(item.ItemId);
        }

        public Task<Cart> GetAsync()
        {
            return Task.FromResult(_cart);
        }

        public Task RemoveAsync(Guid itemId)
        {
            _cart.RemoveItem(itemId);
            return Task.CompletedTask;
        }
    }
}
