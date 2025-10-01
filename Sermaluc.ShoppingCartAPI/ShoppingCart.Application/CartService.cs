using ShoppingCart.Application.DTOs;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Application
{
    public class CartService
    {
        private readonly ICartRepository _repo;
        private readonly ProductDefinition _product;

        public CartService(ICartRepository repo, ProductDefinition productDefinition)
        {
            _repo = repo;
            _product = productDefinition;
        }

        public async Task<Guid> AddAsync(AddToCartRequest req)
        {
            if (req.ProductId != _product.ProductId)
                throw new ArgumentException("Producto no válido para esta prueba.");

            foreach (var groupSel in req.Groups)
            {
                var groupDef = _product.GroupAttributes.FirstOrDefault(g => g.GroupAttributeId == groupSel.GroupAttributeId)
                               ?? throw new ArgumentException($"Grupo {groupSel.GroupAttributeId} no existe.");

                var countSelected = groupSel.Attributes.Sum(a => a.Quantity > 0 ? 1 : 0);
                var required = groupDef.QuantityInformation.GroupAttributeQuantity;
                var verify = groupDef.QuantityInformation.VerifyValue;

                if (verify == "EQUAL_THAN" && countSelected != required)
                    throw new ArgumentException($"Grupo {groupSel.GroupAttributeId}: Debe seleccionar exactamente {required}.");
                if (verify == "LOWER_EQUAL_THAN" && countSelected > required)
                    throw new ArgumentException($"Grupo {groupSel.GroupAttributeId}: Puede seleccionar hasta {required}.");

                foreach (var attrSel in groupSel.Attributes)
                {
                    var attrDef = groupDef.Attributes.FirstOrDefault(a => a.AttributeId == attrSel.AttributeId)
                                  ?? throw new ArgumentException($"Atributo {attrSel.AttributeId} no existe en grupo {groupSel.GroupAttributeId}.");

                    if (attrSel.Quantity < 0 || attrSel.Quantity > attrDef.MaxQuantity)
                        throw new ArgumentException($"Atributo {attrSel.AttributeId}: cantidad inválida (0..{attrDef.MaxQuantity}).");
                }
            }

            var item = new CartItem
            {
                ProductId = _product.ProductId,
                Name = _product.Name,
                BasePrice = _product.Price,
                Quantity = req.Quantity,
                SelectedGroups = req.Groups.Select(g => new SelectedGroup
                {
                    GroupAttributeId = g.GroupAttributeId,
                    Attributes = g.Attributes.Select(a =>
                    {
                        var def = _product.GroupAttributes
                            .First(gg => gg.GroupAttributeId == g.GroupAttributeId)
                            .Attributes.First(ad => ad.AttributeId == a.AttributeId);

                        return new SelectedAttribute
                        {
                            AttributeId = a.AttributeId,
                            Quantity = a.Quantity,
                            PriceImpactAmount = def.PriceImpactAmount
                        };
                    }).ToList()
                }).ToList()
            };

            return await _repo.AddAsync(item);
        }

        public async Task<Cart> GetAsync() => await _repo.GetAsync();

        public async Task RemoveAsync(Guid itemId) => await _repo.RemoveAsync(itemId);

        public async Task UpdateQuantityAsync(Guid itemId, int delta)
        {
            var cart = await _repo.GetAsync();
            var item = cart.GetItem(itemId) ?? throw new ArgumentException("Item no encontrado.");
            item.Quantity = Math.Max(1, item.Quantity + delta);
        }
    }
}
