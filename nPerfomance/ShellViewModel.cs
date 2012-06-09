using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using Core;
using System.Windows.Forms;

namespace nPerfomance {
    public class ShellViewModel : IShell {
        public ObservableCollection<PerformanceSet> Sets { get; set; }

        private readonly IAnalyzer _analyzer;

        public ShellViewModel(IAnalyzer analyzer) {
            Sets = new ObservableCollection<PerformanceSet>();

            _analyzer = analyzer;
        }

        public void Open() {
            var openFileDialog = new OpenFileDialog {Filter = "Assembly|*.dll"};


            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                try {
                    Assembly assembly = Assembly.LoadFrom(openFileDialog.FileName);
                    IEnumerable<PerformanceSet> sets = _analyzer.GetPerformanceSets(assembly);

                    Sets.Clear();
                    foreach (PerformanceSet set in sets)
                        Sets.Add(set);
                }
                catch (Exception) {
                    Sets.Clear();
                }
            }
        }
    }
}
