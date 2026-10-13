namespace Sensordevice
{
    partial class FormLogscolumn
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
            buttonClose = new Button();
            listViewColumn = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            labelHead = new Label();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabelRows = new ToolStripStatusLabel();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // buttonClose
            // 
            buttonClose.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            buttonClose.Location = new Point(698, 643);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(75, 23);
            buttonClose.TabIndex = 0;
            buttonClose.Text = "Close";
            buttonClose.UseVisualStyleBackColor = true;
            buttonClose.Click += buttonClose_Click;
            // 
            // listViewColumn
            // 
            listViewColumn.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4 });
            listViewColumn.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            listViewColumn.Location = new Point(8, 44);
            listViewColumn.Name = "listViewColumn";
            listViewColumn.Size = new Size(765, 593);
            listViewColumn.TabIndex = 1;
            listViewColumn.UseCompatibleStateImageBehavior = false;
            listViewColumn.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Log text";
            columnHeader1.Width = 380;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Code";
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Comment";
            columnHeader3.Width = 140;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Date created";
            columnHeader4.Width = 180;
            // 
            // labelHead
            // 
            labelHead.AutoSize = true;
            labelHead.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelHead.Location = new Point(12, 9);
            labelHead.Name = "labelHead";
            labelHead.Size = new Size(45, 17);
            labelHead.TabIndex = 2;
            labelHead.Text = "label1";
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabelRows });
            statusStrip1.Location = new Point(0, 686);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(785, 22);
            statusStrip1.TabIndex = 3;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelRows
            // 
            toolStripStatusLabelRows.Name = "toolStripStatusLabelRows";
            toolStripStatusLabelRows.Size = new Size(118, 17);
            toolStripStatusLabelRows.Text = "toolStripStatusLabel1";
            // 
            // FormLogscolumn
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(785, 708);
            Controls.Add(statusStrip1);
            Controls.Add(labelHead);
            Controls.Add(listViewColumn);
            Controls.Add(buttonClose);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormLogscolumn";
            ShowIcon = false;
            Text = "Sensor Device";
            Load += Logscolumn_Load;
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonClose;
        private ListView listViewColumn;
        private Label labelHead;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabelRows;
    }
}