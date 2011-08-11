using System.Collections.Generic;
 using Machine.Specifications;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;
 using nothinbutdotnetstore.web.application;
 using nothinbutdotnetstore.web.application.catalogbrowsing;
 using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{  
    [Subject(typeof(ViewProductsForDepartment))]  
    public class ViewProductsForDepartmentSpecs
    {
        public abstract class concern : Observes<IProcessAnApplicationBehaviour, ViewProductsForDepartment>
        {
        
        }

        public class when_process_is_executed : concern
        {
            Establish c = () =>
            {
                view_engine = depends.on<IRenderReports>();
                product_repository = depends.on<IReturnProducts>();
                request = fake.an<IContainRequestInformation>();
                department = fake.an<Department>();

                products = new List<Product> { new Product() };

                request.setup(x => x.map<Department>()).Return(department);
                product_repository.setup(x => x.get_the_products_of(department)).Return(products);

            };

            Because b = () =>
                sut.process(request);


            It should_ask_the_product_repo_for_products_of_a_department = () =>
            {
            };

            It should_pass_the_products_from_the_repository_to_the_view_engine_to_be_rendered = () =>
                view_engine.received(x => x.render(products));

            static IContainRequestInformation request;
            static IReturnProducts product_repository;
            static IRenderReports view_engine;
            static IEnumerable<Product> products;
            static Department department;
        }
    }
}
