using System;
using Company_website.Models.Context;
using Company_website.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Company_website.Reporsitry;

public class EmployeeReporsitry:IEmployeeReporsitry
{
   AppDbContext context;
   public EmployeeReporsitry(AppDbContext _context)
   {
       context =_context;
   }
   public List<Employee> GetAll()
   {
    return context.Employees.Include(c=>c.company).ToList();
   }
   
   public Employee GetById(int id)
   {
    return context.Employees.Include(s=>s.company).FirstOrDefault(s=>s.Id==id);
   }

   public void SaveCreate(Employee emp)
   {
    Employee employee = new Employee();
        employee.Name=emp.Name;
        employee.Age=emp.Age ;
        employee.Address=emp.Address;
        employee.EmailAddress=emp.EmailAddress;
        employee.Phone=emp.Phone;
        employee.Salary=emp.Salary;
        employee.Image=emp.Image;
        employee.CompanyId=emp.CompanyId;
        context.Employees.Add(employee);
        context.SaveChanges();
   }

   public void Update(int id, Employee employee1)
   {
     var employeeId = GetById(id);
        employeeId.Name= employee1.Name;
        employeeId.Age = employee1.Age;
        employeeId.Address = employee1.Address;
        employeeId.EmailAddress= employee1.EmailAddress;
        employeeId.Phone= employee1.Phone;
        employeeId.Salary= employee1.Salary;
        employeeId.Image = employee1.Image;
        employeeId.CompanyId = employee1.CompanyId;
        context.Employees.Update(employeeId);
        context.SaveChanges();
   }

   public void Delete(int id,Employee employee1)
   {
       var employeeD = context.Employees.Include(e=>e.company).FirstOrDefault(s=>s.Id == employee1.Id);
        context.Employees.Remove(employeeD);
        context.SaveChanges();
   }
}
