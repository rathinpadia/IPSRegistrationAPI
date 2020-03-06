using IPS_API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPS_API.Service
{
    public class AccountTypeService : IAccountTypeService
    {
        private readonly IpsDBContext _context;
        public AccountTypeService(IpsDBContext context)
        {
            _context = context;
        }

        public void AddAccountType(AccountType accountType)
        {
            _context.Add(accountType);
            _context.SaveChanges();
        }

        public List<AccountType> GetAccountTypes()
        {
            return _context.AccountType.ToList();
        }

    }
}
