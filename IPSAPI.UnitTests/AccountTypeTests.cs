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
    public class AccountTypeTests
    {

        [Fact]
        public void CreateAccountTypes_saves_AccountTypes_via_context()
        {
            var options = new DbContextOptionsBuilder<IpsDBContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;

            // Run the test against one instance of the context
            using (var context = new IpsDBContext(options))
            {
                var service = new AccountTypeService(context);

                AccountType accountType1 = new AccountType();
                accountType1.AccountTypeName = "Personal";
                AccountType accountType2 = new AccountType();
                accountType2.AccountTypeName = "Corporate";
                service.AddAccountType(accountType1);
                service.AddAccountType(accountType2);

                context.SaveChanges();
            }

            // Use a separate instance of the context to verify correct data was saved to database
            using (var context = new IpsDBContext(options))
            {
                Assert.Equal(2, context.AccountType.Count());
            }
        }
    }
}
