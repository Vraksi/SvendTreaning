using Identity.Data;
using Identity.Models.DataTransferObjects;
using Identity.Models;
using Identity.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System;
using Microsoft.AspNetCore.Http;

namespace Identity.Controllers.LoginMethods
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class GoogleLoginController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly JwtHandler _jwtHandler;
        public GoogleLoginController(
            UserManager<IdentityUser> userManager,
            JwtHandler jwtHandler
            )
        {
            _userManager = userManager;
            _jwtHandler = jwtHandler;
        }

        //TODO: Constructor og parameters
        #region Google Login        
        [HttpPost("ExternalLogin")]
        public async Task<IActionResult> ExternalLogin([FromBody] ExternalAuthDto externalAuth)
        {
            var payload = await _jwtHandler.VerifyGoogleToken(externalAuth); //GoogleJsonWebSignature.VerifyGoogleToken(externalAuth);
            if (payload == null)
                return BadRequest("Invalid External Authentication.");

            var info = new UserLoginInfo(externalAuth.Provider, payload.Subject, externalAuth.Provider);

            var user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);
            if (user == null)
            {
                user = await _userManager.FindByEmailAsync(payload.Email);

                if (user == null)
                {
                    user = new IdentityUser { Email = payload.Email, UserName = payload.Email };
                    await _userManager.CreateAsync(user);

                    //prepare and send an email for the email confirmation

                    await _userManager.AddToRoleAsync(user, "Viewer");
                    await _userManager.AddLoginAsync(user, info);
                }
                else
                {
                    await _userManager.AddLoginAsync(user, info);
                }
            }

            
            if (user == null)
                return BadRequest("Invalid External Authentication.");

            //check for the Locked out account

            var token = await _jwtHandler.GenerateToken(user);
            Response.Cookies.Append("Dusk", token, new CookieOptions() 
            { HttpOnly = true, SameSite = SameSiteMode.None, Secure = true });
            Console.WriteLine(token);
            return Ok(new AuthResponseDto { Token = token, IsAuthSuccessful = true });
        }

        #endregion
        public IActionResult Index()
        {
            return View();
        }
    }
}