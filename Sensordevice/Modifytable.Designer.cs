namespace Sensordevice
{
    partial class FormModifyTable
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
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            modifyRowToolStripMenuItem = new ToolStripMenuItem();
            deleteRowsToolStripMenuItem = new ToolStripMenuItem();
            viewToolStripMenuItem = new ToolStripMenuItem();
            allItemsToolStripMenuItem = new ToolStripMenuItem();
            listViewTable = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            dateTimePickerStartDate = new DateTimePicker();
            dateTimePickerEndDate = new DateTimePicker();
            labelText1 = new Label();
            labelText2 = new Label();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabelRows = new ToolStripStatusLabel();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, editToolStripMenuItem, viewToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(704, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(92, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { modifyRowToolStripMenuItem, deleteRowsToolStripMenuItem });
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(39, 20);
            editToolStripMenuItem.Text = "Edit";
            // 
            // modifyRowToolStripMenuItem
            // 
            modifyRowToolStripMenuItem.Enabled = false;
            modifyRowToolStripMenuItem.Name = "modifyRowToolStripMenuItem";
            modifyRowToolStripMenuItem.Size = new Size(180, 22);
            modifyRowToolStripMenuItem.Text = "Modify row";
            modifyRowToolStripMenuItem.Click += modifyRowToolStripMenuItem_Click;
            // 
            // deleteRowsToolStripMenuItem
            // 
            deleteRowsToolStripMenuItem.Enabled = false;
            deleteRowsToolStripMenuItem.Name = "deleteRowsToolStripMenuItem";
            deleteRowsToolStripMenuItem.Size = new Size(180, 22);
            deleteRowsToolStripMenuItem.Text = "Delete rows";
            deleteRowsToolStripMenuItem.Click += deleteRowsToolStripMenuItem_Click;
            // 
            // viewToolStripMenuItem
            // 
            viewToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { allItemsToolStripMenuItem });
            viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            viewToolStripMenuItem.Size = new Size(44, 20);
            viewToolStripMenuItem.Text = "View";
            // 
            // allItemsToolStripMenuItem
            // 
            allItemsToolStripMenuItem.Name = "allItemsToolStripMenuItem";
            allItemsToolStripMenuItem.Size = new Size(120, 22);
            allItemsToolStripMenuItem.Text = "All items";
            allItemsToolStripMenuItem.Click += allItemsToolStripMenuItem_Click;
            // 
            // listViewTable
            // 
            listViewTable.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4 });
            listViewTable.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            listViewTable.FullRowSelect = true;
            listViewTable.Location = new Point(12, 80);
            listViewTable.Name = "listViewTable";
            listViewTable.Size = new Size(680, 996);
            listViewTable.TabIndex = 1;
            listViewTable.UseCompatibleStateImageBehavior = false;
            listViewTable.View = View.Details;
            listViewTable.Click += listViewTable_Click;
            listViewTable.DoubleClick += listViewTable_DoubleClick;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "ID";
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Temperature";
            columnHeader2.Width = 160;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Humidity";
            columnHeader3.Width = 160;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Date created";
            columnHeader4.Width = 160;
            // 
            // dateTimePickerStartDate
            // 
            dateTimePickerStartDate.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            dateTimePickerStartDate.Location = new Point(12, 49);
            dateTimePickerStartDate.Name = "dateTimePickerStartDate";
            dateTimePickerStartDate.Size = new Size(221, 25);
            dateTimePickerStartDate.TabIndex = 2;
            dateTimePickerStartDate.ValueChanged += dateTimePickerStartDate_ValueChanged;
            // 
            // dateTimePickerEndDate
            // 
            dateTimePickerEndDate.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            dateTimePickerEndDate.Location = new Point(327, 49);
            dateTimePickerEndDate.Name = "dateTimePickerEndDate";
            dateTimePickerEndDate.Size = new Size(233, 25);
            dateTimePickerEndDate.TabIndex = 3;
            dateTimePickerEndDate.CloseUp += dateTimePickerEndDate_CloseUp;
            // 
            // labelText1
            // 
            labelText1.AutoSize = true;
            labelText1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelText1.Location = new Point(12, 24);
            labelText1.Name = "labelText1";
            labelText1.Size = new Size(68, 17);
            labelText1.TabIndex = 4;
            labelText1.Text = "Start date";
            // 
            // labelText2
            // 
            labelText2.AutoSize = true;
            labelText2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelText2.Location = new Point(327, 26);
            labelText2.Name = "labelText2";
            labelText2.Size = new Size(62, 17);
            labelText2.TabIndex = 5;
            labelText2.Text = "End date";
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabelRows });
            statusStrip1.Location = new Point(0, 1066);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(704, 22);
            statusStrip1.TabIndex = 6;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelRows
            // 
            toolStripStatusLabelRows.Name = "toolStripStatusLabelRows";
            toolStripStatusLabelRows.Size = new Size(118, 17);
            toolStripStatusLabelRows.Text = "toolStripStatusLabel1";
            // 
            // FormModifyTable
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(704, 1088);
            Controls.Add(statusStrip1);
            Controls.Add(labelText2);
            Controls.Add(labelText1);
            Controls.Add(dateTimePickerEndDate);
            Controls.Add(dateTimePickerStartDate);
            Controls.Add(listViewTable);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormModifyTable";
            ShowIcon = false;
            Text = "All Item";
            Activated += FormModifyTable_Activated;
            Load += Modifytable_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem modifyRowToolStripMenuItem;
        private ToolStripMenuItem deleteRowsToolStripMenuItem;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem allItemsToolStripMenuItem;
        private ListView listViewTable;
        private DateTimePicker dateTimePickerStartDate;
        private DateTimePicker dateTimePickerEndDate;
        private Label labelText1;
        private Label labelText2;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabelRows;
    }
}