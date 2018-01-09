using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using GregsList.Models;
using Dapper;
using MySql.Data.MySqlClient;
using GregsList.Controllers;

namespace GregsList.Repositories
{
    public class AnimalRepository : DbContext
    {

        public AnimalRepository(IDbConnection db) : base(db)
        {
        }

        // Find One Find Many add update delete
        public IEnumerable<Animal> GetAll()
        {
            return _db.Query<Animal>("SELECT * FROM jkanimals");
        }

        public Animal GetById(int id)
        {
            return _db.QueryFirstOrDefault<Animal>($"SELECT * FROM jkanimals WHERE id = {id}", id);
        }

        public Animal Add(Animal animal)
        {

            int id = _db.ExecuteScalar<int>("INSERT INTO jkanimals (Name, Description, Price)"
                        + " VALUES(@Name, @Description, @Price); SELECT LAST_INSERT_ID()", new
                        {
                            animal.Name,
                            animal.Description,
                            animal.Price
                        });
            animal.Id = id;
            return animal;

        }

        public Animal GetOneByIdAndUpdate(int id, Animal animal)
        {
            return _db.QueryFirstOrDefault<Animal>($@"
                UPDATE jkanimals SET  
                    Name = @Name,
                    Description = @Description,
                    Price = @Price
                WHERE Id = {id};
                SELECT * FROM jkanimals WHERE id = {id};", animal);
        }

        public string FindByIdAndRemove(int id)
        {
            var success = _db.Execute(@"
                DELETE FROM jkanimals WHERE Id = {id}
            ", id);
            return success > 0 ? "success" : "umm that didnt work";
        }
    }
}