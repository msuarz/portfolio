using AutoMapper;
using MbUnit.Framework;
using UltimateSoftware.Foundation.Services.Acceptance.Tests;
using UltimateSoftware.Foundation.Services.Common.Tests;
using UltimateSoftware.Foundation.Services.Core;

namespace Features
{
    public partial class ServiceCRUDSteps<Service, DTO, EmployeeDTO>
    {
        protected string EmployeeNumber
        {
            get { return "[" + original.Get("EmployeeIdentifier").As<EmployeeNumberIdentifier>().EmployeeNumber + "]"; }
        }

        protected DTO original;
        protected DTO proposed;

        public void Original(DTO Entity) { Assert.IsTrue(Entity.Matches(original)); }

        public void Proposed(DTO Entity) { Entity.Update(proposed); }

        public void Actual(DTO Entity) { Assert.IsTrue(Entity.Matches(actual)); }

        protected DTO actual { get { return Get(proposed); } }

        protected virtual DTO Clone(DTO Original) 
        {
            var Clone = Mapper.Map<DTO, DTO>(Original);

            Clone.Set("EmployeeIdentifier", Original.Get("EmployeeIdentifier").As<EmployeeIdentifier>().Clone());

            return Clone;
        }
    }
}