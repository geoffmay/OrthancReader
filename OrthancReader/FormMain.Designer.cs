namespace OrthancReader
{
    partial class FormMain
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
            this.textBoxOrthancFolder.Location = new System.Drawing.Point(9, 24);
            this.textBoxOrthancFolder.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxOrthancFolder.Name = "textBoxOrthancFolder";
            this.textBoxOrthancFolder.Size = new System.Drawing.Size(221, 20);
            this.textBoxOrthancFolder.TabIndex = 0;
            this.textBoxOrthancFolder.Text = "http://localhost:8402";
            this.textBoxOrthancFolder.TextChanged += new System.EventHandler(this.textBoxOrthancFolder_TextChanged);
            // 
            // textBoxDicomFolder
            // 
            this.textBoxDicomFolder.Location = new System.Drawing.Point(9, 76);
            this.textBoxDicomFolder.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxDicomFolder.Name = "textBoxDicomFolder";
            this.textBoxDicomFolder.Size = new System.Drawing.Size(221, 20);
            this.textBoxDicomFolder.TabIndex = 1;
            this.textBoxDicomFolder.Text = "C:\\Orthanc\\FIRMM";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(233, 76);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(56, 19);
            this.button2.TabIndex = 3;
            this.button2.Text = "Browse";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Orthanc Web Address:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 59);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Dicom Folder:";
            // 
            // labelStatus
            // 
            this.labelStatus.Location = new System.Drawing.Point(7, 136);
            this.labelStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(386, 176);
            this.labelStatus.TabIndex = 6;
            this.labelStatus.Text = "[Status]";
            this.labelStatus.Click += new System.EventHandler(this.labelStatus_Click);
            // 
            // checkBoxSynchronize
            // 
            this.checkBoxSynchronize.AutoSize = true;
            this.checkBoxSynchronize.Location = new System.Drawing.Point(9, 98);
            this.checkBoxSynchronize.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBoxSynchronize.Name = "checkBoxSynchronize";
            this.checkBoxSynchronize.Size = new System.Drawing.Size(84, 17);
            this.checkBoxSynchronize.TabIndex = 7;
            this.checkBoxSynchronize.Text = "Synchronize";
            this.checkBoxSynchronize.UseVisualStyleBackColor = true;
            this.checkBoxSynchronize.CheckedChanged += new System.EventHandler(this.checkBoxSynchronize_CheckedChanged);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(401, 366);
            this.Controls.Add(this.checkBoxSynchronize);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBoxDicomFolder);
            this.Controls.Add(this.textBoxOrthancFolder);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormMain";
            this.Text = "Orthanc Synchronizer";
            this.Load += new System.EventHandler(this.FormMain_Load);
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

