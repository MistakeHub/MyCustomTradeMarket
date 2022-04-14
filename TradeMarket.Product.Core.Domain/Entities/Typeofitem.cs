using System;
using System.Collections.Generic;
using TradeMarket.Product.Core.Domain.Entities;

namespace TradeMarket.Product.sakila
{
    public partial class Typeofitem : BaseEntity<int>
    {
        public Typeofitem()
        {
            Items = new HashSet<Item>();
        }

       
        public string Type1 { get; set; }

        public virtual ICollection<Item> Items { get; set; }
        public override string ToString()
        {
            return $"Id:{this.Id} | Character:{this.Type1}";
        }
    }
}
