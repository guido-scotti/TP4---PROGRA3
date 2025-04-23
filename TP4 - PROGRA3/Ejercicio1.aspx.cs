using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP4___PROGRA3
{
    public partial class Ejercicio1 : System.Web.UI.Page
    {
        private const string cadenaConexion = @"Data Source=DESKTOP-GUU4RQA\SQLEXPRESS;Initial Catalog=Viajes;Integrated Security=True;TrustServerCertificate=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Cargamos todas las provincias en ambas listas sin excluir nada
                CargarTodasLasProvincias(ddlProvinciaInicio);
                CargarTodasLasProvincias(ddlProvinciaLlegada);
            }
        }

        protected void ddlProvinciaInicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            string idProvinciaSeleccionada = ddlProvinciaInicio.SelectedValue;
            string valorSeleccionadoActual = ddlProvinciaLlegada.SelectedValue;

            if (!string.IsNullOrEmpty(idProvinciaSeleccionada))
            {
                // Cargar provincias de llegada excluyendo la seleccionada en inicio
                CargarProvinciasDesdeBD(ddlProvinciaLlegada, idProvinciaSeleccionada, valorSeleccionadoActual);
                FiltrarLocalidadesPorProvincia();
                lblMensaje.Visible = false;

                // Deshabilitar la provincia de llegada seleccionada en inicio
                ddlProvinciaLlegada.Enabled = true; // Aseguramos que el ddlProvinciaLlegada esté habilitado
                ListItem provinciaSeleccionada = ddlProvinciaLlegada.Items.FindByValue(idProvinciaSeleccionada);

                // Si existe la provincia, la deshabilitamos
                if (provinciaSeleccionada != null)
                {
                    provinciaSeleccionada.Enabled = false;
                }
            }
        }

        private void FiltrarLocalidadesPorProvincia()
        {
            using (SqlConnection connection = new SqlConnection(cadenaConexion))
            {
                connection.Open();

                int idProvinciaSeleccionada;
                if (int.TryParse(ddlProvinciaInicio.SelectedValue, out idProvinciaSeleccionada))
                {
                    string consulta = "SELECT * FROM localidades WHERE IdProvincia = @IdProvincia";
                    SqlCommand cmd = new SqlCommand(consulta, connection);
                    cmd.Parameters.AddWithValue("@IdProvincia", idProvinciaSeleccionada);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    ddlLocalidadInicio.DataSource = dt;
                    ddlLocalidadInicio.DataTextField = "NombreLocalidad";
                    ddlLocalidadInicio.DataValueField = "IdLocalidad";
                    ddlLocalidadInicio.DataBind();
                    ddlLocalidadInicio.Items.Insert(0, new ListItem("- Seleccione -", ""));
                }

                connection.Close();
            }
        }

        protected void ddlProvinciaLlegada_SelectedIndexChanged(object sender, EventArgs e)
        {
            // No necesitamos cambiar nada aquí, porque la lógica de la provincia de llegada la controlamos en ddlProvinciaInicio_SelectedIndexChanged
            string idProvinciaSeleccionada = ddlProvinciaLlegada.SelectedValue;
            string valorSeleccionadoActual = ddlProvinciaInicio.SelectedValue;

            if (!string.IsNullOrEmpty(idProvinciaSeleccionada))
            {
                // Solo se modifican las localidades de llegada
                FiltrarLocalidadesLlegadaPorProvincia();
                lblMensaje.Visible = false;
            }
        }

        private void FiltrarLocalidadesLlegadaPorProvincia()
        {
            using (SqlConnection connection = new SqlConnection(cadenaConexion))
            {
                connection.Open();

                int idProvinciaSeleccionada;
                if (int.TryParse(ddlProvinciaLlegada.SelectedValue, out idProvinciaSeleccionada))
                {
                    string consulta = "SELECT * FROM localidades WHERE IdProvincia = @IdProvincia";
                    SqlCommand cmd = new SqlCommand(consulta, connection);
                    cmd.Parameters.AddWithValue("@IdProvincia", idProvinciaSeleccionada);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    //LOCALIDADES LLEGADA
                    ddlLocalidadLlegada.DataSource = dt;
                    ddlLocalidadLlegada.DataTextField = "NombreLocalidad";
                    ddlLocalidadLlegada.DataValueField = "IdLocalidad";
                    ddlLocalidadLlegada.DataBind();
                    ddlLocalidadLlegada.Items.Insert(0, new ListItem("- Seleccione -", ""));
                }

                connection.Close();
            }
        }

        private void CargarProvinciasDesdeBD(DropDownList ddl, string provinciaAExcluir, string selectedValue = "")
        {
            using (SqlConnection connection = new SqlConnection(cadenaConexion))
            {
                connection.Open();

                string consulta = "SELECT * FROM provincias";
                SqlCommand cmd = new SqlCommand(consulta, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if (!string.IsNullOrEmpty(provinciaAExcluir))
                {
                    DataRow[] rowsToDelete = dt.Select("IdProvincia = " + provinciaAExcluir);
                    foreach (DataRow row in rowsToDelete)
                        dt.Rows.Remove(row);
                }

                ddl.DataSource = dt;
                ddl.DataTextField = "NombreProvincia";
                ddl.DataValueField = "IdProvincia";
                ddl.DataBind();

                ddl.Items.Insert(0, new ListItem("- Seleccione -", ""));

                // Si el valor seleccionado antes sigue existiendo, lo restauro
                if (!string.IsNullOrEmpty(selectedValue) && ddl.Items.FindByValue(selectedValue) != null)
                {
                    ddl.SelectedValue = selectedValue;
                }

                connection.Close();
            }
        }

        private void CargarTodasLasProvincias(DropDownList ddl)
        {
            using (SqlConnection connection = new SqlConnection(cadenaConexion))
            {
                connection.Open();
                string consulta = "SELECT IdProvincia, NombreProvincia FROM provincias";
                SqlCommand cmd = new SqlCommand(consulta, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                ddl.DataSource = dt;
                ddl.DataTextField = "NombreProvincia";
                ddl.DataValueField = "IdProvincia";
                ddl.DataBind();
                ddl.Items.Insert(0, new ListItem("- Seleccione -", ""));
                connection.Close();
            }
        }

    }
}