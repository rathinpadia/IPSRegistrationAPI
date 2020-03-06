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
    public class PersonalAccountController : ControllerBase

    {
        private readonly IPersonalAccountService _personalAccountService;
        public PersonalAccountController(IPersonalAccountService personalAccountService)
        {
            _personalAccountService = personalAccountService;
        }

        //api/PersonalAccount/AddPersonalAccount
        [HttpPost]
        [Route("AddPersonalAccount")]
        public IActionResult AddPersonalAccount(PersonalAccount items)
        {
             _personalAccountService.AddPersonalAccount(items);

            return Ok();
        }

        [HttpPost]
        [Route("AddTest")]
        public IActionResult AddPersonalAccount(int a, int b)
        {
          
            return Ok();
        }

        //api/PersonalAccount
        [HttpGet]
        public ActionResult<List<PersonalAccount>> Get()
        {
            var perAccountList = _personalAccountService.GetAllPersonalAccounts();
            return Ok(perAccountList);
        }
    }
}