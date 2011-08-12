using System.Collections.Generic;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
    public class CatalogBrowsingController
    {
        IReturnDepartments departments;

        public CatalogBrowsingController(IReturnDepartments departments)
        {
            this.departments = departments;
        }

        public IEnumerable<Department> get_the_main_departments_in_the_store()
        {
            return departments.get_the_main_departments_in_the_store();
        }

        public IEnumerable<Department> get_the_departments_in(Department parent_department)
        {
            return departments.get_the_departments_in(parent_department);
        }
    }
}