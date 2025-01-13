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
    public partial class FormCreateAccount : Form
    {
        DBEntities db =     new DBEntities();
        public FormCreateAccount()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Dispose();
            new FormLogin().ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Method.CheckEmptyField(this)) MessageBox.Show("All field must be filled!");
            else if (db.Users.Any(s => s.Username == tbUsername.Text)) MessageBox.Show("Username must be unique!");
            else if (tbPass.Text.Length < 4) MessageBox.Show("Password should have minimal four characters!");
            else if (tbRePass.Text != tbPass.Text) MessageBox.Show("Retype your Password!");
            else
            {
                var newUser = new User
                {
                    Username = tbUsername.Text,
                    FullName = tbName.Text,
                    Password = tbPass.Text,
                    DateOfBirth = dateTimePicker1.Value.Date,
                };
                db.Users.Add(newUser);
                db.SaveChanges();
                Method.user = db.Users.OrderByDescending(u => u.ID).FirstOrDefault();
                this.Dispose();
                new FormUserMain().ShowDialog();
            }
        }
    }
}
