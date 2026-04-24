using Microsoft.VisualStudio.TestTools.UnitTesting;
using testclass;
namespace DistanceConsoleTests
{
    [TestClass]
    public class DistanceTests
    {
        [TestMethod]
        public void Add_TwoDistanceObjects_ReturnsCorrectSum()
        {
            Distance d1 = new Distance(15);
            Distance d2 = new Distance(25);
            Distance result = Distance.Add(d1, d2);
            Assert.AreEqual(40, result.Kilometer);
        }
    }
}