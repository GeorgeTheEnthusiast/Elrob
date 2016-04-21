namespace Elrob.Terminal.View.Implementations.Main
{
    partial class MainView
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
            this.panelUser = new System.Windows.Forms.Panel();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonImport = new System.Windows.Forms.Button();
            this.buttonMaterials = new System.Windows.Forms.Button();
            this.buttonPlaces = new System.Windows.Forms.Button();
            this.buttonOrders = new System.Windows.Forms.Button();
            this.buttonUsers = new System.Windows.Forms.Button();
            this.buttonGroups = new System.Windows.Forms.Button();
            this.buttonOrderProgress = new System.Windows.Forms.Button();
            this.buttonLogOut = new System.Windows.Forms.Button();
            this.panelUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelUser
            // 
            this.panelUser.Controls.Add(this.textBoxUserName);
            this.panelUser.Controls.Add(this.label1);
            this.panelUser.Location = new System.Drawing.Point(13, 13);
            this.panelUser.Name = "panelUser";
            this.panelUser.Size = new System.Drawing.Size(877, 53);
            this.panelUser.TabIndex = 0;
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Dock = System.Windows.Forms.DockStyle.Right;
            this.textBoxUserName.Enabled = false;
            this.textBoxUserName.Location = new System.Drawing.Point(263, 0);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.ReadOnly = true;
            this.textBoxUserName.Size = new System.Drawing.Size(614, 38);
            this.textBoxUserName.TabIndex = 1;
            this.textBoxUserName.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Zalogowany jako:";
            // 
            // buttonImport
            // 
            this.buttonImport.Location = new System.Drawing.Point(13, 72);
            this.buttonImport.Name = "buttonImport";
            this.buttonImport.Size = new System.Drawing.Size(206, 86);
            this.buttonImport.TabIndex = 0;
            this.buttonImport.Text = "Importuj zamówienie";
            this.buttonImport.UseVisualStyleBackColor = true;
            this.buttonImport.Click += new System.EventHandler(this.buttonImport_Click);
            // 
            // buttonMaterials
            // 
            this.buttonMaterials.Location = new System.Drawing.Point(14, 256);
            this.buttonMaterials.Name = "buttonMaterials";
            this.buttonMaterials.Size = new System.Drawing.Size(206, 86);
            this.buttonMaterials.TabIndex = 1;
            this.buttonMaterials.Text = "Materiały";
            this.buttonMaterials.UseVisualStyleBackColor = true;
            this.buttonMaterials.Click += new System.EventHandler(this.buttonMaterials_Click);
            // 
            // buttonPlaces
            // 
            this.buttonPlaces.Location = new System.Drawing.Point(14, 348);
            this.buttonPlaces.Name = "buttonPlaces";
            this.buttonPlaces.Size = new System.Drawing.Size(206, 86);
            this.buttonPlaces.TabIndex = 2;
            this.buttonPlaces.Text = "Placówki";
            this.buttonPlaces.UseVisualStyleBackColor = true;
            this.buttonPlaces.Click += new System.EventHandler(this.buttonPlaces_Click);
            // 
            // buttonOrders
            // 
            this.buttonOrders.Location = new System.Drawing.Point(14, 440);
            this.buttonOrders.Name = "buttonOrders";
            this.buttonOrders.Size = new System.Drawing.Size(206, 86);
            this.buttonOrders.TabIndex = 3;
            this.buttonOrders.Text = "Zamówienia";
            this.buttonOrders.UseVisualStyleBackColor = true;
            this.buttonOrders.Click += new System.EventHandler(this.buttonOrders_Click);
            // 
            // buttonUsers
            // 
            this.buttonUsers.Location = new System.Drawing.Point(684, 72);
            this.buttonUsers.Name = "buttonUsers";
            this.buttonUsers.Size = new System.Drawing.Size(206, 86);
            this.buttonUsers.TabIndex = 5;
            this.buttonUsers.Text = "Użytkownicy";
            this.buttonUsers.UseVisualStyleBackColor = true;
            this.buttonUsers.Click += new System.EventHandler(this.buttonUsers_Click);
            // 
            // buttonGroups
            // 
            this.buttonGroups.Location = new System.Drawing.Point(684, 164);
            this.buttonGroups.Name = "buttonGroups";
            this.buttonGroups.Size = new System.Drawing.Size(206, 86);
            this.buttonGroups.TabIndex = 6;
            this.buttonGroups.Text = "Grupy użytkowników";
            this.buttonGroups.UseVisualStyleBackColor = true;
            this.buttonGroups.Click += new System.EventHandler(this.buttonGroups_Click);
            // 
            // buttonOrderProgress
            // 
            this.buttonOrderProgress.Location = new System.Drawing.Point(14, 532);
            this.buttonOrderProgress.Name = "buttonOrderProgress";
            this.buttonOrderProgress.Size = new System.Drawing.Size(206, 86);
            this.buttonOrderProgress.TabIndex = 4;
            this.buttonOrderProgress.Text = "Raportowanie";
            this.buttonOrderProgress.UseVisualStyleBackColor = true;
            this.buttonOrderProgress.Click += new System.EventHandler(this.buttonOrderProgress_Click);
            // 
            // buttonLogOut
            // 
            this.buttonLogOut.Location = new System.Drawing.Point(684, 532);
            this.buttonLogOut.Name = "buttonLogOut";
            this.buttonLogOut.Size = new System.Drawing.Size(206, 86);
            this.buttonLogOut.TabIndex = 7;
            this.buttonLogOut.Text = "Wyloguj";
            this.buttonLogOut.UseVisualStyleBackColor = true;
            this.buttonLogOut.Click += new System.EventHandler(this.buttonLogOut_Click);
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 630);
            this.Controls.Add(this.buttonLogOut);
            this.Controls.Add(this.buttonOrderProgress);
            this.Controls.Add(this.buttonGroups);
            this.Controls.Add(this.buttonUsers);
            this.Controls.Add(this.buttonOrders);
            this.Controls.Add(this.buttonPlaces);
            this.Controls.Add(this.buttonMaterials);
            this.Controls.Add(this.buttonImport);
            this.Controls.Add(this.panelUser);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Elrob.Terminal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainView_FormClosing);
            this.panelUser.ResumeLayout(false);
            this.panelUser.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelUser;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonImport;
        private System.Windows.Forms.Button buttonMaterials;
        private System.Windows.Forms.Button buttonPlaces;
        private System.Windows.Forms.Button buttonOrders;
        private System.Windows.Forms.Button buttonUsers;
        private System.Windows.Forms.Button buttonGroups;
        private System.Windows.Forms.Button buttonOrderProgress;
        private System.Windows.Forms.Button buttonLogOut;
    }
}