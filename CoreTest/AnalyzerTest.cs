using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Core;
using NUnit.Framework;

namespace CoreTest {
    [TestFixture]
    public class AnalyzerTest {
        [Test]
        public void GetMarkedClasses_TestHasAttributes_GetsTestType() {
            var analyzer = new Analyzer();
            IEnumerable<Type> types = analyzer.GetMarkedClasses((typeof (Test)).Assembly);
            Type type = types.First();            
            Assert.IsTrue(type == typeof(Test));
        }

        [Test]
        public void GetMarkedMethods_TestMethodHasAttribute_ReturnstestMethod() {
            var analyzer = new Analyzer();
            IEnumerable<MethodInfo> methodInfos = analyzer.GetMarkedMethods(typeof (Test));
            MethodInfo methodInfo = methodInfos.First();

            Assert.AreEqual("TestMethod", methodInfo.Name);

        }
    }
}
