using IPS_API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPS_API.Service
{
    public interface IPersonalAccountService
    {
        void AddPersonalAccount(PersonalAccount personalAccount);
        List<PersonalAccount> GetAllPersonalAccounts(); 
    }
}
