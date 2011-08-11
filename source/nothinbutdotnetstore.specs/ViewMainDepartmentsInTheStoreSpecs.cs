using System;
using System.Collections.Generic;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{
    [Subject(typeof(ViewMainDepartmentsInTheStore))]
    public class ViewMainDepartmentsInTheStoreSpecs
    {
        public abstract class concern : Observes<IProcessAnApplicationBehaviour,
                                            ViewMainDepartmentsInTheStore>
        {
        }

        public class when_processing_a_request : concern
        {
            Establish c = () =>
            {
                department_repository = depends.on<IReturnDepartments>();
                request = fake.an<IContainRequestInformation>();
            };

            Because b = () =>
                sut.process(request);

            It should_ask_the_department_repository_for_a_department_iterator = () =>
                department_repository.received(x => x.get_departments_for(request));

            static IContainRequestInformation request;
            static IReturnDepartments department_repository;
        }
    }

    interface IReturnDepartments
    {
        IEnumerator<Department> get_departments_for(IContainRequestInformation request);
    }

    class Department
    {
    }

    public class ViewMainDepartmentsInTheStore : IProcessAnApplicationBehaviour
    {
        public void process(IContainRequestInformation request)
        {
            throw new NotImplementedException();
        }
    }
}