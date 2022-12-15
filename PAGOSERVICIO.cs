using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace proyectoZapateria
{
    public partial class PAGOSERVICIO : Form
    {
        SqlConnection conexion;
        string pagoservicio;
        SqlCommand comando;
        public PAGOSERVICIO()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Zapateria;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }

        private void PAGOSERVICIO_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void MostrarDatos()
        {
            pagoservicio = "SELECT *FROM PAGOSERVICIO";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(pagoservicio, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "PagoServicio");
            conexion.Close();
            dataGridView1.DataSource = ds.Tables["PagoServicio"];
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string tipopago = textBox1.Text;
            string servicio = textBox2.Text;
            string cantidad = textBox3.Text;



            pagoservicio = "INSERT INTO PAGOSERVICIO (tipopago, servicio, cantidad) values( '" + tipopago + "',  '" + servicio + "'  '" + cantidad + "')";
            conexion.Open();
            comando = new SqlCommand(pagoservicio, conexion); ;
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
