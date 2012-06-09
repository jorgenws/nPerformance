using System;
using System.Collections.Generic;
using System.Reflection;

namespace Core {
    public class PerformanceUnit {
        public string Name { get { return MethodInfo.Name; } }
        public int Runs { get; set; }
        public MethodInfo MethodInfo { get; private set; }

        public Action MethodToInvoke { get; set; }

        public IEnumerable<Result> Results{ get; set;}

        public PerformanceUnit(MethodInfo methodInfo) {
            MethodInfo = methodInfo;
        }
    }
}