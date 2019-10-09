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
    public partial class rCategorias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                IDTextBox.Text = "0";
                FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }
        void MostrarMensaje(TiposMensaje tipo, string mensaje)
        {
            Mensaje.Text = mensaje;

            if (tipo == TiposMensaje.Success)
                Mensaje.CssClass = "alert-success";
            else if (tipo == TiposMensaje.Error)
                Mensaje.CssClass = "alert-danger";
            else
                Mensaje.CssClass = "alert-warning";
        }
        private bool ExisteEnLaBaseDeDatos()
        {
            RepositorioBase<Categorias> Repositorio = new RepositorioBase<Categorias>();
            Categorias C = Repositorio.Buscar(Utils.ToInt(IDTextBox.Text));
            return (C != null);
        }
        private Categorias LlenaClase()
        {
            Categorias C = new Categorias();

            C.CategoriaId = Utils.ToInt(IDTextBox.Text);
            C.Categoria = CategoriaTextBox.Text;
            C.Promedio_Perdida = Utils.ToDecimal(PromedioPerdidoTextBox.Text);
            C.Fecha = Utils.ToDateTime(FechaTextBox.Text);

            return C;
        }
        private void LlenaCampo(Categorias C)
        {
            IDTextBox.Text = C.CategoriaId.ToString();
            CategoriaTextBox.Text = C.Categoria;
            PromedioPerdidoTextBox.Text = C.Promedio_Perdida.ToString();
            FechaTextBox.Text = C.Fecha.ToString("yyyy-MM-dd");
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            Categorias C = new Categorias();
            RepositorioBase<Categorias> Repositorio = new RepositorioBase<Categorias>();
            bool paso = false;

            C = LlenaClase();

            if (Utils.ToInt(IDTextBox.Text) == 0)
            {
                paso = Repositorio.Guardar(C);
                Response.Redirect(Request.RawUrl);
            }
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {

                    MostrarMensaje(TiposMensaje.Error, "Error al guardar.");
                    return;
                }
                paso = Repositorio.Modificar(C);
                Response.Redirect(Request.RawUrl);
            }

            if (paso)
            {
                MostrarMensaje(TiposMensaje.Success, "Exito al guardar.");
                return;
            }
            else
                MostrarMensaje(TiposMensaje.Error, "Error al guardar.");
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Categorias> Repositorio = new RepositorioBase<Categorias>();

            var C = Repositorio.Buscar(Utils.ToInt(IDTextBox.Text));

            if (C != null)
            {
                if (Repositorio.Eliminar(Utils.ToInt(IDTextBox.Text)))
                {
                    MostrarMensaje(TiposMensaje.Success, "Eliminado con exito.");
                }
                else
                    MostrarMensaje(TiposMensaje.Error, "No se ha podido eliminar.");
            }
            else
                    MostrarMensaje(TiposMensaje.Error, "No se ha podido eliminar.");
            Response.Redirect(Request.RawUrl);
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Categorias> Repositorio = new RepositorioBase<Categorias>();

            Categorias C = new Categorias();

            C = Repositorio.Buscar(Utils.ToInt(IDTextBox.Text));

            if (C != null)
                LlenaCampo(C);
            else
            {
                MostrarMensaje(TiposMensaje.Warning, "Problemas inesperados.");
            }
        }
    }
}