using Hotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.reposetory
{
    public interface  IFacility
    {
        Task<int> Insert( string name, string title,  string image);

        Task Update(int id, string name, string title, string image);
        Task Delete(int id);
        IAsyncEnumerable<Facility> Select();
        Task<Facility> SelectById(int id);
    }
}
