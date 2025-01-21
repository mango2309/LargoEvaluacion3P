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
                var peliculas = await _httpClient.GetFromJsonAsync<List<PeliculaSL>>(url);

                return peliculas?.FirstOrDefault();
            }
            catch
            {
                return null;
            }
        }
    }
}
