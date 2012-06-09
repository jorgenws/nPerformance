using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using Attributes;

namespace Core {
    public class Analyzer : IAnalyzer {
        public IEnumerable<PerformanceSet> GetPerformanceSets(Assembly assembly) {
            var results = new Collection<PerformanceSet>();

            foreach (Type type in assembly.GetTypes()) {
                var attributes = type.GetCustomAttributes(typeof (Performance), false);
                if (attributes != null && attributes.Length > 0) {
                    IEnumerable<PerformanceUnit> units = GetMarkedMethods(type);                    
                    results.Add(new PerformanceSet(type, units));
                }                    
            }
            return results;
        }

        private IEnumerable<PerformanceUnit> GetMarkedMethods(Type type) {
            var results = new Collection<PerformanceUnit>();

            foreach (MethodInfo methodInfo in type.GetMethods()) {
                var attribute = Attribute.GetCustomAttribute(methodInfo, typeof (PerformanceTest));
                if (attribute != null && attribute is PerformanceTest) {
                    var runs = (attribute as PerformanceTest).Runs;
                    if (runs == 0)
                        runs = 100;
                    
                    if (methodInfo.ReturnType == typeof(void) && methodInfo.GetParameters().Length == 0)
                        results.Add(new PerformanceUnit(methodInfo) { Runs = runs });
                }

            }

            return results;
        }
    }

    public interface IAnalyzer {
        IEnumerable<PerformanceSet> GetPerformanceSets(Assembly assembly);        
    }
}
