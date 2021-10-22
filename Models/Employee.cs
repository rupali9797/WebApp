using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Employee
    {
        public Employee()
        {

        }
       [Key]
      public int Id { get; set; }
     [Required]
     [StringLength(40)]

      public string Name { get; set; }
      public int FieldExperience { get; set; }
        [MaxLength(13)]
      public string PhoneNumber { get; set; }
      public double Salary { get; set; }
      public DateTime? BirthDate { get; set; }
        public object Department { get; internal set; }
    }
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [Required]

        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
      
        public string UserName { get; set; }
        [Required]
        public int Password { get; set; }
     

    }
}