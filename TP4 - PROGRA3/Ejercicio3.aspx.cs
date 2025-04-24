using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace TP4___PROGRA3
{
    public partial class Ejercicio3 : System.Web.UI.Page
    {
        private const string dbConnection = @"Data Source=CIRIACO\SQLEXPRESS;Initial Catalog=Libreria;Integrated Security=True;Encrypt=False";
        private string consultaSQL = "SELECT * FROM Temas";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarTemas(dropDownListTemas);
            }
        }

        private void cargarTemas(DropDownList ddl_temas)
        {
            using (SqlConnection connection = new SqlConnection(dbConnection))
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand(consultaSQL, connection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                ddl_temas.DataSource = sqlDataReader;
                ddl_temas.DataTextField = "Tema";       // Nombre de la columna
                ddl_temas.DataValueField = "IdTema";    // ID de la columna
                ddl_temas.DataBind();
                ddl_temas.Items.Insert(0, new ListItem("- Seleccione un tema -", ""));


                sqlDataReader.Close(); // siempre cerrá el DataReader
            }
        }

        protected void dropDownListTemas_SelectedIndexChanged(object sender, EventArgs e)
        {
            string idTemaSeleccionado = dropDownListTemas.SelectedValue;

            if (!string.IsNullOrEmpty(idTemaSeleccionado))
            {
                linkNewPage.NavigateUrl = "Redirect_Ejercicio3.aspx?idTema=" + idTemaSeleccionado;
            }
            else
            {
                linkNewPage.NavigateUrl = "";
            }
        }
    }
}