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
    public partial class Personal : Form
    {
        public Personal()
        {
            InitializeComponent();
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
                    myConnectionString = "Server=localhost;User ID= root;Database = proyecto;Allow Zero Datetime=True;Convert Zero Datetime=True;";
                }
                try
                {
                    MySqlConnection myConnection = new MySqlConnection(myConnectionString);

                    DateTime dtpDate = fechaNac.Value.Date;
                    DateTime dtpDate2 = fechaIngreso.Value.Date;


                    string myInsertQuery = "INSERT INTO personal (id, nombre, apellido_p, apellido_m, edad, fec_nac, direccion, telefono, colonia, correo, fec_ing, sueldo, usuario, contrasena) Values(?id,?nombre,?apellido_p,?apellido_m,?edad,?fec_nac,?direccion,?telefono,?colonia,?correo,?fec_ing,?sueldo,?usuario,?contrasena)";
                    MySqlCommand myCommand = new MySqlCommand(myInsertQuery);

                    myCommand.Parameters.Add("?id", MySqlDbType.Int16, 100).Value = textid.Text;
                    myCommand.Parameters.Add("?nombre", MySqlDbType.VarChar, 50).Value = textnom.Text;
                    myCommand.Parameters.Add("?apellido_p", MySqlDbType.VarChar, 30).Value = textpat.Text;
                    myCommand.Parameters.Add("?apellido_m", MySqlDbType.VarChar, 30).Value = textmat.Text;
                    myCommand.Parameters.Add("?edad", MySqlDbType.Int16, 100).Value = textedad.Text;
                    myCommand.Parameters.Add("?fec_nac", MySqlDbType.Date, 8).Value = dtpDate;
                    myCommand.Parameters.Add("?direccion", MySqlDbType.VarChar, 60).Value = textdir.Text;
                    myCommand.Parameters.Add("?telefono", MySqlDbType.VarChar, 20).Value = texttel.Text;
                    myCommand.Parameters.Add("?colonia", MySqlDbType.VarChar, 50).Value = textcol.Text;
                    myCommand.Parameters.Add("?correo", MySqlDbType.VarChar, 30).Value = textcorr.Text;
                    myCommand.Parameters.Add("?fec_ing", MySqlDbType.Date, 8).Value = dtpDate2;
                    myCommand.Parameters.Add("?sueldo", MySqlDbType.Decimal, 10).Value = textsuel.Text;
                    myCommand.Parameters.Add("?usuario", MySqlDbType.VarChar, 30).Value = textusu.Text;
                    myCommand.Parameters.Add("?contrasena", MySqlDbType.VarChar, 30).Value = textcontra.Text;
                    myCommand.Connection = myConnection;
                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                    myCommand.Connection.Close();
                    MessageBox.Show("PERSONAL AGREGADO A LA BASE DE DATOS CORRECTAMENTE", "**********GAMERS*************", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textid.Text = "";
                    textnom.Text = "";
                    textpat.Text = "";
                    textmat.Text = "";
                    textedad.Text = "";

                    textdir.Text = "";
                    texttel.Text = "";
                    textcol.Text = "";
                    textcorr.Text = "";

                    textsuel.Text = "";
                    textusu.Text = "";
                    textcontra.Text = "";

                    string cad = "Server=localhost;User ID= root;Database = proyecto";
                    string query = "select * from personal";
                    MySqlConnection cnn = new MySqlConnection(cad);
                    MySqlDataAdapter da = new MySqlDataAdapter(query, cnn);
                    System.Data.DataSet ds = new System.Data.DataSet();
                    da.Fill(ds, "personal");
                    dataGridView1.DataSource = ds;
                    dataGridView1.DataMember = "personal";
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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            textid.Text = "";
            textnom.Text = "";
            textpat.Text = "";
            textmat.Text = "";
            textedad.Text = "";

            textdir.Text = "";
            texttel.Text = "";
            textcol.Text = "";
            textcorr.Text = "";

            textsuel.Text = "";
            textusu.Text = "";
            textcontra.Text = "";
            MessageBox.Show("ACTUALIZANDO DATOS", "**************GAMERS*****************", MessageBoxButtons.OK, MessageBoxIcon.None);
            cargarDatos();
        }

        private void textnac_TextChanged(object sender, EventArgs e)
        {




        }




        private void texting_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (textid.Text == "")
            { MessageBox.Show("favor de solo introducir el ID de cliente para eliminarlo"); }
            else
            {

                DialogResult result = MessageBox.Show("DESEA ELIMINARL AL CLIENTE ??", "*********GAMERS***********", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        string myConnectionString = "";


                        if (myConnectionString == "") { myConnectionString = "Server=localhost;User ID= root;Database = proyecto"; }

                        try
                        {
                            MySqlConnection myConnection = new MySqlConnection(myConnectionString);

                            DateTime dtpDate = fechaNac.Value.Date;
                            DateTime dtpDate2 = fechaIngreso.Value.Date;

                            string myInsertQuery = "DELETE FROM personal Where id=" + textid.Text + ""; MySqlCommand myCommand = new MySqlCommand(myInsertQuery);
                            myCommand.Connection = myConnection;
                            myConnection.Open();
                            myCommand.ExecuteNonQuery();
                            myCommand.Connection.Close();

                            MessageBox.Show("CLIENTE ELIMINADO", "***********GAMERS***********", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            textnom.Text = "";
                            string cad = "Server=localhost;User ID= root;Database = proyecto";
                            string query = "select * from personal";
                            MySqlConnection cnn = new MySqlConnection(cad);
                            MySqlDataAdapter da = new MySqlDataAdapter(query, cnn);
                            System.Data.DataSet ds = new System.Data.DataSet();
                            da.Fill(ds, "personal");
                            dataGridView1.DataSource = ds;
                            dataGridView1.DataMember = "personal";

                        }
                        catch (MySqlException)
                        {
                            // MessageBox.Show("favor de solo introducir el ID de cliente para eliminarlo");
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

        private void button5_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Visible = true;
            this.Visible = false;
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

                DialogResult result = MessageBox.Show("DESEA MODIFICAR AL USUARIO ??", "*********GAMERS***********", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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

                        DateTime dtpDate = fechaNac.Value.Date;
                        DateTime dtpDate2 = fechaIngreso.Value.Date;

                        string myInsertQuery = "UPDATE personal SET nombre = ?, apellido_p =?, apellido_m =?, edad =?, fec_nac=?, direccion =?, telefono =?, correo =?, fec_ing =?, sueldo=?, usuario=?, contrasena=? Where id=" + textid.Text + "";
                        MySqlCommand myCommand = new MySqlCommand(myInsertQuery);
                        myCommand.Parameters.Add("?nombre", MySqlDbType.VarChar, 50).Value = textnom.Text;
                        myCommand.Parameters.Add("?apellido_p", MySqlDbType.VarChar, 30).Value = textpat.Text;
                        myCommand.Parameters.Add("?apellido_m", MySqlDbType.VarChar, 30).Value = textmat.Text;
                        myCommand.Parameters.Add("?edad", MySqlDbType.Int16, 100).Value = textedad.Text;
                        myCommand.Parameters.Add("?fec_nac", MySqlDbType.Date, 8).Value = dtpDate;
                        myCommand.Parameters.Add("?direccion", MySqlDbType.VarChar, 60).Value = textdir.Text;
                        myCommand.Parameters.Add("?telefono", MySqlDbType.VarChar, 20).Value = texttel.Text;
                        myCommand.Parameters.Add("?colonia", MySqlDbType.VarChar, 50).Value = textcol.Text;
                        myCommand.Parameters.Add("?correo", MySqlDbType.VarChar, 30).Value = textcorr.Text;
                        myCommand.Parameters.Add("?fec_ing", MySqlDbType.Date, 8).Value = dtpDate2;
                        myCommand.Parameters.Add("?sueldo", MySqlDbType.Decimal, 10).Value = textsuel.Text;
                        myCommand.Parameters.Add("?usuario", MySqlDbType.VarChar, 30).Value = textusu.Text;
                        myCommand.Parameters.Add("?contrasena", MySqlDbType.VarChar, 30).Value = textcontra.Text;
                        myCommand.Connection = myConnection;
                        myConnection.Open();
                        myCommand.ExecuteNonQuery();
                        myCommand.Connection.Close();

                        MessageBox.Show("USUARIO MODIFICADO", "***********GAMERS***********", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        textid.Text = "";
                        textnom.Text = "";
                        textpat.Text = "";
                        textmat.Text = "";
                        textedad.Text = "";

                        textdir.Text = "";
                        texttel.Text = "";
                        textcol.Text = "";
                        textcorr.Text = "";

                        textsuel.Text = "";
                        textusu.Text = "";
                        textcontra.Text = "";

                        string cad = "Server=localhost;User ID= root;Database = proyecto";
                        string query = "select * from personal";
                        MySqlConnection cnn = new MySqlConnection(cad);
                        MySqlDataAdapter da = new MySqlDataAdapter(query, cnn);
                        System.Data.DataSet ds = new System.Data.DataSet();
                        da.Fill(ds, "personal");
                        dataGridView1.DataSource = ds;
                        dataGridView1.DataMember = "personal";
                    }

                    catch (System.Exception)
                    {

                        MessageBox.Show("EXISTEN CAMPOS VACIOS FAVOR DE LLENAR TODOS LOS CAMPOS PARA MODIFICAR","**************************GAMERS***********************",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                    }

                }
            }
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


                string mySelectQuery = "SELECT * From personal Where id=" + textid.Text + "";
                MySqlCommand myCommand = new MySqlCommand(mySelectQuery, myConnection);
                myConnection.Open();
                MySqlDataReader myReader;
                myReader = myCommand.ExecuteReader();
                // Always call Read before accessing data.
                if (myReader.Read())
                {
                    MessageBox.Show("MOSTRANDO DATOS", "*************GAMERS****************", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    textnom.Text = (myReader.GetString(1));
                    textpat.Text = (myReader.GetString(2));
                    textmat.Text = (myReader.GetString(3));
                    textedad.Text = (myReader.GetString(4));
                    fechaNac.Text = (myReader.GetString(5));
                    textdir.Text = (myReader.GetString(6));
                    texttel.Text = (myReader.GetString(7));
                    textcol.Text = (myReader.GetString(8));
                    textcorr.Text = (myReader.GetString(9));
                    fechaIngreso.Text = (myReader.GetString(10));
                    textsuel.Text = (myReader.GetString(11));
                    textusu.Text = (myReader.GetString(12));
                    textcontra.Text = (myReader.GetString(13));

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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Personal_Load(object sender, EventArgs e)
        {

            cargarDatos();
        }

        private void cargarDatos()
        {

            string config = "Server=localhost;User ID= root;Database = proyecto";
            string query = String.Format("SELECT * FROM {0}", "personal");

            MySqlConnection conexion = new MySqlConnection(config);
            conexion.Open();

            MySqlCommand comando = new MySqlCommand(query, conexion);

            MySqlDataAdapter adapter = new MySqlDataAdapter(comando);


            DataTable data = new DataTable();
            adapter.Fill(data);
            dataGridView1.DataSource = data;
        }
    }
   
    
}
