using System;
using Company_website.Models;
using Company_website.Models.Context;
using Company_website.Models.Entities;
using Company_website.Reporsitry;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Company_website.Controllers.EntitiesController;

public class CompanyController:Controller
{
    // AppDbContext context = new AppDbContext();
    IComoanyReporsitry company1;
    AppDbContext context;
    public CompanyController(IComoanyReporsitry _company1,AppDbContext _context)
    {
        company1=_company1;
        context=_context;
    }

    public ActionResult GetAll()
    {
        return View("GetAll",company1.GetAll());
    }
     public ActionResult GetById(int id)
       {
        var companyId = company1.GetById(id);
        return View(companyId);
       }

      public ActionResult Create()
       {
        return View();
       }
       public ActionResult SaveCreate(Company company)
       {
        company1.SaveCreate(company);
        return RedirectToAction("GetAll");
       } 
      public ActionResult Delete(int id)
       {
        company1.Delete(id);
        return RedirectToAction("GetAll");
       } 
        public ActionResult Edit(int id)
       {
        var employeeE = context.company.Include(e=>e.employees).FirstOrDefault(s=>s.Id == id);
        return View(employeeE);
       
       }

[HttpPost]
public ActionResult EditCompany(int id, Company company2)
{
    if (company2 == null)
    {
        return BadRequest("Company data cannot be null.");
    }

    try
    {
        company1.update(id, company2);
        return RedirectToAction("GetById", new { id = company2.Id });
    }
    catch (DbUpdateException ex)
    {
        return StatusCode(500, $"Database update error: {ex.InnerException?.Message}");
    }
}
}
