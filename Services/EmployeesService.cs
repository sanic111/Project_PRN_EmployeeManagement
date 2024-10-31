using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.Models;
using DataAccessLayer;
namespace Services
{
    public class EmployeesService
    {
        private readonly EmployeesDAO _employeesDAO = new();
        public List<Employees> GetAllEmployees() 
        {
            return _employeesDAO.GetAll();
        }
        public Employees GetEmployeeById(int id) 
        {
            return _employeesDAO.GetById(id);
        }
        public void AddEmployee(Employees employee) 
        {
            _employeesDAO.Add(employee);
        }
        public void UpdateEmployee(Employees employee)
        {
            _employeesDAO.Update(employee);
        }
        public void DeleteEmployee(Employees employee) {
            _employeesDAO.Delete(employee);
        }
        public List<Employees> SearchEmployees(string searchText, string searchBy) {
            return _employeesDAO.Search(searchText, searchBy);
        }
        public List<Employees> FilterEmployees(int? departmentId, string gender, double? minSalary, double? maxSalary) {
            return _employeesDAO.Filter(departmentId, gender, minSalary, maxSalary);
        }
    }
}
