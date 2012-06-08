using System.Threading;
using Attributes;

namespace CoreTest {
    [Performance]
    public class Test {
        [PerformanceTest]
        public void TestMethod() {
            Thread.Sleep(1);
        }        
    }
}