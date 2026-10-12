namespace Sensordevice
{
    partial class FormModifyRow
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
            buttonSave = new Button();
            buttonCancel = new Button();
            textBoxTemp = new TextBox();
            textBoxHum = new TextBox();
            label1 = new Label();
            labelText1 = new Label();
            labelID = new Label();
            labelDate = new Label();
            SuspendLayout();
            // 
            // buttonSave
            // 
            buttonSave.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            buttonSave.Location = new Point(42, 230);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(75, 23);
            buttonSave.TabIndex = 0;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            buttonCancel.Location = new Point(123, 229);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 1;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // textBoxTemp
            // 
            textBoxTemp.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            textBoxTemp.Location = new Point(12, 48);
            textBoxTemp.Name = "textBoxTemp";
            textBoxTemp.Size = new Size(100, 25);
            textBoxTemp.TabIndex = 2;
            // 
            // textBoxHum
            // 
            textBoxHum.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            textBoxHum.Location = new Point(12, 107);
            textBoxHum.Name = "textBoxHum";
            textBoxHum.Size = new Size(100, 25);
            textBoxHum.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label1.Location = new Point(15, 82);
            label1.Name = "label1";
            label1.Size = new Size(66, 17);
            label1.TabIndex = 4;
            label1.Text = "Humidity";
            // 
            // labelText1
            // 
            labelText1.AutoSize = true;
            labelText1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelText1.Location = new Point(12, 18);
            labelText1.Name = "labelText1";
            labelText1.Size = new Size(86, 17);
            labelText1.TabIndex = 5;
            labelText1.Text = "Temperature";
            // 
            // labelID
            // 
            labelID.AutoSize = true;
            labelID.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelID.Location = new Point(16, 152);
            labelID.Name = "labelID";
            labelID.Size = new Size(45, 17);
            labelID.TabIndex = 6;
            labelID.Text = "label2";
            // 
            // labelDate
            // 
            labelDate.AutoSize = true;
            labelDate.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelDate.Location = new Point(15, 186);
            labelDate.Name = "labelDate";
            labelDate.Size = new Size(45, 17);
            labelDate.TabIndex = 7;
            labelDate.Text = "label3";
            // 
            // FormModifyRow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(210, 264);
            Controls.Add(labelDate);
            Controls.Add(labelID);
            Controls.Add(labelText1);
            Controls.Add(label1);
            Controls.Add(textBoxHum);
            Controls.Add(textBoxTemp);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormModifyRow";
            ShowIcon = false;
            ShowInTaskbar = false;
            Text = "Sensor Device";
            Load += FormModifyRow_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonSave;
        private Button buttonCancel;
        private TextBox textBoxTemp;
        private TextBox textBoxHum;
        private Label label1;
        private Label labelText1;
        private Label labelID;
        private Label labelDate;
    }
}