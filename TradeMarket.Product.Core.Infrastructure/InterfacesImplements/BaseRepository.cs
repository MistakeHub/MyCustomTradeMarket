using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeMarket.Product.Core.Domain.Entities;
using TradeMarket.Product.Core.Domain.Interfaces;
using TradeMarket.Product.sakila;

namespace TradeMarket.Product.Core.Infrastructure.InterfacesImplements
{
    public class BaseRepository<T>:SaveContext,IBaseRepository<T> where T:BaseEntity<int>
    {
        private DbSet<T> _context;


        public BaseRepository(iteminfoContext context) : base(context)
        {
            _context = context.Set<T>();
        }

        public  bool Add(T entity)
        {

            try
            {

                 _context.AddAsync(entity);
                 SaveChanges();
                Log.Information($"{entity} has been added");


            }
            catch (Exception ex)
            {

                Log.Error($"Ошибка:{ex.Message}, {ex.Source}");
                return false;
            }

            return true;
        }

        public  List<T> GetAll()
        {
            return  _context.ToList();
        }

        public List<T> GetByExpression(Func<T, bool> expression)
        {
            return _context.Where(expression).ToList();
        }

        public T GetById(int id)
        {

            var entity = _context.FirstOrDefault(d => d.Id == id);

            Log.Information($"Get Entity type {typeof(T)} with id:{id}");
            return entity;
        }

        public bool Remove(int Id)
        {
            try
            {
                var Entity = _context.FirstOrDefault(d => d.Id == Id);
                Entity.IsDeleted = true;

                SaveChanges();
                Log.Information($"{Entity} has been removed");
            }
            catch (Exception ex)
            {
                Log.Error($"Ошибка:{ex.Message}, {ex.Source}");

                return true;
            }

            return true;
        }

        public bool Update(T Entity)
        {
            try
            {
                _context.Update(Entity);
                 SaveChanges();
                Log.Information($"{Entity} has been updated");
            }
            catch (Exception ex)
            {
                Log.Error($"Ошибка:{ex.Message}, {ex.Source}");
                return true;
            }
            return true;
        }

        public bool RemoveRange(int[] id)
        {


            try
            {
                var entities = _context.Where(d => id.Equals(d.Id)).ToList();
                entities.ForEach(c => c.IsDeleted = true);
                SaveChanges();
                Log.Information($" {typeof(T)}: {entities.Count()} entities has been removed");
            }
            catch (Exception ex)
            {
                Log.Error($"Ошибка:{ex.Message}, {ex.Source}");

                return true;
            }
            return true;
        }
    }
}
