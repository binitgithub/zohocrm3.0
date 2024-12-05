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
    public class AppTaskController : ControllerBase
    {
        private readonly IApptaskRepository apptaskRepository;
        public AppTaskController(IApptaskRepository apptaskRepository)
        {
            this.apptaskRepository = apptaskRepository;
            
        }

    //Get All Task
    [HttpGet]
    public async Task<IActionResult> GetAllApptask()
    {
        var AppTaskModel = await apptaskRepository.GetAllApptaskAsync();
        if (AppTaskModel == null)
        {
            return NotFound();
        }
        return Ok();
    }
    
    //Get By Id
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetAppTaskById([FromRoute] int id)
    {
        var getAppTaskModel = await apptaskRepository.GetApptaskByIdAsync(id);
        if (getAppTaskModel == null)
        {
            return NotFound();
        }
        return Ok();
    }

    //Create App Task
    [HttpPost]
    public async Task<IActionResult> CreateTask([FromBody] Apptask apptask)
    {
        var CreateAppTaskModel = await apptaskRepository.CreateApptaskAsync(apptask);
        return CreatedAtAction(nameof(GetAppTaskById), new {id = CreateAppTaskModel.Id}, CreateAppTaskModel);
    }

    //Update AppTask
    [HttpPut ("{id:int}")]
    public async Task<IActionResult> UpdateTask([FromRoute] int id, [FromBody] Apptask apptask)
    {
        var updateTaskModel = await apptaskRepository.UpdateApptaskAsync(id , apptask);
        if (updateTaskModel == null)
        {
            return NotFound();
        }

        return Ok();
    }

    //Delete Task
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteApptask([FromRoute] int id)
    {
        var deleteTaskModel = await apptaskRepository.DeleteApptaskAsync(id);
        if (deleteTaskModel == null)
        {
            return NotFound();
        }
        return Ok();
    }

    }
}