using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace proyectoZapateria
{
    public partial class Capacitacion : Form
    {
        SqlConnection conexion;
        string capacitacion;
        SqlCommand comando;
        public Capacitacion()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Zapateria;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }

        private void Capacitacion_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void MostrarDatos()
        {
            capacitacion = "SELECT *FROM CAJA";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(capacitacion, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Capacitacion");
            conexion.Close();
            dataGridView1.DataSource = ds.Tables["Capacitacion"];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tipocapacitacion = textBox1.Text;
            string fechacapacitacion = textBox2.Text;
            capacitacion = "INSERT INTO Capacitacion (tipocapacitacion, fechacapacitacion) values('" + tipocapacitacion + "', '" + fechacapacitacion + "')";
            conexion.Open();
            comando = new SqlCommand(capacitacion, conexion);
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
            int idCapacitacion = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM CAPACITACION WHERE idCapacitacion = " + idCapacitacion.ToString();
            capacitacion = "UPDATE CAPACITACION SET Estatus = 0 WHERE idCapacitacion = " + idCapacitacion.ToString(); ;
            conexion.Open();
            comando = new SqlCommand(capacitacion, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
        }

        private void tnModificar_Click(object sender, EventArgs e)
        {
            string tipocapacitacion = textBox1.Text;
            string fechacapacitacion = textBox2.Text;
            int idCapacitacion = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            capacitacion = "UPDATE CAPACITACION SET  tipocapacitacion = '" + tipocapacitacion + "', fechacapacitacion = '" + fechacapacitacion + "' WHERE idCapacitacion = " + idCapacitacion.ToString(); ;
            conexion.Open();
            comando = new SqlCommand(capacitacion, conexion);
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
