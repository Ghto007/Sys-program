namespace Lab
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
            buttonStart = new Button();
            buttonCancel = new Button();
            progressBar1 = new ProgressBar();
            labelProgress = new Label();
            labelResult = new Label();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton3 = new RadioButton();
            SuspendLayout();
            // 
            // buttonStart
            // 
            buttonStart.AccessibleName = "";
            buttonStart.Location = new Point(78, 338);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new Size(75, 23);
            buttonStart.TabIndex = 0;
            buttonStart.Text = "Start";
            buttonStart.UseVisualStyleBackColor = true;
            buttonStart.Click += buttonStart_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(461, 338);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 1;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(78, 142);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(458, 23);
            progressBar1.TabIndex = 2;
            // 
            // labelProgress
            // 
            labelProgress.AutoSize = true;
            labelProgress.Location = new Point(78, 115);
            labelProgress.Name = "labelProgress";
            labelProgress.Size = new Size(23, 15);
            labelProgress.TabIndex = 3;
            labelProgress.Text = "0%";
            // 
            // labelResult
            // 
            labelResult.AutoSize = true;
            labelResult.Location = new Point(78, 194);
            labelResult.Name = "labelResult";
            labelResult.Size = new Size(42, 15);
            labelResult.TabIndex = 4;
            labelResult.Text = "Result:";
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(563, 131);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(94, 19);
            radioButton1.TabIndex = 5;
            radioButton1.TabStop = true;
            radioButton1.Text = "radioButton1";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(563, 214);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(94, 19);
            radioButton2.TabIndex = 6;
            radioButton2.TabStop = true;
            radioButton2.Text = "radioButton2";
            radioButton2.UseVisualStyleBackColor = true;
            radioButton2.CheckedChanged += radioButton2_CheckedChanged;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Location = new Point(563, 289);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(94, 19);
            radioButton3.TabIndex = 7;
            radioButton3.TabStop = true;
            radioButton3.Text = "radioButton3";
            radioButton3.UseVisualStyleBackColor = true;
            radioButton3.CheckedChanged += radioButton3_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(717, 388);
            Controls.Add(radioButton3);
            Controls.Add(radioButton2);
            Controls.Add(radioButton1);
            Controls.Add(labelResult);
            Controls.Add(labelProgress);
            Controls.Add(progressBar1);
            Controls.Add(buttonCancel);
            Controls.Add(buttonStart);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonStart;
        private Button buttonCancel;
        private ProgressBar progressBar1;
        private Label labelProgress;
        private Label labelResult;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private RadioButton radioButton3;
    }
}
