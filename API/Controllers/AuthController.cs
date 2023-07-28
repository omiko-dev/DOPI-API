﻿using API.Data;
using API.dto.UsersDto;
using API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserDbContext _userDb;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public AuthController(UserDbContext userDb, IConfiguration configuration, IMapper mapper)
        {
            _userDb = userDb;
            _configuration = configuration;
            _mapper = mapper;
        }


        [HttpPost("Register")]
        public async Task<ActionResult<User>> Register(UserDto newUser)
        {
            if(newUser.Name == null)
            {
                return BadRequest("Please Enter Name");
            }

            if (await _userDb.Users.AnyAsync(u => u.Email == newUser.Email))
            {
                return BadRequest("Enter Another Email");
            };


            var user = _mapper.Map<User>(newUser);
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(newUser.PasswordHash);

            await Console.Out.WriteLineAsync(user.PasswordHash);


            await _userDb.AddAsync(user);
            await _userDb.SaveChangesAsync();

            return Ok(newUser);

        }


        [HttpPost("Login")]
        public async Task<ActionResult<string>> Login(LoginDto _user)
        {

            var user = await _userDb.Users.FirstOrDefaultAsync(u => u.Email == _user.Email);

            if(user == null)
            {
                return BadRequest("Email Is Incorrect");
            }

            if(!BCrypt.Net.BCrypt.Verify(_user.Password, user.PasswordHash))
            {
                return BadRequest("Invalid Password");
            }

            var Token = token(user);

            var refreshToken = createRefreshToken();

            SetRefreshToken(refreshToken);

            user.refreshToken = refreshToken.refreshToken;
            user.tokenCreate = refreshToken.TokenCreate;
            user.tokenExpires = refreshToken.TokenExpires;

            await _userDb.SaveChangesAsync();
            return Ok(Token);

        }

        [HttpPost("Refresh-Token")]
        public async Task<ActionResult<string>> RefreshToken()
        {

            var refreshToken = Request.Cookies["Refresh_Token"];
            var user = _userDb.Users.FirstOrDefault(u => u.refreshToken == refreshToken);

            if (user == null)
            {
                return BadRequest("Invalid Refresh Token");
            }

            await Console.Out.WriteLineAsync("work");

            if (user?.tokenExpires < DateTime.Now)
            {
                return BadRequest("Token Expires");
            }

            var newToken = token(user);

            var newRefreshToken = createRefreshToken();
            SetRefreshToken(newRefreshToken);


            return Ok(newToken);
        }


        private RefreshToken createRefreshToken()
        {

            var refreshToken = new RefreshToken
            {
                refreshToken = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                TokenExpires = DateTime.Now.AddDays(7)
            };
            return refreshToken;


        }
        private void SetRefreshToken(RefreshToken refreshToken)
        {

            var cookieOption = new CookieOptions
            {
                HttpOnly = true,
                Expires = refreshToken.TokenExpires
            };

            Response.Cookies.Append("Refresh_Token", refreshToken.refreshToken, cookieOption);
        }

        private string token(User user)
        {

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(_configuration.GetSection("JWT:Token").Value!));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken
                (
                   claims: claims,
                   expires: DateTime.Now.AddHours(1),
                   signingCredentials: cred
                );

            var Jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return Jwt;
        }
    }
}
