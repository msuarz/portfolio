using System;
using UltimateSoftware.Foundation.Services.Acceptance.Tests.Features;

namespace Features
{
    public partial class ServiceCRUDSteps<Service, DTO, EmployeeDTO> : ServiceTest<Service>
        where EmployeeDTO : class 
        where DTO : class
    {
        protected virtual DTO Get(DTO Original)
        {
            throw new NotImplementedException();
        }

        protected virtual void ClearWriteOnlyFields(DTO DTO) {}
    }
}