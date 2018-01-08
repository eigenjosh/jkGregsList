using System.Data;
using GregsList.Models;
using Dapper;
using MySql.Data.MySqlClient;

namespace GregsList.Repositories
{
    public class UserRepository : DbContext
    {
        public UserRepository(IDbConnection db) : base(db)
        {
        }

        public UserReturnModel Register(RegisterUserModel creds)
        {
            // encrypt the password??
            creds.Password = BCrypt.Net.BCrypt.HashPassword(creds.Password);
            //sql
            try
            {

                int id = _db.ExecuteScalar<int>(@"
                INSERT INTO users (Username, Email, Password)
                VALUES (@Username, @Email, @Password);
                SELECT LAST_INSERT_ID();
            ", creds);

                return new UserReturnModel()
                {
                    Id = id,
                    Username = creds.Username,
                    Email = creds.Email
                };
            }
            catch (MySqlException e)
            {
                System.Console.WriteLine("ERROR: " + e.Message);
                return null;
            }
        }

        public UserReturnModel Login(LoginUserModel creds)
        {
            // more sql
            User user = _db.QueryFirstOrDefault<User>(@"
                SELECT * FROM users WHERE email = @Email
            ", creds);
            if (user != null)
            {
                var valid = BCrypt.Net.BCrypt.Verify(creds.Password, user.Password);
                if (valid)
                {
                    return new UserReturnModel()
                    {
                        Id = user.Id,
                        Username = user.Username,
                        Email = user.Email
                    };
                }
            }
            return null;
        }

    }
}