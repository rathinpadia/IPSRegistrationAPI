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
    public class PersonalAccountTests
    {

        [Fact]
        public void CreatePersonalAccount_saves_a_PersonalAccount_via_context()
        {
            var options = new DbContextOptionsBuilder<IpsDBContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;

            // Run the test against one instance of the context
            using (var context = new IpsDBContext(options))
            {
                var service = new PersonalAccountService(context);
                List<AssociatedIndividual> associatedIndividuals = new List<AssociatedIndividual>()
                {
                    new AssociatedIndividual
                        {
                            AccountTypeId = 1,
                            DateofBirth = new DateTime(2011,10,1),
                            FirstName = "Rahul",
                            LastName = "Mahajan",
                            Title = "Mr"
                        },
                        new AssociatedIndividual
                        {
                            AccountTypeId = 1,
                            DateofBirth = new DateTime(2011,10,1),
                            FirstName = "Vishal",
                            LastName = "Mahajan",
                            Title = "Mr"
                        }
                };

                PersonalAccount personalAccount = new PersonalAccount
                {
                    AccountName = "My Accounts 1",
                    AccountNo = "123456",
                    BSB = "123",
                    FirstName = "Karim",
                    LastName = "Meghani",
                    TFN = "XYZ1234",
                    AssociatedIndividualPersonal = associatedIndividuals
                };
                service.AddPersonalAccount(personalAccount);

                context.SaveChanges();
            }

            // Use a separate instance of the context to verify correct data was saved to database
            using (var context = new IpsDBContext(options))
            {
                Assert.Equal(1, context.PersonalAccount.Count());
            }
        }
    }
}
