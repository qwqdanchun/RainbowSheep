namespace RainbowSheep
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
            this.textBoxFile = new System.Windows.Forms.TextBox();
            this.labelFile = new System.Windows.Forms.Label();
            this.textBoxString = new System.Windows.Forms.TextBox();
            this.buttonRandom = new System.Windows.Forms.Button();
            this.labelString = new System.Windows.Forms.Label();
            this.buttonChange = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxFile
            // 
            this.textBoxFile.AllowDrop = true;
            this.textBoxFile.Location = new System.Drawing.Point(53, 27);
            this.textBoxFile.Name = "textBoxFile";
            this.textBoxFile.Size = new System.Drawing.Size(372, 21);
            this.textBoxFile.TabIndex = 0;
            this.textBoxFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBoxFile_DragDrop);
            this.textBoxFile.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBoxFile_DragEnter);
            // 
            // labelFile
            // 
            this.labelFile.AutoSize = true;
            this.labelFile.Location = new System.Drawing.Point(12, 30);
            this.labelFile.Name = "labelFile";
            this.labelFile.Size = new System.Drawing.Size(35, 12);
            this.labelFile.TabIndex = 1;
            this.labelFile.Text = "File:";
            // 
            // textBoxString
            // 
            this.textBoxString.Location = new System.Drawing.Point(101, 67);
            this.textBoxString.Name = "textBoxString";
            this.textBoxString.Size = new System.Drawing.Size(256, 21);
            this.textBoxString.TabIndex = 2;
            // 
            // buttonRandom
            // 
            this.buttonRandom.Location = new System.Drawing.Point(363, 67);
            this.buttonRandom.Name = "buttonRandom";
            this.buttonRandom.Size = new System.Drawing.Size(62, 21);
            this.buttonRandom.TabIndex = 3;
            this.buttonRandom.Text = "Random";
            this.buttonRandom.UseVisualStyleBackColor = true;
            this.buttonRandom.Click += new System.EventHandler(this.buttonRandom_Click);
            // 
            // labelString
            // 
            this.labelString.AutoSize = true;
            this.labelString.Location = new System.Drawing.Point(12, 71);
            this.labelString.Name = "labelString";
            this.labelString.Size = new System.Drawing.Size(83, 12);
            this.labelString.TabIndex = 4;
            this.labelString.Text = "Extra String:";
            // 
            // buttonChange
            // 
            this.buttonChange.Location = new System.Drawing.Point(173, 102);
            this.buttonChange.Name = "buttonChange";
            this.buttonChange.Size = new System.Drawing.Size(92, 29);
            this.buttonChange.TabIndex = 5;
            this.buttonChange.Text = "Change";
            this.buttonChange.UseVisualStyleBackColor = true;
            this.buttonChange.Click += new System.EventHandler(this.buttonChange_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 143);
            this.Controls.Add(this.buttonChange);
            this.Controls.Add(this.labelString);
            this.Controls.Add(this.buttonRandom);
            this.Controls.Add(this.textBoxString);
            this.Controls.Add(this.labelFile);
            this.Controls.Add(this.textBoxFile);
            this.Name = "FormMain";
            this.Text = "RainbowSheep";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxFile;
        private System.Windows.Forms.Label labelFile;
        private System.Windows.Forms.TextBox textBoxString;
        private System.Windows.Forms.Button buttonRandom;
        private System.Windows.Forms.Label labelString;
        private System.Windows.Forms.Button buttonChange;
    }
}