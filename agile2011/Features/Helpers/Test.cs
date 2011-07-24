using MbUnit.Framework;

namespace Features
{
    [TestFixture]
    public class Test
    {
         [Test]
         public void IsEqualTo()
         {
             Assert.IsTrue(25000m.IsEqualTo(25000.0005m));
         }
    }
}