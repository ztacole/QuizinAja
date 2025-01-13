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
    public partial class QuizForm : Form
    {
        TimeSpan elapsedTime;
        string nickname;
        private Quiz Quiz;
        DBEntities db =     new DBEntities();
        int Index;
        public class Answer
        {
            public Question question { get; set; }
            public string answer {  get; set; }
            public int index { get; set; }
        }
        List<Answer> quizList = new List<Answer>();
        public QuizForm(Quiz quiz, string nickname)
        {
            InitializeComponent();
            this.nickname = nickname;
            lblNickname.Text = nickname.ToString();
            Quiz = quiz;
        }

        private void QuizForm_Load(object sender, EventArgs e)
        {
            timer();
            ListNumber();
            LoadSoal();
        }
        private void ListNumber()
        {
            flowLayoutPanel1.Controls.Clear();
            for (int i = 1; i <= Quiz.Questions.Count; i++)
            {
                Button b = new Button();
                b.Text = i.ToString();
                b.Size = new System.Drawing.Size(47, 47);
                b.Click += btnClick;
                flowLayoutPanel1.Controls.Add(b);
            }
        }
         private void btnClick(object sender, EventArgs e)
        {
            Button b = sender as Button;
            if (rbA.Checked) quizList.Where(s => s.question.Question1 == lblQuestion.Text).First().answer = rbA.Text;
            else if (rbB.Checked) quizList.Where(s => s.question.Question1 == lblQuestion.Text).First().answer = rbB.Text;
            else if (rbC.Checked) quizList.Where(s => s.question.Question1 == lblQuestion.Text).First().answer = rbC.Text;
            else if (rbD.Checked) quizList.Where(s => s.question.Question1 == lblQuestion.Text).First().answer = rbD.Text;
            else quizList.Where(s => s.question.Question1 == lblQuestion.Text).First().answer = "";
            Method.ClearAllField(panel1);
            setSoal(quizList[Convert.ToInt32(b.Text)-1].question);

        }
        public void setSoal(Question q )
        {
            lblQuestion.Text = q.Question1;
            rbA.Text = q.OptionA;
            rbB.Text = q.OptionB;
            rbC.Text = q.OptionC;
            rbD.Text = q.OptionD;
            var question = quizList.Where(s=>s.question.Question1 == q.Question1).FirstOrDefault();

            if (question.answer == rbA.Text) rbA.Checked = true;
            else if (question.answer == rbB.Text) rbB.Checked = true;
            else if (question.answer == rbC.Text) rbC.Checked = true;
            else if (question.answer == rbD.Text) rbD.Checked = true; 

            foreach (Button i in flowLayoutPanel1.Controls.OfType<Button>())
            {
                if (quizList[Convert.ToInt32(i.Text) - 1].answer != "") i.BackColor = Color.Green;
                else i.BackColor = Color.LightGray;
            }

            if (quizList[4].question.Question1 == lblQuestion.Text) btnNext.Text = "Finish";
            else btnNext.Text = "Next";

            if (quizList[0].question.Question1 == lblQuestion.Text) btnPrev.Visible = false;
            else btnPrev.Visible = true;
        }
        public void LoadSoal()
        {
            var question = db.Questions.Where(s => s.QuizID == Quiz.ID).ToList();

            int ind = 0;
            foreach (var i in question)
            {
                quizList.Add(new Answer
                {
                    question = i,
                    answer = "",
                    index = ind
                });
                ind++;
            }
            setSoal(quizList[0].question);
        }

        private void timer()
        {
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            timer1.Start();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            elapsedTime = elapsedTime.Add(TimeSpan.FromSeconds(0.5));
            lblTime.Text = elapsedTime.ToString(@"hh\:mm\:ss");
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (rbA.Checked) quizList.Where(s => s.question.Question1 == lblQuestion.Text).First().answer = rbA.Text;
            else if (rbB.Checked) quizList.Where(s => s.question.Question1 == lblQuestion.Text).First().answer = rbB.Text;
            else if (rbC.Checked) quizList.Where(s => s.question.Question1 == lblQuestion.Text).First().answer = rbC.Text;
            else if (rbD.Checked) quizList.Where(s => s.question.Question1 == lblQuestion.Text).First().answer = rbD.Text;
            else quizList.Where(s => s.question.Question1 == lblQuestion.Text).First().answer = "";

            if (btnNext.Text == "Next")
            {
                Index = quizList.Where(s => s.question.Question1 == lblQuestion.Text).Select(s => s.index).First();
                Method.ClearAllField(panel1);
                setSoal(quizList[Index + 1].question);
            }
            else
            {
                foreach (var i in quizList)
                {
                    if (i.answer == "")
                    {
                        MessageBox.Show("All the question isn't answered completely!"); 
                        return;
                    }
                }
                TimeSpan timeElapsed = TimeSpan.ParseExact(lblTime.Text, "hh\\:mm\\:ss", null);
                int timeTaken = (int) timeElapsed.TotalSeconds;
                var newParticipant = new Participant
                {
                    QuizID = Quiz.ID,
                    ParticipantNickname = nickname,
                    ParticipationDate = DateTime.Now,
                    TimeTaken = timeTaken,
                };
                db.Participants.Add(newParticipant);
                db.SaveChanges();
                Index = 0;
                foreach (var i in quizList)
                {
                    var questID = db.Questions.First(s => s.Question1.Contains(i.question.Question1) && s.QuizID == Quiz.ID).ID;
                    var newAnswer = new ParticipantAnswer
                    {
                        ParticipantID = db.Participants.OrderByDescending(s=>s.ID).FirstOrDefault().ID,
                        QuestionID = questID,
                        Answer = i.answer
                    };
                    db.ParticipantAnswers.Add(newAnswer);
                    db.SaveChanges();
                    Index++;
                }
                MessageBox.Show("Your Answer has been saved");
                this.Hide();
                new FormLogin().Show();
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (rbA.Checked) quizList.Where(s => s.question.Question1 == lblQuestion.Text).First().answer = rbA.Text;
            else if (rbB.Checked) quizList.Where(s => s.question.Question1 == lblQuestion.Text).First().answer = rbB.Text;
            else if (rbC.Checked) quizList.Where(s => s.question.Question1 == lblQuestion.Text).First().answer = rbC.Text;
            else if (rbD.Checked) quizList.Where(s => s.question.Question1 == lblQuestion.Text).First().answer = rbD.Text;
            else quizList.Where(s => s.question.Question1 == lblQuestion.Text).First().answer = "";
            Index = quizList.Where(s => s.question.Question1 == lblQuestion.Text).Select(s => s.index).First();
            Method.ClearAllField(panel1);
            setSoal(quizList[Index - 1].question);
        }
    }
}
