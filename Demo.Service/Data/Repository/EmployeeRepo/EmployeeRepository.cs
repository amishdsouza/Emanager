﻿using Demo.Service.Data.Repository.EmployeeRepo;
using Demo.Service.Dtos;
using Demo.Service.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Demo.Service.Data.Repository.EmployeeRepo
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DemoDbContext _context;

        public EmployeeRepository(DemoDbContext context)
        {
            _context = context;
        }

       
        public Employee DeleteEmployee(Employee employee)
        {
            _context.Employee.Remove(employee);
            _context.SaveChanges();
            return employee;

        }

        public Employee EditEmployee(Employee employee)
        {
            var existingEmployee = _context.Employee.Find(employee.Id);
            if(existingEmployee != null)
            {
                existingEmployee.Name=employee.Name;
                existingEmployee.EmailID=employee.EmailID;
                existingEmployee.Gender=employee.Gender;

                _context.Employee.Update(existingEmployee);
                _context.SaveChanges();
            }
            return employee;
        }


        public Employee AddEmployee(Employee employee)
        {
            _context.Employee.Add(employee);
            _context.SaveChanges();
            return employee;
        }

        public List<EmployeesInformationDto> GetEmployees()
        {
            var res = (from employee in _context.Employee
            select new EmployeesInformationDto
            {
                //Id = employee.Id,
                Name = employee.Name,
                EmailID = employee.EmailID,
                Gender = employee.Gender,
                Roles = (
                        from empRoleMap in _context.EmpRoleMap
                        join role in _context.Role
                        on empRoleMap.RoleID equals role.Id
                        where empRoleMap.EmployeeID == employee.Id
                        select role.Name).ToList()
            }).ToList();
            return res;
        }

        public EmployeeDto GetEmployee(int id)
        {
            var res = (from employee in _context.Employee
            where employee.Id == id
            select new EmployeeDto
            {
                Name = employee.Name,
                EmailID = employee.EmailID,
                Gender = employee.Gender,
                Roles = (
                from empRoleMap in _context.EmpRoleMap
                join role in _context.Role 
                on empRoleMap.RoleID equals role.Id
                where empRoleMap.EmployeeID == id
                select role.Name)
                .ToList()
            }).FirstOrDefault();
            return res;
        }
    }
}