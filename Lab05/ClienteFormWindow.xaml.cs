using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Data.SqlClient;

namespace Lab05
{
    /// <summary>
    /// Lógica de interacción para ClienteFormWindow.xaml
    /// </summary>
    public partial class ClienteFormWindow : Window
    {
        private readonly string connectionString = "Data Source=LAPTOP-DELL;Initial Catalog=Neptuno;User ID=sa;Password=Tecsup00;TrustServerCertificate=True;";
        public bool EsEdicion { get; set; } = false;

        public Cliente ClienteSeleccionado { get; set; }

        public ClienteFormWindow(Cliente cliente = null)
        {
            InitializeComponent();
            if (cliente != null)
            {
                EsEdicion = true;
                ClienteSeleccionado = cliente;
                RellenarFormulario(cliente);
                txtId.IsEnabled = false;
            }
        }

        private void RellenarFormulario(Cliente c)
        {
            txtId.Text = c.idCliente;
            txtCompania.Text = c.NombreCompañia;
            txtContacto.Text = c.NombreContacto;
            txtCargo.Text = c.CargoContacto;
            txtDireccion.Text = c.Direccion;
            txtCiudad.Text = c.Ciudad;
            txtRegion.Text = c.Region;
            txtCodPostal.Text = c.CodPostal;
            txtPais.Text = c.Pais;
            txtTelefono.Text = c.Telefono;
            txtFax.Text = c.Fax;
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            using SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd;

            if (!EsEdicion)
            {
                cmd = new SqlCommand("USP_InsertCliente", conn);
                cmd.Parameters.AddWithValue("@idCliente", txtId.Text);
            }
            else
            {
                cmd = new SqlCommand("USP_UpdateCliente", conn);
                cmd.Parameters.AddWithValue("@idCliente", txtId.Text);
            }

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NombreCompañia", txtCompania.Text);
            cmd.Parameters.AddWithValue("@NombreContacto", txtContacto.Text);
            cmd.Parameters.AddWithValue("@CargoContacto", txtCargo.Text);
            cmd.Parameters.AddWithValue("@Direccion", txtDireccion.Text);
            cmd.Parameters.AddWithValue("@Ciudad", txtCiudad.Text);
            cmd.Parameters.AddWithValue("@Region", txtRegion.Text);
            cmd.Parameters.AddWithValue("@CodPostal", txtCodPostal.Text);
            cmd.Parameters.AddWithValue("@Pais", txtPais.Text);
            cmd.Parameters.AddWithValue("@Telefono", txtTelefono.Text);
            cmd.Parameters.AddWithValue("@Fax", txtFax.Text);

            conn.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Cliente guardado correctamente");
            this.DialogResult = true;
        }
    }
}
