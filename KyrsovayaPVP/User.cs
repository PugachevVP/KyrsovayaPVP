using System.Windows.Forms;

namespace KyrsovayaPVP
{
    class User
    {
        private string login;
        private string password;
        private string password_2;
        public User(string login, string password, string password_2 = null)
        {
            this.login = login;
            this.password = password;
            this.password_2 = password_2;
        }

        public bool Correct()
        {
            if (login.Trim() == "")
            {
                MessageBox.Show("Поле ввода логина пустое.");
                return false;
            }
            if (login.Trim() != login)
            {
                MessageBox.Show("Логин не должен содержать пробелов.");
                return false;
            }
            if (login.Length < 5)
            {
                MessageBox.Show("Логин должен иметь длину от пяти символов");
                return false;
            }
            if (password == "")
            {
                MessageBox.Show("Поле ввода пароля пустое.");
                return false;
            }
            if (password.Trim() != password)
            {
                MessageBox.Show("Пароль не должен содержать пробелов.");
                return false;
            }
            if (password.Length < 5)
            {
                MessageBox.Show("Пароль должен иметь длину от пяти символов.");
                return false;
            }
            if (password != password_2 && password_2 != null)
            {
                MessageBox.Show("Повторите пароль корректно.");
                return false;
            }
            return true;
        }
    }
}
