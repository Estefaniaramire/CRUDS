using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace proyectoZapateria
{

    public partial class MOBILIARIO : Form
    {

        SqlConnection conexion;
        string mobiliario;
        SqlCommand comando;
        public MOBILIARIO()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Zapateria;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }

        private void MOBILIARIO_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            mobiliario = "SELECT *FROM MOBILIARIO";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(mobiliario, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Mobiliario");
            conexion.Close();
            dataGridView1.DataSource = ds.Tables["Mobiliario"];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string areapertenece = textBox1.Text;
            string cantidad = textBox2.Text;
          



            mobiliario = "INSERT INTO MOBILIARIO (areapertenece, cantidad) values( '" + areapertenece + "',  '" + cantidad +  "')";
            conexion.Open();
            comando = new SqlCommand(mobiliario, conexion); ;
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
         


        }

    }
}
