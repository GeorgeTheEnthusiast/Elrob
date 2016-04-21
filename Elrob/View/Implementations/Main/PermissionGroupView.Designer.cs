using System.Windows.Forms;

namespace Elrob.Terminal.View.Implementations.Main
{
    partial class PermissionGroupView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PermissionGroupView));
            this.dataGridViewPermissionGroups = new System.Windows.Forms.DataGridView();
            this.DocumentNumberColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonChange = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxGroup = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPermissionGroups)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewPermissionGroups
            // 
            this.dataGridViewPermissionGroups.AllowUserToAddRows = false;
            this.dataGridViewPermissionGroups.AllowUserToDeleteRows = false;
            this.dataGridViewPermissionGroups.AllowUserToOrderColumns = true;
            this.dataGridViewPermissionGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewPermissionGroups.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewPermissionGroups.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewPermissionGroups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPermissionGroups.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DocumentNumberColumn});
            this.tableLayoutPanel1.SetColumnSpan(this.dataGridViewPermissionGroups, 2);
            this.dataGridViewPermissionGroups.Location = new System.Drawing.Point(8, 51);
            this.dataGridViewPermissionGroups.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.dataGridViewPermissionGroups.MultiSelect = false;
            this.dataGridViewPermissionGroups.Name = "dataGridViewPermissionGroups";
            this.dataGridViewPermissionGroups.ReadOnly = true;
            this.tableLayoutPanel1.SetRowSpan(this.dataGridViewPermissionGroups, 2);
            this.dataGridViewPermissionGroups.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPermissionGroups.Size = new System.Drawing.Size(1232, 709);
            this.dataGridViewPermissionGroups.TabIndex = 0;
            this.dataGridViewPermissionGroups.TabStop = false;
            this.dataGridViewPermissionGroups.VirtualMode = true;
            this.dataGridViewPermissionGroups.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewPermissionGroups_ColumnHeaderMouseClick);
            // 
            // DocumentNumberColumn
            // 
            this.DocumentNumberColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DocumentNumberColumn.DataPropertyName = "Permission";
            this.DocumentNumberColumn.HeaderText = "Uprawnienie";
            this.DocumentNumberColumn.Name = "DocumentNumberColumn";
            this.DocumentNumberColumn.ReadOnly = true;
            this.DocumentNumberColumn.Width = 190;
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.SetColumnSpan(this.buttonOK, 3);
            this.buttonOK.Location = new System.Drawing.Point(680, 774);
            this.buttonOK.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(200, 55);
            this.buttonOK.TabIndex = 2;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonChange
            // 
            this.buttonChange.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonChange.Location = new System.Drawing.Point(1258, 51);
            this.buttonChange.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.buttonChange.Name = "buttonChange";
            this.buttonChange.Size = new System.Drawing.Size(292, 86);
            this.buttonChange.TabIndex = 0;
            this.buttonChange.Text = "Zmień";
            this.buttonChange.UseVisualStyleBackColor = true;
            this.buttonChange.Click += new System.EventHandler(this.buttonChange_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonDelete.Location = new System.Drawing.Point(1258, 151);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(292, 86);
            this.buttonDelete.TabIndex = 1;
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
            this.label1.Size = new System.Drawing.Size(97, 31);
            this.label1.TabIndex = 5;
            this.label1.Text = "Grupa:";
            // 
            // textBoxGroup
            // 
            this.textBoxGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.textBoxGroup, 2);
            this.textBoxGroup.Location = new System.Drawing.Point(159, 3);
            this.textBoxGroup.Multiline = true;
            this.textBoxGroup.Name = "textBoxGroup";
            this.textBoxGroup.ReadOnly = true;
            this.textBoxGroup.Size = new System.Drawing.Size(1398, 38);
            this.textBoxGroup.TabIndex = 6;
            this.textBoxGroup.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewPermissionGroups, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonOK, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.buttonDelete, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBoxGroup, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonChange, 2, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1560, 837);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // PermissionGroupView
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1584, 861);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PermissionGroupView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Uprawnienia grup";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPermissionGroups)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewPermissionGroups;
        private System.Windows.Forms.Button buttonOK;
        private Button buttonChange;
        private Button buttonDelete;
        private DataGridViewTextBoxColumn DocumentNumberColumn;
        private Label label1;
        private TextBox textBoxGroup;
        private TableLayoutPanel tableLayoutPanel1;
    }
}