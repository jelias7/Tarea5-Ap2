using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Evaluaciones
    {
        [Key]
        public int EvaluacionId { get; set; }
        public int CategoriaId { get; set; }
        public int EstudianteId { get; set; }
        public decimal Total_Perdido { get; set; }
        public DateTime Fecha { get; set; }
        public virtual List<EvaluacionesDetalle> Detalle { get; set; }
        public Evaluaciones()
        {
            EvaluacionId = 0;
            CategoriaId = 0;
            EstudianteId = 0;
            Total_Perdido = 0;
            Fecha = DateTime.Now;
            Detalle = new List<EvaluacionesDetalle>();
        }
    }
}
