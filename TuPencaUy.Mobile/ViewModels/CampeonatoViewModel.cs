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
    public class CampeonatoViewModel : INotifyPropertyChanged
    {
        private readonly ApiService _apiService;

        public ObservableCollection<Campeonato> Campeonatos { get; set; }
        public ICommand SeleccionarCampeonatoCommand { get; }

        public CampeonatoViewModel()
        {
            _apiService = new ApiService();
            Campeonatos = new ObservableCollection<Campeonato>();
            SeleccionarCampeonatoCommand = new Command<Campeonato>(async (campeonato) => await SeleccionarCampeonato(campeonato));
            CargarCampeonatos();
        }

        private async void CargarCampeonatos()
        {
            var campeonatos = await _apiService.GetCampeonatosAsync();
            foreach (var campeonato in campeonatos)
            {
                Campeonatos.Add(campeonato);
            }
        }

        private async Task SeleccionarCampeonato(Campeonato campeonato)
        {
            // Navegar a la página de partidos
            await Shell.Current.GoToAsync($"//PartidosPage?campeonatoId={campeonato.Id}");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}