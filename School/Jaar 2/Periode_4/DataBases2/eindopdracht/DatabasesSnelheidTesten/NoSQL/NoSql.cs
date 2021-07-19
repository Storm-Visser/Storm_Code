using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;

namespace DatabasesSnelheidTesten.NoSQL
{
    class NoSql
    {
		private MongoClient dbClient = new MongoClient("mongodb://localhost:27017");
		private Stopwatch stopwatch { get; set; } = new Stopwatch();

		public Double testCreate(int amount)
		{
			Random r = new Random();
			int totalAffectedRows = 0;
			CreateDataBaseData();
			stopwatch.Start();
			for (int i = 1; i <= amount; i++)
			{
				//create variables
				int genreID = r.Next(1, 31);
				string naam = "film" + i.ToString();
				string locatie = "/films/film" + i.ToString() + ".mp4";
				string omschrijving = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium.";
				DateTime tijdsduur = DateTime.Now;
				string resolutie = "UHD";
				//create connection
				var database = dbClient.GetDatabase("Databases2");
				var collection = database.GetCollection<BsonDocument>("Film");
				var Film = new BsonDocument { { "filmID", i }, { "genreID", genreID }, { "naam", naam }, { "filmLocatie", locatie }, { "omschrijving", omschrijving }, { "tijdsDuur", tijdsduur }, { "resolutie", resolutie } };
				collection.InsertOne(Film);
				totalAffectedRows++;
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
				//create connection
				var database = dbClient.GetDatabase("Databases2");
				var collection = database.GetCollection<BsonDocument>("Film");
				var filter = Builders<BsonDocument>.Filter.Eq("filmID", i);
				collection.Find(filter).FirstOrDefault();
				totalRetrievedRows++;
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
			for (int i = 0; i < amount; i++)
			{
				//create the updated variables
				int genreID = r.Next(1, 31);
				string naam = "updatedFilm" + i.ToString();
				string locatie = "/updatedFilms/film" + i.ToString() + ".mp4";
				string omschrijving = "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo.";
				DateTime tijdsduur = DateTime.Now;
				string resolutie = "HD";
				//create connection
				var database = dbClient.GetDatabase("Databases2");
				var collection = database.GetCollection<BsonDocument>("Film");
				var filter = Builders<BsonDocument>.Filter.Eq("filmID", i);
				var UpdatedFilm = Builders<BsonDocument>.Update.Set("genreID", genreID).Set("naam", naam).Set("filmLocatie", locatie).Set("omschrijving", omschrijving).Set("tijdsDuur", tijdsduur).Set("resolutie", resolutie); ;
				collection.UpdateOne(filter, UpdatedFilm);
				totalAffectedRows++;
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
				var database = dbClient.GetDatabase("Databases2");
				var collection = database.GetCollection<BsonDocument>("Film");
				var deleteFilter = Builders<BsonDocument>.Filter.Eq("filmID", i);
				collection.DeleteOne(deleteFilter);
				totalAffectedRows++;
			}
			stopwatch.Stop();
			Console.WriteLine("Amount of affected rows: " + totalAffectedRows);
			double time = stopwatch.ElapsedMilliseconds;
			stopwatch.Reset();
			return time;
		}

		public void CreateDataBaseData()
        {
			string omschrijving = "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo.";
			string[] genreNames = { "Geen specifiek genre", "Action", "Drama", "Animation | Drama | Fantasy", "Mystery", "Comedy | Mystery", "War film", "Drama | Romance", "Horror movie", "Children | Comedy | Fantasy | Musical", "Action | Adventure | Thriller", "Horror", "Fantasy", "Musical", "Adventure", "Documentary", "Comedy | Romance", "Thriller", "Animation", "Crime", "Sports film", "Detective", "Biographical film", "Psychological thriller", "Crime | Mystery | Thriller", "Action | Comedy | Romance", "Adventure | Comedy | Romance", "Sci - Fi", "Romance", "Drama | Sci - Fi]", "Extra" };
			var database = dbClient.GetDatabase("Databases2");
			var collection = database.GetCollection<BsonDocument>("Genre");
			for (int i = 0; i <= 30; i++)
			{
				var genre = new BsonDocument { { "naam", genreNames[i] }, { "omschrijving", omschrijving } };
				collection.InsertOne(genre);

			}
		}
	}
}
