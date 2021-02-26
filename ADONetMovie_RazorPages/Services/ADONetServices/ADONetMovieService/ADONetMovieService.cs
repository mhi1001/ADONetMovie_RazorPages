using ADONetMovie_RazorPages.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ADONetMovie_RazorPages.Services.ADONetServices.ADONetMovieService
{
    public class ADONetMovieService
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MovieDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public List<Movie> GetMovies()
        {
            List<Movie> lst = new List<Movie>();

            string query = "SELECT * From Movie";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())  // while I am reading row by row
                    {
                        Movie movie = new Movie();                   
                        movie.Id = Convert.ToInt32(reader[0]);
                        movie.Title = Convert.ToString(reader[1]);
                        movie.Year= Convert.ToInt32(reader[2]);
                        movie.Country= Convert.ToString(reader[3]);
                        movie.ActorId = Convert.ToInt32(reader[4]);
                       
                        lst.Add(movie);
                    }
                }
            }
            return lst;
        }

        public void AddMovie(Movie movie)
        {
              string query = $" INSERT into Movie(Id,Title, Year, Country, ActorId) Values(@Id, @Title, @Year, @Country, @ActorId)";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id",movie.Id);
                        command.Parameters.AddWithValue("@Title", movie.Title);
                        command.Parameters.AddWithValue("@Year", movie.Year);
                        command.Parameters.AddWithValue("@Country", movie.Country);
                        command.Parameters.AddWithValue("@ActorId", movie.ActorId);
                        int affectedRows = command.ExecuteNonQuery();
                    }
                }
            }
    }
}
