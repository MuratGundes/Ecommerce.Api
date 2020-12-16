﻿using System;
using System.Collections.Generic;
using Streetwood.Core.Domain.Abstract;

namespace Streetwood.Core.Domain.Entities
{
    public class ProductOrder : Entity
    {
        private readonly List<ProductOrderCharm> productOrderCharms = new List<ProductOrderCharm>();

        public int Amount { get; protected set; }

        public decimal CurrentProductPrice { get; protected set; }

        public decimal FinalPrice { get; protected set; }

        public string Comment { get; protected set; }

        public decimal CharmsPrice { get; protected set; }

        public int? DiscountValue { get; protected set; }

        public string Size { get; protected set; }

        public string Color { get; protected set; }

        public string Graver { get; protected set; }

        public virtual ProductCategoryDiscount ProductCategoryDiscount { get; protected set; }

        public virtual Order Order { get; protected set; }

        public virtual Product Product { get; protected set; }

        public virtual IReadOnlyCollection<ProductOrderCharm> ProductOrderCharms => productOrderCharms;

        public ProductOrder(int amount, string comment, string size, string color)
        {
            Id = Guid.NewGuid();
            Amount = amount;
            Comment = comment;
            Size = size;
            Color = color;
        }

        protected ProductOrder()
        {
        }

        public void SetCurrentProductPrice(decimal price)
            => CurrentProductPrice = price;

        public void SetFinalPrice(decimal price)
            => FinalPrice = price;

        public void SetCharmsPrice(decimal price)
            => CharmsPrice = price;

        public void SetGraver(string graver)
        {
            if (Product != null && Product.AcceptGraver)
            {
                Graver = graver;
            }
        }

        public void AddProductCategoryDiscount(ProductCategoryDiscount discount)
        {
            ProductCategoryDiscount = discount;
            DiscountValue = discount?.PercentValue;
        }

        public void AddProduct(Product product)
            => Product = product;

        public void AddProductOrderCharm(ProductOrderCharm orderCharm)
            => productOrderCharms.Add(orderCharm);

        public void AddProductOrderCharms(IEnumerable<ProductOrderCharm> orderCharms)
            => productOrderCharms.AddRange(orderCharms);

    }
}