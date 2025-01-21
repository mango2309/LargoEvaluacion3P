using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using LargoEvaluacion3P.Models;
using LargoEvaluacion3P.Services;

namespace LargoEvaluacion3P.ViewModels
{
    public class BuscarPeliculaSLViewModel : BaseSLViewModel
    {
        private readonly PeliculaSLService _peliculaService;
        private string _query = string.Empty;
        private PeliculaSL? _peliculaEncontrada;
        private string _mensajeError = string.Empty;

        public BuscarPeliculaSLViewModel()
        {
            _peliculaService = new PeliculaSLService();
            BuscarCommand = new Command(async () => await BuscarPeliculaAsync());
        }

        public string Query
        {
            get => _query;
            set => SetProperty(ref _query, value);
        }

        public PeliculaSL? PeliculaEncontrada
        {
            get => _peliculaEncontrada;
            set => SetProperty(ref _peliculaEncontrada, value);
        }

        public string MensajeError
        {
            get => _mensajeError;
            set => SetProperty(ref _mensajeError, value);
        }

        public ICommand BuscarCommand { get; }

        private async Task BuscarPeliculaAsync()
        {
            MensajeError = string.Empty;
            PeliculaEncontrada = null;

            if (string.IsNullOrWhiteSpace(Query))
            {
                MensajeError = "Por favor, ingresa un nombre para buscar.";
                return;
            }

            try
            {
                var pelicula = await _peliculaService.BuscarPeliculaAsync(Query);
                if (pelicula != null)
                {
                    PeliculaEncontrada = pelicula;
                }
                else
                {
                    MensajeError = "No se encontró ninguna película con ese nombre.";
                }
            }
            catch
            {
                MensajeError = "Ocurrió un error al buscar la película. Inténtalo nuevamente.";
            }
        }
    }
}
