using System.Windows.Forms;

namespace Elrob.Terminal.View.Implementations.Main
{
    partial class OrderPreviewView
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
            this.dataGridViewOrderContent = new System.Windows.Forms.DataGridView();
            this.DocumentNumberColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContentNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlaceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PackageQuantityColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaterialColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThicknessColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WidthColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HeightColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitWeightColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ToCompleteColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonAccept = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelOrderName = new System.Windows.Forms.Label();
            this.textBoxOrderName = new System.Windows.Forms.TextBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrderContent)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewOrderContent
            // 
            this.dataGridViewOrderContent.AllowUserToAddRows = false;
            this.dataGridViewOrderContent.AllowUserToDeleteRows = false;
            this.dataGridViewOrderContent.AllowUserToOrderColumns = true;
            this.dataGridViewOrderContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewOrderContent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewOrderContent.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewOrderContent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOrderContent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DocumentNumberColumn,
            this.ContentNameColumn,
            this.PlaceColumn,
            this.PackageQuantityColumn,
            this.MaterialColumn,
            this.ThicknessColumn,
            this.WidthColumn,
            this.HeightColumn,
            this.UnitWeightColumn,
            this.ToCompleteColumn});
            this.tableLayoutPanel1.SetColumnSpan(this.dataGridViewOrderContent, 3);
            this.dataGridViewOrderContent.Location = new System.Drawing.Point(8, 51);
            this.dataGridViewOrderContent.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.dataGridViewOrderContent.MultiSelect = false;
            this.dataGridViewOrderContent.Name = "dataGridViewOrderContent";
            this.dataGridViewOrderContent.ReadOnly = true;
            this.tableLayoutPanel1.SetRowSpan(this.dataGridViewOrderContent, 3);
            this.dataGridViewOrderContent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewOrderContent.Size = new System.Drawing.Size(1232, 709);
            this.dataGridViewOrderContent.TabIndex = 0;
            this.dataGridViewOrderContent.TabStop = false;
            this.dataGridViewOrderContent.VirtualMode = true;
            this.dataGridViewOrderContent.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewOrderContent_ColumnHeaderMouseClick);
            // 
            // DocumentNumberColumn
            // 
            this.DocumentNumberColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DocumentNumberColumn.DataPropertyName = "DocumentNumber";
            this.DocumentNumberColumn.HeaderText = "Numer dokumentu";
            this.DocumentNumberColumn.Name = "DocumentNumberColumn";
            this.DocumentNumberColumn.ReadOnly = true;
            this.DocumentNumberColumn.Width = 237;
            // 
            // ContentNameColumn
            // 
            this.ContentNameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ContentNameColumn.DataPropertyName = "Name";
            this.ContentNameColumn.HeaderText = "Nazwa";
            this.ContentNameColumn.Name = "ContentNameColumn";
            this.ContentNameColumn.ReadOnly = true;
            this.ContentNameColumn.Width = 123;
            // 
            // PlaceColumn
            // 
            this.PlaceColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.PlaceColumn.DataPropertyName = "Place";
            this.PlaceColumn.HeaderText = "Placówka";
            this.PlaceColumn.Name = "PlaceColumn";
            this.PlaceColumn.ReadOnly = true;
            this.PlaceColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PlaceColumn.Width = 156;
            // 
            // PackageQuantityColumn
            // 
            this.PackageQuantityColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.PackageQuantityColumn.DataPropertyName = "PackageQuantity";
            this.PackageQuantityColumn.HeaderText = "Ilość na kpl.";
            this.PackageQuantityColumn.Name = "PackageQuantityColumn";
            this.PackageQuantityColumn.ReadOnly = true;
            this.PackageQuantityColumn.Width = 128;
            // 
            // MaterialColumn
            // 
            this.MaterialColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MaterialColumn.DataPropertyName = "Material";
            this.MaterialColumn.HeaderText = "Materiał";
            this.MaterialColumn.Name = "MaterialColumn";
            this.MaterialColumn.ReadOnly = true;
            this.MaterialColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.MaterialColumn.Width = 135;
            // 
            // ThicknessColumn
            // 
            this.ThicknessColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ThicknessColumn.DataPropertyName = "Thickness";
            this.ThicknessColumn.HeaderText = "Grubość";
            this.ThicknessColumn.Name = "ThicknessColumn";
            this.ThicknessColumn.ReadOnly = true;
            this.ThicknessColumn.Width = 142;
            // 
            // WidthColumn
            // 
            this.WidthColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.WidthColumn.DataPropertyName = "Width";
            this.WidthColumn.HeaderText = "Kier. X";
            this.WidthColumn.Name = "WidthColumn";
            this.WidthColumn.ReadOnly = true;
            this.WidthColumn.Width = 110;
            // 
            // HeightColumn
            // 
            this.HeightColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.HeightColumn.DataPropertyName = "Height";
            this.HeightColumn.HeaderText = "Kier. Y";
            this.HeightColumn.Name = "HeightColumn";
            this.HeightColumn.ReadOnly = true;
            this.HeightColumn.Width = 110;
            // 
            // UnitWeightColumn
            // 
            this.UnitWeightColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.UnitWeightColumn.DataPropertyName = "UnitWeight";
            this.UnitWeightColumn.HeaderText = "Masa (jedn.)";
            this.UnitWeightColumn.Name = "UnitWeightColumn";
            this.UnitWeightColumn.ReadOnly = true;
            this.UnitWeightColumn.Width = 172;
            // 
            // ToCompleteColumn
            // 
            this.ToCompleteColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ToCompleteColumn.DataPropertyName = "ToComplete";
            this.ToCompleteColumn.HeaderText = "Do realizacji";
            this.ToCompleteColumn.Name = "ToCompleteColumn";
            this.ToCompleteColumn.ReadOnly = true;
            this.ToCompleteColumn.Width = 170;
            // 
            // buttonAccept
            // 
            this.buttonAccept.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.SetColumnSpan(this.buttonAccept, 2);
            this.buttonAccept.Location = new System.Drawing.Point(290, 774);
            this.buttonAccept.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(200, 55);
            this.buttonAccept.TabIndex = 4;
            this.buttonAccept.Text = "Akceptuj";
            this.buttonAccept.UseVisualStyleBackColor = true;
            this.buttonAccept.Click += new System.EventHandler(this.buttonAccept_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.SetColumnSpan(this.buttonCancel, 2);
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(1070, 774);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(200, 55);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Anuluj";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // labelOrderName
            // 
            this.labelOrderName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelOrderName.AutoSize = true;
            this.labelOrderName.Location = new System.Drawing.Point(3, 6);
            this.labelOrderName.Name = "labelOrderName";
            this.labelOrderName.Size = new System.Drawing.Size(306, 31);
            this.labelOrderName.TabIndex = 3;
            this.labelOrderName.Text = "Nazwa zamówienia:";
            // 
            // textBoxOrderName
            // 
            this.textBoxOrderName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.textBoxOrderName, 3);
            this.textBoxOrderName.Location = new System.Drawing.Point(315, 3);
            this.textBoxOrderName.Multiline = true;
            this.textBoxOrderName.Name = "textBoxOrderName";
            this.textBoxOrderName.Size = new System.Drawing.Size(1242, 38);
            this.textBoxOrderName.TabIndex = 0;
            this.textBoxOrderName.TextChanged += new System.EventHandler(this.textBoxOrderName_TextChanged);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonAdd.Location = new System.Drawing.Point(1258, 51);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(292, 86);
            this.buttonAdd.TabIndex = 1;
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
            this.buttonEdit.TabIndex = 2;
            this.buttonEdit.Text = "Edytuj";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonDelete.Location = new System.Drawing.Point(1258, 251);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(292, 86);
            this.buttonDelete.TabIndex = 3;
            this.buttonDelete.Text = "Usuń";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.labelOrderName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonCancel, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.buttonDelete, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.buttonAccept, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.textBoxOrderName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewOrderContent, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonEdit, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonAdd, 3, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1560, 837);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // OrderPreviewView
            // 
            this.AcceptButton = this.buttonAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(1584, 861);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OrderPreviewView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Zamówienie";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrderContent)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewOrderContent;
        private System.Windows.Forms.Button buttonAccept;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelOrderName;
        private System.Windows.Forms.TextBox textBoxOrderName;
        private Button buttonAdd;
        private Button buttonEdit;
        private Button buttonDelete;
        private DataGridViewTextBoxColumn DocumentNumberColumn;
        private DataGridViewTextBoxColumn ContentNameColumn;
        private DataGridViewTextBoxColumn PlaceColumn;
        private DataGridViewTextBoxColumn PackageQuantityColumn;
        private DataGridViewTextBoxColumn MaterialColumn;
        private DataGridViewTextBoxColumn ThicknessColumn;
        private DataGridViewTextBoxColumn WidthColumn;
        private DataGridViewTextBoxColumn HeightColumn;
        private DataGridViewTextBoxColumn UnitWeightColumn;
        private DataGridViewTextBoxColumn ToCompleteColumn;
        private TableLayoutPanel tableLayoutPanel1;
    }
}