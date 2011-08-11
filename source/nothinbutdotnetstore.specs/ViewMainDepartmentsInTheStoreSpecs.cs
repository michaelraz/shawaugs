using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;
using nothinbutdotnetstore.web.application;
using nothinbutdotnetstore.web.application.catalogbrowsing;
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

            It should_ask_the_department_repository_for_the_main_departments = () =>
                department_repository.received(x => x.get_the_main_departments_in_the_store());

            static IContainRequestInformation request;
            static IReturnDepartments department_repository;
        }
    }
}