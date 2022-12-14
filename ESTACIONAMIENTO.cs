using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace proyectoZapateria
{
    public partial class ESTACIONAMIENTO : Form
    {

        SqlConnection conexion;
        string estacionamiento;
        SqlCommand comando;
        public ESTACIONAMIENTO()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Zapateria;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }

        private void ESTACIONAMIENTO_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void MostrarDatos()
        {
            estacionamiento = "SELECT *FROM ESTACIONAMIENTO";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(estacionamiento, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Estacionamiento");
            conexion.Close();
            dataGridView1.DataSource = ds.Tables["Estacionamiento"];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string estacionamientocliente = textBox1.Text;
            string estacionamientoempleado = textBox2.Text;

            estacionamiento = "INSERT INTO ESTACIONAMIENTO (estacionamientocliente, estacionamientoempleado) values('" + estacionamientocliente + "', '" + estacionamientoempleado + "')";
            conexion.Open();
            comando = new SqlCommand(estacionamiento, conexion); ;
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
