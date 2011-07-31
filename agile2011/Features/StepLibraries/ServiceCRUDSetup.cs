using System;
using System.Linq;
using AutoMapper;
using UltimateSoftware.Foundation.Services.Common.Tests;
using UltimateSoftware.Foundation.Services.Core.Query;

namespace Features
{
    public static class Queries
    {
        public static readonly EmployeeQuery UsualSuspects = new EmployeeQuery
        {
            EmployeeNumber = @"in(458968574, 768767897, 342323323, 786878980, 767684322)"
        };

        public static EmployeeQuery Test(string employeeNumber)
        {
            return new EmployeeQuery { EmployeeNumber = "=" + employeeNumber };
        }
    }

    public partial class ServiceCRUDSteps<Service, DTO, EmployeeDTO>
    {
        protected EmployeeDTO[] Suts { get; set; }

        public override void FixtureSetUp()
        {
            base.FixtureSetUp();
            
            Mapper.CreateMap<DTO, DTO>();
            
            Find(Queries.UsualSuspects);
            Suts = EmployeesFound.ToArray();
        }    

        public override void SetUp()
        {
            if (Suts.Length == 0) return;

            var random = new Random().Next(Suts.Length);

            original = Clone(((DTO[])Suts[random].Get(DTOsName))[0]);

            proposed = Clone(original);
        }

        public override void TearDown() 
        {
            Restore();
        }
    }
}