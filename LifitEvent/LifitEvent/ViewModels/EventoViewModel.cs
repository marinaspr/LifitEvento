using LifitEvent.Models;
using LifitEvent.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifitEvent.ViewModels
{
    [QueryProperty(nameof(EventoId), "Id")]
    public class EventoViewModel : BaseViewModel
    {
        private readonly EventoService _eventoService;

        public Evento Evento { get; set; } = new Evento();
        public int EventoId { get; set; }

        public Command SalvarCommand { get; }
        public Command ExcluirCommand { get; }

        public EventoViewModel(EventoService eventoService)
        {
            _eventoService = eventoService;

            SalvarCommand = new Command(async () => await SalvarEvento());
            ExcluirCommand = new Command(async () => await ExcluirEvento());
        }

        public async Task CarregarEvento()
        {
            if (EventoId != 0)
                Evento = await _eventoService.GetEventoByIdAsync(EventoId);

            OnPropertyChanged(nameof(Evento));
        }

        private async Task SalvarEvento()
        {
            if (Evento.Id == 0)
                await _eventoService.AddEventoAsync(Evento);
            else
                await _eventoService.UpdateEventoAsync(Evento);

            await Shell.Current.GoToAsync(".."); // volta
        }

        private async Task ExcluirEvento()
        {
            if (Evento.Id != 0)
                await _eventoService.DeleteEventoAsync(Evento.Id);

            await Shell.Current.GoToAsync("..");
        }
    }

}
