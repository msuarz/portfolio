using System;
using AutoMapper;
using UltimateSoftware.Foundation.Services.Common.Tests;
using Queries=UltimateSoftware.Foundation.Services.Common.Tests.Query;

namespace Features
{
    public partial class ServiceCRUDSteps<Service, DTO, EmployeeDTO>
    {
        protected EmployeeDTO[] Suts { get; set; }

        public override void FixtureSetUp()
        {
            base.FixtureSetUp();
            Mapper.CreateMap<DTO, DTO>();
            Suts = Find(Queries.UsualSuspects);
        }    

        public override void SetUp()
        {
            if (Suts.Length == 0) return;

            var random = new Random().Next(Suts.Length);

            original = ((DTO[])Suts[random].Get(DTOsName))[0];

            proposed = Clone(original);
        }

        public override void TearDown() 
        {
            Restore();
        }
    }
}