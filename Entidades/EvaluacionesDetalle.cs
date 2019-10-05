using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class EvaluacionesDetalle
    {
        [Key]
        public int Id { get; set; }
        public int CategoriaId { get; set; }
        public decimal Valor { get; set; }
        public decimal Logrado { get; set; }
        public decimal Perdido { get; set; }
        public EvaluacionesDetalle()
        {
            Id = 0;
            CategoriaId = 0;
            Valor = 0;
            Logrado = 0;
            Perdido = 0;
        }
        public EvaluacionesDetalle(int categoria, decimal val, decimal log, decimal per)
        {
            CategoriaId = categoria;
            Valor = val;
            Logrado = log;
            Perdido = per;
        }
    }
}
