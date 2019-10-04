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
    public partial class cEvaluaciones : System.Web.UI.Page
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
            Expression<Func<Evaluaciones, bool>> filtros = x => true;
            RepositorioBase<Evaluaciones> repositorio = new RepositorioBase<Evaluaciones>();

            DateTime Desde = Utils.ToDateTime(DesdeFecha.Text);
            DateTime Hasta = Utils.ToDateTime(HastaFecha.Text);

            decimal criterio;
            criterio = Utils.ToInt(CriterioTextBox.Text);
            if (CheckBoxFecha.Checked == true)
            {
                switch (FiltroDropDown.SelectedIndex)
                {
                    case 0: //ID                  
                        filtros = c => c.EvaluacionId == criterio && c.Fecha >= Desde && c.Fecha <= Hasta;
                        break;
                    case 1: //EstudianteId
                        filtros = c => c.EstudianteId == criterio && c.Fecha >= Desde && c.Fecha <= Hasta;
                        break;
                    case 2: //CategoriaId
                        filtros = c => c.CategoriaId == criterio && c.Fecha >= Desde && c.Fecha <= Hasta;
                        break;
                    case 3: //Total Perdido
                        filtros = c => c.Total_Perdido == criterio && c.Fecha >= Desde && c.Fecha <= Hasta;
                        break;
                    case 4: //Todo
                        break;
                }
            }
            else
            {
                switch (FiltroDropDown.SelectedIndex)
                {
                    case 0: //ID                  
                        filtros = c => c.EvaluacionId == criterio;
                        break;
                    case 1: //EstudianteId
                        filtros = c => c.EstudianteId == criterio;
                        break;
                    case 2: //CategoriaId
                        filtros = c => c.CategoriaId == criterio;
                        break;
                    case 3: //Total Perdido
                        filtros = c => c.Total_Perdido == criterio;
                        break;
                    case 4: //Todo
                        break;
                }
            }
            Grid.DataSource = repositorio.GetList(filtros);
            Grid.DataBind();
        }
    }
}