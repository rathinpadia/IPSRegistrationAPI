using IPS_API.Model;
using IPS_API.Service;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace IPSAPI.UnitTests
{
    public class CorporateAccountTests
    {
        [Fact]
        public void CreateCorporateAccount_saves_a_CorporateAccount_via_context()
        {
            var options = new DbContextOptionsBuilder<IpsDBContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;

            // Run the test against one instance of the context
            using (var context = new IpsDBContext(options))
            {
                var service = new CorporateAccountService(context);
                List<AssociatedIndividual> associatedIndividuals = new List<AssociatedIndividual>()
                {
                    new AssociatedIndividual
                        {
                            AccountTypeId = 2,
                            DateofBirth = new DateTime(2011,10,1),
                            FirstName = "Rahul",
                            LastName = "Mahajan",
                            Title = "Mr"
                        },
                        new AssociatedIndividual
                        {
                            AccountTypeId = 2,
                            DateofBirth = new DateTime(2011,10,1),
                            FirstName = "Vishal",
                            LastName = "Mahajan",
                            Title = "Mr"
                        }
                };
                List<CompanyOfficer> companyOfficers = new List<CompanyOfficer>()
                {
                    new CompanyOfficer
                        {
                            FirstName = "Vishwas",
                            LastName = "Mahajan",
                            Title = "Mr"
                        },
                        new CompanyOfficer
                        {
                            FirstName = "Bakul",
                            LastName = "Mahajan",
                            Title = "Mr"
                        }
                };

                CorporateAccount corporateAccount = new CorporateAccount
                {
                    AccountName = "My Corporate Account 1",
                    AccountNo = "123456",
                    BSB = "123",
                    ABN = "abc123",
                    CompanyName = "My New Company",
                    AssociatedIndividualCorporate = associatedIndividuals,
                    CompanyOfficers = companyOfficers
                };
                service.AddCorporateAccount(corporateAccount);

                context.SaveChanges();
            }

            // Use a separate instance of the context to verify correct data was saved to database
            using (var context = new IpsDBContext(options))
            {
                Assert.Equal(1, context.CorporateAccount.Count());
            }
        }
    }
}
