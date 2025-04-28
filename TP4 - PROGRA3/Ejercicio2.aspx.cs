using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;


namespace TP4___PROGRA3
{
    public partial class Ejercicio2 : System.Web.UI.Page
    {

        private const String connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=Neptuno;Integrated Security=True;TrustServerCertificate=True";


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Configurar los DropDownList con las opciones requeridas

                DropDownList1.SelectedIndex = 0;


                DropDownList2.SelectedIndex = 0;

                // cargar productos inicialmente
                CargarProductos();
            }
        }

        private void CargarProductos(string filtroIdProducto = null, string operadorIdProducto = "=",
                                    string filtroIdCategoria = null, string operadorIdCategoria = "=")
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();

                string query = "SELECT IdProducto, NombreProducto, IdCategoría, CantidadPorUnidad, PrecioUnidad FROM Productos";

                string whereClause = "";

                // filtro para ID Producto
                if (!string.IsNullOrEmpty(filtroIdProducto))
                {
                    whereClause += $" IdProducto {operadorIdProducto} @IdProducto";
                }

                /// filtro de la Categoría
                if (!string.IsNullOrEmpty(filtroIdCategoria))
                {
                    if (!string.IsNullOrEmpty(whereClause))
                        whereClause += " AND";

                    whereClause += $" IdCategoría {operadorIdCategoria} @IdCategoria";
                }

                if (!string.IsNullOrEmpty(whereClause))
                    query += " WHERE" + whereClause;

                SqlCommand command = new SqlCommand(query, connection);

                // Agregar parámetros si existen
                if (!string.IsNullOrEmpty(filtroIdProducto))
                    command.Parameters.AddWithValue("@IdProducto", filtroIdProducto);

                if (!string.IsNullOrEmpty(filtroIdCategoria))
                    command.Parameters.AddWithValue("@IdCategoria", filtroIdCategoria);



                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);

                GVProductos.DataSource = table;
                GVProductos.DataBind();
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string filtroIdProducto = txtProducto.Text.Trim();
            string filtroIdCategoria = txtCategoria.Text.Trim();

            string operadorIdProducto = DropDownList1.SelectedValue;
            string operadorIdCategoria = DropDownList2.SelectedValue;

            CargarProductos(
                string.IsNullOrEmpty(filtroIdProducto) ? null : filtroIdProducto,
                operadorIdProducto,
                string.IsNullOrEmpty(filtroIdCategoria) ? null : filtroIdCategoria,
                operadorIdCategoria
            );


            txtProducto.Text = "";
            txtCategoria.Text = "";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            CargarProductos();
            txtProducto.Text = "";
            txtCategoria.Text = "";
            DropDownList1.SelectedIndex = 0;
            DropDownList2.SelectedIndex = 0;
        }
    }

}