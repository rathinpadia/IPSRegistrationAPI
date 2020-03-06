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
    public class CorporateAccountController : ControllerBase
    {
        private readonly ICorporateAccountService  _corporateAccountService;
        public CorporateAccountController(ICorporateAccountService corporateAccountService)
        {
            _corporateAccountService = corporateAccountService;
        }

        //api/CorporateAccount/AddCorporateAccount
        [HttpPost]
        [Route("AddCorporateAccount")]
        public IActionResult AddCorporateAccount(CorporateAccount items)
        {
            _corporateAccountService.AddCorporateAccount(items);

            return Ok();
        }

        //api/CorporateAccount
        [HttpGet]
        public ActionResult<List<CorporateAccount>> Get()
        {
            var corAccountList = _corporateAccountService.GetAllCorporateAccounts();
            return Ok(corAccountList);
        }
    }
}
