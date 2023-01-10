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
    public class RoomNbOp : IRoomNb
    {

        private readonly string sQLAuth;

        public RoomNbOp(string connection)
        {
            this.sQLAuth = connection;
        }
        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Insert(int roomId, int roomNumber)
        {
            int result = default;

            using (SqlConnection conn = new SqlConnection(this.sQLAuth))
            {
                await conn.OpenAsync();
                SqlCommand command = new SqlCommand("usp_CreateRoomNumber", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };


                command.Parameters.AddWithValue("@RoomId",roomId );
                command.Parameters.AddWithValue("@RoomNumber", roomNumber);
               
                result = Convert.ToInt32(await command.ExecuteScalarAsync());

                await conn.CloseAsync();
            }

            return result;
        }

        public IAsyncEnumerable<RoomNb> PaginationRetrieve(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public async IAsyncEnumerable<RoomNb> Select()
        {
            using (SqlConnection conn = new SqlConnection(this.sQLAuth))
            {
                await conn.OpenAsync();

                var command = new SqlCommand()
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "usp_SelectRoomDatas"
                };

                using (SqlDataReader dataReader = await command.ExecuteReaderAsync())
                {
                    while (await dataReader.ReadAsync())
                    {
                        yield return (
                              new RoomNb()
                              {
                                  
                                  ID = Convert.ToInt32(dataReader["Id"]),
                                  RoomId = Convert.ToInt32(dataReader["RoomId"]),
                                  RoomNumber = Convert.ToInt32(dataReader["RoomNumber"]),
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

        public async Task<RoomNb> SelectById(int id)
        {
            RoomNb result = default;
            using (var connect = new SqlConnection(this.sQLAuth))
            {
                await connect.OpenAsync();

                var command = new SqlCommand()
                {
                    Connection = connect,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "usp_SelectRoomDetailss"
                };
                command.Parameters.Add(new SqlParameter("@Id", id));
                using (SqlDataReader dataReader = await command.ExecuteReaderAsync())
                {
                    while (await dataReader.ReadAsync())
                    {
                        result = new RoomNb()
                        {
                            ID = Convert.ToInt32(dataReader["Id"]),
                            RoomId = Convert.ToInt32(dataReader["RoomId"]),
                            RoomNumber = Convert.ToInt32(dataReader["RoomNumber"]),
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

        public Task Update(int id, int roomId, int roomNumber)
        {
            throw new NotImplementedException();
        }
    }
}
