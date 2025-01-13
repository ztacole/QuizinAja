using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizinAja_1
{
    public partial class FormLogin : Form
    {
        DBEntities db = new DBEntities();
        public FormLogin()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tbUsername.Text = "mahdi";
            tbPass.Text = "1234";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var login = db.Users.FirstOrDefault(s => s.Username == tbUsername.Text);
                if (login.Password == tbPass.Text)
                {
                    Method.user = login;
                    new FormUserMain().ShowDialog();
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Wrong Username and Password!");
                }
            }
            catch
            {
                MessageBox.Show("Wrong Username and Password!");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) tbPass.UseSystemPasswordChar = false;
            else tbPass.UseSystemPasswordChar = true;

        }

        private void lblRegist_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new FormCreateAccount().ShowDialog();
        }

        private void labelGuest_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new FormQuizCode().ShowDialog();
        }
    }
}
