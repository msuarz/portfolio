using System;
using UltimateSoftware.Foundation.Services.Acceptance.Tests.Features;
using UltimateSoftware.Foundation.Services.Core;
using UltimateSoftware.Foundation.Services.Core.Query;

namespace Features
{
    public partial class ServiceCRUDSteps<Service, DTO, EmployeeDTO> : ServiceTest<Service>
        where EmployeeDTO : class 
        where DTO : class
    {
        protected virtual EmployeeDTO[] Find(EmployeeQuery Query)
        {
            throw new NotImplementedException();
        }

        protected virtual DTO Get(DTO Original)
        {
            throw new NotImplementedException();
        }

        protected virtual UpdateResponse Update(DTO Proposed)
        {
            throw new NotImplementedException();
        }

        protected virtual void ClearWriteOnlyFields(DTO DTO) {}
    }
}