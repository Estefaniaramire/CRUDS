using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace proyectoZapateria
{
    public partial class Caja : Form
    {
        SqlConnection conexion;
        string caja;
        SqlCommand comando;
        public Caja()
        {

            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Zapateria;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }

        private void Caja_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            caja = "SELECT *FROM CAJA";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(caja, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Caja");
            conexion.Close();
            dataGridView1.DataSource = ds.Tables["Caja"];
        }

        
         private void button1_Click(object sender, EventArgs e)
        {
            string numerocaja = textBox1.Text;
            string detallecaja = textBox2.Text;
            caja = "INSERT INTO Caja (numerocaja, cantidad) values('" + numerocaja + "', '" + detallecaja + "')";
            conexion.Open();
            comando = new SqlCommand(caja, conexion);
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
            int idCaja = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM CAJA WHERE idCaja = " + idCaja.ToString();
            caja = "UPDATE CAJA SET Estatus = 0 WHERE idCaja = " + idCaja.ToString(); ;
            conexion.Open();
            comando = new SqlCommand(caja, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
        }

        private void tnModificar_Click(object sender, EventArgs e)
        {
            string numerocaja = textBox1.Text;
            string detallecaja = textBox2.Text;
            int idCaja = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            caja = "UPDATE CAJA SET  numerocaja = '" + numerocaja + "', detallecaja = '" + detallecaja + "' WHERE idCaja = " + idCaja.ToString(); ;
            conexion.Open();
            comando = new SqlCommand(caja, conexion);
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

    

