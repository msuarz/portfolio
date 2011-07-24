using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
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

        public virtual void Original(DTO DTO)
        {
            DTO.Update(proposed);
            
            EnsureUpdate(proposed);
            
            proposed = Clone(actual);

            ClearWriteOnlyFields(DTO);
            
            DTO.ShouldMatch(proposed);
        }

        public void Proposed(DTO DTO)
        {
            DTO.Update(proposed);
        }

        public void Proposed(string Field, double Times)
        {
            proposed.Set(Field, Math.Round((decimal)proposed.Get(Field) * (decimal)Times, 4));
        }

        public void Actual(DTO DTO)
        {
            DTO.ShouldMatch(actual);
        }

        protected DTO actual
        {
            get { return Get(original); }
        }

        protected virtual DTO Clone(DTO Original) 
        {
            var Clone = Mapper.Map<DTO, DTO>(Original);

            Clone.Set("EmployeeIdentifier", Original.Get("EmployeeIdentifier").As<EmployeeIdentifier>().Clone());

            return Clone;
        }

        protected static readonly string DTOName = typeof (DTO).Name;
        protected static readonly string DTOsName = DTOName.Pluralize();

        protected IEnumerable<DTO> DTOs
        {
            get
            {
                return EmployeesFound.SelectMany(x => (DTO[]) x.Get(DTOsName));
            }
        }

        protected void AssertFound(DTO DTO)
        {
            DTOs.ShouldContain(DTO);
        }


    }
}