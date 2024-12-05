using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zohocrm3._0.Models;

namespace zohocrm3._0.Repositories
{
    public interface IInvoiceRepository
    {
        Task<List<Invoice>> GetAllInvoiceAsync();
        Task<Invoice> GetByIdInvoiceAsync(int id);
        Task<Invoice> CreateInvoiceAsync(Invoice invoice);
        Task<Invoice> UpdateInvoiceAsync(int id, Invoice invoice);
        Task<Invoice> DeleteInvoiceAsync(int id);
    }
}