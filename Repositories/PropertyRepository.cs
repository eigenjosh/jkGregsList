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
            return _db.Query<Property>("SELECT * FROM jkproperties");
        }

        public Property GetById(int id)
        {
            return _db.QueryFirstOrDefault<Property>($"SELECT * FROM jkproperties WHERE id = {id}", id);
        }

        public Property Add(Property property)
        {

            int id = _db.ExecuteScalar<int>("INSERT INTO jkproperties (Name, Description, Price)"
                        + " VALUES(@Name, @Description, @Price); SELECT LAST_INSERT_ID()", new
                        {
                            property.Name,
                            property.Description,
                            property.Price
                        });
            property.Id = id;
            return property;

        }

        public Property GetOneByIdAndUpdate(int id, Property property)
        {
            return _db.QueryFirstOrDefault<Property>($@"
                UPDATE jkproperties SET  
                    Name = @Name,
                    Description = @Description,
                    Price = @Price
                WHERE Id = {id};
                SELECT * FROM jkproperties WHERE id = {id};", property);
        }

        public string FindByIdAndRemove(int id)
        {
            var success = _db.Execute(@"
                DELETE FROM jkproperties WHERE Id = {id}
            ", id);
            return success > 0 ? "success" : "umm that didnt work";
        }
    }
}