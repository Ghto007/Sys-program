namespace Lab6_Task3
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            buttonBrowse = new Button();
            textBoxCurrentFolder = new TextBox();
            listBoxDirectoryContent = new ListBox();
            labelDetails = new Label();
            SuspendLayout();
            // 
            // buttonBrowse
            // 
            buttonBrowse.Location = new Point(51, 22);
            buttonBrowse.Name = "buttonBrowse";
            buttonBrowse.Size = new Size(75, 23);
            buttonBrowse.TabIndex = 0;
            buttonBrowse.Text = "Огляд..";
            buttonBrowse.UseVisualStyleBackColor = true;
            buttonBrowse.Click += buttonBrowse_Click_1;
            // 
            // textBoxCurrentFolder
            // 
            textBoxCurrentFolder.Location = new Point(51, 61);
            textBoxCurrentFolder.Name = "textBoxCurrentFolder";
            textBoxCurrentFolder.Size = new Size(524, 23);
            textBoxCurrentFolder.TabIndex = 1;
            // 
            // listBoxDirectoryContent
            // 
            listBoxDirectoryContent.FormattingEnabled = true;
            listBoxDirectoryContent.Location = new Point(51, 110);
            listBoxDirectoryContent.Name = "listBoxDirectoryContent";
            listBoxDirectoryContent.Size = new Size(524, 274);
            listBoxDirectoryContent.TabIndex = 2;
            // 
            // labelDetails
            // 
            labelDetails.AutoSize = true;
            labelDetails.Location = new Point(581, 69);
            labelDetails.Name = "labelDetails";
            labelDetails.Size = new Size(127, 15);
            labelDetails.TabIndex = 3;
            labelDetails.Text = "Інформація про файл";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(labelDetails);
            Controls.Add(listBoxDirectoryContent);
            Controls.Add(textBoxCurrentFolder);
            Controls.Add(buttonBrowse);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonBrowse;
        private TextBox textBoxCurrentFolder;
        private ListBox listBoxDirectoryContent;
        private Label labelDetails;
    }
}
