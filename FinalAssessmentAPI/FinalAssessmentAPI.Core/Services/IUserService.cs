using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalAssessmentAPI.Core.Entities;

namespace FinalAssessmentAPI.Core.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByEmailAsync(string email);
        Task<int> AddUserAsync(User user);
        // We'll add more methods here as we implement more features
        
    }
}
