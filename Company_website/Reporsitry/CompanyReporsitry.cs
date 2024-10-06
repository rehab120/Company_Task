using System;
using Company_website.Models;
using Company_website.Models.Context;
using Company_website.Models.Entities;
using Microsoft.EntityFrameworkCore;
namespace Company_website.Reporsitry;

public class CompanyReporsitry:IComoanyReporsitry
{
  AppDbContext context;
  public CompanyReporsitry(AppDbContext _context)
  {
    context=_context;
  }
  public List<Company> GetAll()
  {
    var allCompany = context.company.Include(c => c.employees)
                    .ToList();
    return allCompany;
  }
  
  public Company GetById(int id)
  {
        return context.company.Include(s => s.employees).FirstOrDefault(s => s.Id == id);
  }

  public void SaveCreate(Company com) 
  {
        Company company = new Company();
        company.Name=com.Name;
        company.Type=com.Type;
        company.DataStart=com.DataStart;
        company.Address=com.Address;
        context.company.Add(company);
        context.SaveChanges();
  }

public void update(int id, Company com)
{
    var companyI = GetById(id);
    if (companyI == null)
    {
        throw new Exception("Company not found with the provided ID.");
    }
    if (com == null)
    {
        throw new ArgumentNullException(nameof(com), "The updated company object cannot be null.");
    }

    // Update properties
    companyI.Name = com.Name;
    companyI.Type = com.Type;
    companyI.DataStart = com.DataStart;
    companyI.Address = com.Address;

    try
    {
        context.company.Update(companyI);
        context.SaveChanges();
    }
    catch (DbUpdateException ex)
    {
        // Log the inner exception for debugging
        throw new Exception($"Database update error: {ex.InnerException?.Message}", ex);
    }
  
}




  public void Delete(int id)
 {
       var CompanyId = context.company.Include(s=>s.employees).FirstOrDefault(s=>s.Id==id);  
        context.company.Remove(CompanyId);
        context.SaveChanges();
 }
}
