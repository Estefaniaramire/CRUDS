using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace proyectoZapateria
{
    public partial class PROVEEDOR : Form
    {
        SqlConnection conexion;
        string proveedor;
        SqlCommand comando;
        public PROVEEDOR()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Zapateria;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }

        private void PROVEEDOR_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void MostrarDatos()
        {
            proveedor = "SELECT *FROM PROVEEDOR";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(proveedor, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Proveedor");
            conexion.Close();
            dataGridView1.DataSource = ds.Tables["Proveedor"];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nombre = textBox1.Text;
            string telefono = textBox2.Text;
            string direccion = textBox3.Text;



            proveedor = "INSERT INTO PROVEEDOR (nombre, telefono, direccion) values( '" + nombre + "',  '" + telefono + "'  '" + direccion + "')";
            conexion.Open();
            comando = new SqlCommand(proveedor, conexion); ;
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
