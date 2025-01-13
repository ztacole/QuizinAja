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
    public partial class FormViewQuizReport : Form
    {
        DBEntities db = new DBEntities();
        public FormViewQuizReport()
        {
            InitializeComponent();
        }

        private void FormViewQuizReport_Load(object sender, EventArgs e)
        {
            cbQuiz.DataSource = db.Quizs.Where(s=>s.UserID == Method.user.ID).Select(s=>s.Name).ToList();
            fillTable();
        }
        private void fillTable()
        {
            try
            {
                dataGridView1.Rows.Clear();
                var data = db.Participants.Where(s => s.Quiz.Name == cbQuiz.SelectedItem.ToString()).ToList();
                double avgTime = 0, avgPercentageParticiants = 0, totalParticipant = data.Count();
                foreach (var i in data)
                {
                    var correctAnswers = db.ParticipantAnswers.Where(s => s.ParticipantID == i.ID && s.Answer == s.Question.CorrectAnswer).Select(s => s.Answer).Count();
                    var totalQuestion = db.Questions.Where(s => s.Quiz.Name == cbQuiz.Text).Select(s => s.Question1).Count();
                    double percentage = (double)correctAnswers / totalQuestion * 100;
                    TimeSpan time = TimeSpan.FromSeconds(i.TimeTaken);
                    dataGridView1.Rows.Add(i.ParticipantNickname, time.ToString(@"hh\:mm\:ss"), percentage + "%");
                    avgTime += i.TimeTaken;
                    avgPercentageParticiants += percentage;
                }
                lblAvgTime.Text = $"Average Time Taken : {TimeSpan.FromSeconds(avgTime / totalParticipant)}";
                lblAvgPercent.Text = $"Average Correcct Percentage  : {avgPercentageParticiants / totalParticipant}%";
                lblTotalParticipant.Text = $"Total Participant : {totalParticipant} Participant(s)";
            }
            catch
            {
                MessageBox.Show("This quiz report is empty");
                lblAvgTime.Text = $"Average Time Taken : 00:00:00";
                lblAvgPercent.Text = $"Average Correcct Percentage  : 0%";
                lblTotalParticipant.Text = $"Total Participant : 0 Participant";
            }
        }

        private void cbQuiz_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillTable();
        }
    }
}
