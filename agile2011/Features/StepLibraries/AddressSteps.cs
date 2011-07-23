using System.Collections.Generic;
using System.Linq;
using MbUnit.Framework;
using UltimateSoftware.Foundation.Services.AddressDomain.WcfTypes;
using UltimateSoftware.Foundation.Services.Core.Query;

namespace Features
{
    public class AddressSteps : ServiceCRUDSteps<IEmployeeAddress, Address, EmployeeAddress>
    {
        protected override EmployeeAddress[] Find(EmployeeQuery Query)
        {
            var Response = Call(x => x.FindAddresses(Query));

            Result = Response.OperationResult;

            return Response.Results;
        }

        public void Addresses(Address Address)
        {
            Assert.IsTrue(DTOs.Any(Address.Matches));
        }

        protected override IEnumerable<Address> DTOs { get { return EmployeesFound.SelectMany(x => x.Addresses); } }
    }
}