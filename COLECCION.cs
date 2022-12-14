using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace proyectoZapateria
{
    public partial class COLECCION : Form
    {
        SqlConnection conexion;
        string coleccion;
        SqlCommand comando;
        public COLECCION()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Zapateria;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }

        private void COLECCION_Load(object sender, EventArgs e)
        {
            MostrarDatos();

        }
        private void MostrarDatos()
        {
            coleccion = "SELECT *FROM COLECCION";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(coleccion, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Coleccion");
            conexion.Close();
            dataGridView1.DataSource = ds.Tables["Coleccion"];
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string nombrecoleccion = textBox1.Text;
            coleccion = "INSERT INTO Coleccion (nombrecoleccion) values('" + nombrecoleccion + "')";
            conexion.Open();
            comando = new SqlCommand(coleccion, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
         
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idColeccion = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM COLECCION WHERE idColeccion = " + idColeccion.ToString();
            coleccion = "UPDATE COLECCION SET Estatus = 0 WHERE idColeccion = " + idColeccion.ToString(); ;
            conexion.Open();
            comando = new SqlCommand(coleccion, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
        }

        private void tnModificar_Click(object sender, EventArgs e)
        {
            string nombrecoleccion = textBox1.Text;
            int idColeccion = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            coleccion = "UPDATE COLECCION SET  nombrecoleccion = '" + nombrecoleccion + "' WHERE idCliente = " + idColeccion.ToString(); ;
            conexion.Open();
            comando = new SqlCommand(coleccion, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();

        }
    }
}
