using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tarea5_UI.Utilitarios;

namespace Tarea5_UI.Consultas
{
    public partial class cCategorias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DesdeFecha.Text = DateTime.Today.ToString("yyyy-MM-dd");
                HastaFecha.Text = DateTime.Today.ToString("yyyy-MM-dd");
            }
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Expression<Func<Categorias, bool>> filtros = x => true;
            RepositorioBase<Categorias> repositorio = new RepositorioBase<Categorias>();

            DateTime Desde = Utils.ToDateTime(DesdeFecha.Text);
            DateTime Hasta = Utils.ToDateTime(HastaFecha.Text);

            decimal criterio;
            criterio = Utils.ToInt(CriterioTextBox.Text);
            if (CheckBoxFecha.Checked == true)
            {
                switch (FiltroDropDown.SelectedIndex)
                {
                    case 0: //ID                  
                        filtros = c => c.CategoriaId == criterio && c.Fecha >= Desde && c.Fecha <= Hasta;
                        break;
                    case 1: //Categoria
                        filtros = c => c.Categoria.Contains(CriterioTextBox.Text) && c.Fecha >= Desde && c.Fecha <= Hasta;
                        break;
                    case 2: //Promedio perdido
                        filtros = c => c.Promedio_Perdida == criterio && c.Fecha >= Desde && c.Fecha <= Hasta;
                        break;
                    case 3: //Todo
                        break;
                }
            }
            else
            {
                switch (FiltroDropDown.SelectedIndex)
                {
                    case 0: //ID                  
                        filtros = c => c.CategoriaId == criterio;
                        break;
                    case 1: //Categoria
                        filtros = c => c.Categoria.Contains(CriterioTextBox.Text);
                        break;
                    case 2: //Promedio perdido
                        filtros = c => c.Promedio_Perdida == criterio;
                        break;
                    case 3: //Todo
                        break;
                }
            }
            Grid.DataSource = repositorio.GetList(filtros);
            Grid.DataBind();
        }
    }
}