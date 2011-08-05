using MbUnit.Framework;

namespace HelloRaconteur 
{
    public partial class Calculator
    {
        int result;

        void The_sum_of__and(int a, int b)
        {
            result = a + b;
        }

        void Should_be(int expectedResult)
        {
            Assert.AreEqual(expectedResult, result);
        }
    }
}
