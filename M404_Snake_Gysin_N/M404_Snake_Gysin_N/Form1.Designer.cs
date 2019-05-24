//INF2018.d, Noah Gysin, 22.05.2019

namespace M404_Snake_Gysin_N
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnl_game = new System.Windows.Forms.Panel();
            this.btn_start = new System.Windows.Forms.Button();
            this.btn_reset = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pnl_points = new System.Windows.Forms.Panel();
            this.btn_addPoints = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.txt_score = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pnl_game
            // 
            this.pnl_game.BackColor = System.Drawing.Color.White;
            this.pnl_game.Location = new System.Drawing.Point(17, 13);
            this.pnl_game.Margin = new System.Windows.Forms.Padding(4);
            this.pnl_game.Name = "pnl_game";
            this.pnl_game.Size = new System.Drawing.Size(767, 600);
            this.pnl_game.TabIndex = 1;
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(17, 634);
            this.btn_start.Margin = new System.Windows.Forms.Padding(4);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(169, 57);
            this.btn_start.TabIndex = 2;
            this.btn_start.Text = "Start";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // btn_reset
            // 
            this.btn_reset.Location = new System.Drawing.Point(231, 634);
            this.btn_reset.Margin = new System.Windows.Forms.Padding(4);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(169, 57);
            this.btn_reset.TabIndex = 3;
            this.btn_reset.Text = "Reset";
            this.btn_reset.UseVisualStyleBackColor = true;
            this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(816, 16);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Punkte:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(816, 53);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Punkteliste:";
            // 
            // pnl_points
            // 
            this.pnl_points.BackColor = System.Drawing.Color.White;
            this.pnl_points.Location = new System.Drawing.Point(819, 74);
            this.pnl_points.Margin = new System.Windows.Forms.Padding(4);
            this.pnl_points.Name = "pnl_points";
            this.pnl_points.Size = new System.Drawing.Size(160, 539);
            this.pnl_points.TabIndex = 7;
            // 
            // btn_addPoints
            // 
            this.btn_addPoints.Location = new System.Drawing.Point(819, 634);
            this.btn_addPoints.Margin = new System.Windows.Forms.Padding(4);
            this.btn_addPoints.Name = "btn_addPoints";
            this.btn_addPoints.Size = new System.Drawing.Size(160, 57);
            this.btn_addPoints.TabIndex = 8;
            this.btn_addPoints.Text = "Punkte in Liste eintragen";
            this.btn_addPoints.UseVisualStyleBackColor = true;
            this.btn_addPoints.Click += new System.EventHandler(this.btn_addPoints_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // txt_score
            // 
            this.txt_score.AutoSize = true;
            this.txt_score.Location = new System.Drawing.Point(879, 16);
            this.txt_score.Name = "txt_score";
            this.txt_score.Size = new System.Drawing.Size(16, 17);
            this.txt_score.TabIndex = 9;
            this.txt_score.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 704);
            this.Controls.Add(this.txt_score);
            this.Controls.Add(this.btn_addPoints);
            this.Controls.Add(this.pnl_points);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_reset);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.pnl_game);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Snake - friss den Apfel";
            this.Activated += new System.EventHandler(this.timer1_Tick);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pnl_game;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Button btn_reset;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnl_points;
        private System.Windows.Forms.Button btn_addPoints;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label txt_score;
    }
}

