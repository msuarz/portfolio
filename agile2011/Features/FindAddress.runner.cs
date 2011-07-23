using MbUnit.Framework;

namespace Features 
{
    [TestFixture]
    public partial class FindAddress 
    {

        
        [Test]
        public void Abstract()
        {         
            When_I_search_for_addresses_of_an_existing_Employee();        
            I_should_get_the_corresponding_addresses();
        }
        
        [Test]
        public void MoreExplicitButUnmanagable()
        {         
            When_I_search_for_addresses_of_employees_in_EAST();        
            I_should_get_the_corresponding_addresses();
        }
        
        [Test]
        public void UsingArgs()
        {         
            When_I_search_for_addresses_of_employees_with("Organization Level1", "=EAST");        
            and("Last Name", "like (A%)");        
            I_should_get_the_corresponding_addresses();
        }
        
        [Test]
        public void Table()
        {         
            When_I_search_for_addresses
            (        
                new[] {"Organization Level1", "=EAST"},        
                new[] {"Last Name", "like (A%)"},        
                new[] {"Former Name", "not isblank()"}
            );        
            I_should_get_the_corresponding_addresses();
        }
        
        [Test]
        public void Fixture()
        {         
            Query(        
                new UltimateSoftware.Foundation.Services.Core.Query.EmployeeQuery
                {        
                    LastName = "like(%o%)",        
                    FirstName = "=Jack"
                });        
            Find();        
            Employees(        
                new UltimateSoftware.Foundation.Services.AddressDomain.WcfTypes.EmployeeAddress
                {        
                    FirstName = "Jack",        
                    LastName = "Ross"
                });        
            Employees(        
                new UltimateSoftware.Foundation.Services.AddressDomain.WcfTypes.EmployeeAddress
                {        
                    FirstName = "Jack",        
                    LastName = "Locke"
                });        
            Addresses(        
                new UltimateSoftware.Foundation.Services.AddressDomain.WcfTypes.Address
                {        
                    AddressLine1 = "1 Ross",        
                    City = "Neo",        
                    Country = "USA",        
                    ZipOrPostalCode = "458668764"
                });        
            Addresses(        
                new UltimateSoftware.Foundation.Services.AddressDomain.WcfTypes.Address
                {        
                    AddressLine1 = "1261 The Links",        
                    City = "Ithaca",        
                    Country = "USA",        
                    ZipOrPostalCode = "14886"
                });
        }
        
        [Test]
        public void DSL()
        {         
            Find
            (        
                        
                new UltimateSoftware.Foundation.Services.Core.Query.EmployeeQuery
                {        
                    OrganizationLevel1 = "=EAST",        
                    LastName = "=Doe",        
                    FirstName = "=John",        
                    FormerName = ""
                },        
                        
                new UltimateSoftware.Foundation.Services.Core.Query.EmployeeQuery
                {        
                    OrganizationLevel1 = "in(EAST, WEST)",        
                    LastName = "",        
                    FirstName = "",        
                    FormerName = "isblank()"
                }
            );
        }

    }
}
