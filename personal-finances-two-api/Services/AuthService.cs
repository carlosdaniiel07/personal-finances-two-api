using System;
using System.Security.Cryptography;
using System.Text;

using personal_finances_two_api.Models;
using personal_finances_two_api.Repositories;
using personal_finances_two_api.Services.Exceptions;

namespace personal_finances_two_api.Services
{
    public class AuthService
    {
        private UserRepository _userRepository = new UserRepository();
        private AccessLogRepository _accessLogRepository = new AccessLogRepository();

        // Return the user's TOKEN
        public User Auth (User user)
        {
            user.Password = Sha256Encrypt(user.Password);
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

        private string Sha256Encrypt (string value)
        {
            var encoding = new UTF8Encoding();
            var hasher = new SHA256Managed();
            var hash = new StringBuilder();

            foreach (var aByte in hasher.ComputeHash(encoding.GetBytes(value)))
                hash.Append(aByte.ToString("x2"));

            return hash.ToString();
        }
    }
}