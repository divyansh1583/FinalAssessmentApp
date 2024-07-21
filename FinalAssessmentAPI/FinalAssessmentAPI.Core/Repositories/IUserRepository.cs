using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalAssessmentAPI.Core.Entities;

namespace FinalAssessmentAPI.Core.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetUserByEmailAsync(string email);
        Task<int> AddUserAsync(User user);
    }
}
