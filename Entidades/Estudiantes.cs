using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Estudiantes
    {
        [Key]
        public int EstudianteId { get; set; }
        public string Estudiante { get; set; }
        public decimal Puntos_Perdidos { get; set; }
        public DateTime Fecha { get; set; }
        public Estudiantes()
        {
            EstudianteId = 0;
            Estudiante = string.Empty;
            Puntos_Perdidos = 0;
            Fecha = DateTime.Now;
        }
    }
}
