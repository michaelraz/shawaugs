using System.Collections.Generic;

namespace nothinbutdotnetstore.web.application
{
    public interface IReturnDepartments
    {
        IEnumerable<Department> get_the_main_departments_in_the_store();
        IEnumerable<Department> get_related_departments_of_a_department(Department parent_department);
    }
}