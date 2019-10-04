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
    public partial class cEstudiantes : System.Web.UI.Page
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
            Expression<Func<Estudiantes, bool>> filtros = x => true;
            RepositorioBase<Estudiantes> repositorio = new RepositorioBase<Estudiantes>();

            DateTime Desde = Utils.ToDateTime(DesdeFecha.Text);
            DateTime Hasta = Utils.ToDateTime(HastaFecha.Text);

            decimal criterio;
            criterio = Utils.ToInt(CriterioTextBox.Text);
            if (CheckBoxFecha.Checked == true)
            {
                switch (FiltroDropDown.SelectedIndex)
                {
                    case 0: //ID                  
                        filtros = c => c.EstudianteId == criterio && c.Fecha >= Desde && c.Fecha <= Hasta;
                        break;
                    case 1: //Estudiante
                        filtros = c => c.Estudiante.Contains(CriterioTextBox.Text) && c.Fecha >= Desde && c.Fecha <= Hasta;
                        break;
                    case 2: //Puntos perdidos
                        filtros = c => c.Puntos_Perdidos == criterio && c.Fecha >= Desde && c.Fecha <= Hasta;
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
                        filtros = c => c.EstudianteId == criterio;
                        break;
                    case 1: //Estudiante
                        filtros = c => c.Estudiante.Contains(CriterioTextBox.Text);
                        break;
                    case 2: //Puntos perdidos
                        filtros = c => c.Puntos_Perdidos == criterio;
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