using OnlineFoodDelivery.Module;

namespace OnlineFoodDelivery.Repository
{
    public interface IRestaurentOwnerRepo
    {
        Task  AddRestaurentOwnerAsync(RestaurentOwner Restowner);
        Task  UpdateRestaurentOwnerAsync(RestaurentOwner restaurent);
        Task SavaChangesAsync();

        Task<RestaurentOwner> GetRestaurentOwnerByIdAsync(int id);
        Task<RestaurentOwner> GetRestaurentOwnerByEmailAsync(string email);
        Task<RestaurentOwner> GetRestaurentOwnerByUsernameAsync(string username);
    }
}
