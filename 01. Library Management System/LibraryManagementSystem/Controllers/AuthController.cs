using LibraryManagementSystem.Data;
using LibraryManagementSystem.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using LibraryManagementSystem.Model;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;

namespace LibraryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly DBContext _context;
        private readonly IMapper _mapper;
        public AuthController(IConfiguration configuration, IMapper mapper, DBContext context)
        {
            _configuration = configuration;
            _mapper = mapper;
            _context = context;
        }

        [AllowAnonymous]
        [HttpPost("signup")]
        public async Task<ActionResult<UserDto>> CreateUser([FromBody] UserDto _user)
        {
            var user = _mapper.Map<User>(_user);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (await _context.User.AnyAsync(e => e.Username == user.Username))
            {
                ModelState.AddModelError("Username", "Username is already taken");
                return BadRequest(ModelState);
            }
            else
            {
                User new_user = new User
                {
                    Username = user.Username,
                    Password = BCrypt.Net.BCrypt.HashPassword(user.Password),
                    Email = user.Email
                };
                _context.User.Add(new_user);
                await _context.SaveChangesAsync();

                var token = GenerateToken(new_user.Username.ToString());
                return Ok(new { Token = token });
            }
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] UserLoginDto _user)
        {
            var user = await _context.User.SingleOrDefaultAsync(u => u.Username == _user.Username);
            if (user == null || !BCrypt.Net.BCrypt.Verify(_user.Password, user.Password))
            {
                return BadRequest("Invalid Username or Password..");
            }
            else
            {
                var token = GenerateToken(_user.Username.ToString());
                return Ok(new { Token = token });
            }
        }
        private string GenerateToken(String userName)
        {
            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userName),
                    // Add other claims as needed
                };

            var SecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]));
            var Credentials = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_configuration["JwtSettings:Issuer"],
                                             _configuration["JwtSettings:Audience"],
                                             claims,
                                             expires: DateTime.Now.AddMinutes(15),
                                             signingCredentials: Credentials
                                            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
