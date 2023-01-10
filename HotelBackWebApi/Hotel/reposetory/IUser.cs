using Hotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.reposetory
{
    public interface IUser
    {

        Task<int> Insert(string userName,string fullName,string email,string password,int roleId);

        Task Update(int id , string userName, string fullName, string email, string password, int roleId);
        Task Delete(int id);
        IAsyncEnumerable<User> Select();
        Task<User> SelectById(int id);
        
    }
}
