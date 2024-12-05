using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using zohocrm3._0.Data;
using zohocrm3._0.Models;

namespace zohocrm3._0.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly ZohoDbContext zohoDbContext;

        public ContactRepository(ZohoDbContext zohoDbContext)
        {
            this.zohoDbContext = zohoDbContext;
        }
        public async Task<Contact> CreateContactAsync(Contact contact)
        {
            await zohoDbContext.Contacts.AddAsync(contact);
            await zohoDbContext.SaveChangesAsync();
            return contact;
        }

        public async Task<Contact> DeleteContactAsync(int id)
        {
            var deleteContact = await zohoDbContext.Contacts.FirstOrDefaultAsync(x => x.Id == id);
            if (deleteContact == null)
            {
                return null;
            }

            zohoDbContext.Contacts.Remove(deleteContact);
            await zohoDbContext.SaveChangesAsync();
            return deleteContact;
        }

        public async Task<List<Contact>> GetAllContactAsync()
        {
            return await zohoDbContext.Contacts.ToListAsync();
        }

        public async Task<Contact> GetByIdContactAsync(int id)
        {
            return await zohoDbContext.Contacts.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Contact> UpdateContactAsync(int id, Contact contact)
        {
            var updateContact = await zohoDbContext.Contacts.FirstOrDefaultAsync(x => x.Id == id);
            if (updateContact == null)
            {
                return null;
            }
            updateContact.Address = contact.Address;
            updateContact.City = contact.City;
            updateContact.Country = contact.Country;
            updateContact.CreatedDate = contact.CreatedDate;
            updateContact.Email = contact.Email;
            updateContact.LastName = contact.LastName;
            updateContact.FirstName = contact.FirstName;
            updateContact.LastUpdatedDate = contact.LastUpdatedDate;
            updateContact.Notes = contact.Notes;
            updateContact.PhoneNumber = contact.PhoneNumber;
            updateContact.State = contact.State;

            await zohoDbContext.SaveChangesAsync();
            return updateContact;
        }
    }
}