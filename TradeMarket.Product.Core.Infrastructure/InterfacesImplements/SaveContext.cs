using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeMarket.Product.sakila;

namespace TradeMarket.Product.Core.Infrastructure.InterfacesImplements
{
    public abstract class SaveContext
    {
        private iteminfoContext _context;

        protected SaveContext(iteminfoContext context)
        {
            _context = context;
        } 

        public virtual bool SaveChanges()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                Log.Error(ex.Message);
                return false;
            }

            return true;
        }

        public async virtual Task<bool> SaveChangesAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                Log.Error(ex.Message);
                    return false;
            }
            
            return true;
        }

    }
}
