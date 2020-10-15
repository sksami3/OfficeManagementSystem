using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Text;

namespace OAS.Core.Entity.AuthModels
{
    public static class Role
    {
        public const string Admin = "Admin";
        public const string Employee = "Employee";
        public const string HR = "HR";

        public static AuthorizationPolicy AdminPolicy()
        {
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser().RequireRole(Admin).Build();
        }

        public static AuthorizationPolicy EmployeePolicy()
        {
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser().RequireRole(Employee).Build();
        }
        public static AuthorizationPolicy HRPolicy()
        {
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser().RequireRole(HR).Build();
        }
    }
}