
using Hotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.reposetory
{
    public interface IRoomNb
    {
        Task<int> Insert(int roomId,int roomNumber);

        Task Update(int id, int roomId, int roomNumber);
        Task Delete(int id);
        IAsyncEnumerable<RoomNb> Select();
        Task<RoomNb> SelectById(int id);
        public IAsyncEnumerable<RoomNb> PaginationRetrieve(int pageNumber, int pageSize);

    }
}
