using MediatR;
using TradeMarket.Product.Commands.GameCommands;
using TradeMarket.Product.sakila;

namespace TradeMarket.Product.ServicesReigster
{
    public static class MediatrServicesRegister
    {
        public static void AddMediatServices(this IServiceCollection services)
        {
            services.AddTransient<IRequestHandler<BaseAdd.Command<Character>,bool>, BaseAdd.Command<Character>.CommandHandler>();
            services.AddTransient<IRequestHandler<BaseGet.Query<Character>, Character>, BaseGet.Query<Character>.QueryHandler>();
            services.AddTransient<IRequestHandler<BaseGetAll.Query<Character>, List<Character>>, BaseGetAll.Query<Character>.QueryHandler>();
            services.AddTransient<IRequestHandler<BaseGetAllByExpression.Query<Character>, List<Character>>, BaseGetAllByExpression.Query<Character>.QueryHandler>();
            services.AddTransient<IRequestHandler<BaseRemove.Command<Character>, bool>, BaseRemove.Command<Character>.CommandHandler>();
            services.AddTransient<IRequestHandler<BaseRemoveRange.Command<Character>, bool>, BaseRemoveRange.Command<Character>.CommandHandler>();
            services.AddTransient<IRequestHandler<BaseUpdate.Command<Character>, bool>, BaseUpdate.Command<Character>.CommandHandler>();

            services.AddTransient<IRequestHandler<BaseAdd.Command<Game>, bool>, BaseAdd.Command<Game>.CommandHandler>();
            services.AddTransient<IRequestHandler<BaseGet.Query<Game>, Game>, BaseGet.Query<Game>.QueryHandler>();
            services.AddTransient<IRequestHandler<BaseGetAll.Query<Game>, List<Game>>, BaseGetAll.Query<Game>.QueryHandler>();
            services.AddTransient<IRequestHandler<BaseGetAllByExpression.Query<Game>, List<Game>>, BaseGetAllByExpression.Query<Game>.QueryHandler>();
            services.AddTransient<IRequestHandler<BaseRemove.Command<Game>, bool>, BaseRemove.Command<Game>.CommandHandler>();
            services.AddTransient<IRequestHandler<BaseRemoveRange.Command<Game>, bool>, BaseRemoveRange.Command<Game>.CommandHandler>();
            services.AddTransient<IRequestHandler<BaseUpdate.Command<Game>, bool>, BaseUpdate.Command<Game>.CommandHandler>();

            services.AddTransient<IRequestHandler<BaseAdd.Command<Item>, bool>, BaseAdd.Command<Item>.CommandHandler>();
            services.AddTransient<IRequestHandler<BaseGet.Query<Item>, Item>, BaseGet.Query<Item>.QueryHandler>();
            services.AddTransient<IRequestHandler<BaseGetAll.Query<Item>, List<Item>>, BaseGetAll.Query<Item>.QueryHandler>();
            services.AddTransient<IRequestHandler<BaseGetAllByExpression.Query<Item>, List<Item>>, BaseGetAllByExpression.Query<Item>.QueryHandler>();
            services.AddTransient<IRequestHandler<BaseRemove.Command<Item>, bool>, BaseRemove.Command<Item>.CommandHandler>();
            services.AddTransient<IRequestHandler<BaseRemoveRange.Command<Item>, bool>, BaseRemoveRange.Command<Item>.CommandHandler>();
            services.AddTransient<IRequestHandler<BaseUpdate.Command<Item>, bool>, BaseUpdate.Command<Item>.CommandHandler>();

            services.AddTransient<IRequestHandler<BaseAdd.Command<Productitem>, bool>, BaseAdd.Command<Productitem>.CommandHandler>();
            services.AddTransient<IRequestHandler<BaseGet.Query<Productitem>, Productitem>, BaseGet.Query<Productitem>.QueryHandler>();
            services.AddTransient<IRequestHandler<BaseGetAll.Query<Productitem>, List<Productitem>>, BaseGetAll.Query<Productitem>.QueryHandler>();
            services.AddTransient<IRequestHandler<BaseGetAllByExpression.Query<Productitem>, List<Productitem>>, BaseGetAllByExpression.Query<Productitem>.QueryHandler>();
            services.AddTransient<IRequestHandler<BaseRemove.Command<Productitem>, bool>, BaseRemove.Command<Productitem>.CommandHandler>();
            services.AddTransient<IRequestHandler<BaseRemoveRange.Command<Productitem>, bool>, BaseRemoveRange.Command<Productitem>.CommandHandler>();
            services.AddTransient<IRequestHandler<BaseUpdate.Command<Productitem>, bool>, BaseUpdate.Command<Productitem>.CommandHandler>();

            services.AddTransient<IRequestHandler<BaseAdd.Command<Quality>, bool>, BaseAdd.Command<Quality>.CommandHandler>();
            services.AddTransient<IRequestHandler<BaseGet.Query<Quality>, Quality>, BaseGet.Query<Quality>.QueryHandler>();
            services.AddTransient<IRequestHandler<BaseGetAll.Query<Quality>, List<Quality>>, BaseGetAll.Query<Quality>.QueryHandler>();
            services.AddTransient<IRequestHandler<BaseGetAllByExpression.Query<Quality>, List<Quality>>, BaseGetAllByExpression.Query<Quality>.QueryHandler>();
            services.AddTransient<IRequestHandler<BaseRemove.Command<Quality>, bool>, BaseRemove.Command<Quality>.CommandHandler>();
            services.AddTransient<IRequestHandler<BaseRemoveRange.Command<Quality>, bool>, BaseRemoveRange.Command<Quality>.CommandHandler>();
            services.AddTransient<IRequestHandler<BaseUpdate.Command<Quality>, bool>, BaseUpdate.Command<Quality>.CommandHandler>();

            services.AddTransient<IRequestHandler<BaseAdd.Command<Rarity>, bool>, BaseAdd.Command<Rarity>.CommandHandler>();
            services.AddTransient<IRequestHandler<BaseGet.Query<Rarity>, Rarity>, BaseGet.Query<Rarity>.QueryHandler>();
            services.AddTransient<IRequestHandler<BaseGetAll.Query<Rarity>, List<Rarity>>, BaseGetAll.Query<Rarity>.QueryHandler>();
            services.AddTransient<IRequestHandler<BaseGetAllByExpression.Query<Rarity>, List<Rarity>>, BaseGetAllByExpression.Query<Rarity>.QueryHandler>();
            services.AddTransient<IRequestHandler<BaseRemove.Command<Rarity>, bool>, BaseRemove.Command<Rarity>.CommandHandler>();
            services.AddTransient<IRequestHandler<BaseRemoveRange.Command<Rarity>, bool>, BaseRemoveRange.Command<Rarity>.CommandHandler>();
            services.AddTransient<IRequestHandler<BaseUpdate.Command<Rarity>, bool>, BaseUpdate.Command<Rarity>.CommandHandler>();

            services.AddTransient<IRequestHandler<BaseAdd.Command<Slot>, bool>, BaseAdd.Command<Slot>.CommandHandler>();
            services.AddTransient<IRequestHandler<BaseGet.Query<Slot>, Slot>, BaseGet.Query<Slot>.QueryHandler>();
            services.AddTransient<IRequestHandler<BaseGetAll.Query<Slot>, List<Slot>>, BaseGetAll.Query<Slot>.QueryHandler>();
            services.AddTransient<IRequestHandler<BaseGetAllByExpression.Query<Slot>, List<Slot>>, BaseGetAllByExpression.Query<Slot>.QueryHandler>();
            services.AddTransient<IRequestHandler<BaseRemove.Command<Slot>, bool>, BaseRemove.Command<Slot>.CommandHandler>();
            services.AddTransient<IRequestHandler<BaseRemoveRange.Command<Slot>, bool>, BaseRemoveRange.Command<Slot>.CommandHandler>();
            services.AddTransient<IRequestHandler<BaseUpdate.Command<Slot>, bool>, BaseUpdate.Command<Slot>.CommandHandler>();

            services.AddTransient<IRequestHandler<BaseAdd.Command<Typeofitem>, bool>, BaseAdd.Command<Typeofitem>.CommandHandler>();
            services.AddTransient<IRequestHandler<BaseGet.Query<Typeofitem>, Typeofitem>, BaseGet.Query<Typeofitem>.QueryHandler>();
            services.AddTransient<IRequestHandler<BaseGetAll.Query<Typeofitem>, List<Typeofitem>>, BaseGetAll.Query<Typeofitem>.QueryHandler>();
            services.AddTransient<IRequestHandler<BaseGetAllByExpression.Query<Typeofitem>, List<Typeofitem>>, BaseGetAllByExpression.Query<Typeofitem>.QueryHandler>();
            services.AddTransient<IRequestHandler<BaseRemove.Command<Typeofitem>, bool>, BaseRemove.Command<Typeofitem>.CommandHandler>();
            services.AddTransient<IRequestHandler<BaseRemoveRange.Command<Typeofitem>, bool>, BaseRemoveRange.Command<Typeofitem>.CommandHandler>();
            services.AddTransient<IRequestHandler<BaseUpdate.Command<Typeofitem>, bool>, BaseUpdate.Command<Typeofitem>.CommandHandler>();

          

        }
    }
}
