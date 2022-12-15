using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace proyectoZapateria
{
    public partial class HORARIO : Form
    {
        SqlConnection conexion;
        string horario;
        SqlCommand comando;
        public HORARIO()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Zapateria;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }

        private void HORARIO_Load(object sender, EventArgs e)
        {
            MostrarDatos();

        }

        private void MostrarDatos()
        {
            horario = "SELECT *FROM HORARIO";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(horario, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Horario");
            conexion.Close();
            dataGridView1.DataSource = ds.Tables["Horario"];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string horaentrada = textBox1.Text;
            string horasalida = textBox2.Text;
          


            horario = "INSERT INTO HORARIO (horaentrada, horasalida) values('" + horaentrada + "', '" + horasalida + "')";
            conexion.Open();
            comando = new SqlCommand(horario, conexion); ;
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
           

        }

    }
}
