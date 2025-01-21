using LargoEvaluacion3P.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace LargoEvaluacion3P.Services
{
    public class PeliculaSLService
    {
        private readonly HttpClient _httpClient;


        public PeliculaSLService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<PeliculaSL?> BuscarPeliculaAsync(string query)
        {
            try
            {
                var url = $"https://freetestapi.com/api/v1/movies?search={query}&limit=1";
                var peliculas = await _httpClient.GetFromJsonAsync<List<dynamic>>(url); 

                if (peliculas == null || !peliculas.Any())
                {
                    return null;
                }

                var peliculaApi = peliculas.FirstOrDefault();

                return new PeliculaSL
                {
                    Nombre = peliculaApi.title,
                    Genero = string.Join(", ", peliculaApi.genre),
                    Director = peliculaApi.director,
                    Year = peliculaApi.year.ToString(),
                    PosterUrl = peliculaApi.poster,
                    Sinopsis = peliculaApi.plot,
                    Actores = string.Join(", ", peliculaApi.actors),
                    Rating = peliculaApi.rating
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al llamar a la API: {ex.Message}");
                return null;
            }
        }
    }
}
