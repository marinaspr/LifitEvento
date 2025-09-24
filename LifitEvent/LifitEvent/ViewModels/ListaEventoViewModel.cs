using LifitEvent.Models;
using LifitEvent.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifitEvent.ViewModels
{
    public class ListaEventoViewModel : BaseViewModel
    {
        private readonly EventoService _eventoService;

        public ObservableCollection<Evento> Eventos { get; set; } = new ObservableCollection<Evento>();

        public Command CarregarEventosCommand { get; }
        public Command<Evento> EditarCommand { get; }
        public Command<Evento> ExcluirCommand { get; }

        public ListaEventoViewModel(EventoService eventoService)
        {
            _eventoService = eventoService;

            CarregarEventosCommand = new Command(async () => await CarregarEventos());
            EditarCommand = new Command<Evento>(async (evento) => await EditarEvento(evento));
            ExcluirCommand = new Command<Evento>(async (evento) => await ExcluirEvento(evento));
        }

        private async Task CarregarEventos()
        {
            Eventos.Clear();
            var lista = await _eventoService.GetEventosAsync();
            foreach (var ev in lista)
                Eventos.Add(ev);
        }

        private async Task EditarEvento(Evento evento)
        {
            await Shell.Current.GoToAsync($"EditarEventoPage?Id={evento.Id}");
        }

        private async Task ExcluirEvento(Evento evento)
        {
            await _eventoService.DeleteEventoAsync(evento.Id);
            await CarregarEventos();
        }
    }

}
