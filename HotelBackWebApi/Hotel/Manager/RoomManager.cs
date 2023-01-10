
using Hotel.Models;
using Hotel.reposetory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Manager
{
   public class RoomManager
    {
        private readonly IRoom _room;
       
        public RoomManager(IRoom room)
        {
            _room = room;
           
        }
        public async Task<int> CreateRoom( int roomNb,string roomName,string descreption,int cost ,string bedType,int geusts,int roomSize , string roomImage)
        {
            if (cost == default)
            {
                throw new ArgumentException("Number must greater than zero", nameof(cost));
            }
            if (roomSize == default)
            {
                throw new ArgumentException("Number must greater than zero", nameof(roomSize));
            }



            var id = await this._room.Insert(roomNb, roomName,descreption,cost,bedType,geusts,roomSize,roomImage);
           

          

            return id;
        }

        public async Task UpdateRoom(int id, int roomNb,string roomName, string descreption, int cost, string bedType, int geusts, int roomSize, string roomImage)
        {

            if (cost == default)
            {
                throw new ArgumentException("Number must greater than zero", nameof(cost));
            }
            if (roomSize == default)
            {
                throw new ArgumentException("Number must greater than zero", nameof(roomSize));
            }
            await this._room.Update(id,roomNb ,roomName, descreption, cost, bedType, geusts, roomSize, roomImage);
        }

        public async Task<Room> RetrieveRoomById(int id)
        {
            var result = await this._room.SelectById(id);
            if (id <= 0)
            {
                throw new ArgumentException("your Room id must be greater than 0", nameof(id));
            }

           
           

            return result;
        }







        public IAsyncEnumerable<Room> GetRoom()

        {
            var result =  this._room.Select();
            if (result == null)
            {
                throw new ArgumentNullException("No Room Occured ");
            }
            return result;
        }
      

        public async Task DeleteRoom(int id)
        {
            var result = this._room.SelectById(id);
            if (result == null)
            {
                throw new ArgumentNullException(nameof(id), "User for this Id doesnt Exist ");
            }
        
            await this._room.Delete(id);
        }
    }
}
