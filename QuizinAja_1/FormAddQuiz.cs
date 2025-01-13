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
    public partial class FormAddQuiz : Form
    {
        DBEntities db = new DBEntities();
        FormUserMain Main;
        public FormAddQuiz(FormUserMain f)
        {
            InitializeComponent();
            Main = f;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!Method.CheckEmptyField(groupBox1)) MessageBox.Show("All field must be filled!");
            else if (!rbA.Checked && !rbB.Checked && !rbC.Checked && !rbD.Checked) MessageBox.Show("Choose the correct answer for this question!");
            else
            {
                string CorrectAnswer;
                if (rbA.Checked) CorrectAnswer = tbA.Text;
                else if (rbB.Checked) CorrectAnswer = tbB.Text;
                else if (rbC.Checked) CorrectAnswer = tbC.Text;
                else CorrectAnswer = tbD.Text;
                dataGridView1.Rows.Add(dataGridView1.RowCount + 1, tbQuestion.Text, tbA.Text, tbB.Text, tbC.Text, tbD.Text, CorrectAnswer );
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!Method.CheckEmptyField(this)) MessageBox.Show("All field must be filled!");
            else if (dataGridView1.Rows.Count == 0) MessageBox.Show("Add minimal 1 question!");
            else if (!Method.ValidateCode(tbCode.Text)) MessageBox.Show("The quiz code must be a combination of only uppercase character and number!");
            else if (db.Quizs.Any(s => s.Code == tbCode.Text)) MessageBox.Show("The Quiz Code already registered in Database. Please change your Quiz Code!");
            else
            {
                var newQuiz = new Quiz
                {
                    Name = tbName.Text,
                    Code = tbCode.Text,
                    Description = tbDesc.Text,
                    UserID = Method.user.ID,
                    CreatedAt = DateTime.Now
                };
                db.Quizs.Add(newQuiz);
                db.SaveChanges();
                var IDQuiz = db.Quizs.OrderByDescending(x => x.ID).First();
                foreach (DataGridViewRow i in dataGridView1.Rows)
                {
                    var question = i.Cells[1].Value.ToString();
                    var optionA = i.Cells[2].Value.ToString();
                    var optionB = i.Cells[3].Value.ToString();
                    var optionC = i.Cells[4].Value.ToString();
                    var optionD = i.Cells[5].Value.ToString();
                    var correctAnswer = i.Cells[6].Value.ToString();
                    var QuizQuestion = new Question
                    {
                        QuizID = IDQuiz.ID,
                        Question1 = question,
                        OptionA = optionA,
                        OptionB = optionB,
                        OptionC = optionC,
                        OptionD = optionD,
                        CorrectAnswer = correctAnswer
                    };
                    db.Questions.Add(QuizQuestion);
                    db.SaveChanges();
                }
                MessageBox.Show("Quiz have been saved.");
                this.Dispose();
                Main.fillTable();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                if (MessageBox.Show("Are you sure want to delete this record?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    dataGridView1.Rows.RemoveAt(e.RowIndex);
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        dataGridView1.Rows[i].Cells[0].Value = i + 1;
                    }
                }
            }
        }
    }
}
