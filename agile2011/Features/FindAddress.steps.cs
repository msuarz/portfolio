using System.Linq;
using UltimateSoftware.Foundation.Services.Common.Tests;
using UltimateSoftware.Foundation.Services.Core.Query;

namespace Features 
{
    public partial class FindAddress : AddressSteps
    {
        public void When_I_search_for_addresses_of_an_existing_Employee() 
        {
            query = new EmployeeQuery 
            {
                LastName = "LIKE (A%)", 
                OrganizationLevel1 = "=EAST"
            };
        }

        public void I_should_get_the_corresponding_addresses() 
        {
            Find(query);
        }

        public void When_I_search_for_addresses_of_employees_in_EAST() 
        {
            When_I_search_for_addresses_of_an_existing_Employee();    
        }

        public void When_I_search_for_addresses_of_employees_with(string Filter, string Value) 
        {
            query = new EmployeeQuery();
            AddFilter(Filter, Value);
        }
        
        public void AddFilter(string Filter, string Value) 
        {
            query.Set(Filter.CamelCase(), Value);
        }

        public void and(string Filter, string Value) 
        {
            AddFilter(Filter, Value);
        }

        public void When_I_search_for_addresses(params string[][] Filters) 
        {
            query = new EmployeeQuery();

            Filters.ToList().ForEach(f => AddFilter(f[0], f[1]));
        }
    }
}
