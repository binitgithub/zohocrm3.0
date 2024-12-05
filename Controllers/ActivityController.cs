using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using zohocrm3._0.Models;
using zohocrm3._0.Repositories;

namespace zohocrm3._0.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityRepository activityRepository;

        public ActivityController(IActivityRepository activityRepository)
        {
            this.activityRepository = activityRepository;
        }
    //Get All Activity
    [HttpGet]
    public async Task<IActionResult> GetAllActivity()
    {
        var GetActivityModel = await activityRepository.GetAllActivityAsync();
        if (GetActivityModel == null)
        {
            return NotFound();
        }
        return Ok();
    }
    //Get ById Activity
    [HttpGet ("{id:int}")]
    public async Task<IActionResult> GetActivityById([FromRoute] int id)
    {
        var getActivityByIdModel = await activityRepository.GetActivityByIdAsync(id);
        if (getActivityByIdModel == null)
        {
            return NotFound();
        }

        return Ok();
    }

    //Create Activity
    [HttpPost]
    public async Task<IActionResult> CreateActitity([FromBody] Activity activity)
    {
        var CreateActivityModel = await activityRepository.CreateActivityAsync(activity);
        return CreatedAtAction(nameof(GetActivityById), new {id = CreateActivityModel.Id}, CreateActivityModel);
    }

    //Update Activity
    [HttpPut ("{id:int}")]
    public async Task<IActionResult> UpdateActivity([FromRoute] int id, [FromBody] Activity activity)
    {
        var updateActivityModel = await activityRepository.UpdateActivityAsync(id , activity);
        if (updateActivityModel == null)
        {
            return NotFound();
        }

        return Ok();
    }

    //Delete Activity
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteActivity([FromRoute] int id)
    {
        var deleteActivityModel = await activityRepository.DeleteActivityAsync(id);
        if (deleteActivityModel == null)
        {
            return NotFound();
        }
        return Ok();
    }

    }
}