using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace proyectoZapateria
{
    public partial class MARCA : Form
    {
        SqlConnection conexion;
        string marca;
        SqlCommand comando;
        public MARCA()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Zapateria;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }

        private void MARCA_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void MostrarDatos()
        {
            marca = "SELECT *FROM MARCA";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(marca, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Marca");
            conexion.Close();
            dataGridView1.DataSource = ds.Tables["Marca"];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nombremarca = textBox1.Text;
           


            marca = "INSERT INTO MARCA (nombremarca) values( '" + nombremarca + "')";
            conexion.Open();
            comando = new SqlCommand(marca, conexion); ;
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
           

        }

    }
}
