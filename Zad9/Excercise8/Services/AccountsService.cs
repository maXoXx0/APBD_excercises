using Excercise8.Data;
using Excercise8.Models.DTOs;
using Excercise9.Models;
using Microsoft.AspNetCore.Identity;

namespace Excercise9.Services
{
    public interface IAccountsService
    {
        bool DoesLoginExists(string Login);
        Task AddUser(User user);
        bool IsLoginAndPasswordCorrect(LoginRequest loginRequest);
    }

    public class AccountsService : IAccountsService
    {
        private readonly MedicamentsContext _context;
        public AccountsService(MedicamentsContext context)
        {
            _context = context;
        }

        public async Task AddUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public bool DoesLoginExists(string Login)
        {
            return _context.Users.Where(e => e.Login == Login).Any();
        }

        public bool IsLoginAndPasswordCorrect(LoginRequest loginRequest)
        {
            var hasher = new PasswordHasher<User>();

            int res = 0;
            if (_context.Users.Where(e => e.Login.Equals(loginRequest.Login)).Any()) 
            {
                var user = _context.Users.Where(e => e.Login.Equals(loginRequest.Login)).FirstOrDefault();

                res = Convert.ToInt32(hasher.VerifyHashedPassword(user, user.Password, loginRequest.Password));
                
            }

            

            return Convert.ToBoolean(res);
        }
    }
}
