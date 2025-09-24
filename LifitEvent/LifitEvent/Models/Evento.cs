using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifitEvent.Models
{
    public class Evento
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public DateTime Data { get; set; } = DateTime.Now;
        public TimeSpan Horario { get; set; } = TimeSpan.Zero;
        public string Local { get; set; } = string.Empty;
        public string ImagemUrl { get; set; } = string.Empty; // opcional
        public string CriadorId { get; set; } = string.Empty; // usuário dono
    }

}
