using DataFactory;
using DataInterfaces;
using DataInterfaces.Models;
using DataInterfaces.Repositories;
using LogicInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    public class ShoppingCartCollection : IShoppingCartCollection
    {
        private IShoppingCartRepository _shoppingCartRepository;

        public ShoppingCartCollection(IShoppingCartRepository shoppingCartRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
        }

        public IShoppingCart GetShoppingCartById(int id)
        {
            var shoppingCart = _shoppingCartRepository.GetShoppingCartById(id);

            if(shoppingCart == null)
            {
                return null;
            }

            return ShoppingCartDtoToShoppingCart(_shoppingCartRepository.GetShoppingCartById(id));
        }

        private IShoppingCart ShoppingCartDtoToShoppingCart(IShoppingCartDto shoppingCartDto)
        {
            return new ShoppingCart()
            {
                ProfileID = shoppingCartDto.ProfileID,
                ProductID = shoppingCartDto.ProductID,
                Amount = shoppingCartDto.Amount,
            };
        }
    }
}
