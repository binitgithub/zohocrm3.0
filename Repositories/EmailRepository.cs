using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using zohocrm3._0.Data;
using zohocrm3._0.Models;

namespace zohocrm3._0.Repositories
{
    public class EmailRepository : IEmailRepository
    {
        private readonly ZohoDbContext zohoDbContext;

        public EmailRepository(ZohoDbContext zohoDbContext)
        {
            this.zohoDbContext = zohoDbContext;
        }
        public async Task<Email> CreateEmailAsync(Email email)
        {
            await zohoDbContext.Emails.AddAsync(email);
            await zohoDbContext.SaveChangesAsync();
            return email;

        }

        public async Task<Email> DeleteEmailAsync(int id)
        {
            var DeleteEmails = await zohoDbContext.Emails.FirstOrDefaultAsync(x => x.Id == id);
            if (DeleteEmails == null)
            {
                return null;
            }

            zohoDbContext.Emails.Remove(DeleteEmails);
            await zohoDbContext.SaveChangesAsync();
            return DeleteEmails;
        }

        public async Task<List<Email>> GetAllEmailAsync()
        {
            return await zohoDbContext.Emails.ToListAsync();
        }

        public async Task<Email> GetByIdEmailAsync(int id)
        {
            return await zohoDbContext.Emails.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Email> UpdateEmailAsync(int id, Email email)
        {
            var UpdateEmails = await zohoDbContext.Emails.FirstOrDefaultAsync(x => x.Id == id);
            
            if (UpdateEmails == null)
            {
                return null;
            }
            UpdateEmails.AttachmentUrls = email.AttachmentUrls;
            UpdateEmails.Bcc = email.Bcc;
            UpdateEmails.Body = email.Body;
            UpdateEmails.Cc = email.Cc;
            UpdateEmails.CreatedDate = email.CreatedDate;
            UpdateEmails.From = email.From;
            UpdateEmails.IsArchived = email.IsArchived;
            UpdateEmails.IsRead = email.IsRead;
            UpdateEmails.LastUpdatedDate = email.LastUpdatedDate;
            UpdateEmails.SentDate = email.SentDate;
            UpdateEmails.Subject = email.Subject;
            UpdateEmails.To = email.To;

            await zohoDbContext.SaveChangesAsync();
            return UpdateEmails;
        }
    }
}