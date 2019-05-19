using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using personal_finances_two_api.Models;

namespace personal_finances_two_api.Repositories
{
    public class UserRepository
    {
        public User Auth (User auth)
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Users.SingleOrDefault(u => u.Nickname.Equals(auth.Nickname) && u.Password.Equals(auth.Password) && u.Enabled);
            }
        }

        public User GetByToken (string token)
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Users.SingleOrDefault(u => u.Token.Equals(token) && u.Enabled);
            }
        }
    }
}