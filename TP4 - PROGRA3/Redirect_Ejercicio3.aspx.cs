using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;


namespace TP4___PROGRA3
{
    public partial class Redirect_Ejercicio3 : System.Web.UI.Page
    {
        private const string dbConnection = @"Data Source=CIRIACO\SQLEXPRESS;Initial Catalog=Libreria;Integrated Security=True;Encrypt=False";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string idTema = Request.QueryString["idTema"];
                cargarTabla(gridViewLibros, idTema);
            }
        }

        private void cargarTabla(GridView gridViewLibros, string idTemaSeleccionado)
        {
            using (SqlConnection connection = new SqlConnection(dbConnection))
            {
                string consultaSQL = "SELECT * FROM Libros WHERE IdTema = @IdTemaSeleccionado";
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand(consultaSQL, connection);
                sqlCommand.Parameters.AddWithValue("@idTemaSeleccionado", idTemaSeleccionado);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                gridViewLibros.DataSource = sqlDataReader;
                gridViewLibros.DataBind();

                sqlDataReader.Close();
            }
        }
    }
}