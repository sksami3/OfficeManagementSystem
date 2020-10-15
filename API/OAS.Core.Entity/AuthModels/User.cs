using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using OAS.Core.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OAS.Core.Entity.AuthModels
{
    public class User : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
        public string Image { get; set; }
        public string Email { get; set; }
        public string ResetId { get; set; }
        [ForeignKey("Employee")]
        [Required]
        public long EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
    }
}