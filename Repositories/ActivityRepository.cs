using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using zohocrm3._0.Data;
using zohocrm3._0.Models;

namespace zohocrm3._0.Repositories
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly ZohoDbContext zohoDbContext;

        public ActivityRepository(ZohoDbContext zohoDbContext)
        {
            this.zohoDbContext = zohoDbContext;
        }
        public async Task<Activity> CreateActivityAsync(Activity activity)
        {
            await zohoDbContext.Activities.AddAsync(activity);
            await zohoDbContext.SaveChangesAsync();
            return activity;
        }

        public async Task<Activity> DeleteActivityAsync(int id)
        {
           var deleteActivity = await zohoDbContext.Activities.FirstOrDefaultAsync(x => x.Id == id);
           if (deleteActivity == null)
           {
                return null;
           }
           zohoDbContext.Activities.Remove(deleteActivity);
           await zohoDbContext.SaveChangesAsync();
           return deleteActivity;
        }

        public async Task<Activity> GetActivityByIdAsync(int id)
        {
            return await zohoDbContext.Activities.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Activity>> GetAllActivityAsync()
        {
            return await zohoDbContext.Activities.ToListAsync();
        }

        public async Task<Activity> UpdateActivityAsync(int id, Activity activity)
        {
            var updateActivity = await zohoDbContext.Activities.FirstOrDefaultAsync(x => x.Id == id);
            if (updateActivity == null)
            {
                return null;
            }

            updateActivity.ActivityDate = activity.ActivityDate;
            updateActivity.ActivityName = activity.ActivityName;
            updateActivity.ActivityType = activity.ActivityType;
            updateActivity.CreatedDate = activity.CreatedDate;
            updateActivity.Description = activity.Description;
            updateActivity.IsArchived = activity.IsArchived;
            updateActivity.LastUpdatedDate = activity.LastUpdatedDate;
            
            await zohoDbContext.SaveChangesAsync();
            return updateActivity;

        }
    }
}