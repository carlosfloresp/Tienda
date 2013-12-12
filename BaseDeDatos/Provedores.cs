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
    public partial class Provedores : Form
    {
        public Provedores()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textid.Text == "")
            {
                MessageBox.Show("favor de solo introducir el ID del provedor para eliminar");
            }
            else
            {

                DialogResult result = MessageBox.Show("DESEA ELIMINARL AL PROVEDOR ??", "*********GAMERS***********", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                            string myInsertQuery = "DELETE FROM provedor Where id=" + textid.Text + "";
                            MySqlCommand myCommand = new MySqlCommand(myInsertQuery);
                            myCommand.Connection = myConnection;
                            myConnection.Open();
                            myCommand.ExecuteNonQuery();
                            myCommand.Connection.Close();

                            MessageBox.Show("PROVEDOR ELIMINADO", "***********GAMERS***********", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            textid.Text = "";
                            textnom.Text = "";
                            textdir.Text = "";
                            texttel.Text = "";
                            textweb.Text = "";

                            string cad = "Server=localhost;User ID= root;Database = proyecto";
                            string query = "select * from provedor";
                            MySqlConnection cnn = new MySqlConnection(cad);
                            MySqlDataAdapter da = new MySqlDataAdapter(query, cnn);
                            System.Data.DataSet ds = new System.Data.DataSet();
                            da.Fill(ds, "provedor");
                            dataGridView1.DataSource = ds;
                            dataGridView1.DataMember = "provedor";



                        }
                        catch (MySqlException)
                        {
                            MessageBox.Show("favor de solo introducir el ID del provedor a eliminar");
                        }



                    }

                    catch (System.Exception)
                    {

                        MessageBox.Show("No existen registros");

                    }

                }
                else if (result == DialogResult.No)
                {

                    MessageBox.Show("PROVEDOR NO ELIMINADO", "***********GAMERS***********", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }

            }
        }

        private void Provedores_Load(object sender, EventArgs e)
        {
            string config = "Server=localhost;User ID= root;Database = proyecto;Allow Zero Datetime=True;Convert Zero Datetime=True;";
            string query = String.Format("SELECT * FROM {0}", "provedor");

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
                    string myInsertQuery = "INSERT INTO provedor (id, nombre, direccion, telefono, pagina_web) Values(?id,?nombre,?direccion,?telefono,?pagina_web)";
                    MySqlCommand myCommand = new MySqlCommand(myInsertQuery);
                    myCommand.Parameters.Add("?id", MySqlDbType.Int16, 100).Value = textid.Text;
                    myCommand.Parameters.Add("?nombre", MySqlDbType.VarChar, 50).Value = textnom.Text;
                    myCommand.Parameters.Add("?direccion", MySqlDbType.VarChar, 30).Value = textdir.Text;
                    myCommand.Parameters.Add("?telefono", MySqlDbType.VarChar, 30).Value = texttel.Text;
                    myCommand.Parameters.Add("?pagina_web", MySqlDbType.VarChar, 50).Value = textweb.Text;
                   
                    myCommand.Connection = myConnection;
                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                    myCommand.Connection.Close();
                    MessageBox.Show("PROVEDOR AGREGADO A LA BASE DE DATOS CORRECTAMENTE", "**********GAMERS*************", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textid.Text = "";
                    textnom.Text = "";
                    textdir.Text = "";
                    texttel.Text = "";
                    textweb.Text = "";
                    

                    string cad = "Server=localhost;User ID= root;Database = proyecto";
                    string query = "select * from provedor";
                    MySqlConnection cnn = new MySqlConnection(cad);
                    MySqlDataAdapter da = new MySqlDataAdapter(query, cnn);
                    System.Data.DataSet ds = new System.Data.DataSet();
                    da.Fill(ds, "provedor");
                    dataGridView1.DataSource = ds;
                    dataGridView1.DataMember = "provedor";
                }
                catch (MySqlException)
                {
                    MessageBox.Show("YA EXISTE REGISTRO.. FAVOR DE INTRODUCIR UNO DISTINTO", "*********GAMERS***********", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (System.Exception)
            {
                MessageBox.Show("FAVOR DE LLENAR LOS CAMPOS PARA EDITAR", "*********GAMERS***********",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            //EDITAR
            if (textid.Text == "")
            {
                MessageBox.Show("EXISTEN CAMPOS VACIOS FAVOR DE LLENAR TODOS LOS CAMPOS PARA MODIFICAR", "**************************GAMERS***********************", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
                        string myInsertQuery = "UPDATE provedor SET nombre = ?, direccion =?, telefono =?,pagina_web =? Where id=" + textid.Text + "";
                        MySqlCommand myCommand = new MySqlCommand(myInsertQuery);
                        myCommand.Parameters.Add("?nombre", MySqlDbType.VarChar, 50).Value = textnom.Text;
                        myCommand.Parameters.Add("?direccion", MySqlDbType.VarChar, 30).Value = textdir.Text;
                        myCommand.Parameters.Add("?telefono", MySqlDbType.VarChar, 30).Value = texttel.Text;
                        myCommand.Parameters.Add("?pagina_web", MySqlDbType.VarChar, 50).Value = textweb.Text;
                       
                        myCommand.Connection = myConnection;
                        myConnection.Open();
                        myCommand.ExecuteNonQuery();
                        myCommand.Connection.Close();

                        MessageBox.Show("PROVEDOR MODIFICADO", "***********GAMERS***********", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        textid.Text = "";
                        textnom.Text = "";
                        textdir.Text = "";
                        texttel.Text = "";
                        textweb.Text = "";

                        string cad = "Server=localhost;User ID= root;Database = proyecto";
                        string query = "select * from provedor";
                        MySqlConnection cnn = new MySqlConnection(cad);
                        MySqlDataAdapter da = new MySqlDataAdapter(query, cnn);
                        System.Data.DataSet ds = new System.Data.DataSet();
                        da.Fill(ds, "provedor");
                        dataGridView1.DataSource = ds;
                        dataGridView1.DataMember = "provedor";
                    }

                    catch (System.Exception)
                    {
                        MessageBox.Show("EXISTEN CAMPOS VACIOS FAVOR DE LLENAR TODOS LOS CAMPOS PARA MODIFICAR", "**************************GAMERS***********************", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    }

                }
            }
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
                string mySelectQuery = "SELECT * From provedor Where id=" + textid.Text + "";
                MySqlCommand myCommand = new MySqlCommand(mySelectQuery, myConnection);
                myConnection.Open();
                MySqlDataReader myReader;
                myReader = myCommand.ExecuteReader();
                // Always call Read before accessing data.
                if (myReader.Read())
                {
                    MessageBox.Show("MOSTRANDO DATOS", "*************GAMERS****************", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textnom.Text = (myReader.GetString(1));
                    textdir.Text = (myReader.GetString(2));
                    texttel.Text = (myReader.GetString(3));
                    textweb.Text = (myReader.GetString(4));
                    

                }
                else
                {
                    MessageBox.Show("NO EXISTE REGISTRO FAVOR DE INTRODUCIR OTRO ID","**************GAMERS*****************", MessageBoxButtons.OK, MessageBoxIcon.None);
                }
                // always call Close when done reading.
                myReader.Close();
                // Close the connection when done with it.
                myConnection.Close();
            }
            catch (System.Exception)
            {
                MessageBox.Show("FAVOR DE INTRODUCIR EL ID PARA CONSULTAR DATOS", "**************GAMERS*****************", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textid.Text = "";
            textnom.Text = "";
            textdir.Text = "";
            texttel.Text = "";
            textweb.Text = "";
            MessageBox.Show("ACTUALIZANDO DATOS", "**************GAMERS*****************", MessageBoxButtons.OK, MessageBoxIcon.None);

            string config = "Server=localhost;User ID= root;Database = proyecto;Allow Zero Datetime=True;Convert Zero Datetime=True;";
            string query = String.Format("SELECT * FROM {0}", "provedor");

            MySqlConnection conexion = new MySqlConnection(config);
            conexion.Open();

            MySqlCommand comando = new MySqlCommand(query, conexion);

            MySqlDataAdapter adapter = new MySqlDataAdapter(comando);


            DataTable data = new DataTable();
            adapter.Fill(data);
            dataGridView1.DataSource = data;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Visible = true;
            this.Visible = false;
        }
    }
}
