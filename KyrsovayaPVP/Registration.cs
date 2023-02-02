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
    public partial class Registration : Form
    {
        Database data = new Database();
        public Registration()
        {
            InitializeComponent();
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox.Checked == true)
            {
                textBoxPassword.UseSystemPasswordChar = false;
                textBoxPassword2.UseSystemPasswordChar = false;
            }
            if (checkBox.Checked == false)
            {
                textBoxPassword.UseSystemPasswordChar = true;
                textBoxPassword2.UseSystemPasswordChar = true;
            }
        }

        private void buttonreg_Click(object sender, EventArgs e)
        {
            User US = new User(textBoxLogin.Text, textBoxPassword.Text, textBoxPassword2.Text);
            if (US.Correct() == true)
            {
                if (data.CheckCorrect(textBoxLogin.Text) == false)
                {
                    data.CreateUser(textBoxLogin.Text, textBoxPassword.Text);
                    MessageBox.Show("Регистрация прошла успешно");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Пользователь с таким именем уже существует");
                }
            }
        }

        private void buttoncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
