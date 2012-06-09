using System;
using System.Linq;
using Core;
using NUnit.Framework;

namespace CoreTest {
    [TestFixture]
    public class DelegateBuilderTest {
        [Test]
        public void Build_BuildAnActionFromTypeAndMethodInfo_ReturnsActionThatDoesNotThrow() {
            var analyzer = new Analyzer();
            PerformanceSet set = analyzer.GetPerformanceSets((typeof (Test).Assembly)).First();
            PerformanceUnit performanceUnit = set.PerformanceUnits.First();
            
            var builder = new DelegateBuilder();

            Action action = builder.Build(set.Type, performanceUnit.MethodInfo);

            Assert.DoesNotThrow(action.Invoke);
        }
    }
}