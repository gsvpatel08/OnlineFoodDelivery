using System;
using Microsoft.EntityFrameworkCore;
using OnlineFoodDelivery.Data;
using OnlineFoodDelivery.model;
using OnlineFoodDelivery.Module;

namespace OnlineFoodDelivery.Repository
{
  


        public class UserRepository : IUserRepository
        {
            private readonly OnlineFoodDeliveryDB _context;

            public UserRepository(OnlineFoodDeliveryDB context)
            {
                _context = context;
            }

            public async Task<User> GetUserByUsernameAsync(string username)
            {
                return await _context.User.FirstOrDefaultAsync(u => u.Username == username);
            }

            public async Task<User> GetUserByEmailAsync(string email)
            {
                return await _context.User.FirstOrDefaultAsync(u => u.Email == email);
            }

            public async Task AddUserAsync(User user)
            {
                await _context.User.AddAsync(user);
                await _context.SaveChangesAsync();
            }

            public async Task UpdateUserAsync(User user)
            {
                _context.User.Update(user);
            _context.SaveChangesAsync();

            }

            public async Task SaveChangesAsync()
            {
                await _context.SaveChangesAsync();
            }

        public List<Restaurant> GetAllRestaurantsAsync()
        {
           return _context.Restaurant.ToList();
        }

        public List<FoodItems> GetAllFoodItemsAsync()
        {
            return _context.FoodItems.ToList();
        }

        public async Task<List<FoodCategory>> GetFoodCategoriesWithItemsAsync()
        {
            return await _context.FoodCategory
                           .Include(c => c.FoodItems)
                           .ToListAsync();

        }

        public async Task<User> GetUserByIDAsync(int id)
        {
            return  _context.User.FirstOrDefault(u => u.UserId == id);
        }
    }
    }
