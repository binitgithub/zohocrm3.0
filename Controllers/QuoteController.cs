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
    public class QuoteController : ControllerBase
    {
        private readonly IQuoteRepository quoteRepository;

        public QuoteController(IQuoteRepository quoteRepository)
        {
            this.quoteRepository = quoteRepository;
        }
    //Get All Quotes
    [HttpGet]
    public async Task<IActionResult> GetAllQuote()
    {
        var getAllQuoteModel = await quoteRepository.GetAllQuoteAsync();
        if (getAllQuoteModel == null)
        {
            return NotFound();
        }
        return Ok();
    }

    //Get Quote By Id
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetQuoteById([FromRoute] int id)
    {
        var getQuoteByIdModel = await quoteRepository.GetByIdQuoteAsync(id);
        if (getQuoteByIdModel == null)
        {
            return NotFound();
        }
        return Ok();
    }

    //Create Quote
    [HttpPost]
    public async Task<IActionResult> CreateQuote([FromBody] Quote quote)
    {
        var CreateQuoteModel = await quoteRepository.CreateQuoteAsync(quote);
        return CreatedAtAction(nameof(GetQuoteById), new {id = CreateQuoteModel.Id}, CreateQuoteModel);
    }

    //Update Quote
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateQuoate([FromRoute] int id, [FromBody] Quote quote)
    {
        var updateQuoteModel = await quoteRepository.UpdateQuoteAsync(id, quote);
        if (updateQuoteModel == null)
        {
            return NotFound();
        }
        return Ok();
    }

    //Delete Quote
    [HttpDelete ("{id:int}")]
    public async Task<IActionResult> DeleteQuote([FromRoute] int id)
    {
        var deleteQuoteModel = await quoteRepository.DeleteQuoteAsync(id);
        if (deleteQuoteModel == null)
        {
            return NotFound();
        }
        return Ok();
    }
    }
}