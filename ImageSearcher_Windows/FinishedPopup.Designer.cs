namespace ImageSearcher_Windows
{
    partial class FinishedPopup
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
            this.CopyingCompleteLbl = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CopyingCompleteLbl
            // 
            this.CopyingCompleteLbl.AutoSize = true;
            this.CopyingCompleteLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CopyingCompleteLbl.Location = new System.Drawing.Point(14, 15);
            this.CopyingCompleteLbl.Name = "CopyingCompleteLbl";
            this.CopyingCompleteLbl.Size = new System.Drawing.Size(237, 31);
            this.CopyingCompleteLbl.TabIndex = 0;
            this.CopyingCompleteLbl.Text = "Copying Complete";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(223, 80);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FinishedPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 115);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.CopyingCompleteLbl);
            this.Name = "FinishedPopup";
            this.Text = "FinishedPopup";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label CopyingCompleteLbl;
        private System.Windows.Forms.Button btnClose;
    }
}