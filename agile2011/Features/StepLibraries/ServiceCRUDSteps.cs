using UltimateSoftware.Foundation.Services.Acceptance.Tests.Features;

namespace Features
{
    public partial class ServiceCRUDSteps<Service, DTO, EmployeeDTO> : ServiceTest<Service>
        where EmployeeDTO : class 
        where DTO : class
    {
    }
}