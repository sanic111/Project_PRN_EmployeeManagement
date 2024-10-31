using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml.Drawing.Chart.ChartEx;

namespace DataAccessLayer
{
    public class EmployeesDAO
    {
        private readonly PRN_EmployeeManagementContext _context;
        public EmployeesDAO()
        {
            _context = new();
        }
        public List<Employees> GetAll()
        {
            return _context.Employees.Include(e => e.Departments).ToList();
        }
        //Get By Id
        public Employees GetById(int id)
        {
            return _context.Employees.Include(e => e.Departments).FirstOrDefault(e => e.EmployeeID == id) ??
                   throw new KeyNotFoundException($"Employee with ID {id} not found");
        }
        //Create
        public void Add(Employees employees)
        {
            try
            {
                _context.Employees.Add(employees);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error adding employee: {ex.Message}", ex);
            }
        }
        //Update
        public void Update(Employees employees)
        {
            try
            {
                var existingEmployee = _context.Employees.Find(employees.EmployeeID);
                if (existingEmployee == null)
                {
                    throw new KeyNotFoundException($"Employee with ID {employees.EmployeeID} not found");
                }

                _context.Entry(existingEmployee).CurrentValues.SetValues(employees);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating employee: {ex.Message}", ex);
            }
        }
        //Delete
        public void Delete(Employees employees)
        {
            _context.Employees.Remove(employees);
            _context.SaveChanges();
        }
        //Search
        public List<Employees> Search(string searchText, string searchBy)
        {
            var query = _context.Employees.Include(e => e.Departments).AsQueryable();
            if (!string.IsNullOrEmpty(searchText))
            {
                searchText = searchText.ToLower();
                switch (searchBy)
                {
                    case "Full Name":
                        query = query.Where(e => e.FullName.ToLower().Contains(searchText));
                        break;
                    case "Department":
                        query = query.Where(e => e.Departments.DepartmentName.ToLower().Contains(searchText));
                        break;
                    case "Position":
                        query = query.Where(e => e.Position.ToLower().Contains(searchText));
                        break;
                }
            }
            return query.ToList();
        }
        //Filter
        public List<Employees> Filter(int? departmentId, string gender, double? minSalary, double? maxSalary)
        {
            var query = _context.Employees.Include(e => e.Departments).AsQueryable();

            if (departmentId.HasValue && departmentId > 0)
            {
                query = query.Where(e => e.DepartmentID == departmentId);
            }

            if (!string.IsNullOrEmpty(gender) && gender != "All")
            {
                query = query.Where(e => e.Gender == gender);
            }

            if (minSalary.HasValue)
            {
                query = query.Where(e => e.BaseSalary >= minSalary);
            }

            if (maxSalary.HasValue)
            {
                query = query.Where(e => e.BaseSalary <= maxSalary);
            }

            return query.ToList();
        }
    }
}
