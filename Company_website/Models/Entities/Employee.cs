using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace Company_website.Models.Entities;

public class Employee
{

 [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public int Id { get; set; }

  [MaxLength(10,ErrorMessage ="The Mac length 10")]
  [Required]
  [MinLength(3)]
  public String Name { get; set; }

  [Range(25,40)]
  public int Age { get; set; }

  [MaxLength(100)]
  public string? Address { get; set; }

  [DataType(DataType.EmailAddress)]
  [RegularExpression(@"^[a-zA-Z0-9._%+-]+@gmail\.com$", ErrorMessage = "Email must be a valid Gmail address.")]
  public String EmailAddress { get; set; }

  [MaxLength(11)]
  [MinLength(11)]
  public string? Phone { get; set; }

  public int Salary { get; set; }
 [MaxLength(20)]
 [RegularExpression((@"\w+\.(jpg)"),ErrorMessage ="Must  Ended .jpg")]
  public String? Image { get; set; }

 [ForeignKey("company")]
  public int CompanyId { get; set; }

  public Company company { get; set; }

}
 