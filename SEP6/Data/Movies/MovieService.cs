﻿using SEP6.Models;
using System.Text.Json;

namespace SEP6.Data.Movies
{
    public class MovieService : IMovieService
    {
#if DEBUG
        string url = "https://localhost:7178/movie";
#else
       
        string url = "https://moviesep6api.azurewebsites.net/movie";
#endif

        HttpClient client;
        private int movieId = 0;

        public MovieService()
        {
            client = new HttpClient();
        }

        public async Task<Movie> GetMovieByID(int id)
        {
            string message = await client.GetStringAsync(url + "/" + id);
            Movie result = JsonSerializer.Deserialize<Movie>(message);

            // Get director information
            CrewMember director = await GetDirectorByMovieId(id);
            result.Director = director;

            return result;
        }

        public int GetMovieId()
        {
            return movieId;
        }

        public void SetMovieId(int id)
        {
            movieId = id;
        }
        public async Task<ListOfMovies> GetMoviesBySearch(int page, string query)
        {
            string message = await client.GetStringAsync(url + "/search?page=" + page + "&query=" + query);
            ListOfMovies results = JsonSerializer.Deserialize<ListOfMovies>(message);
            return results;
        }

        public async Task<ListOfMovies> GetMoviesByRating(int page)
        {
            string message = await client.GetStringAsync(url + "/ByRating?page=" + page);
            ListOfMovies results = JsonSerializer.Deserialize<ListOfMovies>(message);
            return results;
        }

        public async Task<ListOfMovies> GetMoviesByTitle(int page)
        {
            string message = await client.GetStringAsync(url + "/ByTitle?page=" + page);
            ListOfMovies results = JsonSerializer.Deserialize<ListOfMovies>(message);
            return results;
        }
        public async Task<Credits> GetCreditsByMovieId(int movieId)
        {
            string message = await client.GetStringAsync(url + "/" + movieId + "/credits");
            Credits result = JsonSerializer.Deserialize<Credits>(message);
            return result;
        }

        public async Task<VideoList> GetVideosByMovieId(int movieId)
        {
            string message = await client.GetStringAsync($"{url}/{movieId}/videos");
            VideoList result = JsonSerializer.Deserialize<VideoList>(message);
            return result;
        }
        public async Task<CrewMember> GetDirectorByMovieId(int movieId)
        {
            string message = await client.GetStringAsync(url + "/" + movieId + "/credits");
            Credits credits = JsonSerializer.Deserialize<Credits>(message);

            // Assuming the director is the first crew member with the job title "Director"
            var director = credits.Crew.FirstOrDefault(crew => crew.Job == "Director");

            return director;
        }

        public async Task<ListOfMovies> GetNowPlayingMovies(int page)
        {
            string message = await client.GetStringAsync(url + "/NowPlaying?page=" + page);
            ListOfMovies results = JsonSerializer.Deserialize<ListOfMovies>(message);
            return results;
        }

        public async Task<ListOfMovies> GetPopularMovies(int page)
        {
            string message = await client.GetStringAsync(url + "/Popular?page=" + page);
            ListOfMovies results = JsonSerializer.Deserialize<ListOfMovies>(message);
            return results;
        }

        public async Task<ListOfMovies> GetUpcomingMovies(int page)
        {
            string message = await client.GetStringAsync(url + "/Upcoming?page=" + page);
            ListOfMovies results = JsonSerializer.Deserialize<ListOfMovies>(message);
            return results;
        }
    }
}
