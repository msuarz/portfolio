using System;
using System.Collections.Generic;
using System.Linq;
using MbUnit.Framework;
using UltimateSoftware.Foundation.Services.Core;
using UltimateSoftware.Foundation.Services.Core.Query;

namespace Features
{
    public partial class ServiceCRUDSteps<Service, DTO, EmployeeDTO>
    {
        protected EmployeeQuery query;
        
        public void Query(EmployeeQuery Query) { query = Query; }

        protected FindResponse FindResponse;

        public void Find()
        {
            EmployeesFound = Find(query);
        }

        public void Find(params EmployeeQuery[] Queries)
        {
            Queries.ForEach(AssertFindsSomeone);
        }

        void AssertFindsSomeone(EmployeeQuery Query)
        {
            var Employees = Find(query);

            if (!Result.Success) Assert.Fail("Could not execute query due to " + Result.Messages[0].Message);
            Assert.IsTrue(Employees.Count() > 0, "Could not find anybody");
        }

        protected IEnumerable<EmployeeDTO> EmployeesFound;

        public void Employees(EmployeeDTO Employee)
        {
            EmployeesFound.ShouldContain(Employee);
        }
    }
}