using System;
using UltimateSoftware.Foundation.Services.CompensationDomain.WcfTypes;
using UltimateSoftware.Foundation.Services.Acceptance.Tests;
using UltimateSoftware.Foundation.Services.Core;
using UltimateSoftware.Foundation.Services.Core.Query;

namespace Features
{
    public class CompensationSteps : ServiceCRUDSteps<IEmployeeCompensation, Compensation, EmployeeCompensation>
    {
        protected override EmployeeCompensation[] Find(EmployeeQuery Query) 
        {
            var Response = Call(x => x.FindCompensations(Query));

            Result = Response.OperationResult;

            return Response.Results;
        }

        protected override Compensation Get(Compensation DTO) 
        {
            return Call(x => x.GetCompensationByEmployeeIdentifier(DTO.EmployeeIdentifier)).Results[0];
        }

        void SetUpUpdate(Compensation Proposed)
        {
            Proposed.EffectiveDate = DateTime.Now;

            if (Proposed.RateChangeType.HasValue() || Proposed.PercentChange != 0) return;
            
            Proposed.RateChangeType = "H";
        }

        protected override UpdateResponse Update(Compensation Proposed)
        {
            SetUpUpdate(Proposed);

            return Call(x => x.UpdateCompensation(new[] { Proposed }));
        }

        protected override void ClearWriteOnlyFields(Compensation DTO) 
        {
            DTO.RateChangeType = null;
            DTO.EffectiveDate = default(DateTime);
        }

        protected void AssertSalaryIncreasedTimes(decimal Times)
        {
            try
            {
                actual.SalaryShouldIncreaseOver(original, Times, EmployeeNumber);
            }
            finally
            {
                Restore();
            }
        }
    }
}