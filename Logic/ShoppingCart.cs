using LogicInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class ShoppingCart : IShoppingCart
    {
        public int ProductID { get; set; }

        private IProduct _product;

        public IProduct Product
        {
            get
            {
                return _product;
            }
            set
            {
                _product = value;
                ProductID = _product.ProductID;
            }
        }

        public int ProfileID { get; set; }

        private IProfile _profile;

        public IProfile Profile
        {
            get
            {
                return _profile;
            }
            set
            {
                _profile = value;
                ProfileID = _profile.ID;
            }
        }

        private int _amount { get; set; }

        public int Amount
        {
            get
            {
                return _amount;
            }
            set
            {
                if (value > 0)
                {
                    _amount = value;
                }
                else
                {
                    _amount = 1;
                }
            }
        }
    }
}
