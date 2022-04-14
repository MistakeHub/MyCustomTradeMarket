using System;
using System.Collections.Generic;
using TradeMarket.Product.Core.Domain.Entities;

namespace TradeMarket.Product.sakila
{
    public partial class Character:BaseEntity<int>
    {
        public Character()
        {
            Items = new HashSet<Item>();
        }

     
        public string Character1 { get; set; } = null!;

        public virtual ICollection<Item> Items { get; set; }

        public override string ToString()
        {
            return $"Character: Id:{this.Id}|Character:{this.Character1}";
        }
    }
}
