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
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

    //Get All Accounts
    [HttpGet]
    public async Task<IActionResult> GetAllAccount()
    {
        var getAccountModel = await accountRepository.GetAllAccountAsync();
        if (getAccountModel == null)
        {
            return NotFound();
        }
        return Ok();
    }

    //Get By Id
    [HttpGet ("{id:int}")]
    public async Task<IActionResult> GetAccountById([FromRoute] int id)
    {
        var GetByIdModel = await accountRepository.GetAccountByIdAsync(id);
        if (GetByIdModel == null)
        {
            return NotFound();
        }

        return Ok();
    }

    //Create Account
    [HttpPost]
    public async Task<IActionResult> CreateAccont([FromBody] Account account)
    {
        var CreaeAccountModel = await accountRepository.CreateAccountAsync(account);
        return CreatedAtAction(nameof(GetAccountById), new { id = CreaeAccountModel.Id}, CreaeAccountModel);
    }

    //Update account
    [HttpPut ("{id:int}")]
    public async Task<IActionResult> UpdateAccount([FromRoute] int id, [FromBody] Account account)
    {
        var updateAccountModel = await accountRepository.UpdateAccountAsync(id, account);
        if (updateAccountModel == null)
        {
            return NotFound();
        }

        return Ok();
    }
    
    //Account Delete
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAccont([FromRoute] int id)
    {
        var deleteAccountModel = await accountRepository.DeleteAccountAsync(id);
        if (deleteAccountModel == null)
        {
            return NotFound();
        }

        return Ok();
    }

    }
}