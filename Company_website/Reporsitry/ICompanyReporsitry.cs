using System;
using Company_website.Models;
using Company_website.Models.Entities;

namespace Company_website.Reporsitry;

public interface IComoanyReporsitry
{
  public List<Company> GetAll();
  public Company GetById(int id);
  public void SaveCreate(Company com);
  public void update (int id , Company com);
  public void Delete(int id);

}
