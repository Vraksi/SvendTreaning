using Identity.Areas.Identity.Pages.Account;
using Identity.Data;
using Identity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<LoginModel> _logger;
        private readonly WebshopContext _context;

        public RegisterController(
            SignInManager<IdentityUser> signInManager,
            ILogger<LoginModel> logger,
            UserManager<IdentityUser> userManager,
            WebshopContext context
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _context = context;
        }


        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<Register>> Login(Register register)
        {
            var result = await _signInManager.PasswordSignInAsync(register.email, register.password, register.rememberMe, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                //SameSiteMode.None;
                register.password = "";
                register.confirmPassword = "";
                _logger.LogInformation($"User with email = {register.email} logged in.");
                return register;
            }
            return StatusCode(401);
        }

        //TODO: burde måske være en POST for at kunne sende en json body.
        [HttpGet]
        [Route("RegisterUser")]
        public async Task<ActionResult<Register>> RegisterUser(Register register)
        {
            Customer customer = new Customer();
            //var tempemail = await _userManager.FindByNameAsync("aa@gmail.com");
            if (await _userManager.FindByEmailAsync(register.email) != null)
            {
                //TODO: ERROR HANDLING
                return StatusCode(403);
            }
            else
            {
                if (register.password == register.confirmPassword)
                {
                    //TODO: Emailen skal confirmes via en Email når projektet kommer i produktion
                    var user = new IdentityUser { UserName = register.email, Email = register.email, EmailConfirmed = true };
                    var result = await _userManager.CreateAsync(user, register.password);
                    if (result.Succeeded)
                    {
                        customer.Address = register.Address;
                        customer.LoginId = register.email;
                        _context.Customers.Add(customer);
                        await _context.SaveChangesAsync();
                        register.password = "";
                        register.confirmPassword = "";
                        Console.WriteLine("User created a new account");
                        return register;
                    }
                    else
                    {
                        Console.WriteLine("password probably isnt complex enough or some other error i dunno");
                        return StatusCode(403);
                    }
                }
                else
                {
                    return StatusCode(403);
                }

            }


        }

    }
}
