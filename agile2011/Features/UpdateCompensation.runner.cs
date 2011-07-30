using MbUnit.Framework;

namespace Features 
{
    [TestFixture]
    public partial class UpdateCompensation 
    {

        
        [Test]
        public void IncreaseSalary()
        {         
            When_the_hourly_rate_increases();        
            Then_the_salary_should_increase();
        }
        
        [Test]
        public void DoubleHourlyRate()
        {         
            When_the_hourly_rate_increases_twice();        
            Then_the_salary_should_double();
        }
        
        [Test]
        public void ChangeByHourlyRate()
        {         
            Given_the_hourly_rate_is(20);        
            and_the_salary_is(50000);        
            When_the_hourly_rate_changes_to(40);        
            Then_the_salary_should_be(100000);
        }
        
        [Test]
        public void ChangeByHourlyRate_1()
        {         
            Given_the_hourly_rate_is(20);        
            and_the_salary_is(50000);        
            When_the_hourly_rate_changes_to(40);        
            Then_the_salary_should_be(100000);
        }
        
        [Test]
        public void ChangeByHourlyRate_2()
        {         
            Given_the_hourly_rate_is(40);        
            and_the_salary_is(100000);        
            When_the_hourly_rate_changes_to(20);        
            Then_the_salary_should_be(50000);
        }
        
        [Test]
        public void ChangeByHourlyRate_3()
        {         
            Given_the_hourly_rate_is(40);        
            and_the_salary_is(100000);        
            When_the_hourly_rate_changes_to(0);        
            Then_the_salary_should_be(0);
        }
        
        [Test]
        public void ChangeByRate_1()
        {         
            Given_the__is("H", 20);        
            and_the_salary_is(50000);        
            When_the__changes_to("H", 40);        
            Then_the_salary_should_be(100000);
        }
        
        [Test]
        public void ChangeByRate_2()
        {         
            Given_the__is("Y", 100000);        
            and_the_salary_is(100000);        
            When_the__changes_to("Y", 50000);        
            Then_the_salary_should_be(50000);
        }
        
        [Test]
        public void ChangeByRate_3()
        {         
            Given_the__is("W", 2000);        
            and_the_salary_is(80000);        
            When_the__changes_to("W", 4000);        
            Then_the_salary_should_be(160000);
        }
        
        [Test]
        public void ChangeByPercentages()
        {         
            Update_by_Percent___Salary_increases_X_times(100, 2);        
            Update_by_Percent___Salary_increases_X_times(200, 3);        
            Update_by_Percent___Salary_increases_X_times(-50, 0.5);
        }
        
        [Test]
        public void UpdateBasedOnScheduledHours()
        {         
            Original(        
                new UltimateSoftware.Foundation.Services.CompensationDomain.WcfTypes.Compensation
                {        
                    ScheduledHours = 80,        
                    RateChangeType = "Y",        
                    Annual = 50000
                });        
            Proposed(        
                new UltimateSoftware.Foundation.Services.CompensationDomain.WcfTypes.Compensation
                {        
                    ScheduledHours = 40
                });        
            Update();        
            Actual(        
                new UltimateSoftware.Foundation.Services.CompensationDomain.WcfTypes.Compensation
                {        
                    ScheduledHours = 40,        
                    Annual = 25000
                });
        }
        
        [Test]
        public void UpdateScheduledHoursAndRateFields()
        {         
            Original(        
                new UltimateSoftware.Foundation.Services.CompensationDomain.WcfTypes.Compensation
                {        
                    Annual = 52000,        
                    RateChangeType = "Y"
                });        
            Proposed("ScheduledHours", 0.5);        
            Proposed("Hourly", 2);        
            Update();        
            Actual(        
                new UltimateSoftware.Foundation.Services.CompensationDomain.WcfTypes.Compensation
                {        
                    Annual = 52000
                });
        }

    }
}
