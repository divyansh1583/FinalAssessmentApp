using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalAssessmentAPI.Core.Entities;
using FinalAssessmentAPI.Core.Repositories;
using FinalAssessmentAPI.Infrastructure.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace FinalAssessmentAPI.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManagementContext _context;

        public UserRepository(UserManagementContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        } 
        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Users
                .FromSqlRaw("EXEC sp_GetUserByEmail @Email", new SqlParameter("@Email", email))
                .FirstOrDefaultAsync();
        }

        public async Task<int> AddUserAsync(User user)
        {
            var parameters = new[]
    {
        new SqlParameter("@FirstName", user.FirstName),
        new SqlParameter("@LastName", user.LastName ?? (object)DBNull.Value),
        new SqlParameter("@MiddleName", user.MiddleName),
        new SqlParameter("@Gender", user.Gender ?? (object)DBNull.Value),
        new SqlParameter("@DateOfJoining", user.DateOfJoining ?? (object)DBNull.Value),
        new SqlParameter("@DateOfBirth", user.DateOfBirth ?? (object)DBNull.Value),
        new SqlParameter("@Email", user.Email),
        new SqlParameter("@Phone", user.Phone),
        new SqlParameter("@AlternatePhone", user.AlternatePhone ?? (object)DBNull.Value),
        new SqlParameter("@Address1", user.Address1 ?? (object)DBNull.Value),
        new SqlParameter("@City1", user.City1 ?? (object)DBNull.Value),
        new SqlParameter("@State1", user.State1 ?? (object)DBNull.Value),
        new SqlParameter("@Country1", user.Country1 ?? (object)DBNull.Value),
        new SqlParameter("@ZipCode1", user.ZipCode1 ?? (object)DBNull.Value),
        new SqlParameter("@Address2", user.Address2 ?? (object)DBNull.Value),
        new SqlParameter("@City2", user.City2 ?? (object)DBNull.Value),
        new SqlParameter("@State2", user.State2 ?? (object)DBNull.Value),
        new SqlParameter("@Country2", user.Country2 ?? (object)DBNull.Value),
        new SqlParameter("@ZipCode2", user.ZipCode2 ?? (object)DBNull.Value),
        new SqlParameter("@IsActive", user.IsActive),
        new SqlParameter("@Password", user.Password)
    };

            var result = await _context.Database
                .ExecuteSqlRawAsync("EXEC DC_AddUser @FirstName, @LastName, @MiddleName, @Gender, @DateOfJoining, @DateOfBirth, @Email, @Phone, @AlternatePhone, @Address1, @City1, @State1, @Country1, @ZipCode1, @Address2, @City2, @State2, @Country2, @ZipCode2, @IsActive, @Password", parameters);

            return result;
        }
    }
}
