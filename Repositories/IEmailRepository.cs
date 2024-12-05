using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zohocrm3._0.Models;

namespace zohocrm3._0.Repositories
{
    public interface IEmailRepository
    {
        Task<List<Email>> GetAllEmailAsync();
        Task<Email> GetByIdEmailAsync(int id);
        Task<Email> CreateEmailAsync(Email email);
        Task<Email> UpdateEmailAsync(int id, Email email);
        Task<Email> DeleteEmailAsync(int id);
    }
}