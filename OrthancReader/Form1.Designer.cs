namespace OrthancReader
{
    partial class Form1
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
            this.textBoxOrthancFolder = new System.Windows.Forms.TextBox();
            this.textBoxDicomFolder = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.checkBoxSynchronize = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // textBoxOrthancFolder
            // 
            this.textBoxOrthancFolder.Location = new System.Drawing.Point(12, 29);
            this.textBoxOrthancFolder.Name = "textBoxOrthancFolder";
            this.textBoxOrthancFolder.Size = new System.Drawing.Size(293, 22);
            this.textBoxOrthancFolder.TabIndex = 0;
            this.textBoxOrthancFolder.Text = "http://localhost:8402";
            this.textBoxOrthancFolder.TextChanged += new System.EventHandler(this.textBoxOrthancFolder_TextChanged);
            // 
            // textBoxDicomFolder
            // 
            this.textBoxDicomFolder.Location = new System.Drawing.Point(12, 93);
            this.textBoxDicomFolder.Name = "textBoxDicomFolder";
            this.textBoxDicomFolder.Size = new System.Drawing.Size(293, 22);
            this.textBoxDicomFolder.TabIndex = 1;
            this.textBoxDicomFolder.Text = "C:\\Users\\Whatever\\Documents\\Dicoms";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(311, 93);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Browse";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Orthanc Web Address:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Dicom Folder:";
            // 
            // labelStatus
            // 
            this.labelStatus.Location = new System.Drawing.Point(9, 167);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(514, 217);
            this.labelStatus.TabIndex = 6;
            this.labelStatus.Text = "[Status]";
            this.labelStatus.Click += new System.EventHandler(this.labelStatus_Click);
            // 
            // checkBoxSynchronize
            // 
            this.checkBoxSynchronize.AutoSize = true;
            this.checkBoxSynchronize.Location = new System.Drawing.Point(12, 121);
            this.checkBoxSynchronize.Name = "checkBoxSynchronize";
            this.checkBoxSynchronize.Size = new System.Drawing.Size(108, 21);
            this.checkBoxSynchronize.TabIndex = 7;
            this.checkBoxSynchronize.Text = "Synchronize";
            this.checkBoxSynchronize.UseVisualStyleBackColor = true;
            this.checkBoxSynchronize.CheckedChanged += new System.EventHandler(this.checkBoxSynchronize_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(535, 450);
            this.Controls.Add(this.checkBoxSynchronize);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBoxDicomFolder);
            this.Controls.Add(this.textBoxOrthancFolder);
            this.Name = "Form1";
            this.Text = "Orthanc Synchronizer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxOrthancFolder;
        private System.Windows.Forms.TextBox textBoxDicomFolder;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.CheckBox checkBoxSynchronize;
    }
}

