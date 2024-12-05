using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zohocrm3._0.Models;

namespace zohocrm3._0.Repositories
{
    public interface IActivityRepository
    {
        Task<List<Activity>> GetAllActivityAsync();
        Task<Activity> GetActivityByIdAsync(int id);
        Task<Activity> CreateActivityAsync(Activity activity);
        Task<Activity> UpdateActivityAsync(int id, Activity activity);
        Task<Activity> DeleteActivityAsync(int id);
    }
}