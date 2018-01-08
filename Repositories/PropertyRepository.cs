using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using GregsList.Models;
using Dapper;
using MySql.Data.MySqlClient;

namespace GregsList.Repositories
{
    public class PropertyRepository
    {
        private readonly IDbConnection _db;

        public PropertyRepository(IDbConnection db)
        {
            _db = db;
        }

        // Find One Find Many add update delete
        public IEnumerable<Property> GetAll()
        {
            return _db.Query<Property>("SELECT * FROM Properties");
        }

        public Property GetById(int id)
        {
            return _db.QueryFirstOrDefault<Property>($"SELECT * FROM Properties WHERE id = @id", id);
        }

        public Property Add(Property auto)
        {

            int id = _db.ExecuteScalar<int>("INSERT INTO Properties (Name, Description, Price)"
                        + " VALUES(@Name, @Description, @Price); SELECT LAST_INSERT_ID()", new
                        {
                            auto.Name,
                            auto.Description,
                            auto.Price
                        });
            auto.Id = id;
            return auto;

        }

        public Property GetOneByIdAndUpdate(int id, Property auto)
        {
            return _db.QueryFirstOrDefault<Property>($@"
                UPDATE Properties SET  
                    Name = @Name,
                    Description = @Description,
                    Price = @Price
                WHERE Id = {id};
                SELECT * FROM Properties WHERE id = {id};", auto);
        }

        public string FindByIdAndRemove(int id)
        {
            var success = _db.Execute(@"
                DELETE FROM Properties WHERE Id = @id
            ", id);
            return success > 0 ? "success" : "umm that didnt work";
        }
    }
}