using System.Data;
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
            //sql here
        }

        public UserReturnModel Login(LoginUserModel creds)
        {
            //more sql
        }
    }
}