using System;
using UltimateSoftware.Foundation.Services.CompensationDomain.WcfTypes;
using UltimateSoftware.Foundation.Services.Acceptance.Tests;

namespace Features
{
    public class CompensationSteps : ServiceCRUDSteps<IEmployeeCompensation, Compensation, EmployeeCompensation>
    {
        protected override void SetUpUpdate(Compensation Proposed)
        {
            Proposed.EffectiveDate = DateTime.Now;

            if (Proposed.RateChangeType.HasValue() || Proposed.PercentChange != 0) return;
            
            Proposed.RateChangeType = "H";
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