using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Castle.Core.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OAS.Core.Entity.AuthModels;
using OSA.Infructructure.Services.Services.Interfaces;
using System.IO;
using OSA.Api.Helper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OSA.Api.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        private HelperClass _helper;
        //private readonly IConfiguration configuration;

        public UsersController(IUserService userService)
        {
            _userService = userService;
            //_utility = new Utility();
            //configuration = config;
            _helper = new HelperClass();
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateModel model)
        {
            var user = await _userService.Authenticate(model.Username, model.Password);
            user.Password = "";
            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });
            _helper.GenerateToken(user);
            return Ok(user);

        }

        [Authorize(Policy = Role.Admin)]
        [HttpGet]
        public IActionResult Get()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        [AllowAnonymous]
        [HttpPost("GetByEmail")]
        public async Task<IActionResult> GetByEmail(string Email)
        {
            User users = await _userService.GetByEmail(Email);
            return Ok(users);
        }


        [Authorize(Policy = Role.Admin)]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            // only allow admins to access other user records
            var currentUserId = int.Parse(User.Identity.Name);
            if (id != currentUserId && !User.IsInRole(Role.Admin))
                return Forbid();

            var user = _userService.FindById(id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        // POST: api/Users
        [AllowAnonymous]
        [HttpPost]
        public async Task<User> Post(User user)
        {
            if (!await _userService.IsAlreadyExists(user.Username, user.Email))
            {
                user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
                user.CreatedBy = user.Username;
                user.ModifiedBy = user.Username;
                user.Image = "Images/" + "Files" + "/" + user.Image;
                return await _userService.CreateUser(user);
            }
            return null;
        }

        [HttpPost("FileUploader"), DisableRequestSizeLimit]
        [AllowAnonymous]
        public IActionResult FileUploader()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("wwwroot", "Images", "Files");            
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                bool exists = System.IO.Directory.Exists(pathToSave);

                if (!exists)
                    System.IO.Directory.CreateDirectory(pathToSave);


                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    return Ok(fileName);
                }
                else
                {
                    return BadRequest(new { message = "Bad request" });
                }
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }


        // PUT: api/Users/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        //SendResetLink
        [AllowAnonymous]
        [HttpPost("SendResetLink")]
        public async Task<bool> SendResetLink(User user)
        {
            if (await _userService.IsAlreadyExists(user.Username, user.Email))
            {
                User u = await _userService.GetByEmail(user.Email);
                u.ResetId = Guid.NewGuid().ToString();
                var res = _userService.Update(u);
                //using user.token to get the url of the application
                u.Token = user.Token;
                //todo
                //_utility.SendEmail(u);
                return true;
            }
            return false;
        }
    }
}
