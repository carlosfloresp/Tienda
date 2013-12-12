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
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //ELIMINAR
            if (textid.Text == "")
            {
                MessageBox.Show("favor de solo introducir el ID del registro para eliminarlo");
            }
            else
            {

                DialogResult result = MessageBox.Show("DESEA ELIMINARL EL REGISTRO ??", "*********GAMERS***********", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                            string myInsertQuery = "DELETE FROM registro Where id=" + textid.Text + "";
                            MySqlCommand myCommand = new MySqlCommand(myInsertQuery);
                            myCommand.Connection = myConnection;
                            myConnection.Open();
                            myCommand.ExecuteNonQuery();
                            myCommand.Connection.Close();



                            MessageBox.Show("REGISTRO ELIMINADO", "***********GAMERS***********", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            textid.Text = "";
                            textvideo.Text = "";
                            textcant.Text = "";
                            textmovi.Text = "";
                            textpre.Text = "";
                         
                            string cad = "Server=localhost;User ID= root;Database = proyecto";
                            string query = "select * from registro";
                            MySqlConnection cnn = new MySqlConnection(cad);
                            MySqlDataAdapter da = new MySqlDataAdapter(query, cnn);
                            System.Data.DataSet ds = new System.Data.DataSet();
                            da.Fill(ds, "registro");
                            dataGridView1.DataSource = ds;
                            dataGridView1.DataMember = "registro";



                        }
                        catch (MySqlException)
                        {
                            MessageBox.Show("favor de solo introducir el ID de cliente para eliminarlo");
                        }



                    }

                    catch (System.Exception)
                    {

                        MessageBox.Show("No existen registros");

                    }

                }
                else if (result == DialogResult.No)
                {

                    MessageBox.Show("REGISTRO NO ELIMINADO", "***********GAMERS***********", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

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
                    string myInsertQuery = "INSERT INTO registro (id, id_videojuegos, cantidad, id_movimiento, precio) Values(?id,?id_videojuegos,?cantidad,?id_movimiento,?precio)";
                    MySqlCommand myCommand = new MySqlCommand(myInsertQuery);
                    myCommand.Parameters.Add("?id", MySqlDbType.Int16, 100).Value = textid.Text;
                    myCommand.Parameters.Add("?id_videojuegos", MySqlDbType.Int16, 100).Value = textvideo.SelectedValue;
                    myCommand.Parameters.Add("?cantidad", MySqlDbType.Int16, 100).Value = textcant.Text;
                    myCommand.Parameters.Add("?id_movimiento", MySqlDbType.Int16, 100).Value = textmovi.Text;
                    myCommand.Parameters.Add("?precio", MySqlDbType.Decimal, 7).Value = textpre.Text;
                    
                    myCommand.Connection = myConnection;
                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                    myCommand.Connection.Close();
                    MessageBox.Show("REGISTRO AGREGADO A LA BASE DE DATOS CORRECTAMENTE", "**********GAMERS*************", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textid.Text = "";
                    textvideo.Text = "";
                    textcant.Text = "";
                    textmovi.Text = "";
                    textpre.Text = "";
                  
                    string cad = "Server=localhost;User ID= root;Database = proyecto";
                    string query = "select * from registro";
                    MySqlConnection cnn = new MySqlConnection(cad);
                    MySqlDataAdapter da = new MySqlDataAdapter(query, cnn);
                    System.Data.DataSet ds = new System.Data.DataSet();
                    da.Fill(ds, "registro");
                    dataGridView1.DataSource = ds;
                    dataGridView1.DataMember = "registro";
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

        public void combovideo()
        {
            string connectionString = "Server=localhost;User ID= root;Database = proyecto";
            try
            {
                using (MySqlConnection sc = new MySqlConnection())
                {
                    sc.ConnectionString = connectionString;
                    sc.Open();
                    const string cmd = "SELECT id,nombre From Videojuegos";

                    using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd, sc))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        textvideo.ValueMember = "id";
                        textvideo.DisplayMember = "nombre";
                        textvideo.DataSource = dt;
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error de SQL :" + ex.ToString());
            }
        }

        public void combomovi()
        {
            string connectionString = "Server=localhost;User ID= root;Database = proyecto";
            try
            {
                using (MySqlConnection sc = new MySqlConnection())
                {
                    sc.ConnectionString = connectionString;
                    sc.Open();
                    const string cmd = "SELECT id,id_personal From Movimiento";

                    using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd, sc))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        textmovi.ValueMember = "id";
                        textmovi.DisplayMember = "id_personal"+ "id";
                        textmovi.DataSource = dt;
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error de SQL :" + ex.ToString());
            }
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

        private void Registro_Load(object sender, EventArgs e)
        {
            string config = "Server=localhost;User ID= root;Database = proyecto;Allow Zero Datetime=True;Convert Zero Datetime=True;";
            string query = String.Format("SELECT * FROM {0}", "registro");

            MySqlConnection conexion = new MySqlConnection(config);
            conexion.Open();

            MySqlCommand comando = new MySqlCommand(query, conexion);

            MySqlDataAdapter adapter = new MySqlDataAdapter(comando);


            DataTable data = new DataTable();
            adapter.Fill(data);
            dataGridView1.DataSource = data;

            textvideo.DataSource = new BindingSource(datosDiccionario("SELECT id, nombre FROM videojuegos"), null);
            textvideo.DisplayMember = "Value";
            textvideo.ValueMember = "Key";


            textmovi.DataSource = new BindingSource(datosDiccionario("SELECT id, id FROM movimiento"), null);
            textmovi.DisplayMember = "Value";
            textmovi.ValueMember = "Key";


         
           
        }

        private void textvideo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Visible = true;
            this.Visible = false;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            textid.Text = "";
            textvideo.Text = "";
            textcant.Text = "";
            textmovi.Text = "";
            textpre.Text = "";
            MessageBox.Show("ACTUALIZANDO DATOS", "**************GAMERS*****************", MessageBoxButtons.OK, MessageBoxIcon.None);
            string config = "Server=localhost;User ID= root;Database = proyecto";
            string query = String.Format("SELECT * FROM {0}", "registro");

            MySqlConnection conexion = new MySqlConnection(config);
            conexion.Open();

            MySqlCommand comando = new MySqlCommand(query, conexion);
            MySqlDataAdapter adapter = new MySqlDataAdapter(comando);

            DataTable data = new DataTable();
            adapter.Fill(data);
            dataGridView1.DataSource = data;
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
                string mySelectQuery = "SELECT * From registro Where id=" + textid.Text + "";
                MySqlCommand myCommand = new MySqlCommand(mySelectQuery, myConnection);
                myConnection.Open();
                MySqlDataReader myReader;
                myReader = myCommand.ExecuteReader();
                // Always call Read before accessing data.
                if (myReader.Read())
                {
                    MessageBox.Show("MOSTRANDO DATOS", "*************GAMERS****************", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textid.Text = (myReader.GetString(1));
                    textvideo.Text = (myReader.GetString(2));
                    textcant.Text = (myReader.GetString(3));
                    textmovi.Text = (myReader.GetString(4));
                    textpre.Text = (myReader.GetString(5));
                   

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
                MessageBox.Show("favor de solo introducir el ID del registro para consultar sus datos");
            }
        }
    }
}
