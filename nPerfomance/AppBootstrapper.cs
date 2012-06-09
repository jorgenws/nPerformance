using Core;
using Ninject;
using System;
using System.Collections.Generic;
using Caliburn.Micro;

namespace nPerfomance {
	public class AppBootstrapper : Bootstrapper<IShell> {
	    private IKernel _kernel;

		protected override void Configure() {
		    _kernel = new StandardKernel();

		    _kernel.Bind<IWindowManager>().To<WindowManager>();
		    _kernel.Bind<IEventAggregator>().To<EventAggregator>();

		    _kernel.Bind<IShell>().To<ShellViewModel>();
		    _kernel.Bind<IAnalyzer>().To<Analyzer>();
		}

		protected override object GetInstance(Type serviceType, string key){
            return _kernel.Get(serviceType);
		}

		protected override IEnumerable<object> GetAllInstances(Type serviceType) {
		    return _kernel.GetAll(serviceType);
		}

		protected override void BuildUp(object instance) {
		    _kernel.Inject(instance);
		}
	}
}
