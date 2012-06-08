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
            var type = analyzer.GetMarkedClasses((typeof (Test).Assembly)).First();
            var methodInfo = analyzer.GetMarkedMethods(type).First();
            
            var builder = new DelegateBuilder();

            Action action = builder.Build(type, methodInfo);

            Assert.DoesNotThrow(action.Invoke);
        }
    }
}