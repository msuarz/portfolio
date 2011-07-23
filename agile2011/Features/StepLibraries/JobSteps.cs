using System.Collections.Generic;
using System.Linq;
using MbUnit.Framework;
using UltimateSoftware.Foundation.Services.Core;
using UltimateSoftware.Foundation.Services.Core.Query;
using UltimateSoftware.Foundation.Services.JobDomain.WcfTypes;

namespace Features
{
    public class JobSteps : ServiceCRUDSteps<IEmployeeJob, Job, EmployeeJob>
    {
        protected override IEnumerable<Job> DTOs { get { return EmployeesFound.SelectMany(x => x.Jobs); } }

        protected override EmployeeJob[] Find(EmployeeQuery Query)
        {
            var Response = Call(x => x.FindJobs(Query));

            Result = Response.OperationResult;

            return Response.Results;
        }

        protected override UpdateResponse Update(Job Proposed) 
        {
            return Call(x => x.UpdateJob(new[] {Proposed}));
        }

        public void Jobs(Job Job)
        {
            Assert.IsTrue(DTOs.Any(Job.Matches));
        }
    }
}