using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace proyectoZapateria
{
    public partial class DEPARTAMENTO : Form
    {

        SqlConnection conexion;
        string departamento;
        SqlCommand comando;

        public DEPARTAMENTO()
        {
         
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=AgenciaViajes2;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }

        private void DEPARTAMENTO_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void MostrarDatos()
        {
            departamento = "SELECT *FROM DEPARTAMENTO";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter( departamento, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "DEPARTAMENTO");
            conexion.Close();
            dataGridView1.DataSource = ds.Tables["Departamento"];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tipodepartamento = textBox1.Text;


            departamento = "INSERT INTO Departamento (tipodepartamento) values( '" + tipodepartamento + "')";
            conexion.Open();
            comando = new SqlCommand(departamento, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
           
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idDepartamento = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM Departamento WHERE idDepartamento = " + c.ToString();
            departamento = "UPDATE idDepartamento SET Estatus = 0 WHERE idDepartamento = " + idDepartamento.ToString(); ;
            conexion.Open();
            comando = new SqlCommand(departamento, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
        }
    }
}
