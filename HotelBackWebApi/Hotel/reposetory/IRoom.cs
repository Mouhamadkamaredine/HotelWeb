using Hotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.reposetory
{
    public interface IRoom
    {
        Task<int> Insert(int RoomNb ,string roomName,string descreption,int cost , string bedType , int geusts,int roomSize, string roomImage);

        Task Update( int id, int roomNb, string roomName, string descreption, int cost, string bedType, int geusts, int roomSize, string roomImage);
        Task Delete(int id);
        IAsyncEnumerable<Room> Select();
        Task<Room> SelectById(int id);
        public IAsyncEnumerable<Room> PaginationRetrieve(int pageNumber, int pageSize);
     
    }
}
