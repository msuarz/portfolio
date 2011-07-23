using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MbUnit.Framework;
using UltimateSoftware.Foundation.Services.Acceptance.Tests;
using UltimateSoftware.Foundation.Services.Acceptance.Tests.Features;
using UltimateSoftware.Foundation.Services.Common.Tests;
using UltimateSoftware.Foundation.Services.Core;
using UltimateSoftware.Foundation.Services.Core.Query;

namespace Features
{
    public partial class ServiceCRUDSteps<Service, DTO, EmployeeDTO>
    {
        protected Result Result;

        public void Status(Result Result)
        {
            Assert.IsTrue(Result.Matches(this.Result));    
        }

        public void Messages(params OperationMessage[] Messages)
        {
            Assert.IsTrue(Messages.All(x => Result.Messages.Any(x.Matches)));
        }
    }
}