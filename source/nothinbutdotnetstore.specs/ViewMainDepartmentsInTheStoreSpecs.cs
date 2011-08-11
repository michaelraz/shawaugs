using System.Collections.Generic;
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
                view_engine = depends.on<IRenderDepartments>();
                department_repository = depends.on<IReturnDepartments>();

                request = fake.an<IContainRequestInformation>();
            };

            Because b = () =>
                sut.process(request);

            It should_ask_the_department_repository_for_the_main_departments = () =>
                department_repository.received(x => x.get_the_main_departments_in_the_store());

            It should_pass_the_response_from_the_repository_to_the_view_engine_to_be_rendered = () =>
                view_engine.received(x => x.render(departments));

            static IContainRequestInformation request;
            static IReturnDepartments department_repository;
            static IRenderDepartments view_engine;

            static IEnumerable<Department> departments = null;
        }
    }

    interface IRenderDepartments
    {
        void render(IEnumerable<Department> departments);
    }
}