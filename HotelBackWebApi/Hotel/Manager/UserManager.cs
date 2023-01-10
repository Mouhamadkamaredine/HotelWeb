using Hotel.reposetory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Manager
{
    public class UserManager
    {
        private readonly IUser _user;

        public UserManager(IUser user)
        {
            _user = user;
        }

        public async Task<int> CreateUser(string userName, string fullName, string email, string password,int roleId)
        {
            if (userName == null)
            {
                throw new ArgumentException("UserName not be empty");
            }
            if (password == null)
            {
                throw new ArgumentNullException(nameof(password), "password should not be null");
            }
            
            if (password.Length > 12)
            {
                throw new ArgumentException(nameof(password), "Password must have 12 characters for maximum");
            }
          
            var id = await this._user.Insert(userName, fullName, email,  password, roleId);

            return id;
        }


    }
}
