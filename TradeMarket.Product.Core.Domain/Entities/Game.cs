using System;
using System.Collections.Generic;
using TradeMarket.Product.Core.Domain.Entities;

namespace TradeMarket.Product.sakila
{
    public partial class Game: BaseEntity<int>
    {
        public Game()
        {
            Items = new HashSet<Item>();
        }

        
        public string? Game1 { get; set; }

        public virtual ICollection<Item> Items { get; set; }
        public override string ToString()
        {
            return $"Game: Id:{this.Id}|Character:{this.Game1}";
        }
    }
}
