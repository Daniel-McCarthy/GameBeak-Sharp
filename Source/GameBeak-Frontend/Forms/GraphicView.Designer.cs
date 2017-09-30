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
            this.spriteViewRadioButton = new System.Windows.Forms.RadioButton();
            this.spriteViewGroupBox = new System.Windows.Forms.GroupBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.sprite1GroupBox = new System.Windows.Forms.GroupBox();
            this.sprite1XPosLabel = new System.Windows.Forms.Label();
            this.sprite1YPosLabel = new System.Windows.Forms.Label();
            this.sprite1TileNumberLabel = new System.Windows.Forms.Label();
            this.sprite1OAMAddressLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.sprite1XPosValueLabel = new System.Windows.Forms.Label();
            this.sprite1YPosValueLabel = new System.Windows.Forms.Label();
            this.sprite1TileNumberValueLabel = new System.Windows.Forms.Label();
            this.sprite1TileAddressValueLabel = new System.Windows.Forms.Label();
            this.sprite1OAMAddressValueLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.spriteViewGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.sprite1GroupBox.SuspendLayout();
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
            this.tileViewRadioButton.CheckedChanged += new System.EventHandler(this.tileViewRadioButton_CheckedChanged);
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
            this.fullViewRadioButton.CheckedChanged += new System.EventHandler(this.fullViewRadioButton_CheckedChanged);
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(102, 289);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(75, 23);
            this.refreshButton.TabIndex = 3;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // spriteViewRadioButton
            // 
            this.spriteViewRadioButton.AutoSize = true;
            this.spriteViewRadioButton.Location = new System.Drawing.Point(101, 266);
            this.spriteViewRadioButton.Name = "spriteViewRadioButton";
            this.spriteViewRadioButton.Size = new System.Drawing.Size(78, 17);
            this.spriteViewRadioButton.TabIndex = 4;
            this.spriteViewRadioButton.TabStop = true;
            this.spriteViewRadioButton.Text = "Sprite View";
            this.spriteViewRadioButton.UseVisualStyleBackColor = true;
            this.spriteViewRadioButton.CheckedChanged += new System.EventHandler(this.spriteViewRadioButton_CheckedChanged);
            // 
            // spriteViewGroupBox
            // 
            this.spriteViewGroupBox.Controls.Add(this.sprite1GroupBox);
            this.spriteViewGroupBox.Location = new System.Drawing.Point(12, 12);
            this.spriteViewGroupBox.Name = "spriteViewGroupBox";
            this.spriteViewGroupBox.Size = new System.Drawing.Size(260, 235);
            this.spriteViewGroupBox.TabIndex = 5;
            this.spriteViewGroupBox.TabStop = false;
            this.spriteViewGroupBox.Text = "Sprite View";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.Menu;
            this.pictureBox2.Location = new System.Drawing.Point(6, 19);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // sprite1GroupBox
            // 
            this.sprite1GroupBox.Controls.Add(this.sprite1TileAddressValueLabel);
            this.sprite1GroupBox.Controls.Add(this.sprite1OAMAddressValueLabel);
            this.sprite1GroupBox.Controls.Add(this.sprite1TileNumberValueLabel);
            this.sprite1GroupBox.Controls.Add(this.sprite1YPosValueLabel);
            this.sprite1GroupBox.Controls.Add(this.sprite1XPosValueLabel);
            this.sprite1GroupBox.Controls.Add(this.label1);
            this.sprite1GroupBox.Controls.Add(this.sprite1OAMAddressLabel);
            this.sprite1GroupBox.Controls.Add(this.sprite1TileNumberLabel);
            this.sprite1GroupBox.Controls.Add(this.sprite1YPosLabel);
            this.sprite1GroupBox.Controls.Add(this.sprite1XPosLabel);
            this.sprite1GroupBox.Controls.Add(this.pictureBox2);
            this.sprite1GroupBox.Location = new System.Drawing.Point(6, 19);
            this.sprite1GroupBox.Name = "sprite1GroupBox";
            this.sprite1GroupBox.Size = new System.Drawing.Size(248, 61);
            this.sprite1GroupBox.TabIndex = 1;
            this.sprite1GroupBox.TabStop = false;
            this.sprite1GroupBox.Text = "1";
            // 
            // sprite1XPosLabel
            // 
            this.sprite1XPosLabel.AutoSize = true;
            this.sprite1XPosLabel.Location = new System.Drawing.Point(41, 19);
            this.sprite1XPosLabel.Name = "sprite1XPosLabel";
            this.sprite1XPosLabel.Size = new System.Drawing.Size(38, 13);
            this.sprite1XPosLabel.TabIndex = 1;
            this.sprite1XPosLabel.Text = "X Pos:";
            // 
            // sprite1YPosLabel
            // 
            this.sprite1YPosLabel.AutoSize = true;
            this.sprite1YPosLabel.Location = new System.Drawing.Point(41, 38);
            this.sprite1YPosLabel.Name = "sprite1YPosLabel";
            this.sprite1YPosLabel.Size = new System.Drawing.Size(38, 13);
            this.sprite1YPosLabel.TabIndex = 2;
            this.sprite1YPosLabel.Text = "Y Pos:";
            // 
            // sprite1TileNumberLabel
            // 
            this.sprite1TileNumberLabel.AutoSize = true;
            this.sprite1TileNumberLabel.Location = new System.Drawing.Point(94, 19);
            this.sprite1TileNumberLabel.Name = "sprite1TileNumberLabel";
            this.sprite1TileNumberLabel.Size = new System.Drawing.Size(37, 13);
            this.sprite1TileNumberLabel.TabIndex = 3;
            this.sprite1TileNumberLabel.Text = "Tile #:";
            // 
            // sprite1OAMAddressLabel
            // 
            this.sprite1OAMAddressLabel.AutoSize = true;
            this.sprite1OAMAddressLabel.Location = new System.Drawing.Point(147, 19);
            this.sprite1OAMAddressLabel.Name = "sprite1OAMAddressLabel";
            this.sprite1OAMAddressLabel.Size = new System.Drawing.Size(34, 13);
            this.sprite1OAMAddressLabel.TabIndex = 4;
            this.sprite1OAMAddressLabel.Text = "OAM:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(147, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tile Pos:";
            // 
            // sprite1XPosValueLabel
            // 
            this.sprite1XPosValueLabel.AutoSize = true;
            this.sprite1XPosValueLabel.Location = new System.Drawing.Point(81, 20);
            this.sprite1XPosValueLabel.Name = "sprite1XPosValueLabel";
            this.sprite1XPosValueLabel.Size = new System.Drawing.Size(0, 13);
            this.sprite1XPosValueLabel.TabIndex = 2;
            // 
            // sprite1YPosValueLabel
            // 
            this.sprite1YPosValueLabel.AutoSize = true;
            this.sprite1YPosValueLabel.Location = new System.Drawing.Point(81, 39);
            this.sprite1YPosValueLabel.Name = "sprite1YPosValueLabel";
            this.sprite1YPosValueLabel.Size = new System.Drawing.Size(0, 13);
            this.sprite1YPosValueLabel.TabIndex = 6;
            // 
            // sprite1TileNumberValueLabel
            // 
            this.sprite1TileNumberValueLabel.AutoSize = true;
            this.sprite1TileNumberValueLabel.Location = new System.Drawing.Point(132, 20);
            this.sprite1TileNumberValueLabel.Name = "sprite1TileNumberValueLabel";
            this.sprite1TileNumberValueLabel.Size = new System.Drawing.Size(0, 13);
            this.sprite1TileNumberValueLabel.TabIndex = 7;
            // 
            // sprite1TileAddressValueLabel
            // 
            this.sprite1TileAddressValueLabel.AutoSize = true;
            this.sprite1TileAddressValueLabel.Location = new System.Drawing.Point(198, 39);
            this.sprite1TileAddressValueLabel.Name = "sprite1TileAddressValueLabel";
            this.sprite1TileAddressValueLabel.Size = new System.Drawing.Size(0, 13);
            this.sprite1TileAddressValueLabel.TabIndex = 9;
            // 
            // sprite1OAMAddressValueLabel
            // 
            this.sprite1OAMAddressValueLabel.AutoSize = true;
            this.sprite1OAMAddressValueLabel.Location = new System.Drawing.Point(198, 20);
            this.sprite1OAMAddressValueLabel.Name = "sprite1OAMAddressValueLabel";
            this.sprite1OAMAddressValueLabel.Size = new System.Drawing.Size(0, 13);
            this.sprite1OAMAddressValueLabel.TabIndex = 8;
            // 
            // GraphicView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 319);
            this.Controls.Add(this.spriteViewGroupBox);
            this.Controls.Add(this.spriteViewRadioButton);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.fullViewRadioButton);
            this.Controls.Add(this.tileViewRadioButton);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GraphicView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GameBeak - Graphic View";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.spriteViewGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.sprite1GroupBox.ResumeLayout(false);
            this.sprite1GroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RadioButton tileViewRadioButton;
        private System.Windows.Forms.RadioButton fullViewRadioButton;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.RadioButton spriteViewRadioButton;
        private System.Windows.Forms.GroupBox spriteViewGroupBox;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.GroupBox sprite1GroupBox;
        private System.Windows.Forms.Label sprite1YPosLabel;
        private System.Windows.Forms.Label sprite1XPosLabel;
        private System.Windows.Forms.Label sprite1TileNumberLabel;
        private System.Windows.Forms.Label sprite1OAMAddressLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label sprite1YPosValueLabel;
        private System.Windows.Forms.Label sprite1XPosValueLabel;
        private System.Windows.Forms.Label sprite1TileNumberValueLabel;
        private System.Windows.Forms.Label sprite1TileAddressValueLabel;
        private System.Windows.Forms.Label sprite1OAMAddressValueLabel;
    }
}