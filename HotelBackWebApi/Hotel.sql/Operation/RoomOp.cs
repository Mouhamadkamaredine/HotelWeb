
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
    public class RoomOp : IRoom
    {
        private readonly string sQLAuth;

        public RoomOp(string connection)
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
                    CommandText = "usp_DeletesRoom"
                };
                command.Parameters.Add(new SqlParameter("@Id", id));
                command.ExecuteNonQueryAsync();
                await conn.CloseAsync();
            }
        }

        public async Task<int> Insert(int roomNb,string roomName,string descreption,int cost ,string bedType,int geusts,int roomSize,string roomImage)
        {
            int result = default;

            using (SqlConnection conn = new SqlConnection(this.sQLAuth))
            {
                await conn.OpenAsync();
                SqlCommand command = new SqlCommand("usp_insertRoom1", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@RoomNb", roomNb);
                command.Parameters.AddWithValue("@RoomName", roomName);
                command.Parameters.AddWithValue("@Descreption", descreption);
                command.Parameters.AddWithValue("@Cost", cost);
                command.Parameters.AddWithValue("@BedType", bedType);
                command.Parameters.AddWithValue("@Geusts", geusts);
                command.Parameters.AddWithValue("@RoomSize", roomSize);
                command.Parameters.AddWithValue("@RoomImage", roomImage);
                result = Convert.ToInt32(await command.ExecuteScalarAsync());

                await conn.CloseAsync();
            }

            return result;
        }

        public async IAsyncEnumerable<Room> PaginationRetrieve(int pageNumber, int pageSize)
        {
            using (SqlConnection conn = new SqlConnection(this.sQLAuth))
            {
                await conn.OpenAsync();

                var command = new SqlCommand
                {
                    CommandText = "PaginationRetrieve",
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                };

                command.Parameters.Add(new SqlParameter("@PageNumber", pageNumber));
                command.Parameters.Add(new SqlParameter("@PageSize", (pageSize)));

                using (SqlDataReader dataReader = await command.ExecuteReaderAsync())
                {
                    while (await dataReader.ReadAsync())
                    {
                        yield return
                            new Room()
                            {
                                ID = Convert.ToInt32(dataReader["Id"]),
                                RoomNb = Convert.ToInt32(dataReader["RoomNb"]),
                                RoomName = Convert.ToString(dataReader["NumberOfSeats"]),
                                Descreption = Convert.ToString(dataReader["NumberOfSeats"]),
                                Cost = Convert.ToInt32(dataReader["Number"]),
                                BedType = Convert.ToString(dataReader["NumberOfSeats"]),
                                Geusts = Convert.ToInt32(dataReader["NumberOfSeats"]),
                                RoomSize = Convert.ToInt32(dataReader["NumberOfSeats"]),
                                RoomImage = Convert.ToString(dataReader["NumberOfSeats"]),
                            };
                    }
                }
            }
        }

        public async IAsyncEnumerable<Room> Select()
        {
           
            using (SqlConnection conn = new SqlConnection(this.sQLAuth))
            {
                await conn.OpenAsync();

                var command = new SqlCommand()
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "usp_selectedRom1"
                };
               
                using (SqlDataReader dataReader = await command.ExecuteReaderAsync())
                {
                    while (await dataReader.ReadAsync())
                    {
                        yield return (
                              new Room()
                              {
                                 ID = Convert.ToInt32(dataReader["RoomTypeId"]),
                                  RoomNb = Convert.ToInt32(dataReader["RoomNb"]),
                                  RoomName = Convert.ToString(dataReader["RoomName"]),
                            Descreption = Convert.ToString(dataReader["Descreption"]),
                            Cost = Convert.ToInt32(dataReader["Cost"]),
                            BedType = Convert.ToString(dataReader["BedType"]),
                            Geusts = Convert.ToInt32(dataReader["Geusts"]),
                            RoomSize = Convert.ToInt32(dataReader["RoomSize"]),
                            RoomImage = Convert.ToString(dataReader["RoomImage"]),
                        });
                    }

                }
            }
          
        }

        public async Task<Room> SelectById(int id)
        {
            Room result = default;
            using (SqlConnection conn = new SqlConnection(this.sQLAuth))
            {
                await conn.OpenAsync();

                var command = new SqlCommand()
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "usp_selectedRomId1"
                };
                command.Parameters.Add(new SqlParameter("@Id", id));
                using (SqlDataReader dataReader = await command.ExecuteReaderAsync())
                {
                    while (await dataReader.ReadAsync())
                    {
                        result = new Room()
                        {
                            ID = Convert.ToInt32(dataReader["RoomTypeId"]),
                            RoomNb = Convert.ToInt32(dataReader["RoomNb"]),
                            RoomName = Convert.ToString(dataReader["RoomName"]),
                            Descreption = Convert.ToString(dataReader["Descreption"]),
                            Cost = Convert.ToInt32(dataReader["Cost"]),
                            BedType = Convert.ToString(dataReader["BedType"]),
                            Geusts = Convert.ToInt32(dataReader["Geusts"]),
                            RoomSize = Convert.ToInt32(dataReader["RoomSize"]),
                            RoomImage = Convert.ToString(dataReader["RoomImage"]),
                        };
                    }

                }
            }

            return result;
        }

        public async Task Update(int id, int roomNb, string roomName, string descreption, int cost, string bedType, int geusts, int roomSize, string roomImage)
        {
            using (SqlConnection conn = new SqlConnection(this.sQLAuth))
            {
                await conn.OpenAsync();
                var command = new SqlCommand()
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "usp_UpdatesRoom"
                };
               
                
                command.Parameters.Add(new SqlParameter("@RoomNb", roomNb));
                command.Parameters.Add(new SqlParameter("@RoomName", roomName));
                command.Parameters.Add(new SqlParameter("@Descreption", descreption));
                command.Parameters.Add(new SqlParameter("@Cost", cost));
                command.Parameters.Add(new SqlParameter("@BedType", bedType));
                command.Parameters.Add(new SqlParameter("@Geusts", geusts));
                command.Parameters.Add(new SqlParameter("@RoomSize", roomSize));
                command.Parameters.Add(new SqlParameter("@RoomImage", roomImage));
                command.Parameters.Add(new SqlParameter("@RoomTypeId", id));
                command.ExecuteNonQueryAsync();
                await conn.CloseAsync();
            }
        }
    }
}
