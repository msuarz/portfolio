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
            When_the_hourly_rate_doubles();        
            Then_the_salary_should_double();
        }
        
        [Test]
        public void ChangeByHourlyRate()
        {         
            Given_the_hourly_rate_is(25);        
            and_the_salary_is(52000);        
            When_the_hourly_rate_changes_to(50);        
            Then_the_salary_should_be(104000);
        }
        
        [Test]
        public void ChangeByHourlyRate_1()
        {         
            Given_the_hourly_rate_is(25);        
            and_the_salary_is(52000);        
            When_the_hourly_rate_changes_to(50);        
            Then_the_salary_should_be(104000);
        }
        
        [Test]
        public void ChangeByHourlyRate_2()
        {         
            Given_the_hourly_rate_is(50);        
            and_the_salary_is(104000);        
            When_the_hourly_rate_changes_to(25);        
            Then_the_salary_should_be(52000);
        }
        
        [Test]
        public void ChangeByHourlyRate_3()
        {         
            Given_the_hourly_rate_is(50);        
            and_the_salary_is(104000);        
            When_the_hourly_rate_changes_to(0);        
            Then_the_salary_should_be(0);
        }
        
        [Test]
        public void ChangeByRate_1()
        {         
            Given_the__is("H", 25);        
            and_the_salary_is(52000);        
            When_the__changes_to("H", 50);        
            Then_the_salary_should_be(104000);
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
            Given_the__is("W", 1000);        
            and_the_salary_is(52000);        
            When_the__changes_to("W", 2000);        
            Then_the_salary_should_be(104000);
        }
        
        [Test]
        public void UpdateBasedOnScheduledHours()
        {         
            Original(        
                new UltimateSoftware.Foundation.Services.CompensationDomain.WcfTypes.Compensation
                {        
                    ScheduledHours = 40,        
                    Hourly = 25,        
                    Annual = 52000
                });        
            Proposed(        
                new UltimateSoftware.Foundation.Services.CompensationDomain.WcfTypes.Compensation
                {        
                    ScheduledHours = 80
                });        
            Update();        
            Actual(        
                new UltimateSoftware.Foundation.Services.CompensationDomain.WcfTypes.Compensation
                {        
                    ScheduledHours = 80,        
                    Hourly = 25,        
                    Annual = 104000
                });
        }
        
        [Test]
        public void UpdateScheduledHoursAndRateFields()
        {         
            Original(        
                new UltimateSoftware.Foundation.Services.CompensationDomain.WcfTypes.Compensation
                {        
                    ScheduledHours = 40,        
                    Hourly = 25,        
                    Annual = 52000
                });        
            Proposed(        
                new UltimateSoftware.Foundation.Services.CompensationDomain.WcfTypes.Compensation
                {        
                    ScheduledHours = 20,        
                    Hourly = 50
                });        
            Update();        
            Actual(        
                new UltimateSoftware.Foundation.Services.CompensationDomain.WcfTypes.Compensation
                {        
                    Annual = 52000
                });
        }

    }
}
