using System.Windows.Forms;

namespace Elrob.Terminal.View.Implementations.Main
{
    partial class OrderView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderView));
            this.dataGridViewOrders = new System.Windows.Forms.DataGridView();
            this.OrderColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProgressColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonAccept = new System.Windows.Forms.Button();
            this.buttonOrderContent = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPlace = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrders)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewOrders
            // 
            this.dataGridViewOrders.AllowUserToAddRows = false;
            this.dataGridViewOrders.AllowUserToDeleteRows = false;
            this.dataGridViewOrders.AllowUserToOrderColumns = true;
            this.dataGridViewOrders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewOrders.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OrderColumn,
            this.ProgressColumn});
            this.tableLayoutPanel1.SetColumnSpan(this.dataGridViewOrders, 2);
            this.dataGridViewOrders.Location = new System.Drawing.Point(8, 51);
            this.dataGridViewOrders.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.dataGridViewOrders.MultiSelect = false;
            this.dataGridViewOrders.Name = "dataGridViewOrders";
            this.dataGridViewOrders.ReadOnly = true;
            this.tableLayoutPanel1.SetRowSpan(this.dataGridViewOrders, 4);
            this.dataGridViewOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewOrders.Size = new System.Drawing.Size(1232, 705);
            this.dataGridViewOrders.TabIndex = 0;
            this.dataGridViewOrders.TabStop = false;
            this.dataGridViewOrders.VirtualMode = true;
            this.dataGridViewOrders.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewOrders_ColumnHeaderMouseClick);
            // 
            // OrderColumn
            // 
            this.OrderColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.OrderColumn.DataPropertyName = "Name";
            this.OrderColumn.HeaderText = "Nazwa zamówienia";
            this.OrderColumn.Name = "OrderColumn";
            this.OrderColumn.ReadOnly = true;
            this.OrderColumn.Width = 248;
            // 
            // ProgressColumn
            // 
            this.ProgressColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ProgressColumn.DataPropertyName = "PercentageProgress";
            this.ProgressColumn.HeaderText = "Postęp";
            this.ProgressColumn.Name = "ProgressColumn";
            this.ProgressColumn.ReadOnly = true;
            this.ProgressColumn.Width = 124;
            // 
            // buttonAccept
            // 
            this.buttonAccept.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.SetColumnSpan(this.buttonAccept, 3);
            this.buttonAccept.Location = new System.Drawing.Point(680, 770);
            this.buttonAccept.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(200, 55);
            this.buttonAccept.TabIndex = 4;
            this.buttonAccept.Text = "OK";
            this.buttonAccept.UseVisualStyleBackColor = true;
            this.buttonAccept.Click += new System.EventHandler(this.buttonAccept_Click);
            // 
            // buttonOrderContent
            // 
            this.buttonOrderContent.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonOrderContent.Location = new System.Drawing.Point(1258, 648);
            this.buttonOrderContent.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.buttonOrderContent.Name = "buttonOrderContent";
            this.buttonOrderContent.Size = new System.Drawing.Size(292, 108);
            this.buttonOrderContent.TabIndex = 3;
            this.buttonOrderContent.Text = "Pokaż szczegóły zamówienia";
            this.buttonOrderContent.UseVisualStyleBackColor = true;
            this.buttonOrderContent.Click += new System.EventHandler(this.buttonOrderContent_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonAdd.Location = new System.Drawing.Point(1258, 51);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(292, 86);
            this.buttonAdd.TabIndex = 0;
            this.buttonAdd.Text = "Dodaj";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonEdit.Location = new System.Drawing.Point(1258, 151);
            this.buttonEdit.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(292, 86);
            this.buttonEdit.TabIndex = 1;
            this.buttonEdit.Text = "Edytuj";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonDelete.Location = new System.Drawing.Point(1258, 251);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(292, 86);
            this.buttonDelete.TabIndex = 2;
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
            this.label1.Size = new System.Drawing.Size(139, 31);
            this.label1.TabIndex = 7;
            this.label1.Text = "Placówka:";
            // 
            // textBoxPlace
            // 
            this.textBoxPlace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.textBoxPlace, 2);
            this.textBoxPlace.Location = new System.Drawing.Point(237, 3);
            this.textBoxPlace.Multiline = true;
            this.textBoxPlace.Name = "textBoxPlace";
            this.textBoxPlace.ReadOnly = true;
            this.textBoxPlace.Size = new System.Drawing.Size(1320, 38);
            this.textBoxPlace.TabIndex = 8;
            this.textBoxPlace.TabStop = false;
            this.textBoxPlace.TextChanged += new System.EventHandler(this.textBoxPlace_TextChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonOrderContent, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.buttonDelete, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.textBoxPlace, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewOrders, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonEdit, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonAdd, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonAccept, 0, 5);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1560, 833);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // OrderView
            // 
            this.AcceptButton = this.buttonAccept;
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
            this.Name = "OrderView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Zamówienia";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrders)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewOrders;
        private System.Windows.Forms.Button buttonAccept;
        private Button buttonOrderContent;
        private Button buttonAdd;
        private Button buttonEdit;
        private Button buttonDelete;
        private DataGridViewTextBoxColumn OrderColumn;
        private DataGridViewTextBoxColumn ProgressColumn;
        private Label label1;
        private TextBox textBoxPlace;
        private TableLayoutPanel tableLayoutPanel1;
    }
}