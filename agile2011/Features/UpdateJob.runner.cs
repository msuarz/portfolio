using MbUnit.Framework;

namespace Features 
{
    [TestFixture]
    public partial class UpdateJob 
    {

        
        [Test]
        public void UpdateFields()
        {         
            Update("HourlyOrSalaried", "H", "S");        
            Update("ReasonCode", "100", "101");        
            Update("FullOrPartTime", "F", "P");        
            Update("JobCode", "DELIV", "SALES");        
            Update("AlternateTitle", "Magician", "Doctor");        
            Update("OrgLevel1", "EAST", "Z");        
            Update("OrgLevel2", "HQ", null);        
            Update("OrgLevel3", "EXEC", null);        
            Update("OrgLevel4", "SOFLO", null);        
            Update("ShiftCode", "01", "Z");        
            Update("Seasonal", true, false);        
            Update("Agricultural", true, false);        
            Update("DirectLabor", true, false);
        }

    }
}
