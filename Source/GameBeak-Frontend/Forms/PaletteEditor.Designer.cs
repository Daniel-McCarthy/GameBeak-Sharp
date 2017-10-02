namespace GameBeak_Frontend.Forms
{
    partial class PaletteEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaletteEditor));
            this.paletteSelectGroupBox = new System.Windows.Forms.GroupBox();
            this.okButton = new System.Windows.Forms.Button();
            this.palettePreviewGroupBox = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // paletteSelectGroupBox
            // 
            this.paletteSelectGroupBox.Location = new System.Drawing.Point(12, 12);
            this.paletteSelectGroupBox.Name = "paletteSelectGroupBox";
            this.paletteSelectGroupBox.Size = new System.Drawing.Size(260, 131);
            this.paletteSelectGroupBox.TabIndex = 0;
            this.paletteSelectGroupBox.TabStop = false;
            this.paletteSelectGroupBox.Text = "Palette Select";
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(197, 226);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "Ok";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // palettePreviewGroupBox
            // 
            this.palettePreviewGroupBox.Location = new System.Drawing.Point(12, 149);
            this.palettePreviewGroupBox.Name = "palettePreviewGroupBox";
            this.palettePreviewGroupBox.Size = new System.Drawing.Size(260, 71);
            this.palettePreviewGroupBox.TabIndex = 2;
            this.palettePreviewGroupBox.TabStop = false;
            this.palettePreviewGroupBox.Text = "Palette Preview";
            // 
            // PaletteEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.palettePreviewGroupBox);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.paletteSelectGroupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PaletteEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GameBeak - Palette";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox paletteSelectGroupBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.GroupBox palettePreviewGroupBox;
    }
}