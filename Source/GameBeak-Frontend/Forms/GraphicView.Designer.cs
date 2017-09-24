namespace GameBeak_Frontend.Forms
{
    partial class GraphicView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GraphicView));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tileViewRadioButton = new System.Windows.Forms.RadioButton();
            this.fullViewRadioButton = new System.Windows.Forms.RadioButton();
            this.refreshButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(285, 260);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // tileViewRadioButton
            // 
            this.tileViewRadioButton.AutoSize = true;
            this.tileViewRadioButton.Location = new System.Drawing.Point(12, 266);
            this.tileViewRadioButton.Name = "tileViewRadioButton";
            this.tileViewRadioButton.Size = new System.Drawing.Size(68, 17);
            this.tileViewRadioButton.TabIndex = 1;
            this.tileViewRadioButton.TabStop = true;
            this.tileViewRadioButton.Text = "Tile View";
            this.tileViewRadioButton.UseVisualStyleBackColor = true;
            // 
            // fullViewRadioButton
            // 
            this.fullViewRadioButton.AutoSize = true;
            this.fullViewRadioButton.Location = new System.Drawing.Point(205, 266);
            this.fullViewRadioButton.Name = "fullViewRadioButton";
            this.fullViewRadioButton.Size = new System.Drawing.Size(67, 17);
            this.fullViewRadioButton.TabIndex = 2;
            this.fullViewRadioButton.TabStop = true;
            this.fullViewRadioButton.Text = "Full View";
            this.fullViewRadioButton.UseVisualStyleBackColor = true;
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(102, 277);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(75, 23);
            this.refreshButton.TabIndex = 3;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // GraphicView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 312);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.fullViewRadioButton);
            this.Controls.Add(this.tileViewRadioButton);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GraphicView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GameBeak - Graphic View";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RadioButton tileViewRadioButton;
        private System.Windows.Forms.RadioButton fullViewRadioButton;
        private System.Windows.Forms.Button refreshButton;
    }
}