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
    public class BaseAsyncRepository<T>:SaveContext,IAsyncRepository<T> where T : BaseEntity<int>
    {
        private DbSet<T> _context;
       
       
        public BaseAsyncRepository(iteminfoContext context):base(context)
        {
            _context = context.Set<T>();
       }

        public async Task<bool> AddAsync(T entity)
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

        public async Task<List<T>> GetAllAsync()
        {
                return await Task<T>.FromResult (_context.AsNoTracking().ToList());
        }

        public async Task<List<T>> GetByExpressionAsync(Func<T,bool> expression)
        {
           return await Task<T>.FromResult(_context.AsNoTracking().Where(expression).ToList());
        }

        public async Task<T> GetByIdAsync(int id)
        {
          
                var entity = _context.AsNoTracking().FirstOrDefault(d => d.Id == id);

            Log.Information($"Get Entity type {typeof(T)} with id:{id}");
            return entity;
        }

        public async Task<bool> RemoveAsync(int Id)
        {
            try
            {
                var Entity = _context.FirstOrDefault(d => d.Id == Id);
                Entity.IsDeleted = true;

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

        public async Task<bool> UpdateAsync(T Entity)
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

        public async Task<bool> RemoveRangeAsync(int[] id)
        {
           

            try
            {
                var entities = _context.Where(d => id.Equals(d.Id)).ToList();
                entities.ForEach(c => c.IsDeleted = true);
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
