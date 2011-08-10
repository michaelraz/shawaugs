using System;
using System.Data;
using Machine.Specifications;
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
            };

            Because b = () =>
                sut.initialize();

            It should_connect_to_the_database = () =>
                connection.received(x => x.Open());

            static IDbConnection connection;

                
                
        } 
    }
}