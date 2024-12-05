using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using zohocrm3._0.Data;
using zohocrm3._0.Models;

namespace zohocrm3._0.Repositories
{
    public class DealRepository : IDealRepository
    {
        private readonly ZohoDbContext zohoDbContext;

        public DealRepository(ZohoDbContext zohoDbContext)
        {
            this.zohoDbContext = zohoDbContext;
        }
        public async Task<Deal> CreateDealAsync(Deal deal)
        {
            await zohoDbContext.Deals.AddAsync(deal);
            await zohoDbContext.SaveChangesAsync();
            return deal;
        }
        public async Task<Deal> DeleteDealAsync(int id)
        {
            var DeleteDeal = await zohoDbContext.Deals.FirstOrDefaultAsync(x => x.Id == id);
            if (DeleteDeal == null)
            {
                return null;
            }
            zohoDbContext.Deals.Remove(DeleteDeal);
            await zohoDbContext.SaveChangesAsync();
            return DeleteDeal;
        }

        public async Task<List<Deal>> GetAllDealAsync()
        {
            return await zohoDbContext.Deals.ToListAsync();
        }

        public async Task<Deal> GetByIdDealAsync(int id)
        {
            return await zohoDbContext.Deals.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Deal> UpdateDealAsync(int id, Deal deal)
        {
            var updateDeal = await zohoDbContext.Deals.FirstOrDefaultAsync(x => x.Id ==  id);
            if (updateDeal == null)
            {
                return null;
            }

            updateDeal.Account = updateDeal.Account;
            updateDeal.AccountId = updateDeal.AccountId;
            updateDeal.CreatedBy = updateDeal.CreatedBy;
            updateDeal.CreatedDate = updateDeal.CreatedDate;
            updateDeal.DealAmount = updateDeal.DealAmount;
            updateDeal.DealEndDate = updateDeal.DealEndDate;
            updateDeal.DealName = updateDeal.DealName;
            updateDeal.DealStartDate = updateDeal.DealStartDate;
            updateDeal.Description = updateDeal.Description;
            updateDeal.LastUpdatedDate = updateDeal.LastUpdatedDate;
            updateDeal.Status = updateDeal.Status;

            await zohoDbContext.SaveChangesAsync();
            return updateDeal;
        }
    }
}