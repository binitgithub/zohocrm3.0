using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zohocrm3._0.Models;

namespace zohocrm3._0.Repositories
{
    public interface IDealRepository
    {
        Task<List<Deal>> GetAllDealAsync();
        Task<Deal> GetByIdDealAsync(int id);
        Task<Deal> CreateDealAsync(Deal deal);
        Task<Deal> UpdateDealAsync(int id ,Deal deal);
        Task<Deal> DeleteDealAsync(int id);
    }
}