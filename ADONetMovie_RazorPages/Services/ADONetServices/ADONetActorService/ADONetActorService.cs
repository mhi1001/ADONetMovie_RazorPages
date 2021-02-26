
using ADONetMovie_RazorPages.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ADONetMovie_RazorPages.Services.ADONetActorService
{
    public class ADONetActorService
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MovieDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public  List<Actor> GetActors()
        {
           List<Actor> lst = new List<Actor>();

            string query = "SELECT * From Actor"; 

            using(SqlConnection connection= new SqlConnection(connectionString))
            {
                connection.Open();    
                SqlCommand command = new SqlCommand(query, connection);
                using (SqlDataReader  reader= command.ExecuteReader())
                {
                    while (reader.Read())  // while I am reading row by row
                    {
                        Actor actor = new Actor();
                        //actor.Id = Convert.ToInt32(reader["Id"]);
                       actor.Id = Convert.ToInt32(reader[0]);
                        actor.Name = Convert.ToString(reader["Name"]);
                        actor.Country = Convert.ToString(reader["Country"]);
                        actor.Birth_year = Convert.ToDateTime(reader["Birth_year"]);
                        actor.Alive = Convert.ToBoolean(reader["Alive"]);
                        lst.Add(actor);
                    }
                }
            }
            return lst;
        }

        public Actor GetActorById(int actorId)
        {
            string query = $"SELECT * From Actor where Id=@aid";
            Actor actor = new Actor();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@aid", actorId);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                   while ( reader.Read()) // while I am reading row by row
                    {                      
                        actor.Id = Convert.ToInt32(reader["Id"]);             
                        actor.Name = Convert.ToString(reader["Name"]);
                        actor.Country = Convert.ToString(reader["Country"]);
                        actor.Birth_year = Convert.ToDateTime(reader["Birth_year"]);
                        actor.Alive = Convert.ToBoolean(reader["Alive"]);                   
                    }
                }
            }
            return actor;
        }
        public void DeleteActor(Actor actor)
        {
            string query = $" DELETE from Actor where Id=@id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", actor.Id);
                    int affectedRows = command.ExecuteNonQuery();
                }
            }
        }


        public void AddActor(Actor actor)
        {
            string query = $" INSERT into Actor(Id,Name, Country, Birth_year,Alive) Values(@Id, @Name, @Country, @Birth_year, @Alive)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", actor.Id);
                    command.Parameters.AddWithValue("@Name", actor.Name);
                    command.Parameters.AddWithValue("@Country", actor.Country);
                    command.Parameters.AddWithValue("@Birth_year", actor.Birth_year);
                    command.Parameters.AddWithValue("@Alive", actor.Alive);
                    int affectedRows = command.ExecuteNonQuery();
                }
            }
        }

       
        
    }
}
