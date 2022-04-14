using System;
using System.Collections.Generic;
using TradeMarket.Product.Core.Domain.Entities;

namespace TradeMarket.Product.sakila
{
    public partial class Rarity : BaseEntity<int>
    {
        public Rarity()
        {
            Items = new HashSet<Item>();
        }

      
        public string Rarity1 { get; set; }

        public virtual ICollection<Item> Items { get; set; }
        public override string ToString()
        {
            return $"Rarity: Id:{this.Id} | Rarity:{this.Rarity1}";
        }
    }
}
