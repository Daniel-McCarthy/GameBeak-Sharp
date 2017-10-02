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
            this.paletteNameListBox = new System.Windows.Forms.ListBox();
            this.bgColorPreview1 = new System.Windows.Forms.PictureBox();
            this.bgColorPreview2 = new System.Windows.Forms.PictureBox();
            this.bgColorPreview4 = new System.Windows.Forms.PictureBox();
            this.bgColorPreview3 = new System.Windows.Forms.PictureBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.bp0ColorPreview4 = new System.Windows.Forms.PictureBox();
            this.bp0ColorPreview3 = new System.Windows.Forms.PictureBox();
            this.bp0ColorPreview2 = new System.Windows.Forms.PictureBox();
            this.bp0ColorPreview1 = new System.Windows.Forms.PictureBox();
            this.bp1ColorPreview4 = new System.Windows.Forms.PictureBox();
            this.bp1ColorPreview3 = new System.Windows.Forms.PictureBox();
            this.bp1ColorPreview2 = new System.Windows.Forms.PictureBox();
            this.bp1ColorPreview1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.paletteSelectGroupBox.SuspendLayout();
            this.palettePreviewGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bgColorPreview1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bgColorPreview2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bgColorPreview4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bgColorPreview3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bp0ColorPreview4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bp0ColorPreview3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bp0ColorPreview2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bp0ColorPreview1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bp1ColorPreview4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bp1ColorPreview3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bp1ColorPreview2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bp1ColorPreview1)).BeginInit();
            this.SuspendLayout();
            // 
            // paletteSelectGroupBox
            // 
            this.paletteSelectGroupBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.paletteSelectGroupBox.Controls.Add(this.paletteNameListBox);
            this.paletteSelectGroupBox.Location = new System.Drawing.Point(12, 12);
            this.paletteSelectGroupBox.Name = "paletteSelectGroupBox";
            this.paletteSelectGroupBox.Size = new System.Drawing.Size(260, 131);
            this.paletteSelectGroupBox.TabIndex = 0;
            this.paletteSelectGroupBox.TabStop = false;
            this.paletteSelectGroupBox.Text = "Palette Select";
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(197, 288);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "Ok";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // palettePreviewGroupBox
            // 
            this.palettePreviewGroupBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.palettePreviewGroupBox.Controls.Add(this.label3);
            this.palettePreviewGroupBox.Controls.Add(this.label2);
            this.palettePreviewGroupBox.Controls.Add(this.label1);
            this.palettePreviewGroupBox.Controls.Add(this.bp1ColorPreview4);
            this.palettePreviewGroupBox.Controls.Add(this.bp1ColorPreview3);
            this.palettePreviewGroupBox.Controls.Add(this.bp1ColorPreview2);
            this.palettePreviewGroupBox.Controls.Add(this.bp1ColorPreview1);
            this.palettePreviewGroupBox.Controls.Add(this.bp0ColorPreview4);
            this.palettePreviewGroupBox.Controls.Add(this.bp0ColorPreview3);
            this.palettePreviewGroupBox.Controls.Add(this.bp0ColorPreview2);
            this.palettePreviewGroupBox.Controls.Add(this.bp0ColorPreview1);
            this.palettePreviewGroupBox.Controls.Add(this.bgColorPreview4);
            this.palettePreviewGroupBox.Controls.Add(this.bgColorPreview3);
            this.palettePreviewGroupBox.Controls.Add(this.bgColorPreview2);
            this.palettePreviewGroupBox.Controls.Add(this.bgColorPreview1);
            this.palettePreviewGroupBox.Location = new System.Drawing.Point(12, 149);
            this.palettePreviewGroupBox.Name = "palettePreviewGroupBox";
            this.palettePreviewGroupBox.Size = new System.Drawing.Size(260, 133);
            this.palettePreviewGroupBox.TabIndex = 2;
            this.palettePreviewGroupBox.TabStop = false;
            this.palettePreviewGroupBox.Text = "Palette Preview";
            // 
            // paletteNameListBox
            // 
            this.paletteNameListBox.FormattingEnabled = true;
            this.paletteNameListBox.Location = new System.Drawing.Point(19, 19);
            this.paletteNameListBox.Name = "paletteNameListBox";
            this.paletteNameListBox.Size = new System.Drawing.Size(224, 95);
            this.paletteNameListBox.TabIndex = 0;
            // 
            // bgColorPreview1
            // 
            this.bgColorPreview1.BackColor = System.Drawing.Color.White;
            this.bgColorPreview1.Location = new System.Drawing.Point(67, 19);
            this.bgColorPreview1.Name = "bgColorPreview1";
            this.bgColorPreview1.Size = new System.Drawing.Size(32, 32);
            this.bgColorPreview1.TabIndex = 0;
            this.bgColorPreview1.TabStop = false;
            // 
            // bgColorPreview2
            // 
            this.bgColorPreview2.BackColor = System.Drawing.Color.White;
            this.bgColorPreview2.Location = new System.Drawing.Point(111, 19);
            this.bgColorPreview2.Name = "bgColorPreview2";
            this.bgColorPreview2.Size = new System.Drawing.Size(32, 32);
            this.bgColorPreview2.TabIndex = 1;
            this.bgColorPreview2.TabStop = false;
            // 
            // bgColorPreview4
            // 
            this.bgColorPreview4.BackColor = System.Drawing.Color.White;
            this.bgColorPreview4.Location = new System.Drawing.Point(198, 19);
            this.bgColorPreview4.Name = "bgColorPreview4";
            this.bgColorPreview4.Size = new System.Drawing.Size(32, 32);
            this.bgColorPreview4.TabIndex = 3;
            this.bgColorPreview4.TabStop = false;
            // 
            // bgColorPreview3
            // 
            this.bgColorPreview3.BackColor = System.Drawing.Color.White;
            this.bgColorPreview3.Location = new System.Drawing.Point(156, 19);
            this.bgColorPreview3.Name = "bgColorPreview3";
            this.bgColorPreview3.Size = new System.Drawing.Size(32, 32);
            this.bgColorPreview3.TabIndex = 2;
            this.bgColorPreview3.TabStop = false;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(111, 288);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // bp0ColorPreview4
            // 
            this.bp0ColorPreview4.BackColor = System.Drawing.Color.White;
            this.bp0ColorPreview4.Location = new System.Drawing.Point(199, 57);
            this.bp0ColorPreview4.Name = "bp0ColorPreview4";
            this.bp0ColorPreview4.Size = new System.Drawing.Size(32, 32);
            this.bp0ColorPreview4.TabIndex = 7;
            this.bp0ColorPreview4.TabStop = false;
            // 
            // bp0ColorPreview3
            // 
            this.bp0ColorPreview3.BackColor = System.Drawing.Color.White;
            this.bp0ColorPreview3.Location = new System.Drawing.Point(157, 57);
            this.bp0ColorPreview3.Name = "bp0ColorPreview3";
            this.bp0ColorPreview3.Size = new System.Drawing.Size(32, 32);
            this.bp0ColorPreview3.TabIndex = 6;
            this.bp0ColorPreview3.TabStop = false;
            // 
            // bp0ColorPreview2
            // 
            this.bp0ColorPreview2.BackColor = System.Drawing.Color.White;
            this.bp0ColorPreview2.Location = new System.Drawing.Point(112, 57);
            this.bp0ColorPreview2.Name = "bp0ColorPreview2";
            this.bp0ColorPreview2.Size = new System.Drawing.Size(32, 32);
            this.bp0ColorPreview2.TabIndex = 5;
            this.bp0ColorPreview2.TabStop = false;
            // 
            // bp0ColorPreview1
            // 
            this.bp0ColorPreview1.BackColor = System.Drawing.Color.White;
            this.bp0ColorPreview1.Location = new System.Drawing.Point(67, 57);
            this.bp0ColorPreview1.Name = "bp0ColorPreview1";
            this.bp0ColorPreview1.Size = new System.Drawing.Size(32, 32);
            this.bp0ColorPreview1.TabIndex = 4;
            this.bp0ColorPreview1.TabStop = false;
            // 
            // bp1ColorPreview4
            // 
            this.bp1ColorPreview4.BackColor = System.Drawing.Color.White;
            this.bp1ColorPreview4.Location = new System.Drawing.Point(199, 95);
            this.bp1ColorPreview4.Name = "bp1ColorPreview4";
            this.bp1ColorPreview4.Size = new System.Drawing.Size(32, 32);
            this.bp1ColorPreview4.TabIndex = 11;
            this.bp1ColorPreview4.TabStop = false;
            // 
            // bp1ColorPreview3
            // 
            this.bp1ColorPreview3.BackColor = System.Drawing.Color.White;
            this.bp1ColorPreview3.Location = new System.Drawing.Point(157, 95);
            this.bp1ColorPreview3.Name = "bp1ColorPreview3";
            this.bp1ColorPreview3.Size = new System.Drawing.Size(32, 32);
            this.bp1ColorPreview3.TabIndex = 10;
            this.bp1ColorPreview3.TabStop = false;
            // 
            // bp1ColorPreview2
            // 
            this.bp1ColorPreview2.BackColor = System.Drawing.Color.White;
            this.bp1ColorPreview2.Location = new System.Drawing.Point(112, 95);
            this.bp1ColorPreview2.Name = "bp1ColorPreview2";
            this.bp1ColorPreview2.Size = new System.Drawing.Size(32, 32);
            this.bp1ColorPreview2.TabIndex = 9;
            this.bp1ColorPreview2.TabStop = false;
            // 
            // bp1ColorPreview1
            // 
            this.bp1ColorPreview1.BackColor = System.Drawing.Color.White;
            this.bp1ColorPreview1.Location = new System.Drawing.Point(67, 95);
            this.bp1ColorPreview1.Name = "bp1ColorPreview1";
            this.bp1ColorPreview1.Size = new System.Drawing.Size(32, 32);
            this.bp1ColorPreview1.TabIndex = 8;
            this.bp1ColorPreview1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "BG:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "BP0:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "BP1:";
            // 
            // PaletteEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.ClientSize = new System.Drawing.Size(284, 323);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.palettePreviewGroupBox);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.paletteSelectGroupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PaletteEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GameBeak - Palette";
            this.Load += new System.EventHandler(this.PaletteEditor_Load);
            this.paletteSelectGroupBox.ResumeLayout(false);
            this.palettePreviewGroupBox.ResumeLayout(false);
            this.palettePreviewGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bgColorPreview1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bgColorPreview2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bgColorPreview4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bgColorPreview3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bp0ColorPreview4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bp0ColorPreview3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bp0ColorPreview2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bp0ColorPreview1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bp1ColorPreview4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bp1ColorPreview3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bp1ColorPreview2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bp1ColorPreview1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox paletteSelectGroupBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.GroupBox palettePreviewGroupBox;
        private System.Windows.Forms.ListBox paletteNameListBox;
        private System.Windows.Forms.PictureBox bgColorPreview1;
        private System.Windows.Forms.PictureBox bgColorPreview4;
        private System.Windows.Forms.PictureBox bgColorPreview3;
        private System.Windows.Forms.PictureBox bgColorPreview2;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.PictureBox bp1ColorPreview4;
        private System.Windows.Forms.PictureBox bp1ColorPreview3;
        private System.Windows.Forms.PictureBox bp1ColorPreview2;
        private System.Windows.Forms.PictureBox bp1ColorPreview1;
        private System.Windows.Forms.PictureBox bp0ColorPreview4;
        private System.Windows.Forms.PictureBox bp0ColorPreview3;
        private System.Windows.Forms.PictureBox bp0ColorPreview2;
        private System.Windows.Forms.PictureBox bp0ColorPreview1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}