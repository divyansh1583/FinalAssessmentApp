using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalAssessmentAPI.Core.Entities;
using FinalAssessmentAPI.Core.Repositories;
using FinalAssessmentAPI.Core.Services;
using Microsoft.EntityFrameworkCore;

namespace FinalAssessmentAPI.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllAsync();
        }
        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _userRepository.GetUserByEmailAsync(email);
        }

        public async Task<int> AddUserAsync(User user)
        {
            // Here we can add business logic, validation, etc.
            if (string.IsNullOrWhiteSpace(user.Email))
            {
                throw new ArgumentException("Email is required");
            }

            if (string.IsNullOrWhiteSpace(user.Password))
            {
                throw new ArgumentException("Password is required");
            }

            // You might want to add more validations here

            // You could also hash the password here before saving
            // user.Password = HashPassword(user.Password);

            return await _userRepository.AddUserAsync(user);
        }

        // Add more methods as needed
    } 
}
