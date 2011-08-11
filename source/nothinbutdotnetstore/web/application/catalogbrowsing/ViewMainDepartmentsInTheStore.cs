using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
    public class ViewMainDepartmentsInTheStore : IProcessAnApplicationBehaviour
    {
        IReturnDepartments department_repository;

        public ViewMainDepartmentsInTheStore(IReturnDepartments department_repository)
        {
            this.department_repository = department_repository;
        }

        public void process(IContainRequestInformation request)
        {
            department_repository.get_the_main_departments_in_the_store();
        }
    }
}