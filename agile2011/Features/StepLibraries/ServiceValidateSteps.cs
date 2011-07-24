using System.Collections.Generic;
using System.Linq;
using MbUnit.Framework;
using UltimateSoftware.Foundation.Services.Common.Tests;
using UltimateSoftware.Foundation.Services.Core;

namespace Features
{
    public partial class ServiceCRUDSteps<Service, DTO, EmployeeDTO>
    {
        public void Validate(string Field, object Value, string Message)
        {
            AssertValidates(proposed, Field, Value, Message);
        }

        public void Validate_Required_Fields(string[] RequiredFields)
        {
            foreach (var RequiredField in RequiredFields)
            {
                Assert.IsTrue(proposed.Get(RequiredField).HasValue(), "Bad data, required field " + RequiredField + " should not be empty");

                AssertValidates(proposed, RequiredField, null, "The following field is required:");
            }
        }

        public void Validate_UCD_Fields(string[] UcdFields)
        {
            foreach (var UcdField in UcdFields)
                AssertValidates(proposed, UcdField, "BAD UCD", "Lookup code does not exist.");
        }

        void AssertValidates(DTO Original, string Field, object Value, string Message)
        {
            var Proposed = Clone(Original);
            
            Proposed.Set(Field, Value);

            Update(Proposed);

            Assert.IsTrue(status.HasErrors, "Update did not fail");

            var Messages = Results[0].Messages;

            AssertPropertyNameOnEveryMessage(Messages);
            Assert.IsFalse(Messages.Any(m => m.PropertyName == "Code"), "Found Generic Property Name in error message");
            Assert.IsTrue(Messages.Any(m => m.Message == Message && m.PropertyName == Field), "Did not report error");        
        }

        void AssertPropertyNameOnEveryMessage(IEnumerable<OperationMessage> Messages) 
        {
            var MissingProperty = Messages.FirstOrDefault(m => m.PropertyName.IsNullOrWhiteSpace());
            var MissingPropertyMessage = MissingProperty != null ? MissingProperty.Message : string.Empty;

            Assert.IsTrue(MissingProperty == null, "Missing Property in Message: " + MissingPropertyMessage);
        }
    }
}