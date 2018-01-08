using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using GregsList.Models;
using Dapper;
using MySql.Data.MySqlClient;

namespace GregsList.Repositories
{
    public class AutoRepository
    {
        private readonly IDbConnection _db;

        public AutoRepository(IDbConnection db)
        {
            _db = db;
        }

        // Find One Find Many add update delete
        public IEnumerable<Auto> GetAll()
        {
            return _db.Query<Auto>("SELECT * FROM Autos");
        }

        public Auto GetById(int id)
        {
            return _db.QueryFirstOrDefault<Auto>($"SELECT * FROM Autos WHERE id = @id", id);
        }

        public Auto Add(Auto auto)
        {

            int id = _db.ExecuteScalar<int>("INSERT INTO Autos (Name, Description, Price)"
                        + " VALUES(@Name, @Description, @Price); SELECT LAST_INSERT_ID()", new
                        {
                            auto.Name,
                            auto.Description,
                            auto.Price
                        });
            auto.Id = id;
            return auto;

        }

        public Auto GetOneByIdAndUpdate(int id, Auto auto)
        {
            return _db.QueryFirstOrDefault<Auto>($@"
                UPDATE Autos SET  
                    Name = @Name,
                    Description = @Description,
                    Price = @Price
                WHERE Id = {id};
                SELECT * FROM Autos WHERE id = {id};", auto);
        }

        public string FindByIdAndRemove(int id)
        {
            var success = _db.Execute(@"
                DELETE FROM Autos WHERE Id = @id
            ", id);
            return success > 0 ? "success" : "umm that didnt work";
        }
    }
}