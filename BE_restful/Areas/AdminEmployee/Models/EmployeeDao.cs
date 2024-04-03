using BE_restful.Areas.AdminEmployee.Service;
using BE_restful.Models;
using System.Diagnostics;

namespace BE_restful.Areas.AdminEmployee.Models;

public class EmployeeDao : EmployeeService
{
    private readonly ArtsDbContext _context;
    public EmployeeDao(ArtsDbContext context)
    {
        _context = context;
    }
    public List<Employee> GetAllEmloy()
    {
        try
        {
            var res = _context.Employees.ToList();
            if(res != null)
            {
                return res;
            }
            return [];

        }catch (Exception)
        {
            return [];
        }
    }
    public List<Employee> GetEmloy()
    {
        try
        {
            var Employ = (from pi in _context.Employees
                                      select new Employee
                                      {
                                          EmployeeId = pi.EmployeeId,
                                          EmployeeName = pi.EmployeeName,
                                          Username = pi.Username,
                                          RoleId = pi.RoleId,
                                          ManagerId = pi.ManagerId,
                                          Password = pi.Password,
                                          Role = (from p in _context.Roles
                                                     where p.RoleId == pi.RoleId
                                                  select p).FirstOrDefault()

                                      }).ToList();

            return Employ;
        }
        catch (Exception)
        {
            return [];
        }
    }
    public bool AddEmloy(Employee employee)
    {
        try
        {
            var checkusername = _context.Employees.FirstOrDefault(e => e.Username == employee.Username);
            if (checkusername != null)
            {
                // Nếu tên người dùng đã tồn tại, không thêm nhân viên mới và trả về false
                return false;
            }

            _context.Employees.Add(employee);
            return _context.SaveChanges() > 0;
        }
        catch (Exception)
        {
            
            return false;
        }
    }

    public bool DeleteEmloy(int id)
    {
        try
        {
            var p = _context.Employees.FirstOrDefault(e => e.EmployeeId.Equals(id));
            if(p != null)
            {
                _context.Employees.Remove(p);
                return _context.SaveChanges() > 0;
            }
            return true;
        }catch(Exception)
        {
            return false;
        }
    }
    public bool UpdateEmloy(Employee employ)
    {
        try
        {
            var p = _context.Employees.FirstOrDefault(u => u.EmployeeId == employ.EmployeeId);
            if(p != null)
            {
                p.EmployeeName = employ.EmployeeName;
                return _context.SaveChanges() > 0;
            }
            return true;
        }catch (Exception)
        {
            return false;
        }
    }
}
