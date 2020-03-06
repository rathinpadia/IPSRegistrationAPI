using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPS_API.Model
{
    public class IpsDBContext : DbContext
    {
        public IpsDBContext(DbContextOptions<IpsDBContext> options) : base(options)
        {

        }
        public IpsDBContext()
        {

        }
        public virtual DbSet<AccountType> AccountType { get; set; }

        public virtual DbSet<AssociatedIndividual> AssociatedIndividual { get; set; }

        public virtual DbSet<PersonalAccount> PersonalAccount { get; set; }

        public virtual DbSet<CorporateAccount> CorporateAccount { get; set; }

        public virtual DbSet<CompanyOfficer> CompanyOfficer { get; set; }

    }
}
