using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace proyectoZapateria
{
    public partial class CORTECAJA : Form
    {

        SqlConnection conexion;
        string cortecaja;
        SqlCommand comando;
        public CORTECAJA()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Zapateria;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }

        private void CORTECAJA_Load(object sender, EventArgs e)
        {
            MostrarDatos();

        }

        private void MostrarDatos()
        {
            cortecaja = "SELECT *FROM cCORTECAJA";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(cortecaja, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "CORTECAJA");
            conexion.Close();
            dataGridView1.DataSource = ds.Tables["Cortecaja"];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string empleadocorte = textBox1.Text;
            string fechacorte = textBox2.Text;

            cortecaja = "INSERT INTO Contrato (empleadocorte, fechacorte) values('" + empleadocorte + "', '" + fechacorte + "')";
            conexion.Open();
            comando = new SqlCommand(cortecaja, conexion);
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
            int idCorteCaja = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM CorteCaja WHERE idCorteCaja = " + c.ToString();
            cortecaja = "UPDATE CORTECAJA SET Estatus = 0 WHERE idCorteCaja = " + idCorteCaja.ToString(); ;
            conexion.Open();
            comando = new SqlCommand(cortecaja, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
        }
    }
}
