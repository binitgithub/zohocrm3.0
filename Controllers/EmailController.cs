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
    public class EmailController : ControllerBase
    {
        private readonly IEmailRepository emailRepository;

        public EmailController(IEmailRepository emailRepository)
        {
            this.emailRepository = emailRepository;
        }
    
    //Get All Email
    [HttpGet]
    public async Task<IActionResult> GetAllEmail()
    {
        var GetEmailModel = await emailRepository.GetAllEmailAsync();
        if (GetEmailModel == null)
        {
            return NotFound();
        }
        return Ok();
    }

    //Get By Id Email
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetEmailById([FromRoute] int id)
    {
        var GetEmailByIdModel = await emailRepository.GetByIdEmailAsync(id);
        if (GetEmailByIdModel == null)
        {
            return NotFound();
        }
        return Ok();
    }

    //Create Email
    [HttpPost]
    public async Task<IActionResult> CreateEmail([FromBody] Email email)
    {
        var CreatEmailModel = await emailRepository.CreateEmailAsync(email);
        return CreatedAtAction(nameof(GetEmailById), new {id = CreatEmailModel.Id}, CreatEmailModel);
    }

    //Update Email
    [HttpPut ("{id:int}")]
    public async Task<IActionResult> UpdateEmail([FromRoute] int id, [FromBody] Email email)
    {
        var UpdateEmailModel = await emailRepository.UpdateEmailAsync(id,email);
        if (UpdateEmailModel == null)
        {
            return NotFound();
        }
        return Ok();
    }

    //Delete Email
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteEmail ([FromRoute] int id)
    {
        var deleteEmailModel = await emailRepository.DeleteEmailAsync(id);
        if (deleteEmailModel == null)
        {
            return NotFound();
        }
        return Ok();
    }
    }
}