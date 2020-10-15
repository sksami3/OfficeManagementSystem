using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OAS.Core.Entity.AuthModels
{
    public class AuthenticateModel : IdentityUser
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}