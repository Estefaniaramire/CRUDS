using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace proyectoZapateria
{
    public partial class FACTURA : Form
    {


        SqlConnection conexion;
        string factura;
        SqlCommand comando;
        public FACTURA()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Zapateria;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }

        private void FACTURA_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void MostrarDatos()
        {
            factura = "SELECT *FROM FACTURA";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(factura, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Fcatura");
            conexion.Close();
            dataGridView1.DataSource = ds.Tables["Factura"];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string foliofactura = textBox1.Text;
            string fechafactura = textBox2.Text;
            string nombrefactura = textBox3.Text;


            factura = "INSERT INTO FACTURA (foliofactura, fechafactura, nombrefactura ) values('" + foliofactura + "', '" + fechafactura + "','" + nombrefactura +"')";
            conexion.Open();
            comando = new SqlCommand(factura, conexion); ;
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
