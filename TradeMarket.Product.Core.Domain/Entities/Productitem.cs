using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using TradeMarket.Product.Core.Domain.Entities;

namespace TradeMarket.Product.sakila
{
    [Table("Product")]
    public partial class Productitem : BaseEntity<int>
    {
        public int Id { get; set; }
        public int Iditem { get; set; }
        public float Price { get; set; }
        public int Iduser { get; set; }

        public virtual Item IditemNavigation { get; set; }

        public override string ToString()
        {
            return $"Productitem: Id:{this.Id} | item:{this.Iditem} | price:{Price}";
        }
    }
}
