using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace proyectoZapateria
{
    public partial class COTIZACION : Form


    {

        SqlConnection conexion;
        string cotizacion;
        SqlCommand comando;

        public COTIZACION()

        {
            InitializeComponent();
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Zapateria;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }

        private void COTIZACION_Load(object sender, EventArgs e)
        {
            MostrarDatos();

        }

        private void MostrarDatos()
        {
            cotizacion = "SELECT *FROM COTIZACION";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(cotizacion, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "COTIZACION");
            conexion.Close();
            dataGridView1.DataSource = ds.Tables["Cotizacion"];
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string productocotizacion = textBox1.Text;
           

            cotizacion = "INSERT INTO Cotizacion (productocotizacion) values( '" + productocotizacion + "')";
            conexion.Open();
            comando = new SqlCommand(cotizacion, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
       
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idCotizacion = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM Cotizacion WHERE idCotizacion = " + c.ToString();
            cotizacion = "UPDATE idCotizacion SET Estatus = 0 WHERE idCotizacion = " + idCotizacion.ToString(); ;
            conexion.Open();
            comando = new SqlCommand(cotizacion, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
        }



        }
}
