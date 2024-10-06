using System;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Company_website.Models.Entities;

public class Company
{

  public int Id { get; set; }
  [MaxLength(20,ErrorMessage ="The Mac length 20")]
  [Required]
  public string Name { get; set; }

  [MaxLength(20)]
  public string? Type { get; set; }
  public  DateTime DataStart { get; set; }
   [MaxLength(50)]
  public string? Address { get; set; }

  public ICollection<Employee> employees { get; set; }


}
