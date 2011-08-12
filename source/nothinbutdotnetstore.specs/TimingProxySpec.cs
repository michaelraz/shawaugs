using System;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;
using Machine.Specifications;
using nothinbutdotnetstore.web.application.catalogbrowsing;
using nothinbutdotnetstore.web.core;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs
{
	[Subject(typeof(TimingProxy))]
	public class TimingProxySpec
	{
		public abstract class concern : Observes<IProcessAnApplicationBehaviour, TimingProxy>
		{
		}

		public class when_processing_a_request : concern
		{
			Establish c = () =>
			{
				logger = depends.on<ILogger>();
				real_command = depends.on<IProcessAnApplicationBehaviour>();
				request = fake.an<IContainRequestInformation>();

			};

			Because b = () =>
				sut.process(request);

			It should_delegate_processing_to_the_real_command = () =>
				real_command.received(cmd => cmd.process(request));

			It should_log_the_elapsed_time = () =>
				logger.received(log => log.Log("The command took {0} to process {1}.", Arg<TimeSpan>.Is.Anything, Arg<IProcessAnApplicationBehaviour>.Is.Anything));

			static IContainRequestInformation request;
			static ILogger logger;
			static IProcessAnApplicationBehaviour real_command;
		}
	}
}