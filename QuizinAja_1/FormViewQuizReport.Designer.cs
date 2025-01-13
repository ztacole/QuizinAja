namespace QuizinAja_1
{
    partial class FormViewQuizReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbQuiz = new System.Windows.Forms.ComboBox();
            this.lblAvgTime = new System.Windows.Forms.Label();
            this.lblTotalParticipant = new System.Windows.Forms.Label();
            this.lblAvgPercent = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "View Quiz Report";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Quiz";
            // 
            // cbQuiz
            // 
            this.cbQuiz.FormattingEnabled = true;
            this.cbQuiz.Location = new System.Drawing.Point(48, 62);
            this.cbQuiz.Name = "cbQuiz";
            this.cbQuiz.Size = new System.Drawing.Size(209, 21);
            this.cbQuiz.TabIndex = 4;
            this.cbQuiz.SelectedIndexChanged += new System.EventHandler(this.cbQuiz_SelectedIndexChanged);
            // 
            // lblAvgTime
            // 
            this.lblAvgTime.AutoSize = true;
            this.lblAvgTime.Location = new System.Drawing.Point(334, 65);
            this.lblAvgTime.Name = "lblAvgTime";
            this.lblAvgTime.Size = new System.Drawing.Size(113, 13);
            this.lblAvgTime.TabIndex = 5;
            this.lblAvgTime.Text = "Average Time Taken :";
            // 
            // lblTotalParticipant
            // 
            this.lblTotalParticipant.AutoSize = true;
            this.lblTotalParticipant.Location = new System.Drawing.Point(334, 117);
            this.lblTotalParticipant.Name = "lblTotalParticipant";
            this.lblTotalParticipant.Size = new System.Drawing.Size(90, 13);
            this.lblTotalParticipant.TabIndex = 6;
            this.lblTotalParticipant.Text = "Total Participant :";
            // 
            // lblAvgPercent
            // 
            this.lblAvgPercent.AutoSize = true;
            this.lblAvgPercent.Location = new System.Drawing.Point(334, 90);
            this.lblAvgPercent.Name = "lblAvgPercent";
            this.lblAvgPercent.Size = new System.Drawing.Size(157, 13);
            this.lblAvgPercent.TabIndex = 7;
            this.lblAvgPercent.Text = "Average Correcct Percentage  :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(17, 141);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(748, 404);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detail Data";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dataGridView1.Location = new System.Drawing.Point(12, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(736, 379);
            this.dataGridView1.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Participant Nickname";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Time Taken";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Correct Percentage";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // FormViewQuizReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 557);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblAvgPercent);
            this.Controls.Add(this.lblTotalParticipant);
            this.Controls.Add(this.lblAvgTime);
            this.Controls.Add(this.cbQuiz);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormViewQuizReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormViewQuizReport";
            this.Load += new System.EventHandler(this.FormViewQuizReport_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbQuiz;
        private System.Windows.Forms.Label lblAvgTime;
        private System.Windows.Forms.Label lblTotalParticipant;
        private System.Windows.Forms.Label lblAvgPercent;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}