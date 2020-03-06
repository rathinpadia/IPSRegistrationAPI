using IPS_API.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPS_API.Service
{
    public class PersonalAccountService : IPersonalAccountService
    {
        private readonly IpsDBContext _context;

        public PersonalAccountService(IpsDBContext context)
        {
            _context = context;
        }

        public void AddPersonalAccount(PersonalAccount personalAccount)
        {
            _context.Add(personalAccount);
            _context.SaveChanges();
        }

        public List<PersonalAccount> GetAllPersonalAccounts()
        {
            var personalAccounts = _context.PersonalAccount.Include(a => a.AssociatedIndividualPersonal).ToList();
            return personalAccounts;
        }
    }
}
