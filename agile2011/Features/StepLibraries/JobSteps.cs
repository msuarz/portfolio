using System;
using UltimateSoftware.Foundation.Services.JobDomain.WcfTypes;

namespace Features
{
    public class JobSteps : ServiceCRUDSteps<IEmployeeJob, Job, EmployeeJob>
    {
        public void Jobs(Job Job)
        {
            AssertFound(Job);
        }

        protected override void SetUpUpdate(Job Proposed) 
        {
            Proposed.EffectiveDate = DateTime.Now;
        }
    }
}