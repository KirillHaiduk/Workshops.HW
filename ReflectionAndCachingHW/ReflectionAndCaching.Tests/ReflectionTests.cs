using NUnit.Framework;
using ReflectionAndCaching.Tests.Source;
using ReflectionTask;

namespace ReflectionAndCaching.Tests
{
    [TestFixture]
    public class ReflectionTests
    {
        [Test]
        public void CustomComparerTest_For2EqualObjects_ReturnsEquality()
        {
            var car1 = new Car { Id = 1, Brand = "Audi", Model = "A8", Year = 2010 };

            var car2 = new Car { Id = 1, Brand = "Audi", Model = "A8", Year = 2010 };

            var comparer = new CustomComparer<Car>();

            Assert.IsTrue(comparer.Equals(car1, car2));
        }

        [Test]
        public void CustomComparerTest_For2NonEqualObjects_ReturnsInequality()
        {
            var car1 = new Car { Id = 2, Brand = "Mercedes", Model = "C200", Year = 2012 };

            var car2 = new Car { Id = 2, Brand = "Mercedes", Model = "E320", Year = 2012 };

            var comparer = new CustomComparer<Car>();

            Assert.IsFalse(comparer.Equals(car1, car2));
        }        
    }
}
