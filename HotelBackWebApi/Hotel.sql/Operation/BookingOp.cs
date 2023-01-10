using Hotel.Models;
using Hotel.reposetory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.sql.Operation
{
    public class BookingOp : IBooking
    {

        private readonly string sQLAuth;

        public BookingOp(string connection)
        {
            this.sQLAuth = connection;
        }

        public async Task<Booking> ChecKAvailable(string checkin, string checkout)
        {
            Booking result = default;
            using (SqlConnection conn = new SqlConnection(this.sQLAuth))
            {
                await conn.OpenAsync();

                var command = new SqlCommand()
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "testing1"
                };
                command.Parameters.Add(new SqlParameter("@checkin", checkin));
                command.Parameters.Add(new SqlParameter("@checkout", checkout));
                using (SqlDataReader dataReader = await command.ExecuteReaderAsync())
                {
                    while (await dataReader.ReadAsync())
                    {
                        result = new Booking()
                        {
                          
                           

                            RoomNb = Convert.ToInt32(dataReader["RoomNb"]),
                        };
                    }

                }
            }

            return result;
        }

        public async Task Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(this.sQLAuth))
            {
                await conn.OpenAsync();

                var command = new SqlCommand()
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "usp_DeleteBook1"
                };
                command.Parameters.Add(new SqlParameter("@Id", id));
                command.ExecuteNonQueryAsync();
                await conn.CloseAsync();
            }
        }

        public  async Task<int> Insert(string firstName, string lastName, string email, string phone, string country, string city, string address, string ZipCode, int roomCount, int adult, int child, string checkin, string checkout, string timeArrive,  int roomNb)
        {
            int result = default;

            using (SqlConnection conn = new SqlConnection(this.sQLAuth))
            {
                await conn.OpenAsync();
                SqlCommand command = new SqlCommand("usp_createBook1", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };


                command.Parameters.AddWithValue("@FirstName", firstName);
                command.Parameters.AddWithValue("@LastName", lastName);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Phone", phone);
                command.Parameters.AddWithValue("@Country", country);
                command.Parameters.AddWithValue("@City", city);
                command.Parameters.AddWithValue("@Address", address);
                command.Parameters.AddWithValue("@ZipCode", ZipCode);

                command.Parameters.AddWithValue("@RoomCount",roomCount);
                command.Parameters.AddWithValue("@Checkin", checkin);
                command.Parameters.AddWithValue("@Checkout", checkout);
                command.Parameters.AddWithValue("@TimeArrive", timeArrive);
               
                command.Parameters.AddWithValue("@Adult", adult);
                command.Parameters.AddWithValue("@Child", child);
                command.Parameters.AddWithValue("@RoomNumber", roomNb);
                result = Convert.ToInt32(await command.ExecuteScalarAsync());

                await conn.CloseAsync();
            }

            return result;
        }

      
        public async IAsyncEnumerable<Booking> Select()
        {

            using (SqlConnection conn = new SqlConnection(this.sQLAuth))
            {
                await conn.OpenAsync();

                var command = new SqlCommand()
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "usp_SelectBook1"
                };

                using (SqlDataReader dataReader = await command.ExecuteReaderAsync())
                {
                    while (await dataReader.ReadAsync())
                    {
                        yield return (
                              new Booking()
                              {
                                 BookingId = Convert.ToInt32(dataReader["BookingId"]),
                                 FirstName = Convert.ToString(dataReader["FirstName"]),
                                  LastName = Convert.ToString(dataReader["LastName"]),
                                 Phone= Convert.ToString(dataReader["Phone"]),
                                  Email = Convert.ToString(dataReader["Email"]),
                                  Country = Convert.ToString(dataReader["Country"]),
                                  City = Convert.ToString(dataReader["City"]),
                                  Address = Convert.ToString(dataReader["Address"]),
                                  ZipCode = Convert.ToString(dataReader["ZipCode"]),
                                  RoomCount = Convert.ToInt32(dataReader["RoomCount"]),
                                  Adult = Convert.ToInt32(dataReader["Adult"]),
                                 Child = Convert.ToInt32(dataReader["Child"]),
                                  Checkin = Convert.ToString(dataReader["Checkin"]),
                                  Checkout = Convert.ToString(dataReader["Checkout"]),
                                  TimeArrive = Convert.ToString(dataReader["TimeArrive"]),
                                  
                                  RoomNb= Convert.ToInt32(dataReader["RoomNumber"]),

                              });
                    }

                }
            }
        }

        public async Task<Booking> SelectById(int id)
        {
            Booking result = default;
            using (SqlConnection conn = new SqlConnection(this.sQLAuth))
            {
                await conn.OpenAsync();

                var command = new SqlCommand()
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "usp_SelectBookingId2"
                };
                command.Parameters.Add(new SqlParameter("@Id", id));
                using (SqlDataReader dataReader = await command.ExecuteReaderAsync())
                {
                    while (await dataReader.ReadAsync())
                    {
                        result = new Booking()
                        {
                            BookingId = Convert.ToInt32(dataReader["BookingId"]),
                            FirstName = Convert.ToString(dataReader["FirstName"]),
                            LastName = Convert.ToString(dataReader["LastName"]),
                            Phone = Convert.ToString(dataReader["Phone"]),
                            Email = Convert.ToString(dataReader["Email"]),
                            Country = Convert.ToString(dataReader["Country"]),
                            City = Convert.ToString(dataReader["City"]),
                            Address = Convert.ToString(dataReader["Address"]),
                            ZipCode = Convert.ToString(dataReader["ZipCode"]),
                            RoomCount = Convert.ToInt32(dataReader["RoomCount"]),
                            Adult = Convert.ToInt32(dataReader["Adult"]),
                            Child = Convert.ToInt32(dataReader["Child"]),
                            Checkin = Convert.ToString(dataReader["Checkin"]),
                            Checkout = Convert.ToString(dataReader["Checkout"]),
                            TimeArrive = Convert.ToString(dataReader["TimeArrive"]),
                            
                            RoomNb = Convert.ToInt32(dataReader["RoomNumber"]),
                        };
                    }

                }
            }

            return result;
        }

        public async Task Update(int id, string firstName, string lastName, string email, string phone, string country, string city, string address, string ZipCode, int roomCount, int adult, int child, string checkin, string checkout, string timeArrive, int roomNb)
        {
            using (SqlConnection conn = new SqlConnection(this.sQLAuth))
            {
                await conn.OpenAsync();
                var command = new SqlCommand()
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "usp_UpdateBook1"
                };
               
                command.Parameters.Add(new SqlParameter("@Id", id));
                command.Parameters.AddWithValue("@FirstName", firstName);
                command.Parameters.AddWithValue("@LastName", lastName);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Phone", phone);
                command.Parameters.AddWithValue("@Country", country);
                command.Parameters.AddWithValue("@City", city);
                command.Parameters.AddWithValue("@Address", address);
                command.Parameters.AddWithValue("@ZipCode", ZipCode);

                command.Parameters.AddWithValue("@RoomCount", roomCount);
                command.Parameters.AddWithValue("@Checkin", checkin);
                command.Parameters.AddWithValue("@Checkout", checkout);
                command.Parameters.AddWithValue("@TimeArrive", timeArrive);
               
                command.Parameters.AddWithValue("@Adult", adult);
                command.Parameters.AddWithValue("@Child", child);
                command.Parameters.AddWithValue("@RoomNumber", roomNb);
                command.ExecuteNonQueryAsync();
                await conn.CloseAsync();
            }
        }
    }
}
