using Newtonsoft.Json.Linq;
using OAS.Core.Entity;
using OAS.Core.Entity.AuthModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using OSA.Api.Enums;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using OSA.Infructructure.Services.Helpers;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;

namespace OSA.Api.Helper
{
    public class HelperClass
    {
        private readonly AppSettings _appSettings;
        public HelperClass()
        {
            
        }
        public User GenerateToken(User user)
        {
            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var secret = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings")["Secret"];
            var key = Encoding.ASCII.GetBytes(secret);
            try
            {
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Username.ToString()),
                    new Claim(ClaimTypes.Role, user.Role),
                    //new Claim(ClaimTypes.Actor, user.FirstName + " " + user.LastName ),
                    new Claim(ClaimTypes.Email, user.Email)
                }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                user.Token = tokenHandler.WriteToken(token);
                return user;

            }
            catch (Exception e)
            {
                throw e;
            }

        }
        internal void GetFilterValues(object something,ref int start, ref int length, ref string searchValue)
        {
            JToken token = JObject.Parse(something.ToString());
            length = (int)token.SelectToken("length");
            int draw = (int)token.SelectToken("draw");
            start = (int)token.SelectToken("start");
            string value = token.SelectToken("search").ToString();
            string[] splitted = value.Split(new string[] { System.Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            string[] splitted1 = splitted[1].Split(":");
            searchValue = splitted1[1].Replace("\"", "").Replace(",", "");
        }

        public string GetMACAddress()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            String sMacAddress = string.Empty;
            foreach (NetworkInterface adapter in nics)
            {
                if (sMacAddress == String.Empty)// only return MAC Address from first card  
                {
                    IPInterfaceProperties properties = adapter.GetIPProperties();
                    sMacAddress = adapter.GetPhysicalAddress().ToString();
                }
            }
            return sMacAddress;
        }

        internal User GetUserFromEmployee(Employee employee)
        {
            User user = new User
            {
                EmployeeId = employee.Id,
                Email = employee.Email,
                Role = Roles.Employee.ToString(),
                Username = Guid.NewGuid().ToString().Substring(0, 6),
                Password = Guid.NewGuid().ToString().Substring(0, 6)
        };

            return user;
        }
    }

    
}
