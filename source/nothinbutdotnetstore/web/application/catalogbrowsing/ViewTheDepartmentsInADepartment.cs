using nothinbutdotnetstore.web.application.stubs;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
    public class ViewTheDepartmentsInADepartment : IProcessAnApplicationBehaviour
    {
        IRenderReports report_engine;
        IReturnDepartments department_repository;

        public ViewTheDepartmentsInADepartment(IRenderReports report_engine, IReturnDepartments department_repository)
        {
            this.report_engine = report_engine;
            this.department_repository = department_repository;
        }


        public void process(IContainRequestInformation request)
        {
            report_engine.render(department_repository.get_the_departments_in(request.map<Department>()));
        }
    }
}