using nothinbutdotnetstore.web.application.stubs;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
    public class ViewProductsForDepartment : IProcessAnApplicationBehaviour
    {
        IRenderReports view_engine;
        IReturnProducts product_repository;

        public ViewProductsForDepartment(IRenderReports view_engine, IReturnProducts product_repo)
        {
            this.product_repository = product_repo;
            this.view_engine = view_engine;
        }

        public ViewProductsForDepartment()
            : this(Stub.of<StubReportEngine>(), Stub.of<StubProductRepository>())
        {
        }

        public void process(IContainRequestInformation request)
        {
            view_engine.render(product_repository.get_the_products_of(request.map<Department>()));
        }
    }
}