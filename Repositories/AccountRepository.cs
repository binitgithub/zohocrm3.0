using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using zohocrm3._0.Data;
using zohocrm3._0.Models;

namespace zohocrm3._0.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ZohoDbContext zohoDbContext;

        public AccountRepository(ZohoDbContext zohoDbContext)
        {
            this.zohoDbContext = zohoDbContext;
        }
        public async Task<Account> CreateAccountAsync(Account account)
        {
            await zohoDbContext.Accounts.AddAsync(account);
            await zohoDbContext.SaveChangesAsync();
            return account;
        }

        public async Task<Account> DeleteAccountAsync(int id)
        {
            var deleteAccount = await zohoDbContext.Accounts.FirstOrDefaultAsync(x => x.Id == id);
            if (deleteAccount == null)
            {
                return null;
            }
            zohoDbContext.Accounts.Remove(deleteAccount);
            await zohoDbContext.SaveChangesAsync();
            return deleteAccount;
        }

        public async Task<Account> GetAccountByIdAsync(int id)
        {
            return await zohoDbContext.Accounts.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Account>> GetAllAccountAsync()
        {
            return await zohoDbContext.Accounts.ToListAsync();
        }

        public async Task<Account> UpdateAccountAsync(int id, Account account)
        {
            var updateAccount = await zohoDbContext.Accounts.FirstOrDefaultAsync(x => x.Id == id);
            if (updateAccount == null)
            {
                return null;
            }
            
            updateAccount.AccountName = account.AccountName;
            updateAccount.AccountNumber = account.AccountNumber;
            updateAccount.AccountType = account.AccountType;
            updateAccount.Balance = account.Balance;
            updateAccount.CreatedDate = account.CreatedDate;
            updateAccount.Currency = account.Currency;
            updateAccount.IsActive = account.IsActive;
            updateAccount.LastUpdatedDate = account.LastUpdatedDate;

            await zohoDbContext.SaveChangesAsync();
            return updateAccount;
        }
    }
}