using System.Collections.Generic;
using MbUnit.Framework;
using UltimateSoftware.Foundation.Services.Common.Tests;
using UltimateSoftware.Foundation.Services.CompensationDomain.WcfTypes;

namespace Features 
{
    public partial class UpdateCompensation : CompensationSteps
    {
        void Update_by_Percent___Salary_increases_X_times(decimal Percent, double Times)
        {
            proposed.PercentChange = Percent;

            Update();

            AssertSalaryIncreasedTimes((decimal) Times);        
        }

        void When_the_hourly_rate_increases()
        {
            proposed.Hourly *= 2;

            Update();
        }

        void Then_the_salary_should_increase()
        {
            AssertSalaryIncreasedTimes(2);
        }

        void When_the_hourly_rate_doubles()
        {
            proposed.Hourly *= 2;

            Update();
        }

        void Then_the_salary_should_double()
        {
            AssertSalaryIncreasedTimes(2);
        }

        void Given_the_hourly_rate_is(decimal HourlyRate)
        {
            Original(new Compensation
            {
                Hourly = HourlyRate,
            });
        }

        void and_the_salary_is(decimal Salary)
        {
            Assert.AreEqual(Salary, proposed.Annual);
        }

        void When_the_hourly_rate_changes_to(decimal HourlyRate)
        {
            proposed.Hourly = HourlyRate;
            Update();
        }

        void Then_the_salary_should_be(decimal Salary)
        {
            Assert.AreEqual(Salary, actual.Annual);
        }

        readonly Dictionary<string, string> RateFields = new Dictionary<string, string>
        {
            { "H" , "Hourly" },
            { "W" , "Weekly" },
            { "P" , "Period" },
            { "Y" , "Annual" },
        };

        void Given_the__is(string Rate, decimal Value)
        {
            var DTO = new Compensation { RateChangeType = Rate };

            DTO.Set(RateFields[Rate], Value);

            Original(DTO);
        }

        void When_the__changes_to(string Rate, decimal Value)
        {
            proposed.Set(RateFields[Rate], Value);
            proposed.RateChangeType = Rate;

            Update();
        }
    }
}
