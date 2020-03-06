using IPS_API.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPS_API.Service
{
    public class CorporateAccountService : AccountTypeService, ICorporateAccountService
    {
        private readonly IpsDBContext _context;

        public CorporateAccountService(IpsDBContext context) : base(context)
        {
            _context = context;
        }

        public void AddCorporateAccount(CorporateAccount corporateAccount)
        {
            _context.Add(corporateAccount);
            _context.SaveChanges();
        }

        public List<CorporateAccount> GetAllCorporateAccounts()
        {
            var corporateAccounts = _context.CorporateAccount.Include(a => a.AssociatedIndividualCorporate).Include(b=>b.CompanyOfficers).ToList();
            return corporateAccounts;
        }
    }
}
