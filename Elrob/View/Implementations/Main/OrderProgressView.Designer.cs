using System.Windows.Forms;

namespace Elrob.Terminal.View.Implementations.Main
{
    partial class OrderProgressView
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
            this.dataGridViewOrderProgress = new System.Windows.Forms.DataGridView();
            this.CompletedColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeSpendColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnReportedDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProgressModifiedDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxOrder = new System.Windows.Forms.TextBox();
            this.textBoxOrderContent = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxDocumentNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxToComplete = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this._textBoxCompletedSum = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrderProgress)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewOrderProgress
            // 
            this.dataGridViewOrderProgress.AllowUserToAddRows = false;
            this.dataGridViewOrderProgress.AllowUserToDeleteRows = false;
            this.dataGridViewOrderProgress.AllowUserToOrderColumns = true;
            this.dataGridViewOrderProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewOrderProgress.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewOrderProgress.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewOrderProgress.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOrderProgress.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CompletedColumn,
            this.TimeSpendColumn,
            this.ColumnReportedDateColumn,
            this.ProgressModifiedDateColumn,
            this.UserColumn});
            this.tableLayoutPanel1.SetColumnSpan(this.dataGridViewOrderProgress, 4);
            this.dataGridViewOrderProgress.Location = new System.Drawing.Point(8, 183);
            this.dataGridViewOrderProgress.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.dataGridViewOrderProgress.MultiSelect = false;
            this.dataGridViewOrderProgress.Name = "dataGridViewOrderProgress";
            this.dataGridViewOrderProgress.ReadOnly = true;
            this.tableLayoutPanel1.SetRowSpan(this.dataGridViewOrderProgress, 3);
            this.dataGridViewOrderProgress.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewOrderProgress.Size = new System.Drawing.Size(1232, 577);
            this.dataGridViewOrderProgress.TabIndex = 0;
            this.dataGridViewOrderProgress.VirtualMode = true;
            this.dataGridViewOrderProgress.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewOrderProgress_ColumnHeaderMouseClick);
            // 
            // CompletedColumn
            // 
            this.CompletedColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.CompletedColumn.DataPropertyName = "Completed";
            this.CompletedColumn.HeaderText = "Ukończono";
            this.CompletedColumn.Name = "CompletedColumn";
            this.CompletedColumn.ReadOnly = true;
            this.CompletedColumn.Width = 176;
            // 
            // TimeSpendColumn
            // 
            this.TimeSpendColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TimeSpendColumn.DataPropertyName = "TimeSpend";
            this.TimeSpendColumn.HeaderText = "Spędzony czas";
            this.TimeSpendColumn.Name = "TimeSpendColumn";
            this.TimeSpendColumn.ReadOnly = true;
            this.TimeSpendColumn.Width = 204;
            // 
            // ColumnReportedDateColumn
            // 
            this.ColumnReportedDateColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnReportedDateColumn.DataPropertyName = "ProgressCreatedDate";
            this.ColumnReportedDateColumn.HeaderText = "Data wprowadzenia";
            this.ColumnReportedDateColumn.Name = "ColumnReportedDateColumn";
            this.ColumnReportedDateColumn.ReadOnly = true;
            this.ColumnReportedDateColumn.Width = 252;
            // 
            // ProgressModifiedDateColumn
            // 
            this.ProgressModifiedDateColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ProgressModifiedDateColumn.DataPropertyName = "ProgressModifiedDate";
            this.ProgressModifiedDateColumn.HeaderText = "Data modyfikacji";
            this.ProgressModifiedDateColumn.Name = "ProgressModifiedDateColumn";
            this.ProgressModifiedDateColumn.ReadOnly = true;
            this.ProgressModifiedDateColumn.Width = 217;
            // 
            // UserColumn
            // 
            this.UserColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.UserColumn.DataPropertyName = "User";
            this.UserColumn.HeaderText = "Użytkownik";
            this.UserColumn.Name = "UserColumn";
            this.UserColumn.ReadOnly = true;
            this.UserColumn.Width = 179;
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.SetColumnSpan(this.buttonOK, 5);
            this.buttonOK.Location = new System.Drawing.Point(680, 774);
            this.buttonOK.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(200, 55);
            this.buttonOK.TabIndex = 1;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonAdd.Location = new System.Drawing.Point(1258, 183);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(292, 86);
            this.buttonAdd.TabIndex = 2;
            this.buttonAdd.Text = "Dodaj";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonEdit.Location = new System.Drawing.Point(1258, 283);
            this.buttonEdit.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(292, 86);
            this.buttonEdit.TabIndex = 3;
            this.buttonEdit.Text = "Edytuj";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonDelete.Location = new System.Drawing.Point(1258, 383);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(292, 86);
            this.buttonDelete.TabIndex = 4;
            this.buttonDelete.Text = "Usuń";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 31);
            this.label1.TabIndex = 5;
            this.label1.Text = "Zamówienie:";
            // 
            // textBoxOrder
            // 
            this.textBoxOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.textBoxOrder, 4);
            this.textBoxOrder.Location = new System.Drawing.Point(237, 3);
            this.textBoxOrder.Multiline = true;
            this.textBoxOrder.Name = "textBoxOrder";
            this.textBoxOrder.ReadOnly = true;
            this.textBoxOrder.Size = new System.Drawing.Size(1320, 38);
            this.textBoxOrder.TabIndex = 6;
            this.textBoxOrder.TextChanged += new System.EventHandler(this.textBoxOrder_TextChanged);
            // 
            // textBoxOrderContent
            // 
            this.textBoxOrderContent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.textBoxOrderContent, 4);
            this.textBoxOrderContent.Location = new System.Drawing.Point(237, 47);
            this.textBoxOrderContent.Multiline = true;
            this.textBoxOrderContent.Name = "textBoxOrderContent";
            this.textBoxOrderContent.ReadOnly = true;
            this.textBoxOrderContent.Size = new System.Drawing.Size(1320, 38);
            this.textBoxOrderContent.TabIndex = 8;
            this.textBoxOrderContent.TextChanged += new System.EventHandler(this.textBoxOrderContent_TextChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 31);
            this.label2.TabIndex = 7;
            this.label2.Text = "Element:";
            // 
            // textBoxDocumentNumber
            // 
            this.textBoxDocumentNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.textBoxDocumentNumber, 4);
            this.textBoxDocumentNumber.Location = new System.Drawing.Point(237, 91);
            this.textBoxDocumentNumber.Multiline = true;
            this.textBoxDocumentNumber.Name = "textBoxDocumentNumber";
            this.textBoxDocumentNumber.ReadOnly = true;
            this.textBoxDocumentNumber.Size = new System.Drawing.Size(1320, 38);
            this.textBoxDocumentNumber.TabIndex = 10;
            this.textBoxDocumentNumber.TextChanged += new System.EventHandler(this.textBoxDocumentNumber_TextChanged);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(192, 31);
            this.label3.TabIndex = 9;
            this.label3.Text = "Nr dokumentu:";
            // 
            // textBoxToComplete
            // 
            this.textBoxToComplete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxToComplete.Location = new System.Drawing.Point(237, 135);
            this.textBoxToComplete.Name = "textBoxToComplete";
            this.textBoxToComplete.ReadOnly = true;
            this.textBoxToComplete.Size = new System.Drawing.Size(384, 38);
            this.textBoxToComplete.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(193, 31);
            this.label4.TabIndex = 11;
            this.label4.Text = "Do wykonania:";
            // 
            // _textBoxCompletedSum
            // 
            this._textBoxCompletedSum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._textBoxCompletedSum.Location = new System.Drawing.Point(939, 135);
            this._textBoxCompletedSum.Name = "_textBoxCompletedSum";
            this._textBoxCompletedSum.ReadOnly = true;
            this._textBoxCompletedSum.Size = new System.Drawing.Size(306, 38);
            this._textBoxCompletedSum.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(705, 138);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(150, 31);
            this.label5.TabIndex = 13;
            this.label5.Text = "Wykonano:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewOrderProgress, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.buttonOK, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.buttonDelete, 4, 6);
            this.tableLayoutPanel1.Controls.Add(this._textBoxCompletedSum, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.buttonEdit, 4, 5);
            this.tableLayoutPanel1.Controls.Add(this.textBoxOrder, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonAdd, 4, 4);
            this.tableLayoutPanel1.Controls.Add(this.label5, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBoxToComplete, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.textBoxOrderContent, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBoxDocumentNumber, 1, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1560, 837);
            this.tableLayoutPanel1.TabIndex = 15;
            // 
            // OrderProgressView
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1584, 861);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OrderProgressView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Postęp prac";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrderProgress)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewOrderProgress;
        private System.Windows.Forms.Button buttonOK;
        private Button buttonAdd;
        private Button buttonEdit;
        private Button buttonDelete;
        private Label label1;
        private TextBox textBoxOrder;
        private TextBox textBoxOrderContent;
        private Label label2;
        private TextBox textBoxDocumentNumber;
        private Label label3;
        private TextBox textBoxToComplete;
        private Label label4;
        private TextBox _textBoxCompletedSum;
        private Label label5;
        private DataGridViewTextBoxColumn CompletedColumn;
        private DataGridViewTextBoxColumn TimeSpendColumn;
        private DataGridViewTextBoxColumn ColumnReportedDateColumn;
        private DataGridViewTextBoxColumn ProgressModifiedDateColumn;
        private DataGridViewTextBoxColumn UserColumn;
        private TableLayoutPanel tableLayoutPanel1;
    }
}