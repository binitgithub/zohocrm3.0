using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using zohocrm3._0.Data;
using zohocrm3._0.Models;

namespace zohocrm3._0.Repositories
{
    public class LeadRepository : ILeadRepository
    {
        private readonly ZohoDbContext zohoDbContext;

        public LeadRepository(ZohoDbContext zohoDbContext)
        {
            this.zohoDbContext = zohoDbContext;
        }
        public async Task<Lead> CreateLeadAsync(Lead lead)
        {
            await zohoDbContext.Leads.AddAsync(lead);
            await zohoDbContext.SaveChangesAsync();
            return lead;
        }

        public async Task<Lead> DeleteLeadAsync(int id)
        {
            var DeleteLead = await zohoDbContext.Leads.FirstOrDefaultAsync(x => x.Id == id);
            if (DeleteLead == null)
            {
                return null;
            }
            zohoDbContext.Leads.Remove(DeleteLead);
            await zohoDbContext.SaveChangesAsync();
            return DeleteLead;
        }

        public async Task<List<Lead>> GetAllLeadAsync()
        {
            return await zohoDbContext.Leads.ToListAsync();
        }

        public async Task<Lead> GetByIdLeadAsync(int id)
        {
            return await zohoDbContext.Leads.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Lead> UpdateLeadAsync(int id, Lead lead)
        {
            var updateLeads = await zohoDbContext.Leads.FirstOrDefaultAsync(x => x.Id == id);
            if (updateLeads == null)
            {
                return null;
            }

            updateLeads.FirstName = lead.FirstName;
            updateLeads.LastName = lead.LastName;
            updateLeads.Mail = lead.Mail;
            updateLeads.PhoneNumber = lead.PhoneNumber;
            updateLeads.Company = lead.Company;
            updateLeads.Notes = lead.Notes;
            updateLeads.CreatedDate = lead.CreatedDate;
            updateLeads.LastContactDate = lead.LastContactDate;
            updateLeads.IsQualified = lead.IsQualified;

            await zohoDbContext.SaveChangesAsync();
            return updateLeads;
        }
    }
}