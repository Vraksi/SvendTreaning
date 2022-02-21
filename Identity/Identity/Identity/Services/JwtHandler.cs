using Google.Apis.Auth;
using Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Services
{
    public class JwtHandler
	{
		//TODO: det her er ikke mit arbejde

		/*				JWT HANDLER
		***************************************
		 * henter information fra appsettings under forskellige dele af det,
		 * Det kan ses hvor og hvad der hentes i constructoren
		 * 
		***************************************
		*/
		private readonly IConfiguration _configuration;
		private readonly IConfigurationSection _jwtSettings;
		private readonly IConfigurationSection _googleSettings;
		private readonly UserManager<IdentityUser> _userManager;
		
		public JwtHandler(IConfiguration configuration, UserManager<IdentityUser> userManager)
		{
			_userManager = userManager;
			_configuration = configuration;
			_jwtSettings = _configuration.GetSection("JwtSettings");
			_googleSettings = _configuration.GetSection("GoogleAuthSettings");
		}

		//generere en token til frontend til login
		public async Task<string> GenerateToken(IdentityUser user)
		{
			var signingCredentials = GetSigningCredentials();
			var claims = await GetClaims(user);
			var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
			var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

			return token;
		}

		// henter nøglen til kryptering og sætter hvad for en kryptering der bruges
		private SigningCredentials GetSigningCredentials()
		{
			var key = Encoding.UTF8.GetBytes(_jwtSettings.GetSection("securityKey").Value);
			var secret = new SymmetricSecurityKey(key);

			return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
		}

		// henter claims/roller til den token,
		private async Task<List<Claim>> GetClaims(IdentityUser user)
		{
			var claims = new List<Claim>
			{
				new Claim(ClaimTypes.Name, user.Email)
			};

			// mulighed for flere roller
			var roles = await _userManager.GetRolesAsync(user);
			foreach (var role in roles)
			{
				claims.Add(new Claim(ClaimTypes.Role, role));
			}

			return claims;
		}

		// sætter options for JWT
		private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
		{
			var tokenOptions = new JwtSecurityToken(
				issuer: _jwtSettings.GetSection("validIssuer").Value,
				audience: _jwtSettings.GetSection("validAudience").Value,
				claims: claims,
				expires: DateTime.Now.AddMinutes(Convert.ToDouble(_jwtSettings.GetSection("expiryInMinutes").Value)),
				signingCredentials: signingCredentials);

			return tokenOptions;
		}


		// verifier den login information fra frontend for i vores backend, hvor vi tager nogle settings fra Appsettings,
		// Vi henter ind audience for at vide om vi den information kommer fra det rigtige sted
		public async Task<GoogleJsonWebSignature.Payload> VerifyGoogleToken(ExternalAuthDto externalAuth)
		{
			try
			{
				var settings = new GoogleJsonWebSignature.ValidationSettings()
				{
					Audience = new List<string>() { _googleSettings.GetSection("clientId").Value }
				};

				var payload = await GoogleJsonWebSignature.ValidateAsync(externalAuth.IdToken, settings);
				return payload;
			}
			catch (Exception ex)
			{
				//log an exception
				return null;
			}
		}

		
	}
}