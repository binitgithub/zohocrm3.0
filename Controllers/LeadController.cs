using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using zohocrm3._0.Data;
using zohocrm3._0.Models;
using zohocrm3._0.Repositories;

namespace zohocrm3._0.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeadController : ControllerBase
    {
        private readonly ILeadRepository leadRepository;

        public LeadController(ILeadRepository leadRepository)
        {
            this.leadRepository = leadRepository;
        }
    //Get All Lead
    [HttpGet]
    public async Task<IActionResult> GetAllLead()
    {
        var getAllLeadModel = await leadRepository.GetAllLeadAsync();
        
        if (getAllLeadModel == null)
        {
            return NotFound();
        }
        return Ok();
    }

    //Get By Id Lead
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetLeadById([FromRoute] int id)
    {
        var getLeadsByIdModel = await leadRepository.GetByIdLeadAsync(id);
        if (getLeadsByIdModel == null)
        {
            return NotFound();
        }
        return Ok();
    }

    //Create Lead
    [HttpPost]
    public async Task<IActionResult> CreateLead([FromBody] Lead lead)
    {
        var CreateLeadModel = await leadRepository.CreateLeadAsync(lead);
        return CreatedAtAction(nameof(GetLeadById), new {id = CreateLeadModel.Id}, CreateLeadModel);
    }

    //Update Leads
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateLead([FromRoute] int id, [FromBody] Lead lead)
    {
        var updateLeadModel = await leadRepository.UpdateLeadAsync(id, lead);
        if (updateLeadModel == null)
        {
            return NotFound();
        }
        return Ok();
    }

    //Delete Leads
    [HttpDelete("{int:id}")]
    public async Task<IActionResult> DeleteLead([FromRoute] int id)
    {
        var DeleteLeadModel = await leadRepository.DeleteLeadAsync(id);
        if (DeleteLeadModel == null)
        {
            return NotFound();
        }
        return Ok();
    }
    }
}