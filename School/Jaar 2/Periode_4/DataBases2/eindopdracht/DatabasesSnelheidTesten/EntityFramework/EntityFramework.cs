using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.EntityClient;
using System.Diagnostics;
using System.Linq;
using DatabasesSnelheidTesten.EntityFramework.Model;

namespace DatabasesSnelheidTesten.EntityFramework
{
    public class EntityFramework
	{

		private Stopwatch stopwatch { get; set; } = new Stopwatch();

		public Double testCreate(int amount)
		{
			Random r = new Random();
			int totalAffectedRows = 0;
			stopwatch.Start();
			for (int i = 0; i < amount; i++)
			{
				//create variables
				int genreID = r.Next(1, 31);
				string naam = "film" + i.ToString();
				string locatie = "/films/film" + i.ToString() + ".mp4";
				string omschrijving = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium.";
				TimeSpan tijdsduur = new TimeSpan(r.Next(1, 1000001));
				string resolutie = "UHD";
				//create film object
				var dbContext1 = new DatabaseContext();
				var film = new Film() { genre = dbContext1.Genres.Where(s => s.genreID == genreID).ToList()[0], naam = naam, filmLocatie = locatie, omschrijving = omschrijving, tijdsduur = tijdsduur, resolutie = resolutie };
				using (var dbContext = new DatabaseContext())
                {
					dbContext.Films.Add(film);
					dbContext.SaveChanges();
					totalAffectedRows++;
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
			for (int i = 0; i < amount; i++)
			{
				int id = r.Next(1, 999999);
				var context = new DatabaseContext();
				var filmByID = context.Films.Where(s => s.filmID == id).ToList();
				totalRetrievedRows ++;
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
				int genreID = r.Next(1, 31);
				string naam = "updatedFilm" + i.ToString();
				string locatie = "/updatedFilms/film" + i.ToString() + ".mp4";
				string omschrijving = "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo.";
				TimeSpan tijdsduur = new TimeSpan(r.Next(1, 1000001));
				string resolutie = "HD";
				using (var dbContext = new DatabaseContext())
				{
					var film = dbContext.Films.Find(i + 1);
					film.genre = dbContext.Genres.Where(s => s.genreID == genreID).ToList()[0];
					film.naam = naam;
					film.filmLocatie = locatie;
					film.omschrijving = omschrijving;
					film.tijdsduur = tijdsduur;
					film.resolutie = resolutie;
					dbContext.SaveChanges();
					totalAffectedRows++;
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
			for (int i = 0; i < amount; i++)
			{
				var film = new Film() { filmID = i + 1 };
				using (var dbContext = new DatabaseContext())
				{
					dbContext.Films.Add(film);
					dbContext.Films.Remove(film);
					dbContext.SaveChanges();
					totalAffectedRows++;
				}
			}
			stopwatch.Stop();
			Console.WriteLine("Amount of affected rows: " + totalAffectedRows);
			double time = stopwatch.ElapsedMilliseconds;
			stopwatch.Reset();
			return time;
		}

		public void createGenres()
        {
			string omschrijving = "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo.";
			string[] genreNames = { "Geen specifiek genre", "Action", "Drama", "Animation | Drama | Fantasy", "Mystery", "Comedy | Mystery", "War film", "Drama | Romance", "Horror movie", "Children | Comedy | Fantasy | Musical", "Action | Adventure | Thriller", "Horror", "Fantasy", "Musical", "Adventure", "Documentary", "Comedy | Romance", "Thriller", "Animation", "Crime", "Sports film", "Detective", "Biographical film", "Psychological thriller", "Crime | Mystery | Thriller", "Action | Comedy | Romance", "Adventure | Comedy | Romance", "Sci - Fi", "Romance", "Drama | Sci - Fi]" , "Extra"};
			for (int i = 0; i <= 30; i++)
            {
				var genre  = new Genre() { genreID = i + 1, naam = genreNames[i], omschrijving = omschrijving};
				using (var dbContext = new DatabaseContext())
				{
					dbContext.Genres.Add(genre);
					dbContext.SaveChanges();
				}
			}
		}
	}
}
