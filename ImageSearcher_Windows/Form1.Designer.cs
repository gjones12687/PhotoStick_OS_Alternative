namespace ImageSearcher_Windows
{
    partial class Form1
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
            this.btnSearch = new System.Windows.Forms.Button();
            this.chkListFormats = new System.Windows.Forms.CheckedListBox();
            this.saveLocationLabel = new System.Windows.Forms.Label();
            this.selectSaveLocationDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.selectedFolderText = new System.Windows.Forms.TextBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.Control;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSearch.Location = new System.Drawing.Point(522, 305);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(264, 138);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // chkListFormats
            // 
            this.chkListFormats.FormattingEnabled = true;
            this.chkListFormats.Items.AddRange(new object[] {
            "Images",
            "Videos"});
            this.chkListFormats.Location = new System.Drawing.Point(30, 23);
            this.chkListFormats.Name = "chkListFormats";
            this.chkListFormats.Size = new System.Drawing.Size(273, 394);
            this.chkListFormats.TabIndex = 1;
            this.chkListFormats.SelectedIndexChanged += new System.EventHandler(this.chkListFormats_SelectedIndexChanged);
            // 
            // saveLocationLabel
            // 
            this.saveLocationLabel.AutoSize = true;
            this.saveLocationLabel.Location = new System.Drawing.Point(354, 23);
            this.saveLocationLabel.Name = "saveLocationLabel";
            this.saveLocationLabel.Size = new System.Drawing.Size(76, 13);
            this.saveLocationLabel.TabIndex = 2;
            this.saveLocationLabel.Text = "Save Location";
            // 
            // selectSaveLocationDialog
            // 
            this.selectSaveLocationDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // selectedFolderText
            // 
            this.selectedFolderText.Location = new System.Drawing.Point(357, 40);
            this.selectedFolderText.Name = "selectedFolderText";
            this.selectedFolderText.Size = new System.Drawing.Size(369, 20);
            this.selectedFolderText.TabIndex = 3;
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(732, 37);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(54, 23);
            this.browseButton.TabIndex = 4;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.selectedFolderText);
            this.Controls.Add(this.saveLocationLabel);
            this.Controls.Add(this.chkListFormats);
            this.Controls.Add(this.btnSearch);
            this.Name = "Form1";
            this.Text = "Image Searcher";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.CheckedListBox chkListFormats;
        private System.Windows.Forms.Label saveLocationLabel;
        private System.Windows.Forms.FolderBrowserDialog selectSaveLocationDialog;
        private System.Windows.Forms.TextBox selectedFolderText;
        private System.Windows.Forms.Button browseButton;
    }
}

