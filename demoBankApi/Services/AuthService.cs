using demoBankApi.DTOs;
using demoBankApi.Entities;
using demoBankApi.Repositories;

namespace demoBankApi.Services
{
    public class AuthService
    {
        private readonly UserRepository _userRepository;
        private readonly AccountService _accountService;

        public AuthService(UserRepository userRepository, AccountService accountService)
        {
            _userRepository = userRepository;
            _accountService = accountService;
        }

        public async Task<User> Register(UserRequest request)
        {
            User? userExists = await _userRepository.FindByUsername(request.Username);

            if (userExists != null)
            {
                throw new Exception("Username already exists");
            }

            User user = new()
            {
                Username = request.Username,
                Password = request.Password
            };

            user = await _userRepository.Save(user);

            await _accountService.Create(user, request.Cpf, request.Tel);

            return user;
        }

        public async Task<User> AuthenticateUser(UserRequest request)
        {
            User? user = await _userRepository.FindByUsername(request.Username);

            if (user == null)
            {
                throw new Exception("Invalid Credentials");
            }
            
            if(!PasswordMatch(user, request.Password))
            {
                throw new Exception("Invalid Credentials");
            }

            return user;
        }

        private bool PasswordMatch(User user, string password)
        {
            return user.Password == password;
        }
    }
}
