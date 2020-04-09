using OAS.Core.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OAS.Core.Entity
{
    public class Employee : BaseModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public double Salary { get; set; }
        [Required]
        public string Email { get; set; }
        public int ContactNumber { get; set; }
        [Required]
        public DateTime JoiningDate { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [ForeignKey("Department")]
        [Required]
        public long DepartmentId { get; set; }
        public virtual Department Department { get; set; }

    }
}
