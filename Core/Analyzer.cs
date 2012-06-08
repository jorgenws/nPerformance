using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using Attributes;

namespace Core {
    public class Analyzer {
        public IEnumerable<Type> GetMarkedClasses(Assembly assembly) {
            var results = new Collection<Type>();

            foreach (Type type in assembly.GetTypes()) {
                var attributes = type.GetCustomAttributes(typeof (Performance), false);
                if(attributes!=null && attributes.Length>0) {
                    results.Add(type);
                }
            }

            return results;
        }

        public IEnumerable<MethodInfo> GetMarkedMethods(Type type) {
            var results = new Collection<MethodInfo>();

            foreach (MethodInfo methodInfo in type.GetMethods()) {
                var attribute = Attribute.GetCustomAttribute(methodInfo, typeof (PerformanceTest));
                var x = attribute as PerformanceTest;                
                if (attribute != null)
                    if (methodInfo.ReturnType == typeof(void) && methodInfo.GetParameters().Length == 0)
                        results.Add(methodInfo);
            }

            return results;
        }
    }
}
