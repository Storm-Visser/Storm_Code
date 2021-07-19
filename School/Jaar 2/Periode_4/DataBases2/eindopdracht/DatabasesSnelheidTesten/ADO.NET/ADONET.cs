using System;
using System.Data.SqlClient;
using System.Diagnostics;

namespace DatabasesSnelheidTesten.ADONET
{	
	public class ADONET
	{
		private Stopwatch stopwatch { get; set; } = new Stopwatch();
		private String connString { get; set; } = @"Server=DESKTOP-98ISB48\STORM; Initial Catalog=Netflix; Integrated Security=true";
		
		public Double testCreate(int amount)
        {
			Random r = new Random();
			int totalAffectedRows = 0;
			stopwatch.Start();
			for (int i = 1; i <= amount; i++)
			{
				//create the variables
				int genreID = r.Next(1, 31);
				string naam = "film" + i.ToString();
				string locatie = "/films/film" + i.ToString() + ".mp4";
				string omschrijving = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium.";
				TimeSpan tijdsduur = new TimeSpan(r.Next(1, 1000001));
				string resolutie = "UHD";

				//connect to the DB
				using(var conn = new SqlConnection(connString))
                {
					conn.Open();
					//create the query
					string query = "INSERT INTO Films (genre_genreID, naam, filmlocatie, omschrijving, tijdsDuur, resolutie) VALUES (@genreID, @naam, @filmlocatie, @omschrijving, @tijdsDuur, @resolutie)";
					SqlCommand command = new SqlCommand(query, conn);
					//add parameters
					command.Parameters.AddWithValue("@genreID", genreID);
					command.Parameters.AddWithValue("@naam", naam);
					command.Parameters.AddWithValue("@filmlocatie", locatie);
					command.Parameters.AddWithValue("@omschrijving", omschrijving);
					command.Parameters.AddWithValue("@tijdsduur", tijdsduur);
					command.Parameters.AddWithValue("@resolutie", resolutie);
					//execute query
					int affectedRows = command.ExecuteNonQuery();
					totalAffectedRows += affectedRows;
					conn.Close();
				}
			}
			stopwatch.Stop();
			Console.WriteLine("Amount of affected rows: " + totalAffectedRows);
			double time = stopwatch.ElapsedMilliseconds;
			stopwatch.Reset();
			return time;
        }

		public Double testRead(int amount)
		{
			Random r = new Random();
			int totalRetrievedRows = 0;
			stopwatch.Start();
			for (int i = 1; i <= amount; i++)
			{
				//connect to the DB
				using (var conn = new SqlConnection(connString))
				{
					conn.Open();
					//create the query
					string query = "SELECT * FROM Films WHERE filmID = @ID";
					SqlCommand command = new SqlCommand(query, conn);
					//add parameters
					command.Parameters.AddWithValue("@ID", i);
					//execute query
					SqlDataReader reader = command.ExecuteReader();
					while (reader.Read())
                    {
						totalRetrievedRows++;
					}
					conn.Close();
				}
			}
			stopwatch.Stop();
			Console.WriteLine("Amount of retrieved rows: " + totalRetrievedRows);
			double time = stopwatch.ElapsedMilliseconds;
			stopwatch.Reset();
			return time;
		}

		public Double testUpdate(int amount)
		{
			Random r = new Random();
			int totalAffectedRows = 0;
			stopwatch.Start();
			for (int i = 1; i <= amount; i++)
			{
				//create the updated variables
				int genreID = r.Next(1, 31);
				string naam = "updatedFilm" + i.ToString();
				string locatie = "/updatedFilms/film" + i.ToString() + ".mp4";
				string omschrijving = "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo.";
				TimeSpan tijdsduur = new TimeSpan(r.Next(1, 1000001));
				string resolutie = "HD";

				//connect to the DB
				using (var conn = new SqlConnection(connString))
				{
					conn.Open();
					//create the query
					string query = "UPDATE Films SET genre_genreID = @genreID, naam = @naam, filmlocatie = @filmlocatie, omschrijving = @omschrijving, tijdsDuur = @tijdsDuur, resolutie = @resolutie WHERE filmID = @ID";
					SqlCommand command = new SqlCommand(query, conn);
					//add parameters
					command.Parameters.AddWithValue("@genreID", genreID);
					command.Parameters.AddWithValue("@naam", naam);
					command.Parameters.AddWithValue("@filmlocatie", locatie);
					command.Parameters.AddWithValue("@omschrijving", omschrijving);
					command.Parameters.AddWithValue("@tijdsduur", tijdsduur);
					command.Parameters.AddWithValue("@resolutie", resolutie);
					command.Parameters.AddWithValue("@ID", i);
					//execute query
					int affectedRows = command.ExecuteNonQuery();
					totalAffectedRows += affectedRows;
					conn.Close();
				}
			}
			stopwatch.Stop();
			Console.WriteLine("Amount of affected rows: " + totalAffectedRows);
			double time = stopwatch.ElapsedMilliseconds;
			stopwatch.Reset();
			return time;
		}

		public Double testDelete(int amount)
		{
			int totalAffectedRows = 0;
			stopwatch.Start();
			for (int i = 1; i <= amount; i++)
			{
				//connect to the DB
				using (var conn = new SqlConnection(connString))
				{
					conn.Open();
					//create the query
					string query = "DELETE FROM Films WHERE filmID IN (SELECT TOP 1 filmID FROM Films ORDER BY filmID desc)";
					SqlCommand command = new SqlCommand(query, conn);
					//execute query
					int affectedRows = command.ExecuteNonQuery();
					totalAffectedRows += affectedRows;
					conn.Close();
				}
			}
			stopwatch.Stop();
			Console.WriteLine("Amount of affected rows: " + totalAffectedRows);
			double time = stopwatch.ElapsedMilliseconds;
			stopwatch.Reset();
			return time;
		}

		public void reSeedDB()
		{
			using (var conn = new SqlConnection(connString))
			{
				conn.Open();
				//create the query
				string query = "DBCC CHECKIDENT ('Films', RESEED, 0)";
				SqlCommand command = new SqlCommand(query, conn);
				//execute query
				int affectedRows = command.ExecuteNonQuery();
				conn.Close();
			}
		}
	}	
}

