using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zohocrm3._0.Models;

namespace zohocrm3._0.Repositories
{
    public interface IApptaskRepository
    {
        Task<List<Apptask>> GetAllApptaskAsync();
        Task<Apptask> GetApptaskByIdAsync(int id);
        Task<Apptask> CreateApptaskAsync(Apptask apptask);
        Task<Apptask> UpdateApptaskAsync(int id , Apptask apptask);
        Task<Apptask> DeleteApptaskAsync(int id);
    }
}