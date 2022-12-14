using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace proyectoZapateria
{
    public partial class CREDITO : Form

    {


        SqlConnection conexion;
        string credito;
        SqlCommand comando;

        public CREDITO()
        {
          
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Zapateria;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }

        private void CREDITO_Load(object sender, EventArgs e)
        {
            MostrarDatos();

        }
        private void MostrarDatos()
        {
            credito = "SELECT *FROM CREDITO";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(credito, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "CREDITO");
            conexion.Close();
            dataGridView1.DataSource = ds.Tables["Credito"];
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string montocredito = textBox1.Text;


            credito = "INSERT INTO Credito (montocredito) values( '" + montocredito + "')";
            conexion.Open();
            comando = new SqlCommand(credito, conexion);
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
            int idCreedito = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM Credito WHERE idCredito = " + c.ToString();
            credito = "UPDATE idCredito SET Estatus = 0 WHERE idCredito = " + idCreedito.ToString(); ;
            conexion.Open();
            comando = new SqlCommand(credito, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
        }

    }
}
