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
    public class UserOp : IUser
    {
        private readonly string sQLAuth;

        public UserOp(string connection)
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
                    CommandText = "usp_DeleteUser"
                };
                command.Parameters.Add(new SqlParameter("@Id", id));
                command.ExecuteNonQueryAsync();
                await conn.CloseAsync();
            }
        }

        public async Task<int> Insert(string userName, string fullName, string email, string password,int RoleId)
        {
            int result = default;

            using (SqlConnection conn = new SqlConnection(this.sQLAuth))
            {
                await conn.OpenAsync();
                SqlCommand command = new SqlCommand("usp_createUser2", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };


                command.Parameters.AddWithValue("@UserName", userName);
                command.Parameters.AddWithValue("@FullName", fullName);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@PasswordHash", password);
                command.Parameters.AddWithValue("@AccessFailedCount", RoleId);
             
                result = Convert.ToInt32(await command.ExecuteScalarAsync());

                await conn.CloseAsync();
            }

            return result;
        }

        public async IAsyncEnumerable<User> Select()
        {
            using (SqlConnection conn = new SqlConnection(this.sQLAuth))
            {
                await conn.OpenAsync();

                var command = new SqlCommand()
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "usp_SelectUser"
                };

                using (SqlDataReader dataReader = await command.ExecuteReaderAsync())
                {
                    while (await dataReader.ReadAsync())
                    {
                        yield return (
                              new User()
                              {

                                  UserName = Convert.ToString(dataReader["UserName"]),
                                  FullName = Convert.ToString(dataReader["FullName"]),
                                  Email = Convert.ToString(dataReader["Email"]),
                                  Password = Convert.ToString(dataReader["PasswordHash"]),
                                 RoleId = Convert.ToInt32(dataReader["RoleId"]),
                                 
                              });
                    }

                }
            }
        }

        public async Task<User> SelectById(int id)
        {
           User result = default;
            using (SqlConnection conn = new SqlConnection(this.sQLAuth))
            {
                await conn.OpenAsync();

                var command = new SqlCommand()
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "usp_SelectUserById"
                };
                command.Parameters.Add(new SqlParameter("@Id", id));
                using (SqlDataReader dataReader = await command.ExecuteReaderAsync())
                {
                    while (await dataReader.ReadAsync())
                    {
                        result = new User()
                        {
                            UserName = Convert.ToString(dataReader["UserName"]),
                            FullName = Convert.ToString(dataReader["FullName"]),
                            Email = Convert.ToString(dataReader["Email"]),
                            Password = Convert.ToString(dataReader["PasswordHash"]),
                            RoleId = Convert.ToInt32(dataReader["UserRole"]),
                        };
                    }

                }
            }

            return result;
        }

        public async Task Update(int id, string userName, string fullName, string email, string password, int roleId)
        {
            using (SqlConnection conn = new SqlConnection(this.sQLAuth))
            {
                await conn.OpenAsync();
                var command = new SqlCommand()
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "usp_UpdateUser"
                };
             
                command.Parameters.Add(new SqlParameter("@Id", id));

                command.Parameters.AddWithValue("@UserName", userName);
                command.Parameters.AddWithValue("@FullName", fullName);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@PasswordHash", password);
                command.Parameters.AddWithValue("@RoleId", roleId);
                command.ExecuteNonQueryAsync();
                await conn.CloseAsync();
            }
        }
    }
}
