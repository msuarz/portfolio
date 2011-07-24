using MbUnit.Framework;
using UltimateSoftware.Foundation.Services.Common.Tests;

namespace Features
{
    public partial class ServiceCRUDSteps<Service, DTO, EmployeeDTO>
    {
        public void Update()
        {
            Update(proposed);
        }

        public void Update(string Field, object Value, object AltValue)
        {
            if (proposed.Get(Field).Equals(Value))
            {
                Value = AltValue;
            }

            AssertCanUpdate(Field, Value);
        }

        protected void AssertCanUpdate(string Field, object Value)
        {
            proposed.Set(Field, Value);

            EnsureUpdate(proposed);

            try
            {
                var Error = EmployeeNumber + " could not set " + Field + " to " + (Value ?? "null");

                Assert.AreNotEqual(original.Get(Field), actual.Get(Field), Error);
            }
            finally
            {
                Restore();
            }
        }

        protected virtual void Restore()
        {
            EnsureUpdate(original);
        }

        protected void EnsureUpdate(DTO DTO)
        {
            var Response = Update(DTO);

            if (Response.HasErrors) Assert.Fail(EmployeeNumber + Response.Message());
        }
    }
}