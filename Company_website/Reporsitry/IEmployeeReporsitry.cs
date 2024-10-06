using System;
using Company_website.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Company_website.Reporsitry;

public interface IEmployeeReporsitry
{
  public List<Employee> GetAll();
  public Employee GetById(int id);
   public void SaveCreate(Employee emp);
   public void Update(int id, Employee employee1);
    public void Delete(int id,Employee employee1);

}
