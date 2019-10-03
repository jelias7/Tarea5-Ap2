using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Categorias> Categoria { get; set; }
        public DbSet<Estudiantes> Estudiante { get; set; }
        public DbSet<Evaluaciones> Evaluacion { get; set; }
        public Contexto() : base("ConStr") { }
    }
}
