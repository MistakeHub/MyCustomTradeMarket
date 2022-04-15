using AutoMapper;
using TradeMarket.Product.sakila;

namespace TradeMarket.Product.ViewModels.Mappers
{
    public class AutoMappers:Profile
    {
        public AutoMappers()
        {
            CreateMap<Productitem, ProductViewModel>().
                ForMember(d => d.Id, opt => opt.MapFrom(v => v.Id)).
                ForMember(d => d.Quality, opt => opt.MapFrom(v => v.IditemNavigation.IdqualityNavigation.Quality1)).
                ForMember(d => d.Rarity, opt => opt.MapFrom(v => v.IditemNavigation.IdrarityNavigation.Rarity1)).
                ForMember(d => d.Price, opt => opt.MapFrom(v => v.Price)).
                ForMember(d => d.Slot, opt => opt.MapFrom(v => v.IditemNavigation.IdslotNavigation.Slot1)).
                ForMember(d => d.Name, opt => opt.MapFrom(v => v.IditemNavigation.Name)).
                ForMember(d => d.Character, opt => opt.MapFrom(v => v.IditemNavigation.IdcharacterNavigation.Character1)).
                ForMember(d => d.Game, opt => opt.MapFrom(v => v.IditemNavigation.IdgameNavigation.Game1)).
                ForMember(d => d.Typeofitem, opt => opt.MapFrom(v => v.IditemNavigation.IdtypeNavigation.Type1));

        }

    }
}
