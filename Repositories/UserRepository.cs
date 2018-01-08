using System.Data;
using Dapper;
using GregsList.Models;

namespace GregsList.Repositories
{
    public class UserRepository : DbContext
    {
        public UserRepository(IDbConnection db) : base(db)
        {
        }
        public UserReturnModel Register(RegisterUserModel creds)
        {
            //encrypt password
            creds.Password = BCrypt.Net.BCrypt.HashPassword(creds.Password);
            //sql here
            int id = _db.ExecuteScalar<int>(@"
            INSERT INTO users (Username, Email, Password)
            VALUES  (@Username, @Email, @Password)
            SELECT LAST_INSERT_ID();
            ", creds);
            return new UserReturnModel()
            {
                Id = id,
                Username = creds.Username,
                Email = creds.Email
            };


        }

        public UserReturnModel Login(LoginUserModel creds)
        {

            //more sql
            User user = _db.QueryFirstOrDefault<User>(@"
            SELECT * FROM users WHERE email = @Email
            ", creds);

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
    }
}