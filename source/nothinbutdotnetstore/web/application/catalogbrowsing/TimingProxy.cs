using System.Diagnostics;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
	public class TimingProxy : IProcessAnApplicationBehaviour
	{
		IProcessAnApplicationBehaviour inner;
		ILogger logger;

		public TimingProxy(IProcessAnApplicationBehaviour inner, ILogger logger)
		{
			this.inner = inner;
			this.logger = logger;
		}

		public void process(IContainRequestInformation request)
		{
			var timer = Stopwatch.StartNew();
			inner.process(request);
			timer.Stop();
			logger.Log("The command took {0} to process {1}.", timer.Elapsed, request);
		}
	}
}