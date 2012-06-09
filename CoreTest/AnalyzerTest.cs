using System;
using System.Collections.Generic;
using System.Linq;
using Core;
using NUnit.Framework;

namespace CoreTest {
    [TestFixture]
    public class AnalyzerTest {
        [Test]
        public void GetMarkedClasses_TestHasAttributes_GetsTestType() {
            var analyzer = new Analyzer();
            IEnumerable<PerformanceSet> sets = analyzer.GetPerformanceSets((typeof (Test)).Assembly);
            PerformanceSet type = sets.First();
            Assert.IsTrue(type.Name == typeof(Test).Name);
        }

        [Test]
        public void GetMarkedMethods_TestMethodHasAttribute_ReturnstestMethod() {
            var analyzer = new Analyzer();
            IEnumerable<PerformanceSet> sets = analyzer.GetPerformanceSets((typeof (Test).Assembly));
            PerformanceSet set = sets.First();
            PerformanceUnit unit = set.PerformanceUnits.First();


            Assert.AreEqual("TestMethod", unit.Name);
        }
    }
}
