using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IPS_API.Model;
using IPS_API.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IPS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountTypeController : ControllerBase
    {
        private readonly IAccountTypeService _accountTypeService;
        public AccountTypeController(IAccountTypeService accountTypeService)
        {
            _accountTypeService = accountTypeService;
        }

        //api/AccountType
        [HttpGet]
        public ActionResult<List<AccountType>> Get()
        {
            var accountTypes = _accountTypeService.GetAccountTypes();
            return Ok(accountTypes);
        }
    }
}