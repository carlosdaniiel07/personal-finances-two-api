using System;
using System.Linq;

using Liphsoft.Crypto.Argon2;

using personal_finances_two_api.Models;
using personal_finances_two_api.Repositories;
using personal_finances_two_api.Services.Exceptions;

namespace personal_finances_two_api.Services
{
    public class AuthService
    {
        private UserRepository _userRepository = new UserRepository();
        private AccessLogRepository _accessLogRepository = new AccessLogRepository();
        private PasswordHasher _argonHasher = new PasswordHasher();

        // Return the user's TOKEN
        public User Auth (User user)
        {
            user.Password = Hash(user.Password);
            var retrievedUser = _userRepository.Auth(user);

            if (retrievedUser != null)
            {
                GenerateAcessLog(retrievedUser);
                return retrievedUser;
            }
            else
            {
                throw new ObjectNotFoundException("Not found a user with this credentials");
            }
        }

        public bool IsValidToken (string token)
        {
            return _userRepository.GetByToken(token) != null;
        }

        private void GenerateAcessLog (User user)
        {
            var accessLog = new AccessLog(DateTime.Now, user.Id);
            _accessLogRepository.Insert(accessLog);
        }

        // Hash a password with the Argon2 lib
        private string Hash (string password)
        {
            string salt = "jWtoG33gflJY2U5d";
            return _argonHasher.Hash(password, salt);
        }

        // Compare a Hash with a plain text value
        private bool CompareHash (string hash, string plainText)
        {
            return _argonHasher.Verify(hash, plainText);
        }
    }
}