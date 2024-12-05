using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using zohocrm3._0.Data;
using zohocrm3._0.Models;

namespace zohocrm3._0.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly ZohoDbContext zohoDbContext;

        public InvoiceRepository(ZohoDbContext zohoDbContext)
        {
            this.zohoDbContext = zohoDbContext;
        }
        public async Task<Invoice> CreateInvoiceAsync(Invoice invoice)
        {
            await zohoDbContext.Invoices.AddAsync(invoice);
            await zohoDbContext.SaveChangesAsync();
            return invoice;
        }

        public async Task<Invoice> DeleteInvoiceAsync(int id)
        {
            var deleteInvoice = await zohoDbContext.Invoices.FirstOrDefaultAsync(x => x.Id == id);
            if (deleteInvoice == null)
            {
                return null;
            }
            zohoDbContext.Invoices.Remove(deleteInvoice);
            await zohoDbContext.SaveChangesAsync();
            return deleteInvoice;
        }

        public async Task<List<Invoice>> GetAllInvoiceAsync()
        {
            return await zohoDbContext.Invoices.ToListAsync();
        }

        public async Task<Invoice> GetByIdInvoiceAsync(int id)
        {
            return await zohoDbContext.Invoices.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Invoice> UpdateInvoiceAsync(int id, Invoice invoice)
        {
            var updateInvoice = await zohoDbContext.Invoices.FirstOrDefaultAsync(x => x.Id == id);
            if (updateInvoice == null)
            {
                return null;
            }
            updateInvoice.AmountDue = invoice.AmountDue;
            updateInvoice.AmountPaid = invoice.AmountPaid;
            updateInvoice.CreatedDate = invoice.CreatedDate;
            updateInvoice.CustomerId = invoice.CustomerId;
            updateInvoice.Description = invoice.Description;
            updateInvoice.DueDate = invoice.DueDate;
            updateInvoice.IsArchived = invoice.IsArchived;
            updateInvoice.IssueDate = invoice.IssueDate;
            updateInvoice.LastUpdatedDate = invoice.LastUpdatedDate;
            updateInvoice.SalesRepId = invoice.SalesRepId;
            updateInvoice.Status = updateInvoice.Status;
            updateInvoice.TermsAndConditions = invoice.TermsAndConditions;
            updateInvoice.TotalAmount = invoice.TotalAmount;

            await zohoDbContext.SaveChangesAsync();
            return updateInvoice;
        }
    }
}