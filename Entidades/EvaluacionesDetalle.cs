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
        public string Categoria { get; set; }
        public decimal Valor { get; set; }
        public decimal Logrado { get; set; }
        public decimal Perdido { get; set; }
        public EvaluacionesDetalle()
        {
            Id = 0;
            Categoria = string.Empty;
            Valor = 0;
            Logrado = 0;
            Perdido = 0;
        }
    }
}
