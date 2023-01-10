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
    public class FacilityOp : IFacility
    {
        private readonly string sQLAuth;

        public FacilityOp(string connection)
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
                    CommandText = "usp_DeleteFacility"
                };
                command.Parameters.Add(new SqlParameter("@Id", id));
                command.ExecuteNonQueryAsync();
                await conn.CloseAsync();
            }
        }

        public async Task<int> Insert(string name, string title, string image)
        {
            int result = default;

            using (SqlConnection conn = new SqlConnection(this.sQLAuth))
            {
                await conn.OpenAsync();
                SqlCommand command = new SqlCommand("usp_insertFacility", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Title", title);
                command.Parameters.AddWithValue("@Image",image);
               
                result = Convert.ToInt32(await command.ExecuteScalarAsync());

                await conn.CloseAsync();
            }

            return result;
        }

        public async IAsyncEnumerable<Facility> Select()
        {
            using (SqlConnection conn = new SqlConnection(this.sQLAuth))
            {
                await conn.OpenAsync();

                var command = new SqlCommand()
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "usp_selectFacility1"
                };

                using (SqlDataReader dataReader = await command.ExecuteReaderAsync())
                {
                    while (await dataReader.ReadAsync())
                    {
                        yield return (
                              new Facility()
                              {
                                  ID = Convert.ToInt32(dataReader["Id"]),
                                 
                                  Name = Convert.ToString(dataReader["Name"]),
                                  Title = Convert.ToString(dataReader["Title"]),
                                 
                                  Image = Convert.ToString(dataReader["Image"]),
                              });
                    }

                }
            }
        }

        public async Task<Facility> SelectById(int id)
        {
            Facility result = default;
            using (SqlConnection conn = new SqlConnection(this.sQLAuth))
            {
                await conn.OpenAsync();

                var command = new SqlCommand()
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "usp_selectedFacilityId"
                };
                command.Parameters.Add(new SqlParameter("@Id", id));
                using (SqlDataReader dataReader = await command.ExecuteReaderAsync())
                {
                    while (await dataReader.ReadAsync())
                    {
                        result = new Facility()
                        {
                            ID = Convert.ToInt32(dataReader["Id"]),

                            Name = Convert.ToString(dataReader["Name"]),
                            Title = Convert.ToString(dataReader["Title"]),

                            Image = Convert.ToString(dataReader["Image"]),
                        };
                    }

                }
            }

            return result;
        }

        public async Task Update(int id, string name, string title, string image)
        {
            using (SqlConnection conn = new SqlConnection(this.sQLAuth))
            {
                await conn.OpenAsync();
                var command = new SqlCommand()
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "usp_UpdateFacility"
                };


                command.Parameters.Add(new SqlParameter("@Name", name));
                command.Parameters.Add(new SqlParameter("@Title", title));
                command.Parameters.Add(new SqlParameter("@Image", image));
              
                command.Parameters.Add(new SqlParameter("@RoomTypeId", id));
                command.ExecuteNonQueryAsync();
                await conn.CloseAsync();
            }
        }
    }
    }

