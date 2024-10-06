using Company_website.Models.Context;
using Company_website.Models.Entities;
using Company_website.Reporsitry;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Company_website.Controllers.EntitiesController
{
    public class EmployeeController : Controller
    {
        // AppDbContext context = new AppDbContext();

        // GET: EmployeeController
        IEmployeeReporsitry employee1;
        AppDbContext context;

        public EmployeeController(IEmployeeReporsitry _employee, AppDbContext _context)
        {
            employee1=_employee;
            context=_context;
            
        }
        public ActionResult GetAll()
        {
            var allEmployee = employee1.GetAll();
            return View("GetAll",allEmployee);
        }


       public ActionResult GetById(int id)
       {
        var EmployeeId = employee1.GetById(id);
        return View(EmployeeId);
       
       }
       public ActionResult Create()
       {
        ViewBag.Company = context.company.ToList();
        return View();
       
       }
       public ActionResult SaveCreate(Employee emp)
       {
        employee1.SaveCreate(emp);
        return RedirectToAction("GetAll");
       }

     [HttpGet]
      public ActionResult Edit(int id)
       {
        var employeeE = context.Employees.Include(e=>e.company).FirstOrDefault(s=>s.Id == id);
        ViewBag.Company = context.company.ToList();
        return View(employeeE);
       
       }
      [HttpPost]
       public ActionResult Edit(int id , Employee employee)
       {
       employee1.Update(id,employee);
       return RedirectToAction("GetById",new {id=employee.Id});
       }


     public ActionResult DeleteEmployee(int id , Employee EmployeeD)
       {
        employee1.Delete(id,EmployeeD);

       return RedirectToAction("GetAll");
       }

    }
}
