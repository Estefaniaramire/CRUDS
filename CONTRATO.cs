using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace proyectoZapateria
{
    public partial class CONTRATO : Form
    {
        SqlConnection conexion;
        string contrato;
        SqlCommand comando;
        public CONTRATO()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Zapateria;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }

        private void CONTRATO_Load(object sender, EventArgs e)

        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            contrato = "SELECT *FROM CONTRATO";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(contrato, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "CONTRATO");
            conexion.Close();
            dataGridView1.DataSource = ds.Tables["Contrato"];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fechacontrato = textBox1.Text;
            string tipocontrato = textBox2.Text;

            contrato = "INSERT INTO Contrato (fechacontrato, tipocontrato) values('" + fechacontrato + "', '" + tipocontrato + "')";
            conexion.Open();
            comando = new SqlCommand(contrato, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();

        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idContrato = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM Contrato WHERE idContrato = " + idContrato.ToString();
            contrato = "UPDATE CONTRATO SET Estatus = 0 WHERE idContrato = " + idContrato.ToString(); ;
            conexion.Open();
            comando = new SqlCommand(contrato, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string fechacontrato = textBox1.Text;
            string tipocontrato = textBox2.Text;
        
           
            int idContrato = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            contrato = "UPDATE CONTRATO SET fechacontrato = '" + fechacontrato + "',tipocontrato = '" + tipocontrato +  "' WHERE idContrato = " + idContrato.ToString();
            conexion.Open();
            comando = new SqlCommand(contrato, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            
        }
    }
}
