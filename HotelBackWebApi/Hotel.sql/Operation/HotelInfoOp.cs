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
    public class HotelInfoOp : IHotelInfo
    {
        private readonly string sQLAuth;

        public HotelInfoOp(string connection)
        {
            this.sQLAuth = connection;
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
                    CommandText = "usp_DeleteHotelInfo"
                };
                command.Parameters.Add(new SqlParameter("@Id", id));
                command.ExecuteNonQueryAsync();
                await conn.CloseAsync();
            }
        }

        public async Task<int> Insert(string descreption, string abouUs, string email, string phone1, string phone2, string address1, string address2, string copyright)
        {

            int result = default;

            using (SqlConnection conn = new SqlConnection(this.sQLAuth))
            {
                await conn.OpenAsync();
                SqlCommand command = new SqlCommand("usp_insertHotelInfo", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@Descreption", descreption);
                command.Parameters.AddWithValue("@Aboutus", abouUs);
                command.Parameters.AddWithValue("@Email",email);
                command.Parameters.AddWithValue("@phone1",phone1);
                command.Parameters.AddWithValue("@phone2", phone2);
                command.Parameters.AddWithValue("@Address1",address1);
                command.Parameters.AddWithValue("@Address2", address2);
                command.Parameters.AddWithValue("@Copyright", copyright);
                result = Convert.ToInt32(await command.ExecuteScalarAsync());

                await conn.CloseAsync();
            }

            return result;
        }

        public async IAsyncEnumerable<HotelInfo> Select()
        {
            using (SqlConnection conn = new SqlConnection(this.sQLAuth))
            {
                await conn.OpenAsync();

                var command = new SqlCommand()
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "usp_selectHotelInfo"
                };

                using (SqlDataReader dataReader = await command.ExecuteReaderAsync())
                {
                    while (await dataReader.ReadAsync())
                    {
                        yield return (
                              new HotelInfo()
                              {
                                  ID = Convert.ToInt32(dataReader["Id"]),
                                 
                                  Descreption = Convert.ToString(dataReader["Descreption"]),

                               
                                  AboutUs = Convert.ToString(dataReader["Aboutus"]),
                                 Email = Convert.ToString(dataReader["Email"]),

                                  Phone1 = Convert.ToString(dataReader["phone1"]),
                                  phone2 = Convert.ToString(dataReader["phone2"]),


                                  Address1 = Convert.ToString(dataReader["Address1"]),

                                  Address2 = Convert.ToString(dataReader["Address2"]),
                                  CopyRight = Convert.ToString(dataReader["Copyright"]),
                              });
                    }

                }
            }
        }

        public  async Task<HotelInfo> SelectById(int id)
        {
           HotelInfo result = default;
            using (SqlConnection conn = new SqlConnection(this.sQLAuth))
            {
                await conn.OpenAsync();

                var command = new SqlCommand()
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "usp_selecteHotelInfo"
                };
                command.Parameters.Add(new SqlParameter("@Id", id));
                using (SqlDataReader dataReader = await command.ExecuteReaderAsync())
                {
                    while (await dataReader.ReadAsync())
                    {
                        result = new HotelInfo()
                        {
                            ID = Convert.ToInt32(dataReader["Id"]),
                            Descreption = Convert.ToString(dataReader["Descreption"]),


                            AboutUs = Convert.ToString(dataReader["Aboutus"]),
                            Email = Convert.ToString(dataReader["Email"]),
                            Phone1 = Convert.ToString(dataReader["phone1"]),
                            phone2 = Convert.ToString(dataReader["phone2"]),


                            Address1 = Convert.ToString(dataReader["Address1"]),

                            Address2 = Convert.ToString(dataReader["Address2"]),
                            CopyRight = Convert.ToString(dataReader["Copyright"]),
                        };
                    }

                }
            }

            return result;
        }

        public async Task Update(int id, string descreption, string abouUs, string email, string phone1, string phone2, string address1, string address2, string copyright)
        {
            using (SqlConnection conn = new SqlConnection(this.sQLAuth))
            {
                await conn.OpenAsync();
                var command = new SqlCommand()
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "usp_UpdateHotelInfo"
                };


                command.Parameters.AddWithValue("@Descreption", descreption);
                command.Parameters.AddWithValue("@Aboutus", abouUs);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@phone1", phone1);
                command.Parameters.AddWithValue("@phone2", phone2);
                command.Parameters.AddWithValue("@Address1", address1);
                command.Parameters.AddWithValue("@Address2", address2);
                command.Parameters.AddWithValue("@Copyright", copyright);
                command.Parameters.Add(new SqlParameter("@Id", id));
                command.ExecuteNonQueryAsync();
                await conn.CloseAsync();
            }
        }
    }
}
