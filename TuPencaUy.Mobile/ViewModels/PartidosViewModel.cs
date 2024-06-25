using TuPencaUy.Mobile.Models;
using TuPencaUy.Mobile.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace TuPencaUy.Mobile.ViewModels
{
    public class PartidosViewModel : INotifyPropertyChanged, IQueryAttributable
    {
        private readonly ApiService _apiService;

        public ObservableCollection<Partido> Partidos { get; set; }
        public ICommand SeleccionarPartidoCommand { get; }

        public PartidosViewModel()
        {
            _apiService = new ApiService();
            Partidos = new ObservableCollection<Partido>();
            SeleccionarPartidoCommand = new Command<Partido>(async (partido) => await SeleccionarPartido(partido));
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            int campeonatoId = int.Parse(query["campeonatoId"].ToString());
            CargarPartidos(campeonatoId);
        }

        private async void CargarPartidos(int campeonatoId)
        {
            var partidos = await _apiService.GetPartidosAsync(campeonatoId);
            foreach (var partido in partidos)
            {
                Partidos.Add(partido);
            }
        }

        private async Task SeleccionarPartido(Partido partido)
        {
            // Navegar a la página de detalles del partido
            await Shell.Current.GoToAsync($"//PartidoDetallePage?partidoId={partido.Id}");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}