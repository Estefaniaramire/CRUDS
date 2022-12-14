using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace proyectoZapateria
{
    public partial class DEVOLUCION : Form


    {

        SqlConnection conexion;
        string devolucion;
        SqlCommand comando;
        public DEVOLUCION()
        {

            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Zapateria;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }

        private void DEVOLUCION_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void MostrarDatos()
        {
            devolucion = "SELECT *FROM DEVOLUCION";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(devolucion, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Devolucion");
            conexion.Close();
            dataGridView1.DataSource = ds.Tables["Devolucion"];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string producto = textBox1.Text;
            string fechadevolucion = textBox2.Text;
           
            devolucion = "INSERT INTO Devolucion (producto, fechadevolucion) values('" + producto + "', '" + fechadevolucion + "')";
            conexion.Open();
            comando = new SqlCommand(devolucion, conexion); ;
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();

        }

    }
}
