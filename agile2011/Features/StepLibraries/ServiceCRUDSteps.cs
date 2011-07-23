using System;
using System.Collections.Generic;
using AutoMapper;
using MbUnit.Framework;
using UltimateSoftware.Foundation.Services.Acceptance.Tests.Features;
using UltimateSoftware.Foundation.Services.Core;
using UltimateSoftware.Foundation.Services.Core.Query;

namespace Features
{
    public partial class ServiceCRUDSteps<Service, DTO, EmployeeDTO> : ServiceTest<Service>
        where EmployeeDTO : class 
        where DTO : class
    {
        protected virtual IEnumerable<DTO> DTOs
        {
            get { throw new NotImplementedException(); }
        }

        protected virtual EmployeeDTO[] Find(EmployeeQuery Query)
        {
            throw new NotImplementedException();
        }

        protected virtual DTO Get(DTO Original)
        {
            throw new NotImplementedException();
        }

        protected virtual UpdateResponse Update(DTO Proposed)
        {
            throw new NotImplementedException();
        }

        protected EmployeeDTO[] Suts { get; set; }

        public override void FixtureSetUp()
        {
            base.FixtureSetUp();
            Mapper.CreateMap<DTO, DTO>();
        }    

        public override void SetUp()
        {
            base.SetUp();

/*
            if (Suts.Length == 0)
            {
                return;
            }

            var random = new Random().Next(Suts.Length);

            Original = ((TObject[])Suts[random].Get(typeof(TObject).Name.Pluralize()))[0];

            Proposed = Clone(Original);

            Console.WriteLine(EmployeeNumber);
*/
        }
    }
}