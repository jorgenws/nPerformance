using System;
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
            Type type = analyzer.GetMarkedClasses((typeof (Test).Assembly)).First();
            MethodInfo methodInfo = analyzer.GetMarkedMethods(type).First();

            var builder = new DelegateBuilder();
            Action action = builder.Build(type, methodInfo);

            var runner = new UnitRunner();

            Result result = runner.Run(type.Name, methodInfo.Name, action, 100);

            Assert.IsTrue(result.Success);
        }
    }
}
