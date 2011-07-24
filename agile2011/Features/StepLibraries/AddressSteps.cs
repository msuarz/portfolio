using UltimateSoftware.Foundation.Services.AddressDomain.WcfTypes;

namespace Features
{
    public class AddressSteps : ServiceCRUDSteps<IEmployeeAddress, Address, EmployeeAddress>
    {
        public void Addresses(Address Address) 
        {
            AssertFound(Address);
        }
    }
}