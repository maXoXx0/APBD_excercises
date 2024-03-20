using Exercise4.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace Exercise4.Repositories
{
    public interface IAnimalsRepository
    {
        Task<ICollection<Animal>> GetAnimalsAsync(string orderBy);
        Task AddAnimal(Animal animal);
        Task UpdateAnimal(Animal newData);
        Task DeleteAnimal(int ID);
        Task<bool> CheckQuearyAsync(int id);
    }

    public class AnimalsRepository : IAnimalsRepository
    {
        private readonly string _connectionString;

        public AnimalsRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Default") 
                ?? throw new Exception("Nie podano connection Stringa");
        }

        public async Task<ICollection<Animal>> GetAnimalsAsync(string orderBy)
        {
          
            var query = $"SELECT * FROM Animal ORDER BY {orderBy}";

            var animals = new List<Animal>();


            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();


                SqlCommand command = new SqlCommand(query, connection);


                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    int ID = reader.GetOrdinal("ID");
                    int name = reader.GetOrdinal("Name");
                    int description = reader.GetOrdinal("Description");
                    int category = reader.GetOrdinal("Category");
                    int area = reader.GetOrdinal("Area");

                    while (await reader.ReadAsync())
                    {
                        animals.Add(new Animal
                        {
                            Id = reader.GetInt32(ID),
                            Name = reader.GetString(name),
                            Description = reader.GetString(description),
                            Category = reader.GetString(category),
                            Area = reader.GetString(area)

                        });
                    }
                }
            }
            return animals;
        }
        public async Task AddAnimal(Animal animal)
        {
            var query = $"INSERT INTO [dbo].[Animal] ([ID], [Name], [Description], [Category], [Area]) VALUES (@ID, @Name, @Description, @Category, @Area)";


            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                


                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", animal.Id);
                command.Parameters.AddWithValue("@Name", animal.Name);
                command.Parameters.AddWithValue("@Description", animal.Description);
                command.Parameters.AddWithValue("@Category", animal.Category);
                command.Parameters.AddWithValue("@Area", animal.Area);

                await connection.OpenAsync();

                await command.ExecuteNonQueryAsync();

                

            };

        }


        public async Task<bool> CheckQuearyAsync(int id)
        {
            var query = $"Select 1 from Animal where ID = @ID";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", id);
                

                await connection.OpenAsync();

                if (await command.ExecuteScalarAsync() is null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            };

            
        }

        public async Task UpdateAnimal(Animal newData)
        {
            var query = "update animal set name = @Name, Description = @Description , Category = @Category, Area = 'Japonia' where ID = @ID";


            using (SqlConnection connection = new SqlConnection(_connectionString))
            {



                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", newData.Name);
                command.Parameters.AddWithValue("@Description", newData.Description);
                command.Parameters.AddWithValue("@Category", newData.Category);
                command.Parameters.AddWithValue("@Area", newData.Area);
                command.Parameters.AddWithValue("@ID", newData.Id);

                await connection.OpenAsync();

                await command.ExecuteNonQueryAsync();



            };
        }

        public async Task DeleteAnimal(int ID)
        {
            var query = "delete from Animal where id = @ID";


            using (SqlConnection connection = new SqlConnection(_connectionString))
            {



                SqlCommand command = new SqlCommand(query, connection);
                
                command.Parameters.AddWithValue("@ID", ID);

                await connection.OpenAsync();

                await command.ExecuteNonQueryAsync();



            };
        }
    }

}
