using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zohocrm3._0.Models;

namespace zohocrm3._0.Repositories
{
    public interface IQuoteRepository
    {
        Task<List<Quote>> GetAllQuoteAsync();
        Task<Quote> GetByIdQuoteAsync(int id);
        Task<Quote> CreateQuoteAsync(Quote quote);
        Task<Quote> UpdateQuoteAsync(int id, Quote quote);
        Task<Quote> DeleteQuoteAsync(int id);
    }
}