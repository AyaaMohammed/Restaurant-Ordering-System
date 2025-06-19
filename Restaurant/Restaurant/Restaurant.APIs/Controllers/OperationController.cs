using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Restaurant.Core.DTOs.Account;
using Restaurant.Core.Entities;
using Restaurant.Core.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Restaurant.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationController : ControllerBase
    {
        private readonly ILogger<RestaurantController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        public IMapper _map { get; }
        private const string SECRET_KEY = "welcome to my secret key hhh llhplkod";
        private readonly SymmetricSecurityKey _signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SECRET_KEY));
        public OperationController(ILogger<RestaurantController> logger, IUnitOfWork unitOfWork, IMapper map)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _map = map;
        }
        [HttpPost("Register")]
        public IActionResult Register([FromBody] RegisterDTO registerDTO)
        {
            if (registerDTO == null)
            {
                return BadRequest("Invalid request.");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var existingCustomer = _unitOfWork.CustomerRepository.GetByEmail(registerDTO.Email);

            if (existingCustomer != null)
            {
                return BadRequest("Email is already in use. Please choose a different email.");
            }
            var customer = _map.Map<Customer>(registerDTO);
            try
            {
                _unitOfWork.Customers.Add(customer);
                _unitOfWork.Save();

                return Ok(new { message = "Registration successful!" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while registering customer.");

                if (ex.InnerException != null)
                    return StatusCode(500, $"Inner error: {ex.InnerException.Message}");

                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDTO loginDTO)
        {
            if (loginDTO == null)
            {
                return BadRequest("Invalid request.");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var customer = _unitOfWork.CustomerRepository.CheckLogin(loginDTO.Email,loginDTO.Password);
            if(customer == null)
            {
                return NotFound();
            }
            var claims = new List<Claim>
            {
                    new Claim("name", customer.Name),
                    new Claim("email", customer.Email),
                    new Claim("userId", customer.Id.ToString()),
            };
            var creds = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256);

              var accessToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(1),
                signingCredentials: creds);

            var accessTokenString = new JwtSecurityTokenHandler().WriteToken(accessToken);


            var refreshToken = GenerateRefreshToken();
            customer.RefreshToken = refreshToken;
            customer.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
            _unitOfWork.Customers.Edit(customer);
            _unitOfWork.Save();

            return Ok(new
            {
                AccessToken = accessTokenString,
                RefreshToken = refreshToken,
                ExpiresIn = 60 
            });
        }
        [HttpPost("refresh-token")]
        public IActionResult Refresh([FromBody] RefreshTokenDTO refreshTokenDTO)
        {
            if (refreshTokenDTO == null || string.IsNullOrEmpty(refreshTokenDTO.RefreshToken))
                return BadRequest("Invalid client request");

            var customer = _unitOfWork.CustomerRepository.GetByRefreshToken(refreshTokenDTO.RefreshToken);
            if (customer == null)
            {
                return Unauthorized("Invalid or expired refresh token.");
            }
            var claims = new List<Claim>
            {
                    new Claim("name", customer.Name),
                    new Claim("email", customer.Email),
                    new Claim("userId", customer.Id.ToString()),
            };
            var creds = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256);

            var newAccessToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(1),
                signingCredentials: creds);

            var newAccessTokenString = new JwtSecurityTokenHandler().WriteToken(newAccessToken);

            var newRefreshToken = GenerateRefreshToken();


            customer.RefreshToken = newRefreshToken;
            customer.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
            _unitOfWork.Customers.Edit(customer);
            _unitOfWork.Save();

            return Ok(new
            {
                AccessToken = newAccessTokenString,
                RefreshToken = newRefreshToken,
                ExpiresIn = 60
            });
        }
        [HttpPost("logout")]
        public IActionResult Logout([FromBody] RefreshTokenDTO dto)
        {
            if (dto == null || string.IsNullOrEmpty(dto.RefreshToken))
                return BadRequest("Refresh token is required.");

            var customer = _unitOfWork.CustomerRepository.GetByRefreshToken(dto.RefreshToken);
            if (customer == null)
                return NotFound("Refresh token not found.");

            customer.RefreshToken = null;
            customer.RefreshTokenExpiryTime = null;
            _unitOfWork.Customers.Edit(customer);
            _unitOfWork.Save();

            return Ok(new { message = "Logged out successfully." });
        }
        private string GenerateRefreshToken()
        {
            var randomBytes = new byte[32];
            using var rng = System.Security.Cryptography.RandomNumberGenerator.Create();
            rng.GetBytes(randomBytes);
            return Convert.ToBase64String(randomBytes);
        }

    }
}
