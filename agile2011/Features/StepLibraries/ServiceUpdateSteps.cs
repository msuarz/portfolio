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

            AssertCanUpdate(proposed, Field, Value);
        }

        protected void AssertCanUpdate(DTO Original, string Field, object Value)
        {
            var Proposed = Clone(Original);

            EnsureUpdate(Proposed, Field, Value);

            try
            {
                var Error = EmployeeNumber + " could not set " + Field + " to " + (Value ?? "null");

                var ActualValue = Get(Original).Get(Field);

                Assert.AreNotEqual(Proposed.Get(Field), ActualValue, Error);
            }
            finally
            {
                EnsureUpdate(Original);
            }
        }

        protected void EnsureUpdate(DTO Proposed, string Field, object Value)
        {
            Proposed.Set(Field, Value);
            EnsureUpdate(Proposed);
        }

        protected void EnsureUpdate(DTO Proposed)
        {
            var Response = Update(Proposed);

            if (Response.HasErrors) Assert.Fail(EmployeeNumber + Response.Message());
        }

        protected virtual void Restore()
        {
            EnsureUpdate(original);
        }
    }
}