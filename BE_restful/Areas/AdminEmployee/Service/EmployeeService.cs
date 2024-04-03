using BE_restful.Models;

namespace BE_restful.Areas.AdminEmployee.Service;

public interface EmployeeService
{
    public List<Employee> GetAllEmloy();
    public List<Employee> GetEmloy();
    public bool AddEmloy(Employee employ);
    public bool DeleteEmloy(int id);
    public bool UpdateEmloy(Employee employ);
}
