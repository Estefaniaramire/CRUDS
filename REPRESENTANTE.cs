using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace proyectoZapateria
{
    public partial class REPRESENTANTE : Form
    {

        SqlConnection conexion;
        string representante;
        SqlCommand comando;
        public REPRESENTANTE()
        {

            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Zapateria;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }

        private void REPRESENTANTE_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void MostrarDatos()
        {
            representante = "SELECT *FROM REPRESENTANTE";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(representante, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Representante");
            conexion.Close();
            dataGridView1.DataSource = ds.Tables["Representante"];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nombre = textBox1.Text;
            string telefono = textBox2.Text;
            string direccion = textBox3.Text;



            representante = "INSERT INTO REPRESENTANTE (nombre, telefono, direccion) values( '" + nombre + "',  '" + telefono + "'  '" + direccion + "')";
            conexion.Open();
            comando = new SqlCommand(representante, conexion); ;
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();


        }
    }
}
