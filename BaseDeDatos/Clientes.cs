using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Net.Mail;


namespace BaseDeDatos
{
    public partial class Clientes : Form
    {



        public Clientes()
        {
            InitializeComponent();
        }

         
        
        private void Clientes_Load(object sender, EventArgs e)
        {

            string config = "Server=localhost;User ID= root;Database = proyecto";
            string query = String.Format("SELECT * FROM {0}", "clientes");

            MySqlConnection conexion = new MySqlConnection(config);
            conexion.Open();

            MySqlCommand comando = new MySqlCommand(query, conexion);
            MySqlDataAdapter adapter = new MySqlDataAdapter(comando);

            DataTable data = new DataTable();
            adapter.Fill(data);
            dataGridView1.DataSource = data;
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
                    string myInsertQuery = "INSERT INTO clientes (id, nombre, apellido_p, apellido_m, direccion, telefono) Values(?id,?nombre,?apellido_p,?apellido_m,?direccion,?telefono)";
                    MySqlCommand myCommand = new MySqlCommand(myInsertQuery);
                    myCommand.Parameters.Add("?id", MySqlDbType.Int16, 100).Value = textid.Text;
                    myCommand.Parameters.Add("?nombre", MySqlDbType.VarChar, 50).Value = textnom.Text;
                    myCommand.Parameters.Add("?apellido_p", MySqlDbType.VarChar, 30).Value = textpat.Text;
                    myCommand.Parameters.Add("?apellido_m", MySqlDbType.VarChar, 30).Value = textmat.Text;
                    myCommand.Parameters.Add("?direccion", MySqlDbType.VarChar, 50).Value = textdir.Text;
                    myCommand.Parameters.Add("?telefono", MySqlDbType.VarChar, 30).Value = texttel.Text;
                    myCommand.Connection = myConnection;
                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                    myCommand.Connection.Close();
                    MessageBox.Show("CLIENTE AGREGADO A LA BASE DE DATOS CORRECTAMENTE", "**********GAMERS*************", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textid.Text = "";
                    textnom.Text = "";
                    textpat.Text = "";
                    textmat.Text = "";
                    textdir.Text = "";
                    texttel.Text = "";

                    string cad = "Server=localhost;User ID= root;Database = proyecto";
                    string query = "select * from clientes";
                    MySqlConnection cnn = new MySqlConnection(cad);
                    MySqlDataAdapter da = new MySqlDataAdapter(query, cnn);
                    System.Data.DataSet ds = new System.Data.DataSet();
                    da.Fill(ds, "clientes");
                    dataGridView1.DataSource = ds;
                    dataGridView1.DataMember = "clientes";
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
            //EDITAR
            if (textid.Text == "")
            {
                MessageBox.Show("favor de introducir el ID y los campos que desea modificar");
            }
            else
            {

                DialogResult result = MessageBox.Show("DESEA MODIFICAR AL CLIENTE ??", "*********GAMERS***********", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                        MySqlConnection myConnection = new MySqlConnection(myConnectionString);
                        string myInsertQuery = "UPDATE clientes SET nombre = ?, apellido_p =?, apellido_m =?,direccion =?, telefono =? Where id=" + textid.Text + "";
                        MySqlCommand myCommand = new MySqlCommand(myInsertQuery);
                        myCommand.Parameters.Add("?nombre", MySqlDbType.VarChar, 50).Value = textnom.Text;
                        myCommand.Parameters.Add("?apellido_pat", MySqlDbType.VarChar, 30).Value = textpat.Text;
                        myCommand.Parameters.Add("?apellido_mat", MySqlDbType.VarChar, 30).Value = textmat.Text;
                        myCommand.Parameters.Add("?direccion", MySqlDbType.VarChar, 50).Value = textdir.Text;
                        myCommand.Parameters.Add("?telefono", MySqlDbType.VarChar, 30).Value = texttel.Text;
                        myCommand.Connection = myConnection;
                        myConnection.Open();
                        myCommand.ExecuteNonQuery();
                        myCommand.Connection.Close();

                        MessageBox.Show("CLIENTE MODIFICADO", "***********GAMERS***********", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        textid.Text = "";
                        textnom.Text = "";
                        textpat.Text = "";
                        textmat.Text = "";
                        textdir.Text = "";
                        texttel.Text = "";

                        string cad = "Server=localhost;User ID= root;Database = proyecto";
                        string query = "select * from clientes";
                        MySqlConnection cnn = new MySqlConnection(cad);
                        MySqlDataAdapter da = new MySqlDataAdapter(query, cnn);
                        System.Data.DataSet ds = new System.Data.DataSet();
                        da.Fill(ds, "clientes");
                        dataGridView1.DataSource = ds;
                        dataGridView1.DataMember = "clientes";
                    }

                    catch (System.Exception)
                    {
                       

                    }

                }
            }
        }
             

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ACTUALIZANDO DATOS","**************GAMERS*****************" ,MessageBoxButtons.OK, MessageBoxIcon.None);
            string config = "Server=localhost;User ID= root;Database = proyecto";
            string query = String.Format("SELECT * FROM {0}", "clientes");

            MySqlConnection conexion = new MySqlConnection(config);
            conexion.Open();

            MySqlCommand comando = new MySqlCommand(query, conexion);
            MySqlDataAdapter adapter = new MySqlDataAdapter(comando);

            DataTable data = new DataTable();
            adapter.Fill(data);
            dataGridView1.DataSource = data;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Visible = true;
            this.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textid.Text == "")
            {
                MessageBox.Show("favor de solo introducir el ID del cliente para eliminarlo");
            }
            else
            {

                DialogResult result = MessageBox.Show("DESEA ELIMINARL EL CLIENTE ??", "*********GAMERS***********", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                            string myInsertQuery = "DELETE FROM clientes Where id=" + textid.Text + "";
                            MySqlCommand myCommand = new MySqlCommand(myInsertQuery);
                            myCommand.Connection = myConnection;
                            myConnection.Open();
                            myCommand.ExecuteNonQuery();
                            myCommand.Connection.Close();



                            MessageBox.Show("CLIENTE ELIMINADO", "***********GAMERS***********", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            textid.Text = "";
                          

                            string cad = "Server=localhost;User ID= root;Database = proyecto";
                            string query = "select * from clientes";
                            MySqlConnection cnn = new MySqlConnection(cad);
                            MySqlDataAdapter da = new MySqlDataAdapter(query, cnn);
                            System.Data.DataSet ds = new System.Data.DataSet();
                            da.Fill(ds, "clientes");
                            dataGridView1.DataSource = ds;
                            dataGridView1.DataMember = "clientes";



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

                    MessageBox.Show("CLIENTE NO ELIMINADO", "***********GAMERS***********", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }

            }
        }


        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textid_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
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
                string mySelectQuery = "SELECT * From clientes Where id=" + textid.Text + "";
                MySqlCommand myCommand = new MySqlCommand(mySelectQuery, myConnection);
                myConnection.Open();
                MySqlDataReader myReader;
                myReader = myCommand.ExecuteReader();
                // Always call Read before accessing data.
                if (myReader.Read())
                {
                    MessageBox.Show("MOSTRANDO DATOS","*************GAMERS****************",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    textnom.Text = (myReader.GetString(1));
                    textpat.Text = (myReader.GetString(2));
                    textmat.Text = (myReader.GetString(3));
                    textdir.Text = (myReader.GetString(4));
                    texttel.Text = (myReader.GetString(5));
                    texttel.Text = (myReader.GetString(5));

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
                MessageBox.Show("favor de solo introducir el ID de cliente para consultar sus datos");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            correo correo = new correo();
            correo.Show();
        }



    }
}




