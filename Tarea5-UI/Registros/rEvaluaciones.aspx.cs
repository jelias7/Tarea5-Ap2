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
    public partial class rEvaluaciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ValoresDeDropdowns();
                IDTextBox.Text = "0";
                FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                ViewState["Evaluacion"] = new Evaluaciones();
                BindGrid();
            }
        }
        private void ValoresDeDropdowns()
        {
            RepositorioBase<Estudiantes> db = new RepositorioBase<Estudiantes>();
            var listado = new List<Estudiantes>();
            listado = db.GetList(p => true);
            EstudianteDropDown.DataSource = listado;
            EstudianteDropDown.DataValueField = "EstudianteId";
            EstudianteDropDown.DataTextField = "Estudiante";
            EstudianteDropDown.DataBind();

            RepositorioBase<Categorias> repositorio = new RepositorioBase<Categorias>();
            var list = new List<Categorias>();
            list = repositorio.GetList(p => true);
            CategoriaDropdown.DataSource = list;
            CategoriaDropdown.DataValueField = "CategoriaId";
            CategoriaDropdown.DataTextField = "Categoria";
            CategoriaDropdown.DataBind();
        }
        protected void BindGrid()
        {
            if (ViewState["Evaluacion"] != null)
            {
                Grid.DataSource = ((Evaluaciones)ViewState["Evaluacion"]).Detalle;
                Grid.DataBind();
            }
        }
        private bool ExisteEnLaBaseDeDatos()
        {
            RepositorioBase<Evaluaciones> Repositorio = new RepositorioBase<Evaluaciones>();
            Evaluaciones e = Repositorio.Buscar(Utils.ToInt(IDTextBox.Text));
            return (e != null);
        }
        private Evaluaciones LlenaClase()
        {
            Evaluaciones e = new Evaluaciones();
            e = (Evaluaciones)ViewState["Evaluacion"];
            e.EvaluacionId = Utils.ToInt(IDTextBox.Text);
            e.EstudianteId = Utils.ToInt(EstudianteDropDown.SelectedValue);
          //  e.CategoriaId = Utils.ToInt(CategoriaDropdown.SelectedValue);
            e.Total_Perdido = Utils.ToDecimal(TotalPerdidoTextBox.Text);
            e.Fecha = Utils.ToDateTime(FechaTextBox.Text);

            return e;
        }
        private void LlenaCampo(Evaluaciones e)
        {
            ((Evaluaciones)ViewState["Evaluacion"]).Detalle = e.Detalle;
            IDTextBox.Text = e.EvaluacionId.ToString();
            FechaTextBox.Text = e.Fecha.ToString("yyyy-MM-dd");
            EstudianteDropDown.SelectedValue = e.EstudianteId.ToString();
            //CategoriaDropdown.SelectedValue = e.CategoriaId.ToString();
            TotalPerdidoTextBox.Text = e.Total_Perdido.ToString();
            this.BindGrid();
        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
            Evaluaciones ex = new Evaluaciones();

            ex = (Evaluaciones)ViewState["Evaluacion"];

            decimal Perdido = Utils.ToDecimal(ValorTextBox.Text) - Utils.ToDecimal(LogradoTextBox.Text);
            ex.Detalle.Add(new EvaluacionesDetalle(Utils.ToInt(CategoriaDropdown.SelectedValue),
                Utils.ToDecimal(ValorTextBox.Text),
                Utils.ToDecimal(LogradoTextBox.Text),
                Perdido));

            ViewState["Detalle"] = ex.Detalle;

            this.BindGrid();
            Grid.Columns[1].Visible = false;
            decimal Total = 0;
            foreach(var item in ex.Detalle.ToList())
            {
                Total += item.Perdido;
            }
            TotalPerdidoTextBox.Text = Total.ToString();
        }

        protected void Grid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Evaluaciones ex = new Evaluaciones();

            ex = (Evaluaciones)ViewState["Evaluacion"];

            ViewState["Detalle"] = ex.Detalle;

            int Fila = e.RowIndex;

            ex.Detalle.RemoveAt(Fila);

            this.BindGrid();

            decimal Total = 0;
            foreach (var item in ex.Detalle.ToList())
            {
                Total += item.Perdido;
            }
            TotalPerdidoTextBox.Text = Total.ToString();
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            Evaluaciones E = new Evaluaciones();
            bool paso = false;

            E = LlenaClase();

            if (Utils.ToInt(IDTextBox.Text) == 0)
            {
                paso = BLL.EvaluacionBLL.Guardar(E);
            }
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {

                    Utils.ShowToastr(this.Page, "Problema al guardar", "Error", "error");
                    return;
                }
                paso = BLL.EvaluacionBLL.Modificar(E);
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
            RepositorioBase<Evaluaciones> Repositorio = new RepositorioBase<Evaluaciones>();

            var E = Repositorio.Buscar(Utils.ToInt(IDTextBox.Text));

            if (E != null)
            {
                if (BLL.EvaluacionBLL.Eliminar(Utils.ToInt(IDTextBox.Text)))
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
            RepositorioBase<Evaluaciones> Repositorio = new RepositorioBase<Evaluaciones>();

            Evaluaciones E = new Evaluaciones();

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