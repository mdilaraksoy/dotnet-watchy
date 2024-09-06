using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using watchyproject.Models;

namespace watchyproject.Utility
{
    public class JsonFileReader
    {
        public List<TopMovs> GetMovieFromFile(string filePath)
        {
            string jsonString = File.ReadAllText(filePath);
            var topMovies = JsonSerializer.Deserialize<List<TopMovs>>(jsonString);

            return topMovies;
        }
    }
}
