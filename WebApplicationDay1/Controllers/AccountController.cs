using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
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

            //eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1lIjoiQWRtaW4iLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9wb3N0YWxjb2RlIjoiNjQ2MTIiLCJleHAiOjE3ODU2MzI1NDd9.8tPJcNXoyi4L_2llOxAl8J9Jri0Xg3YdlCy2uTRhfdU
        }
    }
}
