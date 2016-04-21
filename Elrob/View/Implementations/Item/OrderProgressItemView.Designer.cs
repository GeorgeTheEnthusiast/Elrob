namespace Elrob.Terminal.View.Implementations.Item
{
    partial class OrderProgressItemView
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderProgressItemView));
            this.label1 = new System.Windows.Forms.Label();
            this.buttonAccept = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.nameErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickerTimeSpend = new System.Windows.Forms.DateTimePicker();
            this.numericUpDownCompleted = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nameErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCompleted)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 43);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ukończono";
            // 
            // buttonAccept
            // 
            this.buttonAccept.Location = new System.Drawing.Point(155, 158);
            this.buttonAccept.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(200, 55);
            this.buttonAccept.TabIndex = 2;
            this.buttonAccept.Text = "Akceptuj";
            this.buttonAccept.UseVisualStyleBackColor = true;
            this.buttonAccept.Click += new System.EventHandler(this.buttonAccept_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(424, 158);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(200, 55);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Anuluj";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // nameErrorProvider
            // 
            this.nameErrorProvider.ContainerControl = this;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 95);
            this.label2.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(199, 31);
            this.label2.TabIndex = 6;
            this.label2.Text = "Spędzony czas";
            // 
            // dateTimePickerTimeSpend
            // 
            this.dateTimePickerTimeSpend.CustomFormat = "HH:mm:ss";
            this.dateTimePickerTimeSpend.Location = new System.Drawing.Point(284, 95);
            this.dateTimePickerTimeSpend.Name = "dateTimePickerTimeSpend";
            this.dateTimePickerTimeSpend.ShowUpDown = true;
            this.dateTimePickerTimeSpend.Size = new System.Drawing.Size(386, 38);
            this.dateTimePickerTimeSpend.TabIndex = 1;
            this.dateTimePickerTimeSpend.Value = new System.DateTime(2016, 3, 9, 0, 0, 0, 0);
            // 
            // numericUpDownCompleted
            // 
            this.numericUpDownCompleted.Location = new System.Drawing.Point(284, 43);
            this.numericUpDownCompleted.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownCompleted.Name = "numericUpDownCompleted";
            this.numericUpDownCompleted.Size = new System.Drawing.Size(386, 38);
            this.numericUpDownCompleted.TabIndex = 0;
            this.numericUpDownCompleted.Click += new System.EventHandler(this.control_Click);
            // 
            // OrderProgressItemView
            // 
            this.AcceptButton = this.buttonAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(757, 234);
            this.Controls.Add(this.numericUpDownCompleted);
            this.Controls.Add(this.dateTimePickerTimeSpend);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonAccept);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OrderProgressItemView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Elrob.Terminal";
            ((System.ComponentModel.ISupportInitialize)(this.nameErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCompleted)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonAccept;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ErrorProvider nameErrorProvider;
        private System.Windows.Forms.NumericUpDown numericUpDownCompleted;
        private System.Windows.Forms.DateTimePicker dateTimePickerTimeSpend;
        private System.Windows.Forms.Label label2;
    }
}