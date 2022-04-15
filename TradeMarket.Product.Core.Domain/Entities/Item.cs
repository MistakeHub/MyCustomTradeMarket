using System;
using System.Collections.Generic;
using TradeMarket.Product.Core.Domain.Entities;

namespace TradeMarket.Product.sakila
{
    public partial class Item:BaseEntity<int>
    {
        public Item()
        {
            Products = new HashSet<Productitem>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Idgame { get; set; }
        public int Idcharacter { get; set; }
        public int Idquality { get; set; }
        public int Idslot { get; set; }
        public int Idtype { get; set; }
        public int Idrarity { get; set; }
        public string Description { get; set; } = null!;
        
        public virtual Character IdcharacterNavigation { get; set; } 
        public virtual Game IdgameNavigation { get; set; } 
        public virtual Quality IdqualityNavigation { get; set; } 
        public virtual Rarity IdrarityNavigation { get; set; } 
        public virtual Slot IdslotNavigation { get; set; } 
        public virtual Typeofitem IdtypeNavigation { get; set; }
        public virtual ICollection<Productitem> Products { get; set; }

        public override string ToString()
        {
            return $"Item: Id:{this.Id} | Name:{this.Name} | Character:{Idcharacter} | Game:{Idgame} | " +
                $"Quality:{Idquality} | Rarity:{Idrarity} | Slot:{IdslotNavigation?.Slot1} | Type:{Idtype}";
        }
    }
}
