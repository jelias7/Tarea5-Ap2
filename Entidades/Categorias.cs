using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Categorias
    {
        [Key]
        public int CategoriaId { get; set; }
        public string Categoria { get; set; }
        public decimal Promedio_Perdida { get; set; }
        public DateTime Fecha { get; set; }
        public Categorias()
        {
            CategoriaId = 0;
            Categoria = string.Empty;
            Promedio_Perdida = 0;
            Fecha = DateTime.Now;
        }
    }
}
