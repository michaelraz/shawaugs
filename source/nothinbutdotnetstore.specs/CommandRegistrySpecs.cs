using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using nothinbutdotnetstore.web.core;
using developwithpassion.specifications.extensions;

namespace nothinbutdotnetstore.specs
{
    [Subject(typeof(CommandRegistry))]
    public class CommandRegistrySpecs
    {
        public abstract class concern : Observes<IFindCommandsThatCanProcessRequests,
                                            CommandRegistry>
        {
        }

        public class when_finding_a_command_that_can_process_a_request : concern
        {
            public class and_it_has_the_command : when_finding_a_command_that_can_process_a_request
            {
                Establish c = () =>
                {
                    the_command_that_can_process_the_request = fake.an<IProcessOneSpecificRequest>();
                    all_commands = Enumerable.Range(1, 100).Select(x => fake.an<IProcessOneSpecificRequest>()).ToList();
                    all_commands.Add(the_command_that_can_process_the_request);

                    request = fake.an<IContainRequestInformation>();
                    the_command_that_can_process_the_request.setup(x => x.can_process(request)).Return(true);


                    depends.on<IEnumerable<IProcessOneSpecificRequest>>(all_commands);
                };

                Because b = () =>
                    result = sut.get_command_for(request);

                It should_return_the_command_to_the_caller = () =>
                    result.ShouldEqual(the_command_that_can_process_the_request);

                static IProcessOneSpecificRequest the_command_that_can_process_the_request;
                static IList<IProcessOneSpecificRequest> all_commands;
            }

            public class and_it_does_not_have_the_command : when_finding_a_command_that_can_process_a_request
            {
                Establish c = () =>
                {
                    all_commands = Enumerable.Range(1, 100).Select(x => fake.an<IProcessOneSpecificRequest>()).ToList();
                    request = fake.an<IContainRequestInformation>();
                    the_null_command = fake.an<IProcessOneSpecificRequest>();
                    depends.on<IEnumerable<IProcessOneSpecificRequest>>(all_commands);
                    depends.on<MissingCommandFactory>(() => the_null_command);
                };

                Because b = () =>
                    result = sut.get_command_for(request);

                It should_return_the_special_case = () =>
                    result.ShouldEqual(the_null_command);

                static IList<IProcessOneSpecificRequest> all_commands;
                static IProcessOneSpecificRequest the_null_command;
            }

            static IProcessOneSpecificRequest result;
            static IContainRequestInformation request;
        }
    }
}