using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BaseDeDatos
{
    public partial class Ingreso : Form
    {

        string usuario = "";
        string password = "";

        public Ingreso()
        {
            InitializeComponent();
        }

        private void usuBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void passBox2_TextChanged(object sender, EventArgs e)
        {

        }


        private void iniciar_Click(object sender, EventArgs e)
        {
            //Boton Iniciar Sesión
            //Validar Usuario y Password
            if (usuario == usuBox.Text)
            {
                if (password == passBox.Text)
                {
                    MessageBox.Show("El usuario y password son correctos!!", " OK Acesso");
                    usuBox.Enabled = false;
                    passBox.Enabled = false;
                    iniciar.Enabled = false;

                    //Inicia Menu 
                    Menu menu = new Menu();
                        menu.Visible = true;
                        this.Visible = false;
                   /* Logo logo = new Logo();
                    if (logo.ShowDialog() == DialogResult.OK)
                    {
                        
                    }*/
                    
                   
                   
                       
                    
                    
                }
                else
                {
                    MessageBox.Show("el password es incorrecto", "No acceso");
                    passBox.Clear();
                    passBox.Focus();
                }
            }
            else
            {
                MessageBox.Show("El usuario es incorrecto", "No acceso");
                usuBox.Clear();
                usuBox.Focus();

            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Close();

        }

        private void Ingreso_Load(object sender, EventArgs e)
        {

        }
    }
}
