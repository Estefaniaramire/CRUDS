using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace proyectoZapateria
{
    public partial class ENVIO : Form
    {
        SqlConnection conexion;
        string envio;
        SqlCommand comando;
        public ENVIO()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Zapateria;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }

        private void ENVIO_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void MostrarDatos()
        {
            envio = "SELECT *FROM ENVIO";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(envio, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Envio");
            conexion.Close();
            dataGridView1.DataSource = ds.Tables["Envio"];
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string direccion = textBox1.Text;
            string numero = textBox2.Text;
          
            envio = "INSERT INTO ENVIO (direccion, numero) values('" + direccion + "', '" + numero + "')";
            conexion.Open();
            comando = new SqlCommand(envio, conexion); ;
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            

        }
    }
}
