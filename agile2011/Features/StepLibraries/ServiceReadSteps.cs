using System.Collections.Generic;
using System.Linq;
using MbUnit.Framework;
using UltimateSoftware.Foundation.Services.Core.Query;

namespace Features
{
    public partial class ServiceCRUDSteps<Service, DTO, EmployeeDTO>
    {
        protected EmployeeQuery query;
        
        public void Query(EmployeeQuery Query) { query = Query; }

        public void Find()
        {
            Find(query);
        }

        public void Find(params EmployeeQuery[] Queries)
        {
            Queries.ForEach(AssertFindsSomeone);
        }

        public void Find(EmployeeQuery Query)
        {
            ReadResponse(Call(x => x.Call("Find" + DTOsName, Query)));
        }

        void AssertFindsSomeone(EmployeeQuery Query)
        {
            Find(query);

            if (!OperationResult.Success) Assert.Fail("Could not execute query due to " + OperationResult.Messages[0].Message);
            Assert.IsTrue(EmployeesFound.Count() > 0, "Could not find anybody");
        }

        public void Employees(EmployeeDTO Employee)
        {
            EmployeesFound.ShouldContain(Employee);
        }
    }
}