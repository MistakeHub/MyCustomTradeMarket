using System;
using System.Collections.Generic;
using TradeMarket.Product.Core.Domain.Entities;

namespace TradeMarket.Product.sakila
{
    public partial class Slot : BaseEntity<int>
    {
        public Slot()
        {
            Items = new HashSet<Item>();
        }

       
        public string Slot1 { get; set; }

        public virtual ICollection<Item> Items { get; set; }
        public override string ToString()
        {
            return $"Slot: Id:{this.Id}| Slot:{this.Slot1}";
        }
    }
}
