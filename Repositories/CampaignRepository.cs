using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using zohocrm3._0.Data;
using zohocrm3._0.Models;

namespace zohocrm3._0.Repositories
{
    public class CampaignRepository : ICampaignRepository
    {
        private readonly ZohoDbContext zohoDbContext;

        public CampaignRepository(ZohoDbContext zohoDbContext)
        {
            this.zohoDbContext = zohoDbContext;
        }
        public async Task<Campaign> CreateCampaignAsync(Campaign campaign)
        {
            await zohoDbContext.Campaigns.AddAsync(campaign);
            await zohoDbContext.SaveChangesAsync();
            return campaign;
        }

        public async Task<Campaign> DeleteCampaignAsync(int id)
        {
            var deleteCampain = await zohoDbContext.Campaigns.FirstOrDefaultAsync(x => x.Id == id);
            if (deleteCampain == null)
            {
                return null;
            }
            zohoDbContext.Campaigns.Remove(deleteCampain);
            await zohoDbContext.SaveChangesAsync();
            return deleteCampain;
        }

        public async Task<List<Campaign>> GetAllCampaignAsync()
        {
            return await zohoDbContext.Campaigns.ToListAsync();
        }

        public async Task<Campaign> GetByIdCampaignAsync(int id)
        {
            return await zohoDbContext.Campaigns.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Campaign> UpdateCampaignAsync(int id, Campaign campaign)
        {
            var updateCampaign = await zohoDbContext.Campaigns.FirstOrDefaultAsync(x => x.Id == id);
            if (updateCampaign == null)
            {
                return null;
            }

            updateCampaign.AmountSpent = campaign.AmountSpent;
            updateCampaign.Budget = campaign.Budget;
            updateCampaign.CampaignName = campaign.CampaignName;
            updateCampaign.CreatedDate = campaign.CreatedDate;
            updateCampaign.Description = campaign.Description;
            updateCampaign.EndDate = campaign.EndDate;
            updateCampaign.IsArchived = campaign.IsArchived;
            updateCampaign.LastUpdatedDate = campaign.LastUpdatedDate;

            await zohoDbContext.SaveChangesAsync();
            return updateCampaign;
        }
    }
}