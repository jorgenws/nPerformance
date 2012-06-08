using System;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Core {
    public class UnitRunner {
        public Result Run(string className, string methodName, Action action, int repetitions) {
            
            WarmUp(action);

            var stopwatch = new Stopwatch();

            var result = new Result {
                                        ClassName = className,
                                        MethodName = methodName,
                                        Runs = repetitions
                                    };

            try {
                for (int i = 0; i < repetitions; i++) {
                    stopwatch.Reset();
                    stopwatch.Start();
                    action.Invoke();
                    stopwatch.Stop();

                    result.ResultsInTicks.Add(stopwatch.ElapsedTicks);
                }
            }
            catch (Exception) {
                result.Success = false;
            }

            return result;
        }

        private bool WarmUp(Action action) {
            bool result = true;
            
            try {
                for (int i = 0; i < 5; i++)
                    action.Invoke();
            }
            catch (Exception) {
                result = false;
            }

            return result;
        }
    }

    public class Result {
        public string ClassName { get; set;}
        public string MethodName { get; set;}
        public int Runs { get; set;}
        public Collection<long> ResultsInTicks { get; set;}
        public bool Success { get; set; }

        public Result() {
            ResultsInTicks = new Collection<long>();
            Success = true;
        }
    }
}
