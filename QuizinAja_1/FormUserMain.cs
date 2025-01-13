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
    public partial class FormUserMain : Form
    {
        DBEntities db = new DBEntities();
        public FormUserMain()
        {
            InitializeComponent();
        }

        private void FormUserMain_Load(object sender, EventArgs e)
        {
            lblName.Text = Method.user.FullName;
            fillTable();
        }
        public void fillTable()
        {
            dataGridView1.Rows.Clear();
            var data = db.Quizs.Where(s=>s.UserID == Method.user.ID).ToList();
            foreach (var i in data)
            {
                var numOfQuestion = db.Questions.Count(s=>s.QuizID == i.ID);
                dataGridView1.Rows.Add(i.ID,i.Name, i.Code, i.Description, numOfQuestion);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            new FormAddQuiz(this).ShowDialog();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            new FormViewQuizReport().ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Dispose();
            new FormLogin().ShowDialog();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var QuizID = (int)dataGridView1.Rows[e.RowIndex].Cells[0].Value;
            var Quiz = db.Quizs.First(s => s.ID == QuizID);
            if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "")
            {
                if (MessageBox.Show("Are you sure want to delete this record?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var Question = db.Questions.First(s => s.QuizID == QuizID);
                    db.Quizs.Remove(Quiz);
                    db.Questions.Remove(Question);
                    db.SaveChanges();
                    fillTable();
                }
            }
        }
    }
}
