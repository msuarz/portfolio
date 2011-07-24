using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using MbUnit.Framework;
using UltimateSoftware.Foundation.Services.Common.Tests;
using UltimateSoftware.Foundation.Services.Core;

namespace Features
{
    public partial class ServiceCRUDSteps<Service, DTO, EmployeeDTO>
    {
        protected IEnumerable<EmployeeDTO> EmployeesFound;
        protected Collection<Result> Results;
        protected Result OperationResult;
        protected IStatus status;

        protected IEnumerable<string> ErrorMessages
        {
            get
            {
                return Results
                    .SelectMany(x => x.Messages)
                    .Select(x => x.AsString());
            }
        }

        protected string ErrorMessage
        {
            get { return ErrorMessages.FirstOrDefault(); }
        }

        protected void WriteResponse(object Response)
        {
            status = Response as IStatus;
            OperationResult = Response.Get("OperationResult") as Result;
            Results = Response.Get("Results") as Collection<Result>;
        }

        protected void ReadResponse(object Response)
        {
            EmployeesFound = Response.Get("Results") as EmployeeDTO[];
            status = OperationResult = Response.Get("OperationResult") as Result;
            Results = null;
        }

        public void Status(Result Result)
        {
            Assert.IsTrue(Result.Matches(this.OperationResult));    
        }

        public void OperationStatus(Result Result)
        {
            Assert.IsTrue(Result.Matches(OperationResult));    
        }

        public void Messages(params OperationMessage[] Messages)
        {
            Assert.IsTrue(Messages.All(x => OperationResult.Messages.Any(x.Matches)));
        }
    }
}