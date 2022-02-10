using Microsoft.AspNetCore.Mvc;

namespace Identity.Controllers.LoginMethods
{
    public class GoogleLoginController : Controller
    {

        //TODO: Constructor og parameters
        #region Google Login        
        [HttpPost("ExternalLogin")]
        public async Task<IActionResult> ExternalLogin([FromBody] ExternalAuthDto externalAuth)
        {
            var payload = await JwtHandler.VerifyGoogleToken(externalAuth); //GoogleJsonWebSignature.VerifyGoogleToken(externalAuth);
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
            return Ok(new AuthResponseDto { Token = token, IsAuthSuccessful = true });
        }


        #endregion
        public IActionResult Index()
        {
            return View();
        }
    }
}
