using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace proyectoZapateria
{
    public partial class INVENTARIO : Form
    {

        SqlConnection conexion;
        string inventario;
        SqlCommand comando;
        public INVENTARIO()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Zapateria;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }

        private void INVENTARIO_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void MostrarDatos()
        {
            inventario = "SELECT *FROM INVENTARIO";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(inventario, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Inventario");
            conexion.Close();
            dataGridView1.DataSource = ds.Tables["Inventario"];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string personalencargado = textBox1.Text;
            string fecha = textBox2.Text;
            string tipoinventario = textBox3.Text;


            inventario = "INSERT INTO INVENTARIO (personalencargado, fecha, tipoinventario) values('" + personalencargado + "', '" + fecha + "', '" + tipoinventario + "')";
            conexion.Open();
            comando = new SqlCommand(inventario, conexion); ;
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
