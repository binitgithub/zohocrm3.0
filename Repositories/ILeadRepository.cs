using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zohocrm3._0.Models;

namespace zohocrm3._0.Repositories
{
    public interface ILeadRepository
    {
        Task<List<Lead>> GetAllLeadAsync();
        Task<Lead> GetByIdLeadAsync(int id);
        Task<Lead> CreateLeadAsync(Lead lead);
        Task<Lead> UpdateLeadAsync(int id, Lead lead);
        Task<Lead> DeleteLeadAsync(int id);
    }
}