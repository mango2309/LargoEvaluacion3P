using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LargoEvaluacion3P.Models
{
    public class PeliculaSL
    {
        [JsonProperty("title")]
        public string Nombre { get; set; }

        [JsonProperty("year")]
        public string Year { get; set; }

        [JsonProperty("genre")]
        public List<string> Genero { get; set; }

        [JsonProperty("rating")]
        public double Rating { get; set; }

        [JsonProperty("director")]
        public string Director { get; set; }

        [JsonProperty("actors")]
        public List<string> Actores { get; set; }

        [JsonProperty("plot")]
        public string Sinopsis { get; set; }

        [JsonProperty("poster")]
        public string PosterUrl { get; set; }
    }

}
