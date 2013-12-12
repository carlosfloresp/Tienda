using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;

namespace BaseDeDatos
{
    public partial class correo : Form
    {
        public correo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MailMessage men = new MailMessage(textBox1.Text, textBox2.Text, textBox6.Text, textBox7.Text);
            SmtpClient sm = new SmtpClient(textBox3.Text);
            sm.Port = 587;
            sm.Credentials = new System.Net.NetworkCredential(textBox4.Text, textBox5.Text);
            sm.EnableSsl = true;
            sm.Send(men);
            MessageBox.Show("Mensaje enviado", "Correctamente", MessageBoxButtons.OK);
        }
    }
}
