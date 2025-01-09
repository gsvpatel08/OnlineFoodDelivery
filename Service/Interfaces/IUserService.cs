using OnlineFoodDelivery.Data;
using OnlineFoodDelivery.model;
using OnlineFoodDelivery.Module;
using OnlineFoodDelivery.Utility;
using OnlineFoodDelivery.Utility.ApiResponses;

namespace OnlineFoodDelivery.Service
{
    public interface IUserService
    {
      
            Task<ServiceResponse<string>> RegisterAsync(RegisterUserDto registerDto);
            Task<ServiceResponse<string>> LoginAsync(LoginDto loginDto);
            Task<ServiceResponse<string>> ForgotPasswordAsync(string email);
            Task<ServiceResponse<string>> ResetPasswordAsync(string token, string newPassword, string username);


        
            Task<List<ServiceResponse<RestaurentFoodItemListApiResponse>>> GetFoodItemsByRestaurantNameAsync(string restaurantName);
        




    }
}
