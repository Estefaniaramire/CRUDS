using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace proyectoZapateria
{
    public partial class SUCURSAL : Form
    {
        SqlConnection conexion;
        string sucursal;
        SqlCommand comando;
        public SUCURSAL()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Zapateria;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }

        private void SUCURSAL_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            sucursal = "SELECT *FROM SUCURSAL";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(sucursal, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Sucursal");
            conexion.Close();
            dataGridView1.DataSource = ds.Tables["Sucursal"];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string personalencargado = textBox1.Text;
            string fecha = textBox2.Text;
            string tipoinventario = textBox3.Text;


            sucursal = "INSERT INTO SUCURSAL (personalencargado, fecha, tipoinventario) values('" + personalencargado + "', '" + fecha + "', '" + tipoinventario + "')";
            conexion.Open();
            comando = new SqlCommand(sucursal, conexion); ;
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
