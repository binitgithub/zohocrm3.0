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
    public class InvoicesController : ControllerBase
    {
        private readonly IInvoiceRepository invoiceRepository;

        public InvoicesController(IInvoiceRepository invoiceRepository)
        {
            this.invoiceRepository = invoiceRepository;
        }
    
    //Get All Invoice
    [HttpGet]
    public async Task<IActionResult> GetAllInvoice()
    {
        var GetAllInvoiceModel = await invoiceRepository.GetAllInvoiceAsync();
        if (GetAllInvoiceModel == null)
        {
            return NotFound();
        }
        return Ok();
    }

    //Get Invoice By Id
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetInvoiceById([FromRoute] int id)
    {
        var GetInvoiceModelById = await invoiceRepository.GetByIdInvoiceAsync(id);
        if (GetInvoiceModelById == null)
        {
            return NotFound();
        } 
        return Ok();
    }

    //Create Invoice
    [HttpPost]
    public async Task<IActionResult> CreateIonvice([FromBody] Invoice invoice)
    {
        var CreateInvoiceModel = await invoiceRepository.CreateInvoiceAsync(invoice);
        return CreatedAtAction(nameof(GetInvoiceById), new {id = CreateInvoiceModel.Id}, CreateInvoiceModel);
    }

    //Update Invoice
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateInvoice([FromRoute] int id, [FromBody] Invoice invoice)
    {
        var UpdateInvoiceModel = await invoiceRepository.UpdateInvoiceAsync(id, invoice);
        if (UpdateInvoiceModel == null)
        {
            return NotFound();
        }
        return Ok();
    }

    //Delete Invoice
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteInvoice([FromRoute] int id)
    {
        var DeleteInvoiceModel = await invoiceRepository.DeleteInvoiceAsync(id);
        if (DeleteInvoiceModel == null)
        {
            return NotFound();
        }
        return Ok();
    }
    }
}