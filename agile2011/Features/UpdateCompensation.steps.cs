using UltimateSoftware.Foundation.Services.Common.Tests;

namespace Features 
{
    public partial class UpdateCompensation : CompensationSteps
    {
        void Update_by_Percent___Salary_increases_X_times(int Percent, double Times)
        {
            proposed.PercentChange = Percent;

            EnsureUpdate(proposed);

            AssertSalaryIncreasedTimes((decimal) Times);        
        }

        void Update_by_Rate(string Rate, string Field)
        {
            proposed.RateChangeType = Rate;

            proposed.Set(Field, (decimal)proposed.Get(Field) * 2);

            Update();

            AssertSalaryIncreasedTimes(2);
        }
    }
}
