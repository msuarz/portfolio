using System;
using MbUnit.Framework;
using UltimateSoftware.Foundation.Services.CompensationDomain.WcfTypes;
using UltimateSoftware.Foundation.Services.Acceptance.Tests;

namespace Features
{
    public class CompensationSteps : ServiceCRUDSteps<IEmployeeCompensation, Compensation, EmployeeCompensation>
    {
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

        protected override void Restore()
        {
            Assert.IsEmpty(original.RateChangeType, "Rate change type was not empty before restore");
            original.RateChangeType = "H";

            base.Restore();
            
            original.RateChangeType = String.Empty;
        }
    }
}