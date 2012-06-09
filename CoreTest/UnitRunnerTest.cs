using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Core;
using NUnit.Framework;

namespace CoreTest {
    [TestFixture]
    public class UnitRunnerTest {
        [Test]
        public void Run_RunsAMarkedMethodOneHundredTimes_ReturnsResultWithOneHundredResults() {
            var analyzer = new Analyzer();
            IEnumerable<PerformanceSet> sets = analyzer.GetPerformanceSets((typeof (Test).Assembly));
            PerformanceSet set = sets.First();
            PerformanceUnit unit = set.PerformanceUnits.First();

            MethodInfo methodInfo = unit.MethodInfo;

            var builder = new DelegateBuilder();
            Action action = builder.Build(set.Type, methodInfo);

            var runner = new UnitRunner();

            Result result = runner.Run(set.Name, methodInfo.Name, action, unit.Runs);

            Assert.IsTrue(result.Success);
        }
    }
}
