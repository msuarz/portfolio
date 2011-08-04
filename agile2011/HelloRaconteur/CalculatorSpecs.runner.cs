using MbUnit.Framework;

namespace HelloRaconteur 
{
    [TestFixture]
    public partial class CalculatorSpecs 
    {

        
        [Test]
        public void ShouldAddTwoNumbers()
        {         
            The_sum_of__and(2, 2);        
            Should_be(4);
        }

    }
}
