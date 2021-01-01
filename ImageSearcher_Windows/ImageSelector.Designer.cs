namespace ImageSearcher_Windows
{
    partial class ImageSelector
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
            this.removedDuplicatesLabel = new System.Windows.Forms.Label();
            this.duplicateCountLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.totalImagesLabel = new System.Windows.Forms.Label();
            this.CopyBtn = new System.Windows.Forms.Button();
            this.videosLabel = new System.Windows.Forms.Label();
            this.totalVideosLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.copiedImagesLabel = new System.Windows.Forms.Label();
            this.copiedVideosLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.copiedVideoSizeLabel = new System.Windows.Forms.Label();
            this.totalVideoSizeLabel = new System.Windows.Forms.Label();
            this.siVideoSizeLabel = new System.Windows.Forms.Label();
            this.siImageSizeLabel = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.copiedImageSizeLabel = new System.Windows.Forms.Label();
            this.totalImageSizeLabel = new System.Windows.Forms.Label();
            this.CopyVideosBtn = new System.Windows.Forms.Button();
            this.CopyImagesBtn = new System.Windows.Forms.Button();
            this.CombinedTooLargeLabel = new System.Windows.Forms.Label();
            this.VideoSizeTooLargeLabel = new System.Windows.Forms.Label();
            this.ImageSizeTooLargeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // removedDuplicatesLabel
            // 
            this.removedDuplicatesLabel.AutoSize = true;
            this.removedDuplicatesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removedDuplicatesLabel.Location = new System.Drawing.Point(12, 162);
            this.removedDuplicatesLabel.Name = "removedDuplicatesLabel";
            this.removedDuplicatesLabel.Size = new System.Drawing.Size(265, 31);
            this.removedDuplicatesLabel.TabIndex = 2;
            this.removedDuplicatesLabel.Text = "Removed Duplicates";
            this.removedDuplicatesLabel.Click += new System.EventHandler(this.removedDuplicatesLabel_Click);
            // 
            // duplicateCountLabel
            // 
            this.duplicateCountLabel.AutoSize = true;
            this.duplicateCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.duplicateCountLabel.Location = new System.Drawing.Point(306, 162);
            this.duplicateCountLabel.Name = "duplicateCountLabel";
            this.duplicateCountLabel.Size = new System.Drawing.Size(29, 31);
            this.duplicateCountLabel.TabIndex = 3;
            this.duplicateCountLabel.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 31);
            this.label1.TabIndex = 4;
            this.label1.Text = "Copied Images";
            // 
            // totalImagesLabel
            // 
            this.totalImagesLabel.AutoSize = true;
            this.totalImagesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalImagesLabel.Location = new System.Drawing.Point(367, 24);
            this.totalImagesLabel.Name = "totalImagesLabel";
            this.totalImagesLabel.Size = new System.Drawing.Size(29, 31);
            this.totalImagesLabel.TabIndex = 5;
            this.totalImagesLabel.Text = "0";
            this.totalImagesLabel.Click += new System.EventHandler(this.totalImagesLabel_Click);
            // 
            // CopyBtn
            // 
            this.CopyBtn.Location = new System.Drawing.Point(572, 361);
            this.CopyBtn.Name = "CopyBtn";
            this.CopyBtn.Size = new System.Drawing.Size(229, 117);
            this.CopyBtn.TabIndex = 6;
            this.CopyBtn.Text = "Copy All";
            this.CopyBtn.UseVisualStyleBackColor = true;
            this.CopyBtn.Click += new System.EventHandler(this.CopyBtn_Click);
            // 
            // videosLabel
            // 
            this.videosLabel.AutoSize = true;
            this.videosLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.videosLabel.Location = new System.Drawing.Point(12, 84);
            this.videosLabel.Name = "videosLabel";
            this.videosLabel.Size = new System.Drawing.Size(190, 31);
            this.videosLabel.TabIndex = 7;
            this.videosLabel.Text = "Copied Videos";
            // 
            // totalVideosLabel
            // 
            this.totalVideosLabel.AutoSize = true;
            this.totalVideosLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalVideosLabel.Location = new System.Drawing.Point(367, 84);
            this.totalVideosLabel.Name = "totalVideosLabel";
            this.totalVideosLabel.Size = new System.Drawing.Size(29, 31);
            this.totalVideosLabel.TabIndex = 8;
            this.totalVideosLabel.Text = "0";
            this.totalVideosLabel.Click += new System.EventHandler(this.totalVideosLabel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(236, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Total copied videos may be lower than expected";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // copiedImagesLabel
            // 
            this.copiedImagesLabel.AutoSize = true;
            this.copiedImagesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.copiedImagesLabel.Location = new System.Drawing.Point(248, 24);
            this.copiedImagesLabel.Name = "copiedImagesLabel";
            this.copiedImagesLabel.Size = new System.Drawing.Size(29, 31);
            this.copiedImagesLabel.TabIndex = 10;
            this.copiedImagesLabel.Text = "0";
            // 
            // copiedVideosLabel
            // 
            this.copiedVideosLabel.AutoSize = true;
            this.copiedVideosLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.copiedVideosLabel.Location = new System.Drawing.Point(248, 84);
            this.copiedVideosLabel.Name = "copiedVideosLabel";
            this.copiedVideosLabel.Size = new System.Drawing.Size(29, 31);
            this.copiedVideosLabel.TabIndex = 11;
            this.copiedVideosLabel.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(339, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 31);
            this.label3.TabIndex = 12;
            this.label3.Text = "/";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(339, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 31);
            this.label4.TabIndex = 13;
            this.label4.Text = "/";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(604, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 31);
            this.label5.TabIndex = 16;
            this.label5.Text = "/";
            // 
            // copiedVideoSizeLabel
            // 
            this.copiedVideoSizeLabel.AutoSize = true;
            this.copiedVideoSizeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.copiedVideoSizeLabel.Location = new System.Drawing.Point(513, 84);
            this.copiedVideoSizeLabel.Name = "copiedVideoSizeLabel";
            this.copiedVideoSizeLabel.Size = new System.Drawing.Size(29, 31);
            this.copiedVideoSizeLabel.TabIndex = 15;
            this.copiedVideoSizeLabel.Text = "0";
            // 
            // totalVideoSizeLabel
            // 
            this.totalVideoSizeLabel.AutoSize = true;
            this.totalVideoSizeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalVideoSizeLabel.Location = new System.Drawing.Point(632, 84);
            this.totalVideoSizeLabel.Name = "totalVideoSizeLabel";
            this.totalVideoSizeLabel.Size = new System.Drawing.Size(29, 31);
            this.totalVideoSizeLabel.TabIndex = 14;
            this.totalVideoSizeLabel.Text = "0";
            // 
            // siVideoSizeLabel
            // 
            this.siVideoSizeLabel.AutoSize = true;
            this.siVideoSizeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.siVideoSizeLabel.Location = new System.Drawing.Point(748, 84);
            this.siVideoSizeLabel.Name = "siVideoSizeLabel";
            this.siVideoSizeLabel.Size = new System.Drawing.Size(32, 31);
            this.siVideoSizeLabel.TabIndex = 17;
            this.siVideoSizeLabel.Text = "B";
            // 
            // siImageSizeLabel
            // 
            this.siImageSizeLabel.AutoSize = true;
            this.siImageSizeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.siImageSizeLabel.Location = new System.Drawing.Point(748, 24);
            this.siImageSizeLabel.Name = "siImageSizeLabel";
            this.siImageSizeLabel.Size = new System.Drawing.Size(32, 31);
            this.siImageSizeLabel.TabIndex = 18;
            this.siImageSizeLabel.Text = "B";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(604, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(22, 31);
            this.label10.TabIndex = 21;
            this.label10.Text = "/";
            // 
            // copiedImageSizeLabel
            // 
            this.copiedImageSizeLabel.AutoSize = true;
            this.copiedImageSizeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.copiedImageSizeLabel.Location = new System.Drawing.Point(513, 24);
            this.copiedImageSizeLabel.Name = "copiedImageSizeLabel";
            this.copiedImageSizeLabel.Size = new System.Drawing.Size(29, 31);
            this.copiedImageSizeLabel.TabIndex = 20;
            this.copiedImageSizeLabel.Text = "0";
            // 
            // totalImageSizeLabel
            // 
            this.totalImageSizeLabel.AutoSize = true;
            this.totalImageSizeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalImageSizeLabel.Location = new System.Drawing.Point(632, 24);
            this.totalImageSizeLabel.Name = "totalImageSizeLabel";
            this.totalImageSizeLabel.Size = new System.Drawing.Size(29, 31);
            this.totalImageSizeLabel.TabIndex = 19;
            this.totalImageSizeLabel.Text = "0";
            // 
            // CopyVideosBtn
            // 
            this.CopyVideosBtn.Location = new System.Drawing.Point(337, 361);
            this.CopyVideosBtn.Name = "CopyVideosBtn";
            this.CopyVideosBtn.Size = new System.Drawing.Size(229, 117);
            this.CopyVideosBtn.TabIndex = 22;
            this.CopyVideosBtn.Text = "Copy Videos";
            this.CopyVideosBtn.UseVisualStyleBackColor = true;
            this.CopyVideosBtn.Click += new System.EventHandler(this.CopyBtn_Click);
            // 
            // CopyImagesBtn
            // 
            this.CopyImagesBtn.Location = new System.Drawing.Point(99, 361);
            this.CopyImagesBtn.Name = "CopyImagesBtn";
            this.CopyImagesBtn.Size = new System.Drawing.Size(229, 117);
            this.CopyImagesBtn.TabIndex = 23;
            this.CopyImagesBtn.Text = "Copy Images";
            this.CopyImagesBtn.UseVisualStyleBackColor = true;
            this.CopyImagesBtn.Click += new System.EventHandler(this.CopyBtn_Click);
            // 
            // CombinedTooLargeLabel
            // 
            this.CombinedTooLargeLabel.AutoSize = true;
            this.CombinedTooLargeLabel.Enabled = false;
            this.CombinedTooLargeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CombinedTooLargeLabel.ForeColor = System.Drawing.Color.Red;
            this.CombinedTooLargeLabel.Location = new System.Drawing.Point(17, 211);
            this.CombinedTooLargeLabel.Name = "CombinedTooLargeLabel";
            this.CombinedTooLargeLabel.Size = new System.Drawing.Size(750, 25);
            this.CombinedTooLargeLabel.TabIndex = 24;
            this.CombinedTooLargeLabel.Text = "Combined Size of Images and Videos Larger than Available Space on Selected Drive";
            this.CombinedTooLargeLabel.Visible = false;
            // 
            // VideoSizeTooLargeLabel
            // 
            this.VideoSizeTooLargeLabel.AutoSize = true;
            this.VideoSizeTooLargeLabel.Enabled = false;
            this.VideoSizeTooLargeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VideoSizeTooLargeLabel.ForeColor = System.Drawing.Color.Red;
            this.VideoSizeTooLargeLabel.Location = new System.Drawing.Point(18, 211);
            this.VideoSizeTooLargeLabel.Name = "VideoSizeTooLargeLabel";
            this.VideoSizeTooLargeLabel.Size = new System.Drawing.Size(548, 25);
            this.VideoSizeTooLargeLabel.TabIndex = 25;
            this.VideoSizeTooLargeLabel.Text = "Size of Videos Larger than Available Space on Selected Drive";
            this.VideoSizeTooLargeLabel.Visible = false;
            // 
            // ImageSizeTooLargeLabel
            // 
            this.ImageSizeTooLargeLabel.AutoSize = true;
            this.ImageSizeTooLargeLabel.Enabled = false;
            this.ImageSizeTooLargeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ImageSizeTooLargeLabel.ForeColor = System.Drawing.Color.Red;
            this.ImageSizeTooLargeLabel.Location = new System.Drawing.Point(17, 211);
            this.ImageSizeTooLargeLabel.Name = "ImageSizeTooLargeLabel";
            this.ImageSizeTooLargeLabel.Size = new System.Drawing.Size(551, 25);
            this.ImageSizeTooLargeLabel.TabIndex = 26;
            this.ImageSizeTooLargeLabel.Text = "Size of Images Larger than Available Space on Selected Drive";
            this.ImageSizeTooLargeLabel.Visible = false;
            // 
            // ImageSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 490);
            this.Controls.Add(this.ImageSizeTooLargeLabel);
            this.Controls.Add(this.VideoSizeTooLargeLabel);
            this.Controls.Add(this.CombinedTooLargeLabel);
            this.Controls.Add(this.CopyImagesBtn);
            this.Controls.Add(this.CopyVideosBtn);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.copiedImageSizeLabel);
            this.Controls.Add(this.totalImageSizeLabel);
            this.Controls.Add(this.siImageSizeLabel);
            this.Controls.Add(this.siVideoSizeLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.copiedVideoSizeLabel);
            this.Controls.Add(this.totalVideoSizeLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.copiedVideosLabel);
            this.Controls.Add(this.copiedImagesLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.totalVideosLabel);
            this.Controls.Add(this.videosLabel);
            this.Controls.Add(this.CopyBtn);
            this.Controls.Add(this.totalImagesLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.duplicateCountLabel);
            this.Controls.Add(this.removedDuplicatesLabel);
            this.Name = "ImageSelector";
            this.Text = "ImageSelector";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label removedDuplicatesLabel;
        private System.Windows.Forms.Label duplicateCountLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label totalImagesLabel;
        private System.Windows.Forms.Button CopyBtn;
        private System.Windows.Forms.Label videosLabel;
        private System.Windows.Forms.Label totalVideosLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label copiedImagesLabel;
        private System.Windows.Forms.Label copiedVideosLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label copiedVideoSizeLabel;
        private System.Windows.Forms.Label totalVideoSizeLabel;
        private System.Windows.Forms.Label siVideoSizeLabel;
        private System.Windows.Forms.Label siImageSizeLabel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label copiedImageSizeLabel;
        private System.Windows.Forms.Label totalImageSizeLabel;
        private System.Windows.Forms.Button CopyVideosBtn;
        private System.Windows.Forms.Button CopyImagesBtn;
        private System.Windows.Forms.Label CombinedTooLargeLabel;
        private System.Windows.Forms.Label VideoSizeTooLargeLabel;
        private System.Windows.Forms.Label ImageSizeTooLargeLabel;
    }
}