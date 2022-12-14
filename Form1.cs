using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace proyectoZapateria
{
    public partial class Form1 : Form
    {
        SqlConnection conexion;
        string apartado;
        SqlCommand comando;

        public Form1()
        {
            InitializeComponent();
           string cadena = @"Server=localhost\SQLEXPRESS;Database=Zapateria;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            apartado = "SELECT *FROM APARTADO";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(apartado, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Apartado");
            conexion.Close();
            dataGridView1.DataSource = ds.Tables["Apartado"];
        }

        private void mantenimmientoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cantidad = textBox1.Text;
            string productoapartado = textBox2.Text;
            apartado = "INSERT INTO Apartado (cantidad, productoapatado) values('" + cantidad  + "', '" + productoapartado + "')";
            conexion.Open();
            comando = new SqlCommand(apartado, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idApartado = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM APARTADO WHERE idApartado = " + idApartado.ToString();
            apartado = "UPDATE APARTADO SET Estatus = 0 WHERE idApartado = " + idApartado.ToString(); ;
            conexion.Open();
            comando = new SqlCommand(apartado, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
        }

        private void tnModificar_Click(object sender, EventArgs e)
        {
            string cantidad = textBox1.Text;
            string productoapartado = textBox2.Text;
            int idApartado = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            apartado = "UPDATE APARTADO SET cantidad = '" + cantidad + "', productoapartado = '" + productoapartado + "' WHERE idApartado = " + idApartado.ToString();
            conexion.Open();
            comando = new SqlCommand(apartado, conexion);
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
