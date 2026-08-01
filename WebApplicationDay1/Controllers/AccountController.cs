using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebApplicationDay1.DTO;

namespace WebApplicationDay1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpPost]
        public ActionResult Login(UserData userData)
        {
            if (userData.userName == "Admin" && userData.password == "123")
            {
                // Generate Token

                // Define claims
                List<Claim> claim = new List<Claim>();
                claim.Add(new Claim("name", userData.userName));
                claim.Add(new Claim(ClaimTypes.PostalCode, "64612"));

                // Security key 
                var secretKey = "Hello, from the key, video about JWTkey from the key, video about JWTkey";
                var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));

                // create token
                var signingCredential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

                var token = new JwtSecurityToken(
                    claims: claim,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: signingCredential
                    );

                var tokenHandler = new JwtSecurityTokenHandler();
                string tokenString = tokenHandler.WriteToken(token);

                return Ok(tokenString);
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpGet]
        [Authorize]
        public ActionResult GetAll() => Ok();
    }
}

