using Google.Apis.Auth;
using Identity.Areas.Identity.Pages.Account;
using Identity.Data;
using Identity.Models;
using Identity.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Controllers
{

    //TODO: Renames til IdentityController
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

        #region IdentityLogin
        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<Register>> Login(Register register)
        {
            var result = await _signInManager.PasswordSignInAsync(register.email, register.password, register.rememberMe, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                register.password = "";
                register.confirmPassword = "";
                _logger.LogInformation($"User with email = {register.email} logged in.");
                return register;
            }
            return StatusCode(401);
        }

        // using the identity signinmanager to log out a user
        [HttpGet]
        [Route("LogOut")]
        public async Task<ActionResult> LogOut()
        {
            if (User.Identity.IsAuthenticated)
            {
                await _signInManager.SignOutAsync();
                _logger.LogInformation("User logged out");
                return StatusCode(200);
            }
            else
            {
                await _signInManager.SignOutAsync(); // Dunno if this breaks it.
                _logger.LogInformation("You shouldnt be able to do this");
                return StatusCode(402);
            }
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


        //TODO: Check if logged in
        [HttpGet]
        [Route("CheckLogin")]
        public async Task<ActionResult<bool>> Logout()
        {
            bool res = true;
            // a little unsure if this works the way its intended but for now it just works :=)
            await Task.Run(() => { res = IsUserAuth(); });
            return res;
        }

        public bool IsUserAuth()
        {
            return User.Identity.IsAuthenticated;
        }
        #endregion
    }
}
