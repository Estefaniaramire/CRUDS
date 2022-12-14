using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace proyectoZapateria
{
    public partial class ENTREGA : Form
    {

        SqlConnection conexion;
        string entrega;
        SqlCommand comando;
        public ENTREGA()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Zapateria;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }

        private void ENTREGA_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void MostrarDatos()
        {
            entrega = "SELECT *FROM ENTREGA";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(entrega, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Entrega");
            conexion.Close();
            dataGridView1.DataSource = ds.Tables["Entrega"];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string direccion = textBox1.Text;
            string fecha = textBox2.Text;
            string nombre = textBox3.Text;

            entrega = "INSERT INTO ENTREGA (direccion, fecha, nombre) values('" + direccion + "', '" + fecha + "',  '" + nombre + "')";
            conexion.Open();
            comando = new SqlCommand(entrega, conexion); ;
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();

        }



    }
}
