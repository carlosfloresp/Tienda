using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BaseDeDatos
{
    public partial class Movimientos : Form
    {
        public Movimientos()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Visible = true;
            this.Visible = false;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            textid.Text = "";
            textper.Text = "";
            textcli.Text = "";
            textfec.Text = "";
            
            MessageBox.Show("ACTUALIZANDO DATOS", "**************GAMERS*****************", MessageBoxButtons.OK, MessageBoxIcon.None);

            string config = "Server=localhost;User ID= root;Database = proyecto;Allow Zero Datetime=True;Convert Zero Datetime=True;";
            string query = String.Format("SELECT * FROM {0}", "movimiento");

            MySqlConnection conexion = new MySqlConnection(config);
            conexion.Open();

            MySqlCommand comando = new MySqlCommand(query, conexion);

            MySqlDataAdapter adapter = new MySqlDataAdapter(comando);


            DataTable data = new DataTable();
            adapter.Fill(data);
            dataGridView1.DataSource = data;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        public Dictionary<string, string> datosDiccionario(string consulta)
        {
            MySqlConnection myConnection = new MySqlConnection("Server=localhost;User ID= root;Database = proyecto");
            myConnection.Open();
            MySqlCommand comandoConsulta = new MySqlCommand(consulta, myConnection);
            MySqlDataReader datosConsulta = comandoConsulta.ExecuteReader();
            // Bind combobox to dictionary
            Dictionary<string, string> valorDatos = new Dictionary<string, string>();

            if (!datosConsulta.HasRows)
                MessageBox.Show("No hay datos disponibles en la base de datos ");
            else
                while (datosConsulta.Read())
                {
                    valorDatos.Add(datosConsulta.GetValue(0).ToString(), datosConsulta.GetValue(1).ToString());
                }
            myConnection.Close();
            return valorDatos;

        }


        private void Movimientos_Load(object sender, EventArgs e)
        {


            textper.DataSource = new BindingSource(datosDiccionario("SELECT id, nombre FROM personal"), null);
            textper.DisplayMember = "Value";
            textper.ValueMember = "Key";

            textcli.DataSource = new BindingSource(datosDiccionario("SELECT id, nombre FROM Clientes"), null);
            textcli.DisplayMember = "Value";
            textcli.ValueMember = "Key";


            string config = "Server=localhost;User ID= root;Database = proyecto";
            string query = String.Format("SELECT * FROM {0}", "movimiento");

            MySqlConnection conexion = new MySqlConnection(config);
            conexion.Open();

            MySqlCommand comando = new MySqlCommand(query, conexion);

            MySqlDataAdapter adapter = new MySqlDataAdapter(comando);


            DataTable data = new DataTable();
            adapter.Fill(data);
            dataGridView1.DataSource = data;
          
        }

        private void textper_TextChanged(object sender, EventArgs e)
        {
            


        }

        private void textcli_SelectedIndexChanged(object sender, EventArgs e)
        {

          

        }
         public void comboper(){
            string connectionString = "Server=localhost;User ID= root;Database = proyecto";
            try
            {
                using (MySqlConnection sc = new MySqlConnection())
                {
                    sc.ConnectionString = connectionString;
                    sc.Open();
                    const string cmd = "SELECT id,nombre From Personal";

                    using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd, sc))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        textper.ValueMember = "id";
                        textper.DisplayMember = "nombre";
                        textper.DataSource = dt;
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error de SQL :" + ex.ToString());
            }
            }

         public void combocli()
         {
             string connectionString = "Server=localhost;User ID= root;Database = proyecto";
             try
             {
                 using (MySqlConnection sc = new MySqlConnection())
                 {
                     sc.ConnectionString = connectionString;
                     sc.Open();
                     const string cmd = "SELECT id,nombre From Clientes";

                     using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd, sc))
                     {
                         DataTable dt = new DataTable();
                         sda.Fill(dt);
                         textcli.ValueMember = "id";
                         textcli.DisplayMember = "nombre";
                         textcli.DataSource = dt;

                     }
                 }
             }
             catch (MySqlException ex)
             {
                 Console.WriteLine("Error de SQL :" + ex.ToString());
             }
         }

         private void button2_Click(object sender, EventArgs e)
         {
             //ELIMINAR
            if (textid.Text == "")
            {
                MessageBox.Show("favor de solo introducir el ID del movimiento para eliminarlo");
            }
            else
            {

                DialogResult result = MessageBox.Show("DESEA ELIMINARL EL MOVIMIENTO ??", "*********GAMERS***********", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        string myConnectionString = "";

                        // If the connection string is null, use a default.
                        if (myConnectionString == "")
                        {
                            myConnectionString = "Server=localhost;User ID= root;Database = proyecto";
                        }

                        try
                        {
                            MySqlConnection myConnection = new MySqlConnection(myConnectionString);
                            string myInsertQuery = "DELETE FROM movimiento Where id=" + textid.Text + "";
                            MySqlCommand myCommand = new MySqlCommand(myInsertQuery);
                            myCommand.Connection = myConnection;
                            myConnection.Open();
                            myCommand.ExecuteNonQuery();
                            myCommand.Connection.Close();



                            MessageBox.Show("MOVIMIENTO ELIMINADO", "***********GAMERS***********", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            textid.Text = "";
                            textper.Text = "";
                            textcli.Text = "";
                            textfec.Text = "";
                            
                            string cad = "Server=localhost;User ID= root;Database = proyecto";
                            string query = "select * from movimiento";
                            MySqlConnection cnn = new MySqlConnection(cad);
                            MySqlDataAdapter da = new MySqlDataAdapter(query, cnn);
                            System.Data.DataSet ds = new System.Data.DataSet();
                            da.Fill(ds, "movimiento");
                            dataGridView1.DataSource = ds;
                            dataGridView1.DataMember = "movimiento";
                        


                        }
                        catch (MySqlException)
                        {
                            MessageBox.Show("favor de solo introducir el ID del movimiento para eliminarlo");
                        }

                    }

                    catch (System.Exception)
                    {

                        MessageBox.Show("No existen registros");

                    }

                }
                else if (result == DialogResult.No)
                {

                    MessageBox.Show("MOVIMIENTO NO ELIMINADO", "***********GAMERS***********", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }

            }
                    
         }

        

         private void button1_Click(object sender, EventArgs e)
         {
             //AGREGAR
             try
             {
                 string myConnectionString = "";

                 // If the connection string is null, use a default.
                 if (myConnectionString == "")
                 {
                     myConnectionString = "Server=localhost;User ID= root;Database = proyecto";
                 }
                 try
                 {
                     MySqlConnection myConnection = new MySqlConnection(myConnectionString);
                     DateTime dtpDate = textfec.Value.Date;
                     string myInsertQuery = "INSERT INTO movimiento (id, id_personal, id_cliente, fec_movi) Values(?id,?id_personal,?id_cliente,?fec_movi)";
                     MySqlCommand myCommand = new MySqlCommand(myInsertQuery);
                     myCommand.Parameters.Add("?id", MySqlDbType.Int16, 100).Value = textid.Text;
                     myCommand.Parameters.Add("?id_personal", MySqlDbType.Int16, 100).Value = textper.SelectedValue;
                     myCommand.Parameters.Add("?id_cliente", MySqlDbType.Int16, 100).Value = textcli.SelectedValue;
                     myCommand.Parameters.Add("?fec_movi", MySqlDbType.Date, 8).Value = dtpDate;
                    
                     myCommand.Connection = myConnection;
                     myConnection.Open();
                     myCommand.ExecuteNonQuery();
                     myCommand.Connection.Close();
                     MessageBox.Show("CLIENTE AGREGADO A LA BASE DE DATOS CORRECTAMENTE", "**********GAMERS*************", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     textid.Text = "";
                     textper.Text = "";
                     textcli.Text = "";
                     textfec.Text = "";
                    
                     string cad = "Server=localhost;User ID= root;Database = proyecto";
                     string query = "select * from movimiento";
                     MySqlConnection cnn = new MySqlConnection(cad);
                     MySqlDataAdapter da = new MySqlDataAdapter(query, cnn);
                     System.Data.DataSet ds = new System.Data.DataSet();
                     da.Fill(ds, "movimiento");
                     dataGridView1.DataSource = ds;
                     dataGridView1.DataMember = "movimimento";
                 }
                 catch (MySqlException)
                 {
                     MessageBox.Show("ya existe registro.. favor de introducir uno distinto");
                 }
             }
             catch (System.Exception)
             {
                 MessageBox.Show("favor de llenar los  campos vacios");
             }



         }

         private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
         {

         }

         private void button3_Click(object sender, EventArgs e)
         {
             //CONSULTAR
             try
             {
                 string myConnectionString = "";

                 // If the connection string is null, use a default.
                 if (myConnectionString == "")
                 {
                     myConnectionString = "Server=localhost;User ID= root;Database = proyecto";
                 }
                 MySqlConnection myConnection = new MySqlConnection(myConnectionString);
                 string mySelectQuery = "SELECT * From movimiento Where id=" + textid.Text + "";
                 MySqlCommand myCommand = new MySqlCommand(mySelectQuery, myConnection);
                 myConnection.Open();
                 MySqlDataReader myReader;
                 myReader = myCommand.ExecuteReader();
                 // Always call Read before accessing data.
                 if (myReader.Read())
                 {
                     MessageBox.Show("MOSTRANDO DATOS", "*************GAMERS****************", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     textper.Text = (myReader.GetString(1));
                     textcli.Text = (myReader.GetString(2));
                     textfec.Text = (myReader.GetString(3));
                     

                 }
                 else
                 {
                     MessageBox.Show("no existe registro favor de introducir otro ID");
                 }
                 // always call Close when done reading.
                 myReader.Close();
                 // Close the connection when done with it.
                 myConnection.Close();
             }
             catch (System.Exception)
             {
                 MessageBox.Show("favor de solo introducir el ID del movimiento para consultar sus datos");
             }
         }
        
    }
}
