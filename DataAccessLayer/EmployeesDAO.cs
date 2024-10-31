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
        private PRN_EmployeeManagementContext _context;
        public List<Employees> GetAll()
        {
            _context = new();
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
            _context.Employees.Add(employees);
            _context.SaveChanges();
        }
        //Update
        public void Update(Employees employees)
        {
            _context.Employees.Update(employees);
            _context.SaveChanges();
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
