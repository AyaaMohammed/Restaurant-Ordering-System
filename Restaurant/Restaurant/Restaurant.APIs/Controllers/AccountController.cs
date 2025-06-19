using AutoMapper;
using Castle.Core.Resource;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Crypto.Generators;
using Restaurant.Core.DTOs.Account;
using Restaurant.Core.Entities;
using Restaurant.Core.Interfaces;
using Restaurant.Core.Repositories;
using System;
using System.Linq;
using System.Net;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Restaurant.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<RestaurantController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailService _emailService;
        private readonly IMapper _map;

        public AccountController(IEmailService emailService, ILogger<RestaurantController> logger, IUnitOfWork unitOfWork, IMapper map)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _map = map;
            _emailService = emailService;
        }

        private async Task SendForgotPasswordEmail(string email, Customer user)
        {
            var token = Guid.NewGuid().ToString();
            user.PasswordResetToken = token;
            user.PasswordResetTokenExpiry = DateTime.UtcNow.AddHours(1); 

            _unitOfWork.Customers.Edit(user);
             _unitOfWork.Save();

            var encodedToken = WebUtility.UrlEncode(token);
            var angularAppUrl = "http://localhost:4200/reset-password";
            var passwordResetLink = $"{angularAppUrl}?email={WebUtility.UrlEncode(email)}&token={encodedToken}";

            var safeLink = HtmlEncoder.Default.Encode(passwordResetLink);
            var subject = "Reset Your Password";

            var messageBody = $@"
                <div style=""font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; background-color: #f4f4f4; padding: 40px;"">
                    <div style=""max-width: 600px; margin: auto; background-color: #ffffff; border-radius: 8px; box-shadow: 0 2px 10px rgba(0,0,0,0.1); padding: 30px;"">
                        <h2 style=""text-align: center; color: #2c3e50;"">🔐 Reset Your Password</h2>
                        <p style=""font-size: 16px; color: #333;"">Hello <strong>{user.Name}</strong>,</p>
                        <p style=""font-size: 16px; color: #333;"">
                            We received a request to reset your password for your <strong>Restaurant</strong> account. Click the button below to set a new password:
                        </p>
                        <div style=""text-align: center; margin: 30px 0;"">
                            <a href=""{safeLink}"" 
                               style=""background-color: #28a745; color: #ffffff; padding: 12px 24px; text-decoration: none; font-weight: bold; border-radius: 5px;"">
                                🔁 Reset Password
                            </a>
                        </div>
                        <p style=""font-size: 15px; color: #666;"">If the button above doesn’t work, copy and paste this link into your browser:</p>
                        <p style=""word-break: break-all; background-color: #f9f9f9; border-left: 4px solid #28a745; padding: 10px;"">
                            <a href=""{safeLink}"" style=""color: #007bff;"">{safeLink}</a>
                        </p>
                        <p style=""font-size: 14px; color: #999;"">
                            If you did not request this, you can safely ignore this email.
                        </p>
                        <p style=""font-size: 14px; color: #999;"">Thanks,<br>The Restaurant Team</p>
                    </div>
                </div>";

            await _emailService.SendEmailAsync(email, subject, messageBody);
        }

        [HttpPost("ForgotPassword")]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = _unitOfWork.CustomerRepository.GetByEmail(email);
            if (user != null)
            {
                await SendForgotPasswordEmail(user.Email, user);
                return Ok(new { message = "Email sent successfully." });
            }

            return NotFound(new { message = "User not found." });
        }

        [HttpPost("ResetPassword")]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = _unitOfWork.CustomerRepository.GetByEmail(model.Email);
            if (user == null)
                return NotFound(new { message = "User not found." });

            if (user.PasswordResetToken != model.Token || user.PasswordResetTokenExpiry < DateTime.UtcNow)
                return BadRequest(new { message = "Invalid or expired token." });

            user.Password = model.Password;


            user.PasswordResetToken = null;
            user.PasswordResetTokenExpiry = null;

            _unitOfWork.Customers.Edit(user);
            _unitOfWork.Save();

            return Ok(new { message = "Password reset successfully." });
        }


    }
}
