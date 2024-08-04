using Microsoft.Data.SqlClient;
using System.Data;
using TBTBGlobal_PruebaTecnicaAPI.Interfaces;
using TBTBGlobal_PruebaTecnicaAPI.Models;

namespace TBTBGlobal_PruebaTecnicaAPI.Services
{
    public class UserService : IUserService
    {
        private readonly string _cadenaSQL;
        public UserService(IConfiguration configuration)
        {
            _cadenaSQL = configuration.GetConnectionString("CadenaSQL");
        }

        public async Task<List<User>> GeUsersAsync()
        {
            List<User> users = new List<User>();

            try
            {
                using (var conn = new SqlConnection(_cadenaSQL))
                {
                    await conn.OpenAsync();
                    var cmd = new SqlCommand("sp_list_users", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    using (var rd = await cmd.ExecuteReaderAsync())
                    {
                        while (await rd.ReadAsync())
                        {
                            users.Add(new User()
                            {
                                Id = Convert.ToInt32(rd["ID"]),
                                Name = Convert.ToString(rd["NAME"]),
                                Email = Convert.ToString(rd["EMAIL"]),
                                RegisterDate = Convert.ToDateTime(rd["REGISTER_DATE"]),
                                Status = Convert.ToBoolean(rd["STATUS"]),
                                Rol = new Rol()
                                {
                                    Id = Convert.ToInt32(rd["ID_ROL"]),
                                    Name = Convert.ToString(rd["NAME_ROl"]),
                                    Status = Convert.ToBoolean(rd["STATUS_ROL"]),
                                }
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }

            return users;
        }

        public async Task<User> GeUsersByIdAsync(Int32 id)
        {
            List<User> users = new List<User>();
            User user = new User();

            try
            {
                using (var conn = new SqlConnection(_cadenaSQL))
                {
                    await conn.OpenAsync();
                    var cmd = new SqlCommand("sp_list_users", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    using (var rd = await cmd.ExecuteReaderAsync())
                    {
                        while (await rd.ReadAsync())
                        {
                            users.Add(new User()
                            {
                                Id = Convert.ToInt32(rd["ID"]),
                                Name = Convert.ToString(rd["NAME"]),
                                Email = Convert.ToString(rd["EMAIL"]),
                                RegisterDate = Convert.ToDateTime(rd["REGISTER_DATE"]),
                                Status = Convert.ToBoolean(rd["STATUS"]),
                                Rol = new Rol()
                                {
                                    Id = Convert.ToInt32(rd["ID_ROL"]),
                                    Name = Convert.ToString(rd["NAME_ROl"]),
                                    Status = Convert.ToBoolean(rd["STATUS_ROL"]),
                                }
                            });
                        }
                    }
                }
                user = users.Where(user => user.Id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }

            return user;
        }

        public async Task<Boolean> InsertUser(User user)
        {
            try
            {
                using (var conn = new SqlConnection(_cadenaSQL))
                {
                    await conn.OpenAsync();
                    var command = new SqlCommand("sp_insert_user", conn);
                    command.Parameters.AddWithValue("NAME", user.Name);
                    command.Parameters.AddWithValue("EMAIL", user.Email);
                    command.Parameters.AddWithValue("ROLE_ID", user.Rol.Id);
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }

        public async Task<Boolean> UpdateUser(User user)
        {
            try
            {
                using (var conn = new SqlConnection(_cadenaSQL))
                {
                    await conn.OpenAsync();
                    var command = new SqlCommand("sp_update_user", conn);
                    command.Parameters.AddWithValue("ID", user.Id);
                    command.Parameters.AddWithValue("NAME", user.Name);
                    command.Parameters.AddWithValue("EMAIL", user.Email);
                    command.Parameters.AddWithValue("ROLE_ID", user.Rol.Id);
                    command.Parameters.AddWithValue("STATUS", user.Status);
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }

        public async Task<Boolean> DeleteUser(Int32 userId)
        {
            try
            {
                using (var conn = new SqlConnection(_cadenaSQL))
                {
                    await conn.OpenAsync();
                    var command = new SqlCommand("sp_delete_user", conn);
                    command.Parameters.AddWithValue("ID", userId);
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }
    }
}
