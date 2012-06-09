using System;
using System.Collections.Generic;

namespace Core {
    public class PerformanceSet {
        public string Name { get { return _type.Name; } }
        public Type Type { get { return _type; } }
        public IEnumerable<PerformanceUnit> PerformanceUnits { get{ return _units;}}

        private readonly Type _type;
        private readonly IEnumerable<PerformanceUnit> _units;

        public PerformanceSet(Type type, IEnumerable<PerformanceUnit> units) {
            _type = type;
            _units = units;
        }
    }
}