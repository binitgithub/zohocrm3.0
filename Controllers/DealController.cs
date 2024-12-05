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
    public class DealController : ControllerBase
    {
        private readonly IDealRepository dealRepository;

        public DealController(IDealRepository dealRepository)
        {
            this.dealRepository = dealRepository;
        }
    
    //Get All Deal
    [HttpGet]
    public async Task<IActionResult> GetAllDeal()
    {
        var GetAllDealModel = await dealRepository.GetAllDealAsync();
        if (GetAllDealModel == null)
        {
            return NotFound();
        }
        return Ok();
    }

    //Get By Id Deal
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetDealById([FromRoute] int id)
    {
        var getDealbyIdModel = await dealRepository.GetByIdDealAsync(id);
        if (getDealbyIdModel == null)
        {
            return NotFound();
        }
        return Ok();
    }

    //Create Deal
    [HttpPost]
    public async Task<IActionResult> CreateDeal([FromBody] Deal deal)
    {
        var CreatDealModel= await dealRepository.CreateDealAsync(deal);
        return CreatedAtAction(nameof(GetDealById), new {id = CreatDealModel }, CreatDealModel);
    }

    //Update Deal
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateDeal([FromRoute] int id, [FromBody] Deal deal)
    {
        var updateDealModel = await dealRepository.UpdateDealAsync(id, deal);

        if (updateDealModel == null)
        {
            return NotFound();
        }
        return Ok();
    }

    //Delete Deal
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteDeal([FromRoute] int id)
    {
        var deleteDealModel = await dealRepository.DeleteDealAsync(id);
        if (deleteDealModel == null)
        {
            return NotFound();
        }

        return Ok();
    }

    }
}