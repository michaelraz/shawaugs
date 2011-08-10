using System;
using System.Data;
using System.Security.Principal;
using System.Threading;
using Machine.Specifications;
using Rhino.Mocks;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace nothinbutdotnetstore.specs
{
    public class CalculatorSpecs
    {
        public class concern : Observes<Calculator>
        {
            
        }

        public class when_adding_two_numbers : concern
        {
            Because b = () =>
                result = sut.add(2, 3);


            It should_return_the_sum = () =>
                result.ShouldEqual(5);


            static int result; 
        } 

        public class when_attempting_to_add_a_negative_number : concern
        {
            Because b = () =>
                spec.catch_exception(() => sut.add(2, -2));

            It should_throw_an_argument_exception = () =>
                spec.exception_thrown.ShouldBeAn<ArgumentException>();

            static int result; 
        } 

        public class when_initializing : concern
        {
            Establish c = () =>
            {
                connection = depends.on<IDbConnection>();
                depends.on(3);
                command = fake.an<IDbCommand>();

                connection.setup(x => x.CreateCommand()).Return(command);
            };

            Because b = () =>
                sut.initialize();

            It should_connect_to_the_database = () =>
                connection.received(x => x.Open());

            It should_run_a_query = () =>
                command.received(x => x.ExecuteNonQuery());
                

            static IDbConnection connection;
            static IDbCommand command;
        } 

        public class when_shutting_off_and_they_are_in_the_correct_security_group   : concern
        {
            Establish c = () =>
            {
                principal = fake.an<IPrincipal>();
                principal.setup(x => x.IsInRole(Arg<string>.Is.Anything)).Return(true);

                spec.change(() => Thread.CurrentPrincipal).to(principal);
            };
            Because b = () =>
                sut.shut_off();

            It should_shut_down = () =>
                sut.is_off.ShouldBeTrue();

            static IPrincipal principal;
        } 

        public class when_shutting_off_and_they_are_not_in_the_correct_security_group   : concern
        {
            Establish c = () =>
            {
                principal = fake.an<IPrincipal>();
                principal.setup(x => x.IsInRole(Arg<string>.Is.Anything)).Return(false);

                spec.change(() => Thread.CurrentPrincipal).to(principal);
            };
            Because b = () =>
                sut.shut_off();

            It should_shut_down = () =>
                sut.is_off.ShouldBeFalse();

            static IPrincipal principal;
        } 
    }
}