using System.Collections.Generic;
using System.Linq;

namespace nothinbutdotnetstore.web.application.stubs
{
    public class StubDepartmentRepository : IReturnDepartments
    {
        public IEnumerable<Department> get_the_main_departments_in_the_store()
        {
            return Enumerable.Range(1, 100).Select(x => new Department{name = x.ToString("Department 0")});
        }
    }
}