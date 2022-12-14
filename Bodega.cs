using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace proyectoZapateria
{
    public partial class Bodega : Form
    {

        SqlConnection conexion;
        string bodega;
        SqlCommand comando;

        public Bodega()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Zapateria;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }

        private void Bodega_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
           bodega = "SELECT *FROM BODEGA";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(bodega, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Bodega");
            conexion.Close();
            dataGridView1.DataSource = ds.Tables["Bodega"];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string capacidad = textBox1.Text;
            bodega = "INSERT INTO Bodega (capacidad) values('" + capacidad + "')";
            conexion.Open();
            comando = new SqlCommand(bodega, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
       
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idBodega = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //bodega = "DELETE FROM BODEGA WHERE idBodega = " + idBodega.ToString();
            bodega = "UPDATE BODEGA SET Estatus = 0 WHERE idBodega = " + idBodega.ToString(); 
            conexion.Open();
            comando = new SqlCommand(bodega, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
        }

        private void tnModificar_Click(object sender, EventArgs e)
        {
            string capacidad = textBox1.Text;
            int idBodega = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            bodega = "UPDATE BODEGA SET capacidad = '" + capacidad + "' WHERE idBodega = " + idBodega.ToString();
            conexion.Open();
            comando = new SqlCommand(bodega, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
           
        }
    }
}

    

