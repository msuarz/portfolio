using MbUnit.Framework;

namespace Features 
{
    [TestFixture]
    public partial class ValidateJob 
    {

        
        [Test]
        public void ValidatePayGroup()
        {         
            Original(        
                new UltimateSoftware.Foundation.Services.JobDomain.WcfTypes.Job
                {        
                    PayGroup = "BIWEEKLY"
                });        
            Proposed(        
                new UltimateSoftware.Foundation.Services.JobDomain.WcfTypes.Job
                {        
                    PayGroup = "bad value"
                });        
            Update();        
            Actual(        
                new UltimateSoftware.Foundation.Services.JobDomain.WcfTypes.Job
                {        
                    PayGroup = "BIWEEKLY"
                });        
            Status(        
                new UltimateSoftware.Foundation.Services.Core.Result
                {        
                    Success = false
                });        
            Messages
            (        
                        
                new UltimateSoftware.Foundation.Services.Core.OperationMessage
                {        
                    PropertyName = "RateChangeType",        
                    Message = "Lookup code does not exist."
                }
            );
        }
        
        [Test]
        public void ValidateFields()
        {         
            Validate("PayGroup", "", "The following field is required:");        
            Validate("PayGroup", "01X", "Lookup code does not exist.");        
            Validate("TimeClock", "1234567890", "Parameter exceeds maximum length.");        
            Validate("ScheduledHours", -1, "Value is not within valid range");        
            Validate("ScheduledHours", 100000000, "Value is not within valid range");
        }
        
        [Test]
        public void ValidateCannotClearRequiredFields()
        {         
            Validate_Required_Fields
            (        
                new[] {"Pay Group", "Job Code", "Reason Code", "Employee Type", "Hourly Or Salaried", "Full Or Part Time"}
            );
        }
        
        [Test]
        public void ValidateUCDFields()
        {         
            Validate_UCD_Fields
            (        
                new[] {"PayGroup", "JobCode", "ReasonCode", "EmployeeType", "HourlyOrSalaried", "FullOrPartTime", "OrgLevel1", "OrgLevel2", "OrgLevel3", "OrgLevel4", "ShiftCode"}
            );
        }

    }
}
