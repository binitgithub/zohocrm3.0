using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using zohocrm3._0.Data;
using zohocrm3._0.Models;

namespace zohocrm3._0.Repositories
{
    public class QuoteRepository : IQuoteRepository
    {
        private readonly ZohoDbContext zohoDbContext;

        public QuoteRepository(ZohoDbContext zohoDbContext)
        {
            this.zohoDbContext = zohoDbContext;
        }
        public async Task<Quote> CreateQuoteAsync(Quote quote)
        {
            await zohoDbContext.Quotes.AddAsync(quote);
            await zohoDbContext.SaveChangesAsync();
            return quote;
        }

        public async Task<Quote> DeleteQuoteAsync(int id)
        {
            var deleteQuote = await zohoDbContext.Quotes.FirstOrDefaultAsync(x => x.Id == id);
            if (deleteQuote == null)
            {
                return null;
            }

            zohoDbContext.Quotes.Remove(deleteQuote);
            await zohoDbContext.SaveChangesAsync();
            return deleteQuote;
        }

        public async Task<List<Quote>> GetAllQuoteAsync()
        {
            return await zohoDbContext.Quotes.ToListAsync();
        }

        public async Task<Quote> GetByIdQuoteAsync(int id)
        {
            return await zohoDbContext.Quotes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Quote> UpdateQuoteAsync(int id, Quote quote)
        {
            var updateQuote = await zohoDbContext.Quotes.FirstOrDefaultAsync(x => x.Id == id);
            if (updateQuote == null)
            {
                return null;
            }

            updateQuote.CreatedDate = quote.CreatedDate;
            updateQuote.CustomerId = quote.CustomerId;
            updateQuote.ExpiryDate = quote.ExpiryDate;
            updateQuote.IsConvertedToOrder = quote.IsConvertedToOrder;
            updateQuote.IssueDate = quote.IssueDate;
            updateQuote.LastUpdatedDate = quote.LastUpdatedDate;
            updateQuote.QuoteDescription = quote.QuoteDescription;
            updateQuote.SalesRepId = quote.SalesRepId;
            updateQuote.Status = quote.Status;
            updateQuote.TermsAndConditions = quote.TermsAndConditions;
            updateQuote.TotalAmount = quote.TotalAmount;

            await zohoDbContext.SaveChangesAsync();
            return updateQuote;
        }
    }
}