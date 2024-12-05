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
    public class CampaignController : ControllerBase
    {
        private readonly ICampaignRepository campaignRepository;

        public CampaignController(ICampaignRepository campaignRepository)
        {
            this.campaignRepository = campaignRepository;
        }
    //Get All Campaign
    [HttpGet]
    public async Task<IActionResult> GetAllCampaign()
    {
        var getAllCampaignModel = await campaignRepository.GetAllCampaignAsync();
        if (getAllCampaignModel == null)
        {
            return NotFound();
        } 
        return Ok();
    }

    //Get Campaign By Id
    [HttpGet("id:int")]
    public async Task<IActionResult> GetCampaignById([FromRoute] int id)
    {
        var getCampaignModel = await campaignRepository.GetByIdCampaignAsync(id);
        if (getCampaignModel == null)
        {
            return NotFound();
        }
        return Ok();
    }

    //Create Campaign
    [HttpPost]
    public async Task<IActionResult> CreateCampaign([FromBody] Campaign campaign)
    {
        var CreateCampaignModel = await campaignRepository.CreateCampaignAsync(campaign);
        return CreatedAtAction(nameof(GetCampaignById), new {id = CreateCampaignModel}, CreateCampaignModel);
    }

    //Update Campaign
    [HttpPut ("{id:int}")]
    public async Task<IActionResult> UpdateCampaign([FromRoute] int id, [FromBody] Campaign campaign)
    {
        var updateCampaignModel = await campaignRepository.UpdateCampaignAsync(id, campaign);
        if (updateCampaignModel == null)
        {
            return NotFound();
        }
        return Ok();
    }

    //Delete Campaign
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteCampaign([FromRoute] int id)
    {
        var deleteCampaign = await campaignRepository.DeleteCampaignAsync(id);
        if (deleteCampaign == null)
        {
            return NotFound();
        }

        return Ok();
    }
    }
}