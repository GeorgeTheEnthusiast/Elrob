namespace Elrob.Terminal.View.Implementations.Choose
{
    partial class LogInMethodChooseView
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
            this.buttonLoginAndPassword = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCard = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonLoginAndPassword
            // 
            this.buttonLoginAndPassword.Location = new System.Drawing.Point(17, 96);
            this.buttonLoginAndPassword.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.buttonLoginAndPassword.Name = "buttonLoginAndPassword";
            this.buttonLoginAndPassword.Size = new System.Drawing.Size(244, 97);
            this.buttonLoginAndPassword.TabIndex = 0;
            this.buttonLoginAndPassword.Text = "Login/Hasło";
            this.buttonLoginAndPassword.UseVisualStyleBackColor = true;
            this.buttonLoginAndPassword.Click += new System.EventHandler(this.buttonLoginAndPassword_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(159, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(346, 31);
            this.label1.TabIndex = 5;
            this.label1.Text = "Wybierz metodę logowania:";
            // 
            // buttonCard
            // 
            this.buttonCard.Location = new System.Drawing.Point(380, 96);
            this.buttonCard.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.buttonCard.Name = "buttonCard";
            this.buttonCard.Size = new System.Drawing.Size(254, 97);
            this.buttonCard.TabIndex = 1;
            this.buttonCard.Text = "Karta";
            this.buttonCard.UseVisualStyleBackColor = true;
            this.buttonCard.Click += new System.EventHandler(this.buttonCard_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(197, 229);
            this.buttonExit.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(244, 97);
            this.buttonExit.TabIndex = 2;
            this.buttonExit.Text = "Wyjdź";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // LogInMethodChooseView
            // 
            this.AcceptButton = this.buttonLoginAndPassword;
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 345);
            this.ControlBox = false;
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonCard);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonLoginAndPassword);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LogInMethodChooseView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Elrob.Terminal";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonLoginAndPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCard;
        private System.Windows.Forms.Button buttonExit;
    }
}