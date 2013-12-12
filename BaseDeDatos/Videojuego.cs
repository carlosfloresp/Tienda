using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using System.Net.Mail;

namespace BaseDeDatos
{
    public partial class Videojuego : Form
    {
        public Videojuego()
        {
            InitializeComponent();
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
        DataTable videojuegos;
        private void Videojuego_Load(object sender, EventArgs e)
        {
                        string config = "Server=localhost;User ID= root;Database = proyecto;Allow Zero Datetime=True;Convert Zero Datetime=True;";
            string query = String.Format("SELECT * FROM {0}", "videojuegos");

            MySqlConnection conexion = new MySqlConnection(config);
            conexion.Open();

            MySqlCommand comando = new MySqlCommand(query, conexion);

            MySqlDataAdapter adapter = new MySqlDataAdapter(comando);


            videojuegos = new DataTable();
            adapter.Fill(videojuegos);
            dataGridView1.DataSource = videojuegos;




            textpro.DataSource = new BindingSource(datosDiccionario("SELECT id, nombre FROM provedor"), null);
            textpro.DisplayMember = "Value";
            textpro.ValueMember = "Key";

        }

        private void button4_Click(object sender, EventArgs e)
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
                string mySelectQuery = "SELECT * From videojuegos Where id=" + textid.Text + "";
                MySqlCommand myCommand = new MySqlCommand(mySelectQuery, myConnection);
                myConnection.Open();
                MySqlDataReader myReader;
                myReader = myCommand.ExecuteReader();
                // Always call Read before accessing data.
                if (myReader.Read())
                {
                    MessageBox.Show("MOSTRANDO DATOS", "*************GAMERS****************", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textgen.Text = (myReader.GetString(1));
                    textano.Text = (myReader.GetString(2));
                    textnom.Text = (myReader.GetString(3));
                    textpla.Text = (myReader.GetString(4));
                    textpro.Text = (myReader.GetString(5));
                    textexis.Text = (myReader.GetString(6));

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
                MessageBox.Show("favor de solo introducir el ID del videojuego para consultar sus datos");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Visible = true;
            this.Visible = false;
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
                    string myInsertQuery = "INSERT INTO videojuegos (id, genero, año, nombre, plataforma, id_provedor, existencias) Values(?id,?genero,?año,?nombre,?plataforma,?id_provedor,?existencias)";
                    MySqlCommand myCommand = new MySqlCommand(myInsertQuery);
                    myCommand.Parameters.Add("?id", MySqlDbType.Int16, 100).Value = textid.Text;
                    myCommand.Parameters.Add("?genero", MySqlDbType.VarChar, 50).Value = textgen.Text;
                    myCommand.Parameters.Add("?año", MySqlDbType.VarChar, 50).Value = textano.Text;
                    myCommand.Parameters.Add("?nombre", MySqlDbType.VarChar, 50).Value = textnom.Text;
                    myCommand.Parameters.Add("?plataforma", MySqlDbType.VarChar, 20).Value = textpla.Text;
                    myCommand.Parameters.Add("?id_provedor", MySqlDbType.Int16, 100).Value = textpro.SelectedValue;
                    myCommand.Parameters.Add("?existencias", MySqlDbType.Int16, 100).Value = textexis.Text;

                    myCommand.Connection = myConnection;
                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                    myCommand.Connection.Close();
                    MessageBox.Show("VIDEOJUEGO AGREGADO A LA BASE DE DATOS CORRECTAMENTE", "**********GAMERS*************", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textid.Text = "";
                    textgen.Text = "";
                    textano.Text = "";
                    textnom.Text = "";
                    textpla.Text = "";
                    textpro.Text = "";
                    textexis.Text = "";
                   

                    string cad = "Server=localhost;User ID= root;Database = proyecto";
                    string query = "select * from videojuegos";
                    MySqlConnection cnn = new MySqlConnection(cad);
                    MySqlDataAdapter da = new MySqlDataAdapter(query, cnn);
                    System.Data.DataSet ds = new System.Data.DataSet();
                    da.Fill(ds, "videojuegos");
                    dataGridView1.DataSource = ds;
                    dataGridView1.DataMember = "videojuegos";
                }
                catch (MySqlException)
                {
                    MessageBox.Show("YA EXISTE REGISTRO.. FAVOR DE INTRODUCIR UNO DISTINTO", "*********GAMERS***********", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (System.Exception)
            {
                MessageBox.Show("FAVOR DE LLENAR LOS CAMPOS PARA EDITAR", "*********GAMERS***********", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            textid.Text = "";
            textgen.Text = "";
            textano.Text = "";
            textnom.Text = "";
            textpla.Text = "";
            textpro.Text = "";
            textexis.Text = "";

            MessageBox.Show("ACTUALIZANDO DATOS", "**************GAMERS*****************", MessageBoxButtons.OK, MessageBoxIcon.None);

            string config = "Server=localhost;User ID= root;Database = proyecto;Allow Zero Datetime=True;Convert Zero Datetime=True;";
            string query = String.Format("SELECT * FROM {0}", "videojuegos");

            MySqlConnection conexion = new MySqlConnection(config);
            conexion.Open();

            MySqlCommand comando = new MySqlCommand(query, conexion);

            MySqlDataAdapter adapter = new MySqlDataAdapter(comando);


            DataTable data = new DataTable();
            adapter.Fill(data);
            dataGridView1.DataSource = data;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //ELIMNAR
            if (textid.Text == "")
            {
                MessageBox.Show("favor de solo introducir el ID del videojuego para eliminar");
            }
            else
            {

                DialogResult result = MessageBox.Show("DESEA ELIMINARL EL VIDEOJUEGO ??", "*********GAMERS***********", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                            string myInsertQuery = "DELETE FROM videojuegos Where id=" + textid.Text + "";
                            MySqlCommand myCommand = new MySqlCommand(myInsertQuery);
                            myCommand.Connection = myConnection;
                            myConnection.Open();
                            myCommand.ExecuteNonQuery();
                            myCommand.Connection.Close();

                            MessageBox.Show("VIDEOJUEGO ELIMINADO", "***********GAMERS***********", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            textid.Text = "";
                            textgen.Text = "";
                            textano.Text = "";
                            textnom.Text = "";
                            textpla.Text = "";
                            textpro.Text = "";
                            textexis.Text = "";

                            string cad = "Server=localhost;User ID= root;Database = proyecto";
                            string query = "select * from videojuegos";
                            MySqlConnection cnn = new MySqlConnection(cad);
                            MySqlDataAdapter da = new MySqlDataAdapter(query, cnn);
                            System.Data.DataSet ds = new System.Data.DataSet();
                            da.Fill(ds, "videojuegos");
                            dataGridView1.DataSource = ds;
                            dataGridView1.DataMember = "videojuegos";



                        }
                        catch (MySqlException)
                        {
                            MessageBox.Show("favor de solo introducir el ID del videojuego a eliminar");
                        }



                    }

                    catch (System.Exception)
                    {

                        MessageBox.Show("No existen registros");

                    }

                }
                else if (result == DialogResult.No)
                {

                    MessageBox.Show("VIDEOJUEGO NO ELIMINADO", "***********GAMERS***********", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }

            }
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

                DialogResult result = MessageBox.Show("DESEA MODIFICAR EL VIDEOJUEGO ??", "*********GAMERS***********", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                        string myInsertQuery = "UPDATE videojuegos SET genero = ?, año =?, nombre =?,plataforma =?, id_provedor =?, existencias=? Where id=" + textid.Text + "";
                        MySqlCommand myCommand = new MySqlCommand(myInsertQuery);
                        myCommand.Parameters.Add("?genero", MySqlDbType.VarChar, 50).Value = textgen.Text;
                        myCommand.Parameters.Add("?año", MySqlDbType.VarChar, 50).Value = textano.Text;
                        myCommand.Parameters.Add("?nombre", MySqlDbType.VarChar, 50).Value = textnom.Text;
                        myCommand.Parameters.Add("?plataforma", MySqlDbType.VarChar, 20).Value = textpla.Text;
                        myCommand.Parameters.Add("?id_provedor", MySqlDbType.Int16, 100).Value = textpro.Text;
                        myCommand.Parameters.Add("?existencias", MySqlDbType.Int16, 100).Value = textexis.Text;
                        myCommand.Connection = myConnection;
                        myConnection.Open();
                        myCommand.ExecuteNonQuery();
                        myCommand.Connection.Close();

                        MessageBox.Show("VIDEOJUEGO MODIFICADO", "***********GAMERS***********", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        textid.Text = "";
                        textgen.Text = "";
                        textano.Text = "";
                        textnom.Text = "";
                        textpla.Text = "";
                        textpro.Text = "";
                        textexis.Text = "";

                        string cad = "Server=localhost;User ID= root;Database = proyecto";
                        string query = "select * from videojuegos";
                        MySqlConnection cnn = new MySqlConnection(cad);
                        MySqlDataAdapter da = new MySqlDataAdapter(query, cnn);
                        System.Data.DataSet ds = new System.Data.DataSet();
                        da.Fill(ds, "videojuegos");
                        dataGridView1.DataSource = ds;
                        dataGridView1.DataMember = "videojuegos";
                    }

                    catch (MySqlException)
                    {

                        MessageBox.Show("No existe registro");

                    }

                }
            }
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel._Application Excel_Application;
            Microsoft.Office.Interop.Excel._Workbook HojaTrabajo;
            Microsoft.Office.Interop.Excel._Worksheet PestañaTrabajo;
            Excel_Application = new Microsoft.Office.Interop.Excel.Application();
            object misValue = System.Reflection.Missing.Value;
            HojaTrabajo = Excel_Application.Workbooks.Add(misValue);
            PestañaTrabajo = (Microsoft.Office.Interop.Excel._Worksheet)HojaTrabajo.ActiveSheet;
            int i = 0;
            int j = 0;
            for (i = 1; i < dataGridView1.Columns.Count + 1; i++)
            {
                PestañaTrabajo.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
            }
            for (i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                for (j = 0; j <= dataGridView1.ColumnCount - 1; j++)
                {
                    DataGridViewCell cell = dataGridView1[j, i];
                    PestañaTrabajo.Cells[i + 2, j + 1] = cell.Value;

                }
            }
            string Carpeta = @"C:\users\Anthony\desktop\";
            if (!Directory.Exists(Carpeta))
            {
                Directory.CreateDirectory(Carpeta);
            }
            string archivo = Carpeta + "reporteVideojuegs.xls";
            try
            {
                HojaTrabajo.SaveAs(archivo, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                System.Diagnostics.Process.Start(Carpeta);
            }
            catch
            {
                Excel_Application.Quit();
            }
            MessageBox.Show("Reporte Creado Satisfactoriamente", "Gamers", MessageBoxButtons.OK);


        }




        private void textpro_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
