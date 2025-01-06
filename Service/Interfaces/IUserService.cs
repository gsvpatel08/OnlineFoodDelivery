using OnlineFoodDelivery.Data;
using OnlineFoodDelivery.Module;
using OnlineFoodDelivery.Utility;

namespace OnlineFoodDelivery.Service
{
    public interface IUserService
    {
      
            Task<ServiceResponse<string>> RegisterAsync(RegisterUserDto registerDto);
            Task<ServiceResponse<string>> LoginAsync(LoginDto loginDto);
            Task<ServiceResponse<string>> ForgotPasswordAsync(string email);
            Task<ServiceResponse<string>> ResetPasswordAsync(string token, string newPassword, string username);
        }
    }
