 using System.Collections.Generic;
 using Machine.Specifications;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;
 using nothinbutdotnetstore.web.application;
 using nothinbutdotnetstore.web.application.catalogbrowsing;
 using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{  
    [Subject(typeof(ViewTheDepartmentsInADepartment))]  
    public class ViewTheDepartmentsInADepartmentSpecs
    {
        public abstract class concern : Observes<IProcessAnApplicationBehaviour,
                                            ViewTheDepartmentsInADepartment>
        {
        
        }

   
        public class when_processing_a_request : concern
        {
            Establish c = () =>
            {
                view_engine = depends.on<IRenderReports>();
                department_repository = depends.on<IReturnDepartments>();
                request = fake.an<IContainRequestInformation>();
                parent_department = fake.an<Department>();

                related_departments = new List<Department> { new Department() };

                request.setup(x => x.map<Department>()).Return(parent_department);
                department_repository.setup(x => x.get_the_departments_in(parent_department)).Return(related_departments);

            };

            Because b = () =>
                sut.process(request);


            It should_ask_the_department_repo_for_related_departments_of_a_department = () =>
            {
            };

            It should_pass_the_response_from_the_repository_to_the_view_engine_to_be_rendered = () =>
                view_engine.received(x => x.render(related_departments));

            static IContainRequestInformation request;
            static IReturnDepartments department_repository;
            static IRenderReports view_engine;
            static IEnumerable<Department> related_departments;
            static Department parent_department;
        }
    }
}
