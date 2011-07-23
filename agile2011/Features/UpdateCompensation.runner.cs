using MbUnit.Framework;

namespace Features 
{
    [TestFixture]
    public partial class UpdateCompensation 
    {

        
        [Test]
        public void UpdateBasedOnScheduledHours()
        {         
            Original(        
                new UltimateSoftware.Foundation.Services.CompensationDomain.WcfTypes.Compensation
                {        
                    ScheduledHours = 80,        
                    Hourly = 24,        
                    Weekly = 900,        
                    Period = 2000,        
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
                    Hourly = 24,        
                    Weekly = 450,        
                    Period = 1000,        
                    Annual = 25000
                });
        }
        
        [Test]
        public void UpdateScheduledHoursAndRateFields()
        {         
            Original(        
                new UltimateSoftware.Foundation.Services.CompensationDomain.WcfTypes.Compensation
                {        
                    ScheduledHours = 40,        
                    Hourly = 24,        
                    Annual = 25000
                });        
            Proposed(        
                new UltimateSoftware.Foundation.Services.CompensationDomain.WcfTypes.Compensation
                {        
                    ScheduledHours = 20,        
                    Hourly = 48,        
                    RateChangeType = "H"
                });        
            Update();        
            Actual(        
                new UltimateSoftware.Foundation.Services.CompensationDomain.WcfTypes.Compensation
                {        
                    ScheduledHours = 20,        
                    Hourly = 48,        
                    Annual = 25000
                });
        }
        
        [Test]
        public void UpdateBasedOnPercentages()
        {         
            Update_by_Percent___Salary_increases_X_times(100, 2);        
            Update_by_Percent___Salary_increases_X_times(200, 3);        
            Update_by_Percent___Salary_increases_X_times(-50, 0.5);
        }
        
        [Test]
        public void UpdateBasedOnRate()
        {         
            Update_by_Rate("H", "Hourly");        
            Update_by_Rate("W", "Weekly");        
            Update_by_Rate("P", "Period");        
            Update_by_Rate("Y", "Annual");
        }

    }
}
