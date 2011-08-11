using System.Collections.Generic;

namespace nothinbutdotnetstore.web.application
{
    public interface IReturnDepartments
    {
        IEnumerable<Department> get_the_main_departments_in_the_store();
        IEnumerable<Department> get_the_departments_in(Department parent_department);
    }
}