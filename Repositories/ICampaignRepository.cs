using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zohocrm3._0.Models;

namespace zohocrm3._0.Repositories
{
    public interface ICampaignRepository
    {
        Task<List<Campaign>> GetAllCampaignAsync();
        Task<Campaign> GetByIdCampaignAsync(int id);
        Task<Campaign> CreateCampaignAsync(Campaign campaign);
        Task<Campaign> UpdateCampaignAsync(int id, Campaign campaign);
        Task<Campaign> DeleteCampaignAsync(int id);
    }
}