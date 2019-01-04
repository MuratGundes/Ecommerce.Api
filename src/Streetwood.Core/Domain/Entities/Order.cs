﻿using System;
using System.Collections.Generic;
using Streetwood.Core.Domain.Abstract;

namespace Streetwood.Core.Domain.Entities
{
    public class Order : Entity
    {
        private readonly List<ProductOrder> productOrders = new List<ProductOrder>();

        public bool IsShipped { get; protected set; }

        public bool IsPayed { get; protected set; }

        public bool IsClosed { get; protected set; }

        public string Comment { get; protected set; }

        public decimal BasePrice { get; protected set; }

        public decimal ShipmentPrice { get; protected set; }

        public decimal AgreedPrice { get; protected set; }

        public DateTime CreationDateTime { get; protected set; }

        public DateTime? PayedDateTime { get; protected set; }

        public DateTime? ShipmentDateTime { get; protected set; }

        public DateTime? ClosedDateTime { get; protected set; }

        public virtual Shipment Shipment { get; protected set; }

        public virtual User User { get; protected set; }

        public virtual OrderDiscount OrderDiscount { get; protected set; }

        public virtual Address Address { get; protected set; }

        public virtual IReadOnlyCollection<ProductOrder> ProductOrders => productOrders;

        public Order(IEnumerable<ProductOrder> productOrders, OrderDiscount orderDiscount, Shipment shipment, decimal basePrice, string comment)
        {
            Id = Guid.NewGuid();
            SetIsShipped(false);
            SetIsPayed(false);
            SetIsClosed(false);
            Comment = comment;
            BasePrice = basePrice;
            SetShipment(shipment);
            ShipmentPrice = shipment.Price;
            CreationDateTime = DateTime.UtcNow;
            AddProductOrders(productOrders);
            SetDiscount(orderDiscount);
        }

        protected Order()
        {
        }

        public void SetIsShipped(bool isShipped)
            => IsShipped = isShipped;

        public void SetIsPayed(bool isPayed)
            => IsPayed = isPayed;

        public void SetIsClosed(bool isClosed)
            => IsClosed = isClosed;

        public void SetPayedDateTime(DateTime dateTime)
            => PayedDateTime = dateTime;

        public void SetShipmentDateTime(DateTime dateTime)
            => ShipmentDateTime = dateTime;

        public void SetClosedDate(DateTime dateTime)
            => ClosedDateTime = dateTime;

        public void SetShipment(Shipment shipment)
            => Shipment = shipment;

        public void SetDiscount(OrderDiscount discount)
            => OrderDiscount = discount;

        public void AddProductOrder(ProductOrder productOrder)
            => productOrders.Add(productOrder);

        public void AddProductOrders(IEnumerable<ProductOrder> productOrderss)
            => this.productOrders.AddRange(productOrderss);
    }
}