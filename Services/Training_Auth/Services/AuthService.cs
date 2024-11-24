using Grpc.Core;
using IrisTraining_Auth;
using IrisTraining_Auth.Context;
using IrisTraining_Auth.Models;
using IrisTraining_Auth.Repositories.UserRepository;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace IrisTraining_Auth.Services
{
    public class AuthService : Auth.AuthBase
    {
        private readonly ILogger<AuthService> _logger;
        private readonly IUserRepository _userRepository;
        private readonly DatabaseContext _databaseContext;
        public AuthService(ILogger<AuthService> logger,IUserRepository userRepository , DatabaseContext databaseContext)
        {
            _userRepository = userRepository;
            _logger = logger;
            _databaseContext = databaseContext;
        }

        public override async Task<RegisterResponse> Register(RegisterRequest request, ServerCallContext context)
        {
            //_userRepository
            string sql = "EXEC dbo.REGISTER_USER @Email , @Password ";
            var result = await _databaseContext.Users.FromSqlRaw
            (sql,
            new SqlParameter("@Email", request.Email),
            new SqlParameter("@Password", request.PassWord)
            ).ToListAsync();
            var user = result.FirstOrDefault();
            await _databaseContext.SaveChangesAsync();
            if (user == null)
            {
                throw new InvalidOperationException("User already exists");
            }
            return await Task.FromResult(new RegisterResponse
            {
                Message = "Register successfully"
            });
        }

        public override async Task<LoginResponse> Login(LoginRequest request, ServerCallContext context)
        {
            User user = await _databaseContext.Users.FirstOrDefaultAsync(item => item.Email.Equals(request.Email) && item.Password.Equals(request.PassWord));
            if (user == null)
            {
                throw new InvalidOperationException("Incorrect email or password");
            }
            return await Task.FromResult(new LoginResponse
            {
                Message = "Login successfully"
            });
        }
    }
}
