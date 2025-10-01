using ShoppingCart.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Application.Interfaces
{
    public interface ICartRepository
    {
        Task<Cart> GetAsync();
        Task<Guid> AddAsync(CartItem item);
        Task RemoveAsync(Guid itemId);
    }
}
