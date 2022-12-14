using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace proyectoZapateria
{
    public partial class Cliente : Form
    {
        SqlConnection conexion;
        string cliente;
        SqlCommand comando;
        public Cliente()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Zapateria;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }

        private void Cliente_Load(object sender, EventArgs e)
        {
            MostrarDatos();

        }

        private void MostrarDatos()
        {
            cliente = "SELECT *FROM CLIENTE";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(cliente, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Cliente");
            conexion.Close();
            dataGridView1.DataSource = ds.Tables["Cliente"];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string clientegeneral = textBox1.Text;
            string clienterevendedor = textBox2.Text;
            cliente = "INSERT INTO Cliente (clienterevendedor, clientegeneral) values('" + clienterevendedor + "', '" + clientegeneral + "')";
            conexion.Open();
            comando = new SqlCommand(cliente, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idCliente = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM CLIENTE WHERE idCliente = " + idCliente.ToString();
            cliente = "UPDATE CLIENTE SET Estatus = 0 WHERE idCliente = " + idCliente.ToString(); ;
            conexion.Open();
            comando = new SqlCommand(cliente, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
        }

        private void tnModificar_Click(object sender, EventArgs e)
        {
            string clienterevendedor = textBox1.Text;
            string clientegeneral = textBox2.Text;
            int idCliente = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            cliente = "UPDATE CLIENTE SET  clienterevendedor = '" + clienterevendedor + "', clientegeneral = '" + clientegeneral + "' WHERE idCliente = " + idCliente.ToString(); ;
            conexion.Open();
            comando = new SqlCommand(cliente, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }
    }
}
