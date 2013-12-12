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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Ingreso ingreso = new Ingreso();
            ingreso.Visible = true;
            this.Visible = false;

        }

        private void Menu_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clientes clientes = new Clientes();
            clientes.Visible = true;
            this.Visible = false;


        }

        private void button4_Click(object sender, EventArgs e)
        {
            Personal personal = new Personal();
            personal.Visible = true;
            this.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Provedores provedor = new Provedores();
            provedor.Visible= true;
            this.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Movimientos movis = new Movimientos();
            movis.Visible = true;
            this.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Videojuego video = new Videojuego();
            video.Visible = true;
            this.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Registro regis = new Registro();
            regis.Visible = true;
            this.Visible = false;

        }
    }
}
