using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tarea5_UI.Utilitarios;

namespace Tarea5_UI.Registros
{
    public partial class rEstudiantes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                IDTextBox.Text = "0";
                FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }
        private bool ExisteEnLaBaseDeDatos()
        {
            RepositorioBase<Estudiantes> Repositorio = new RepositorioBase<Estudiantes>();
            Estudiantes E = Repositorio.Buscar(Utils.ToInt(IDTextBox.Text));
            return (E != null);
        }
        private Estudiantes LlenaClase()
        {
            Estudiantes E = new Estudiantes();

            E.EstudianteId = Utils.ToInt(IDTextBox.Text);
            E.Estudiante = EstudianteTextBox.Text;
            E.Puntos_Perdidos = Utils.ToDecimal(PuntosPerdidosTextBox.Text);
            E.Fecha = Utils.ToDateTime(FechaTextBox.Text);

            return E;
        }
        private void LlenaCampo(Estudiantes E)
        {
            IDTextBox.Text = E.EstudianteId.ToString();
            EstudianteTextBox.Text = E.Estudiante;
            PuntosPerdidosTextBox.Text = E.Puntos_Perdidos.ToString();
            FechaTextBox.Text = E.Fecha.ToString("yyyy-MM-dd");
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            Estudiantes E = new Estudiantes();
            RepositorioBase<Estudiantes> Repositorio = new RepositorioBase<Estudiantes>();
            bool paso = false;

            E = LlenaClase();

            if (Utils.ToInt(IDTextBox.Text) == 0)
            {
                paso = Repositorio.Guardar(E);
            }
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {

                    Utils.ShowToastr(this.Page, "Problema al guardar", "Error", "error");
                    return;
                }
                paso = Repositorio.Modificar(E);
            }

            if (paso)
            {
                Utils.ShowToastr(this.Page, "Guardado con exito!!", "Guardado", "success");
                return;
            }
            else
                Utils.ShowToastr(this.Page, "Problema al guardar", "Error", "error");

            Response.Redirect(Request.RawUrl);
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Estudiantes> Repositorio = new RepositorioBase<Estudiantes>();

            var E = Repositorio.Buscar(Utils.ToInt(IDTextBox.Text));

            if (E != null)
            {
                if (Repositorio.Eliminar(Utils.ToInt(IDTextBox.Text)))
                {
                    Utils.ShowToastr(this.Page, "Eliminado con exito!!", "Guardado", "success");
                }
                else
                    Utils.ShowToastr(this.Page, "Problema al eliminar", "Error", "error");
            }
            else
                Utils.ShowToastr(this.Page, "Problema al eliminar", "Error", "error");

            Response.Redirect(Request.RawUrl);
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Estudiantes> Repositorio = new RepositorioBase<Estudiantes>();

            Estudiantes E = new Estudiantes();

            E = Repositorio.Buscar(Utils.ToInt(IDTextBox.Text));

            if (E != null)
                LlenaCampo(E);
            else
            {
                Utils.ShowToastr(this.Page, "Problema al buscar", "Error", "error");
            }
        }
    }
}