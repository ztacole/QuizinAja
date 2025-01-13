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
    public partial class FormQuizCode : Form
    {
        DBEntities db = new DBEntities();
        public FormQuizCode()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Method.CheckEmptyField(this)) MessageBox.Show("All field must be filled!");
            else
            {
                try
                {
                    var Quiz = db.Quizs.First(s => s.Code == tbCode.Text);
                    new QuizForm(Quiz, tbNickname.Text).Show();
                }
                catch
                {
                    MessageBox.Show("Code not Found");
                }
            }
        }

        private void tbCode_TextChanged(object sender, EventArgs e)
        {
            int cursorPosition = tbCode.SelectionStart;

            tbCode.Text = tbCode.Text.ToUpper();

            tbCode.SelectionStart = cursorPosition;
        }
    }
}
