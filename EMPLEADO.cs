using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace proyectoZapateria
{
    public partial class EMPLEADO : Form
    {

        SqlConnection conexion;
        string empleado;
        SqlCommand comando;
        public EMPLEADO()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Zapateria;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }

        private void EMPLEADO_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void MostrarDatos()
        {
            empleado = "SELECT *FROM EMPLEADO";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(empleado, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Empleado");
            conexion.Close();
            dataGridView1.DataSource = ds.Tables["Empleado"];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nombre = textBox1.Text;
            string telefono = textBox2.Text;

            empleado = "INSERT INTO Empleado (nombre, telefono) values('" + nombre + "', '" + telefono + "')";
            conexion.Open();
            comando = new SqlCommand(empleado, conexion); ;
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();

        }

    }
}
