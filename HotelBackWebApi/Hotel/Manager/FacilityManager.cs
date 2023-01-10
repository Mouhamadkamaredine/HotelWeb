using Hotel.Models;
using Hotel.reposetory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Manager
{
  public class FacilityManager
    {
        private readonly IFacility _facility;
        public FacilityManager(IFacility facility)
        {
            _facility = facility;
        }
        public async Task<int> CreateFacility(string name, string title,  string image)
        {
            if (name == null)
            {
                throw new ArgumentException("Number must greater than zero", nameof(name));
            }
            if (title == null)
            {
                throw new ArgumentException("Number must greater than zero", nameof(title));
            }



            var id = await this._facility.Insert(name,title,image);




            return id;
        }

        public async Task UpdateFacility(int id, string name, string title, string image)
        {
            if (name == null)
            {
                throw new ArgumentException("Number must greater than zero", nameof(name));
            }
            if (title == null)
            {
                throw new ArgumentException("Number must greater than zero", nameof(title));
            }
            await this._facility.Update(id, name, title, image);
        }

        public async Task<Facility> RetrieveFacilityById(int id)
        {
            var result = await this._facility.SelectById(id);
            if (id <= 0)
            {
                throw new ArgumentException("your Room id must be greater than 0", nameof(id));
            }




            return result;
        }
        public IAsyncEnumerable<Facility> GetFacility()

        {
            var result = this._facility.Select();
            if (result == null)
            {
                throw new ArgumentNullException("No Room Occured ");
            }
            return result;
        }
        public async Task DeleteFacility(int id)
        {
            var result = this._facility.SelectById(id);
            if (result == null)
            {
                throw new ArgumentNullException(nameof(id), "User for this Id doesnt Exist ");
            }

            await this._facility.Delete(id);
        }
    }
}
