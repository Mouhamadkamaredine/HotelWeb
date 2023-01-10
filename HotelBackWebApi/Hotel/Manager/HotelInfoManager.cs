using Hotel.Models;
using Hotel.reposetory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Manager
{
   public class HotelInfoManager
    {

        private readonly IHotelInfo _hotelInfo;
        public HotelInfoManager(IHotelInfo hotelInfo)
        {
            _hotelInfo = hotelInfo;
        }
        public async Task<int> CreateHotelInfo(string descreption, string abouUs, string email, string phone1, string phone2, string address1, string address2, string copyright)
        {
            if (descreption== null)
            {
                throw new ArgumentException("Number must greater than zero", nameof(descreption));
            }
            if (phone1 == null)
            {
                throw new ArgumentException("Number must greater than zero", nameof(phone1));
            }



            var id = await this._hotelInfo.Insert(descreption,abouUs,email,phone1,phone2,address1,address2,copyright);




            return id;
        }

        public async Task UpdateHotelInfo(int id, string descreption, string abouUs, string email, string phone1, string phone2, string address1, string address2, string copyright)
        {
            if (descreption == null)
            {
                throw new ArgumentException("Number must greater than zero", nameof(descreption));
            }
            if (phone1 == null)
            {
                throw new ArgumentException("Number must greater than zero", nameof(phone1));
            }


            await this._hotelInfo.Update(id, descreption, abouUs, email, phone1, phone2, address1, address2, copyright);
        }

        public async Task<HotelInfo> RetrieveHotelInfoById(int id)
        {
            var result = await this._hotelInfo.SelectById(id);
            if (id <= 0)
            {
                throw new ArgumentException("your Room id must be greater than 0", nameof(id));
            }




            return result;
        }
        public IAsyncEnumerable<HotelInfo> GetFacility()

        {
            var result = this._hotelInfo.Select();
            if (result == null)
            {
                throw new ArgumentNullException("No Room Occured ");
            }
            return result;
        }
        public async Task DeleteFacility(int id)
        {
            var result = this._hotelInfo.SelectById(id);
            if (result == null)
            {
                throw new ArgumentNullException(nameof(id), "User for this Id doesnt Exist ");
            }

            await this._hotelInfo.Delete(id);
        }
    }
}
