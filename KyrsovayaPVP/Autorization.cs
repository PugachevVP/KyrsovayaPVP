using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KyrsovayaPVP
{
    public partial class Autorization : Form
    {
        Database data = new Database();
        public Autorization()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox.Checked == true)
            {
                textBoxPassword.UseSystemPasswordChar = false;
            }
            if (checkBox.Checked == false)
            {
                textBoxPassword.UseSystemPasswordChar = true;
            }
        }

        private void buttonexit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonreg_Click(object sender, EventArgs e)
        {
            Registration registration = new Registration();
            registration.ShowDialog();
        }

        private void buttongo_Click(object sender, EventArgs e)
        {
            User US = new User(textBoxLogin.Text, textBoxPassword.Text);
            if (US.Correct() == true)
            {
                if (data.CheckUser(textBoxLogin.Text, textBoxPassword.Text))
                {
                    this.Hide();
                    FormProgram formprogram = new FormProgram();
                    formprogram.Closed += (s, args) => this.Close();
                    formprogram.Show();
                }
                else
                {
                    MessageBox.Show("Проверьте правильность ввода данных.");
                }
            }
        }
    }
}
