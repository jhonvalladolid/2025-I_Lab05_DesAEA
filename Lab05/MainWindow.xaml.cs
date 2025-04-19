using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Data.SqlClient;

namespace Lab05
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string connectionString = "Data Source=LAPTOP-DELL;Initial Catalog=Neptuno;User ID=sa;Password=Tecsup00;TrustServerCertificate=True;";

        public MainWindow()
        {
            InitializeComponent();
            CargarClientes();
        }

        private void CargarClientes()
        {
            using SqlConnection conn = new SqlConnection(connectionString);
            using SqlCommand cmd = new SqlCommand("USP_ListarClientes", conn);

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Cliente> clientes = new List<Cliente>();

            while (reader.Read())
            {
                clientes.Add(new Cliente
                {
                    idCliente = reader.GetString(0),
                    NombreCompañia = reader.GetString(1),
                    NombreContacto = reader.GetString(2),
                    Ciudad = reader.GetString(3),
                    Pais = reader.GetString(4),
                    Telefono = reader.GetString(5)
                });
            }

            dgClientes.ItemsSource = clientes;
        }

        private void btnInsertCliente_Click(object sender, RoutedEventArgs e)
        {
            var form = new ClienteFormWindow();
            if (form.ShowDialog() == true)
            {
                CargarClientes();
            }
        }

        private void btnDeleteCliente_Click(object sender, RoutedEventArgs e)
        {
            if (dgClientes.SelectedItem is Cliente cliente)
            {
                var confirm = MessageBox.Show($"¿Deseas eliminar al cliente {cliente.NombreCompañia}?", "Confirmación", MessageBoxButton.YesNo);
                if (confirm == MessageBoxResult.Yes)
                {
                    using SqlConnection conn = new SqlConnection(connectionString);
                    using SqlCommand cmd = new SqlCommand("USP_DeleteClienteLogical", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idCliente", cliente.idCliente);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Cliente eliminado (lógicamente).");
                    CargarClientes();
                }
            }
        }

        private void dgClientes_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dgClientes.SelectedItem is Cliente cliente)
            {
                var form = new ClienteFormWindow(cliente);
                if (form.ShowDialog() == true)
                {
                    CargarClientes();
                }
            }
        }
    }
}