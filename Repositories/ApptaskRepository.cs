using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using zohocrm3._0.Data;
using zohocrm3._0.Models;

namespace zohocrm3._0.Repositories
{
    public class ApptaskRepository : IApptaskRepository
    {
        private readonly ZohoDbContext zohoDbContext;

        public ApptaskRepository(ZohoDbContext zohoDbContext)
        {
            this.zohoDbContext = zohoDbContext;
        }
        public async Task<Apptask> CreateApptaskAsync(Apptask apptask)
        {
            await zohoDbContext.Tasks.AddAsync(apptask);
            await zohoDbContext.SaveChangesAsync();
            return apptask;
        }

        public async Task<Apptask> DeleteApptaskAsync(int id)
        {
            var apptaskDelete = await zohoDbContext.Tasks.FirstOrDefaultAsync(x => x.Id == id);
            if (apptaskDelete == null)
            {
                return null;
            }

             zohoDbContext.Tasks.Remove(apptaskDelete);
             await zohoDbContext.SaveChangesAsync();
             return apptaskDelete;
             
        }

        public async Task<List<Apptask>> GetAllApptaskAsync()
        {
            return await zohoDbContext.Tasks.ToListAsync();
        }

        public async Task<Apptask> GetApptaskByIdAsync(int id)
        {
            return await zohoDbContext.Tasks.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Apptask> UpdateApptaskAsync(int id, Apptask apptask)
        {
            var updateTask = await zohoDbContext.Tasks.FirstOrDefaultAsync(x => x.Id == id);
            if (updateTask == null)
            {
                return null;
            }
            updateTask.AssignedToUserId = apptask.AssignedToUserId;
            updateTask.CompletedDate = apptask.CompletedDate;
            updateTask.CreatedDate = apptask.CreatedDate;
            updateTask.Description = apptask.Description;
            updateTask.DueDate = apptask.DueDate;
            updateTask.Priority = apptask.Priority;
            updateTask.IsArchived = apptask.IsArchived;
            updateTask.Status = apptask.Status;

            await zohoDbContext.SaveChangesAsync();
            return updateTask;

        }
    }
}