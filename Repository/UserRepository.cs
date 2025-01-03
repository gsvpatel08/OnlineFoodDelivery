﻿using System;
using Microsoft.EntityFrameworkCore;
using OnlineFoodDelivery.Data;
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
                return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
            }

            public async Task<User> GetUserByEmailAsync(string email)
            {
                return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            }

            public async Task AddUserAsync(User user)
            {
                await _context.Users.AddAsync(user);
            }

            public async Task UpdateUserAsync(User user)
            {
                _context.Users.Update(user);
            }

            public async Task SaveChangesAsync()
            {
                await _context.SaveChangesAsync();
            }

    
    }
    }
