using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace proyectoZapateria
{
    public partial class MERCANCIAEXTRA : Form
    {


        SqlConnection conexion;
        string mercanciaextra;
        SqlCommand comando;
        public MERCANCIAEXTRA()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Zapateria;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }

        private void MERCANCIAEXTRA_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void MostrarDatos()
        {
            mercanciaextra = "SELECT *FROM MERCANCIAEXTRA";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(mercanciaextra, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Mercanciaextra");
            conexion.Close();
            dataGridView1.DataSource = ds.Tables["Mercanciaextra"];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fecha = textBox1.Text;
            string tipomercancia = textBox2.Text;
            mercanciaextra = "INSERT INTO MERCANCIAEXTRA (fecha, tipomercancia) values( '" + fecha + "',  '" + tipomercancia + "')";
            conexion.Open();
            comando = new SqlCommand(mercanciaextra, conexion); ;
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();



        }
    }
}
