namespace CameraDevice
{
    partial class FormUpdatedevice
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
            buttonUpdate = new Button();
            buttonClose = new Button();
            labelUpdate = new Label();
            pictureBoxStatus = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxStatus).BeginInit();
            SuspendLayout();
            // 
            // buttonUpdate
            // 
            buttonUpdate.Location = new Point(128, 143);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new Size(75, 23);
            buttonUpdate.TabIndex = 0;
            buttonUpdate.Text = "Update";
            buttonUpdate.UseVisualStyleBackColor = true;
            buttonUpdate.Click += buttonUpdate_Click;
            // 
            // buttonClose
            // 
            buttonClose.Location = new Point(222, 143);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(75, 23);
            buttonClose.TabIndex = 1;
            buttonClose.Text = "Close";
            buttonClose.UseVisualStyleBackColor = true;
            buttonClose.Click += buttonClose_Click;
            // 
            // labelUpdate
            // 
            labelUpdate.AutoSize = true;
            labelUpdate.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelUpdate.Location = new Point(27, 39);
            labelUpdate.Name = "labelUpdate";
            labelUpdate.Size = new Size(158, 15);
            labelUpdate.TabIndex = 2;
            labelUpdate.Text = "Software last downloaded: ";
            // 
            // pictureBoxStatus
            // 
            pictureBoxStatus.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBoxStatus.Location = new Point(22, 107);
            pictureBoxStatus.Name = "pictureBoxStatus";
            pictureBoxStatus.Size = new Size(61, 59);
            pictureBoxStatus.TabIndex = 3;
            pictureBoxStatus.TabStop = false;
            // 
            // FormUpdatedevice
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(309, 197);
            Controls.Add(pictureBoxStatus);
            Controls.Add(labelUpdate);
            Controls.Add(buttonClose);
            Controls.Add(buttonUpdate);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormUpdatedevice";
            ShowIcon = false;
            Text = "Sensor Device";
            Load += FormUpdatedevice_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBoxStatus).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonUpdate;
        private Button buttonClose;
        private Label labelUpdate;
        private PictureBox pictureBoxStatus;
    }
}