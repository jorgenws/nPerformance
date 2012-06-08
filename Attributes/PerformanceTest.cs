using System;

namespace Attributes {
    [AttributeUsage(AttributeTargets.Method)]
    public class PerformanceTest : Attribute {
        public int Runs { get; set; }
    }
}