using Hotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.reposetory
{
   public interface IHotelInfo
    {
        Task<int> Insert(string descreption, string abouUs, string email ,string phone1, string phone2, string address1,string address2,string copyright);

        Task Update(int id, string descreption, string abouUs, string email, string phone1, string phone2, string address1, string address2, string copyright);
        Task Delete(int id);
        IAsyncEnumerable<HotelInfo> Select();
        Task<HotelInfo> SelectById(int id);
    }
}
