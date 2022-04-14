using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Serilog;
using System.Threading.Tasks;
using TradeMarket.Product.Core.Domain.Interfaces;
using TradeMarket.Product.sakila;

using Microsoft.EntityFrameworkCore;
using TradeMarket.Product.Core.Domain.Entities;

namespace TradeMarket.Product.Core.Infrastructure.InterfacesImplements
{
    public class BaseAsyncRepository<T>:SaveContext,IAsyncRepository<T> where T:BaseEntity<int>
    {
        private DbSet<T> _context;
       
       
        public BaseAsyncRepository(iteminfoContext context):base(context)
        {
            _context = context.Set<T>();
       }

        public async Task<bool> Add(T entity)
        {

            try 
            {
                
               await _context.AddAsync(entity);
                await SaveChangesAsync();
                Log.Information($"{entity} has been added");
                
              
            }
            catch (Exception ex)
            {

                Log.Error($"Ошибка:{ex.Message}, {ex.Source}");
                return false;
            }

            return true;
        }

        public async Task<List<T>> GetAll()
        {
                return await Task<T>.FromResult (_context.ToList());
        }

        public async Task<List<T>> GetByExpression(Func<T,bool> expression)
        {
           return await Task<T>.FromResult(_context.Where(expression).ToList());
        }

        public async Task<T> GetById(int id)
        {
          
                var entity = _context.FirstOrDefault(d => d.Id == id);

            Log.Information($"Get Entity type {typeof(T)} with id:{id}");
            return entity;
        }

        public async Task<bool> Remove(int Id)
        {
            try
            {
                var Entity = _context.FirstOrDefault(d => d.Id == Id);
                _context.Remove(Entity);

               await SaveChangesAsync();
                Log.Information($"{Entity} has been removed");
            }
            catch (Exception ex)
            {
                Log.Error($"Ошибка:{ex.Message}, {ex.Source}");

                return true;
            }
            
            return true;
        }

        public async Task<bool> Update(T Entity)
        {
            try
            {
                _context.Update(Entity);
                await SaveChangesAsync();
                Log.Information($"{Entity} has been updated");
            }
            catch (Exception ex)
            {
                Log.Error($"Ошибка:{ex.Message}, {ex.Source}");
                return true;
            }
            return true;
        }

        public async Task<bool> RemoveRange(int[] id)
        {
           

            try
            {
                var entities = _context.Where(d => id.Equals(d.Id)).ToList();
                _context.RemoveRange(entities);
                await SaveChangesAsync();
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
