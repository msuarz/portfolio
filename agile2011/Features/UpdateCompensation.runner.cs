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
                    ScheduledHours = 40,        
                    Hourly = 25,        
                    Annual = 52000,        
                    PayFrequency = "W"
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
                    ScheduledHours = 20,        
                    Hourly = 50,        
                    Annual = 52000
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
