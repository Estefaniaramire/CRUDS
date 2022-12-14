using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;


namespace proyectoZapateria
{

    public partial class COMPRA : Form
    {
        SqlConnection conexion;
        string compra;
        SqlCommand comando;
        public COMPRA()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Zapateria;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }

        private void COMPRA_Load(object sender, EventArgs e)
        {
            MostrarDatos();

        }

        private void MostrarDatos()
        {
            compra = "SELECT *FROM COMPRA";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(compra, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Compra");
            conexion.Close();
            dataGridView1.DataSource = ds.Tables["Compra"];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cantidadcompra = textBox1.Text;
            string fechacompra = textBox2.Text;
            string foliocompra = textBox3.Text;
             compra = "INSERT INTO Compra (cantidadcompra, fechacompra, foliocompra) values('" + cantidadcompra + "', '" + fechacompra + "' , '" + foliocompra + "')";
            conexion.Open();
            comando = new SqlCommand(compra, conexion); ; 
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();

        }

    }
}
