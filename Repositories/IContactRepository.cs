using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zohocrm3._0.Models;

namespace zohocrm3._0.Repositories
{
    public interface IContactRepository
    {
        Task<List<Contact>> GetAllContactAsync();
        Task<Contact> GetByIdContactAsync(int id);
        Task<Contact> CreateContactAsync(Contact contact);
        Task<Contact> UpdateContactAsync(int id, Contact contact);
        Task<Contact> DeleteContactAsync(int id);
    }
}