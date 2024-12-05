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
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository contactRepository;

        public ContactController(IContactRepository contactRepository)
        {
            this.contactRepository = contactRepository;
        }
    //Get All Contact
    [HttpGet]
    public async Task<IActionResult> GetAllContact()
    {
        var getContactModel = await contactRepository.GetAllContactAsync();
        if (getContactModel == null)
        {
            return NotFound();
        }
        return Ok();
    }
    
    //Get By Id Contact
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetContactById([FromRoute] int id)
    {
        var GetByIdContactModel = await contactRepository.GetByIdContactAsync(id);
        if (GetByIdContactModel == null)
        {
            return NotFound();
        }
        return Ok();
    }

    //Create Contact
    [HttpPost]
    public async Task<IActionResult> CreateContact([FromBody] Contact contact)
    {
        var contactModel = await contactRepository.CreateContactAsync(contact);
        return CreatedAtAction(nameof(GetContactById), new {id = contactModel.Id}, contactModel);
    }

    //Update Contact
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateContact([FromRoute] int id, [FromBody] Contact contact)
    {
        var updateContactModel = await contactRepository.UpdateContactAsync(id, contact);
        if (updateContactModel == null)
        {
            return NotFound();
        }

        return Ok();
    }

    //Delete Contact
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteContact([FromRoute] int id)
    {
        var deleteContact = await contactRepository.DeleteContactAsync(id);
        if (deleteContact == null)
        {
            return NotFound();
        }
        return Ok();
    }

    }
}