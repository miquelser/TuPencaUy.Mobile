using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using TuPencaUy.Mobile.Models;
using TuPencaUy.Mobile.Services;

namespace TuAplicacion.ViewModels
{
    public class PartidoDetalleViewModel : INotifyPropertyChanged, IQueryAttributable
    {
        private readonly ApiService _apiService;

        public Partido Partido { get; set; }
        public ObservableCollection<string> Estados { get; set; } // Lista de estados posibles

        // Lista de resultados para el ComboBox
        public List<string> Resultados { get; } = new List<string> { "Empate", "Victoria Local", "Victoria Visitante" };

        private string _resultadoSeleccionado;
        public string ResultadoSeleccionado
        {
            get { return _resultadoSeleccionado; }
            set
            {
                if (_resultadoSeleccionado != value)
                {
                    _resultadoSeleccionado = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand GuardarPronosticoCommand { get; }
        public ICommand VolverCommand { get; }

        public PartidoDetalleViewModel()
        {
            _apiService = new ApiService();

            GuardarPronosticoCommand = new Command<Partido>(async (partido) => await GuardarPronostico(partido));
            VolverCommand = new Command(Volver);
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            int partidoId = int.Parse(query["partidoId"].ToString());
            CargarPartido(partidoId);
        }

        private async void CargarPartido(int partidoId)
        {
            Partido = await _apiService.GetPartidoDetalleAsync(partidoId);
            OnPropertyChanged(nameof(Partido));
        }

        private async Task GuardarPronostico(Partido partido)
        {
            // Asignar el resultado seleccionado al partido (por ejemplo, en un campo Resultado)
           // partido.Resultado = ResultadoSeleccionado;

            // Llamar a la API para guardar el pronóstico
            //await _apiService.GuardarPronosticoAsync(partido);

            // Mostrar mensaje de confirmación o realizar otras acciones necesarias

            // Opcional: Navegar de vuelta a la lista de partidos
           // await Volver();
        }

        private async void Volver()
        {
            // Navegar de vuelta a la página anterior
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}