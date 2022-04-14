using TradeMarket.Product.Core.Domain.Interfaces;
using TradeMarket.Product.Core.Infrastructure.InterfacesImplements;
using TradeMarket.Product.sakila;

namespace TradeMarket.Product.ServicesReigster
{
    public static class RepositoryServicesRegister
    {
        public static void AddRepositoryServices(this IServiceCollection services)
        {
            services.AddTransient<IAsyncRepository<Game>, BaseAsyncRepository<Game>>();
            services.AddTransient<IAsyncRepository<Character>, BaseAsyncRepository<Character>>();
            services.AddTransient<IAsyncRepository<Quality>, BaseAsyncRepository<Quality>>();
            services.AddTransient<IAsyncRepository<Slot>, BaseAsyncRepository<Slot>>();
            services.AddTransient<IAsyncRepository<Rarity>, BaseAsyncRepository<Rarity>>();
            services.AddTransient<IAsyncRepository<Typeofitem>, BaseAsyncRepository<Typeofitem>>();
            services.AddTransient<IAsyncRepository<Item>, BaseAsyncRepository<Item>>();
            services.AddTransient<IAsyncRepository<Productitem>, BaseAsyncRepository<Productitem>>();

            services.AddTransient<IBaseRepository<Game>, BaseRepository<Game>>();
            services.AddTransient<IBaseRepository<Character>, BaseRepository<Character>>();
            services.AddTransient<IBaseRepository<Quality>, BaseRepository<Quality>>();
            services.AddTransient<IBaseRepository<Slot>, BaseRepository<Slot>>();
            services.AddTransient<IBaseRepository<Rarity>, BaseRepository<Rarity>>();
            services.AddTransient<IBaseRepository<Typeofitem>, BaseRepository<Typeofitem>>();
            services.AddTransient<IBaseRepository<Item>, BaseRepository<Item>>();
            services.AddTransient<IBaseRepository<Productitem>, BaseRepository<Productitem>>();

        }
    }
}
