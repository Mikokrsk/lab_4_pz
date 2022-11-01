using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_3
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(check_user(login.Text,password.Text))
            {
                var form = new Form2();
                form.Show(this);
            }
            else
            {
                MessageBox.Show("Не правильний логін , або пароль");
            }
        }
        public bool check_user(string login,string password )
        {
            string login_machine = "login";
            string password_machine = "password";
            if (login == login_machine && password == password_machine)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



    }
}
