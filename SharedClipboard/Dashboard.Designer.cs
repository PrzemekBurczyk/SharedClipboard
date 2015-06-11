namespace SharedClipboard
{
    partial class Dashboard
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
            this.lbCopyKey = new System.Windows.Forms.Label();
            this.tbCopyHotKey = new System.Windows.Forms.TextBox();
            this.btnCopyRegister = new System.Windows.Forms.Button();
            this.btnCopyUnregister = new System.Windows.Forms.Button();
            this.lbNotice = new System.Windows.Forms.Label();
            this.tbLocalClipboardText = new System.Windows.Forms.TextBox();
            this.lbClipboard = new System.Windows.Forms.Label();
            this.pbLocalClipboardImage = new System.Windows.Forms.PictureBox();
            this.lbLocalClipboardFileDropList = new System.Windows.Forms.ListBox();
            this.btnPasteUnregister = new System.Windows.Forms.Button();
            this.btnPasteRegister = new System.Windows.Forms.Button();
            this.tbPasteHotKey = new System.Windows.Forms.TextBox();
            this.lbPasteKey = new System.Windows.Forms.Label();
            this.lbLocalText = new System.Windows.Forms.Label();
            this.lbLocalImage = new System.Windows.Forms.Label();
            this.lbLocalFiles = new System.Windows.Forms.Label();
            this.lbShared1Files = new System.Windows.Forms.Label();
            this.lbShared1Image = new System.Windows.Forms.Label();
            this.lbShared1Text = new System.Windows.Forms.Label();
            this.lbSharedClipboard1FileDropList = new System.Windows.Forms.ListBox();
            this.pbSharedClipboard1Image = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbSharedClipboard1Text = new System.Windows.Forms.TextBox();
            this.lbLocalName = new System.Windows.Forms.Label();
            this.lbShared1Name = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbLocalClipboardImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSharedClipboard1Image)).BeginInit();
            this.SuspendLayout();
            // 
            // lbCopyKey
            // 
            this.lbCopyKey.AutoSize = true;
            this.lbCopyKey.Location = new System.Drawing.Point(11, 15);
            this.lbCopyKey.Name = "lbCopyKey";
            this.lbCopyKey.Size = new System.Drawing.Size(68, 13);
            this.lbCopyKey.TabIndex = 0;
            this.lbCopyKey.Text = "Copy Hotkey";
            // 
            // tbCopyHotKey
            // 
            this.tbCopyHotKey.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tbCopyHotKey.Location = new System.Drawing.Point(98, 12);
            this.tbCopyHotKey.Name = "tbCopyHotKey";
            this.tbCopyHotKey.Size = new System.Drawing.Size(286, 20);
            this.tbCopyHotKey.TabIndex = 1;
            this.tbCopyHotKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbCopyHotKey_KeyDown);
            // 
            // btnCopyRegister
            // 
            this.btnCopyRegister.Enabled = false;
            this.btnCopyRegister.Location = new System.Drawing.Point(390, 10);
            this.btnCopyRegister.Name = "btnCopyRegister";
            this.btnCopyRegister.Size = new System.Drawing.Size(75, 23);
            this.btnCopyRegister.TabIndex = 2;
            this.btnCopyRegister.Text = "Register";
            this.btnCopyRegister.UseVisualStyleBackColor = true;
            this.btnCopyRegister.Click += new System.EventHandler(this.btnCopyRegister_Click);
            // 
            // btnCopyUnregister
            // 
            this.btnCopyUnregister.Enabled = false;
            this.btnCopyUnregister.Location = new System.Drawing.Point(470, 10);
            this.btnCopyUnregister.Name = "btnCopyUnregister";
            this.btnCopyUnregister.Size = new System.Drawing.Size(75, 23);
            this.btnCopyUnregister.TabIndex = 3;
            this.btnCopyUnregister.Text = "Unregister";
            this.btnCopyUnregister.UseVisualStyleBackColor = true;
            this.btnCopyUnregister.Click += new System.EventHandler(this.btnCopyUnregister_Click);
            // 
            // lbNotice
            // 
            this.lbNotice.AutoSize = true;
            this.lbNotice.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbNotice.Location = new System.Drawing.Point(11, 71);
            this.lbNotice.Name = "lbNotice";
            this.lbNotice.Size = new System.Drawing.Size(535, 13);
            this.lbNotice.TabIndex = 4;
            this.lbNotice.Text = "Please click the textbox and press keys.  The keys must be in combination with th" +
    "e Ctrl, Shift or Alt (e.g. Ctrl+Alt+T)";
            // 
            // tbLocalClipboardText
            // 
            this.tbLocalClipboardText.Location = new System.Drawing.Point(14, 149);
            this.tbLocalClipboardText.Multiline = true;
            this.tbLocalClipboardText.Name = "tbLocalClipboardText";
            this.tbLocalClipboardText.ReadOnly = true;
            this.tbLocalClipboardText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbLocalClipboardText.Size = new System.Drawing.Size(162, 162);
            this.tbLocalClipboardText.TabIndex = 5;
            this.tbLocalClipboardText.Visible = false;
            // 
            // lbClipboard
            // 
            this.lbClipboard.AutoSize = true;
            this.lbClipboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbClipboard.Location = new System.Drawing.Point(11, 105);
            this.lbClipboard.Name = "lbClipboard";
            this.lbClipboard.Size = new System.Drawing.Size(126, 17);
            this.lbClipboard.TabIndex = 6;
            this.lbClipboard.Text = "Local Clipboard ";
            // 
            // pbLocalClipboardImage
            // 
            this.pbLocalClipboardImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbLocalClipboardImage.Location = new System.Drawing.Point(14, 149);
            this.pbLocalClipboardImage.Name = "pbLocalClipboardImage";
            this.pbLocalClipboardImage.Size = new System.Drawing.Size(162, 162);
            this.pbLocalClipboardImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLocalClipboardImage.TabIndex = 7;
            this.pbLocalClipboardImage.TabStop = false;
            this.pbLocalClipboardImage.Visible = false;
            // 
            // lbLocalClipboardFileDropList
            // 
            this.lbLocalClipboardFileDropList.FormattingEnabled = true;
            this.lbLocalClipboardFileDropList.HorizontalScrollbar = true;
            this.lbLocalClipboardFileDropList.Location = new System.Drawing.Point(14, 151);
            this.lbLocalClipboardFileDropList.Name = "lbLocalClipboardFileDropList";
            this.lbLocalClipboardFileDropList.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lbLocalClipboardFileDropList.Size = new System.Drawing.Size(162, 160);
            this.lbLocalClipboardFileDropList.TabIndex = 8;
            this.lbLocalClipboardFileDropList.Visible = false;
            // 
            // btnPasteUnregister
            // 
            this.btnPasteUnregister.Enabled = false;
            this.btnPasteUnregister.Location = new System.Drawing.Point(470, 36);
            this.btnPasteUnregister.Name = "btnPasteUnregister";
            this.btnPasteUnregister.Size = new System.Drawing.Size(75, 23);
            this.btnPasteUnregister.TabIndex = 12;
            this.btnPasteUnregister.Text = "Unregister";
            this.btnPasteUnregister.UseVisualStyleBackColor = true;
            this.btnPasteUnregister.Click += new System.EventHandler(this.btnPasteUnregister_Click);
            // 
            // btnPasteRegister
            // 
            this.btnPasteRegister.Enabled = false;
            this.btnPasteRegister.Location = new System.Drawing.Point(390, 36);
            this.btnPasteRegister.Name = "btnPasteRegister";
            this.btnPasteRegister.Size = new System.Drawing.Size(75, 23);
            this.btnPasteRegister.TabIndex = 11;
            this.btnPasteRegister.Text = "Register";
            this.btnPasteRegister.UseVisualStyleBackColor = true;
            this.btnPasteRegister.Click += new System.EventHandler(this.btnPasteRegister_Click);
            // 
            // tbPasteHotKey
            // 
            this.tbPasteHotKey.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tbPasteHotKey.Location = new System.Drawing.Point(98, 38);
            this.tbPasteHotKey.Name = "tbPasteHotKey";
            this.tbPasteHotKey.Size = new System.Drawing.Size(286, 20);
            this.tbPasteHotKey.TabIndex = 10;
            this.tbPasteHotKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbPasteHotKey_KeyDown);
            // 
            // lbPasteKey
            // 
            this.lbPasteKey.AutoSize = true;
            this.lbPasteKey.Location = new System.Drawing.Point(11, 41);
            this.lbPasteKey.Name = "lbPasteKey";
            this.lbPasteKey.Size = new System.Drawing.Size(71, 13);
            this.lbPasteKey.TabIndex = 9;
            this.lbPasteKey.Text = "Paste Hotkey";
            // 
            // label1
            // 
            this.lbLocalText.AutoSize = true;
            this.lbLocalText.Location = new System.Drawing.Point(11, 133);
            this.lbLocalText.Name = "label1";
            this.lbLocalText.Size = new System.Drawing.Size(28, 13);
            this.lbLocalText.TabIndex = 13;
            this.lbLocalText.Text = "Text";
            this.lbLocalText.Visible = false;
            // 
            // lbLocalImage
            // 
            this.lbLocalImage.AutoSize = true;
            this.lbLocalImage.Location = new System.Drawing.Point(14, 133);
            this.lbLocalImage.Name = "lbLocalImage";
            this.lbLocalImage.Size = new System.Drawing.Size(36, 13);
            this.lbLocalImage.TabIndex = 14;
            this.lbLocalImage.Text = "Image";
            this.lbLocalImage.Visible = false;
            // 
            // lbLocalFiles
            // 
            this.lbLocalFiles.AutoSize = true;
            this.lbLocalFiles.Location = new System.Drawing.Point(14, 135);
            this.lbLocalFiles.Name = "lbLocalFiles";
            this.lbLocalFiles.Size = new System.Drawing.Size(28, 13);
            this.lbLocalFiles.TabIndex = 15;
            this.lbLocalFiles.Text = "Files";
            this.lbLocalFiles.Visible = false;
            // 
            // label4
            // 
            this.lbShared1Files.AutoSize = true;
            this.lbShared1Files.Location = new System.Drawing.Point(9, 368);
            this.lbShared1Files.Name = "label4";
            this.lbShared1Files.Size = new System.Drawing.Size(28, 13);
            this.lbShared1Files.TabIndex = 22;
            this.lbShared1Files.Text = "Files";
            this.lbShared1Files.Visible = false;
            // 
            // label5
            // 
            this.lbShared1Image.AutoSize = true;
            this.lbShared1Image.Location = new System.Drawing.Point(11, 368);
            this.lbShared1Image.Name = "label5";
            this.lbShared1Image.Size = new System.Drawing.Size(36, 13);
            this.lbShared1Image.TabIndex = 21;
            this.lbShared1Image.Text = "Image";
            this.lbShared1Image.Visible = false;
            // 
            // label6
            // 
            this.lbShared1Text.AutoSize = true;
            this.lbShared1Text.Location = new System.Drawing.Point(11, 368);
            this.lbShared1Text.Name = "label6";
            this.lbShared1Text.Size = new System.Drawing.Size(28, 13);
            this.lbShared1Text.TabIndex = 20;
            this.lbShared1Text.Text = "Text";
            this.lbShared1Text.Visible = false;
            // 
            // lbSharedClipboardFileDropList
            // 
            this.lbSharedClipboard1FileDropList.FormattingEnabled = true;
            this.lbSharedClipboard1FileDropList.HorizontalScrollbar = true;
            this.lbSharedClipboard1FileDropList.Location = new System.Drawing.Point(12, 384);
            this.lbSharedClipboard1FileDropList.Name = "lbSharedClipboardFileDropList";
            this.lbSharedClipboard1FileDropList.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lbSharedClipboard1FileDropList.Size = new System.Drawing.Size(162, 160);
            this.lbSharedClipboard1FileDropList.TabIndex = 19;
            this.lbSharedClipboard1FileDropList.Visible = false;
            // 
            // pbSharedClipboardImage
            // 
            this.pbSharedClipboard1Image.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbSharedClipboard1Image.Location = new System.Drawing.Point(14, 384);
            this.pbSharedClipboard1Image.Name = "pbSharedClipboardImage";
            this.pbSharedClipboard1Image.Size = new System.Drawing.Size(162, 162);
            this.pbSharedClipboard1Image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSharedClipboard1Image.TabIndex = 18;
            this.pbSharedClipboard1Image.TabStop = false;
            this.pbSharedClipboard1Image.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(11, 340);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(139, 17);
            this.label7.TabIndex = 17;
            this.label7.Text = "Shared Clipboard ";
            // 
            // tbSharedClipboardText
            // 
            this.tbSharedClipboard1Text.Location = new System.Drawing.Point(14, 384);
            this.tbSharedClipboard1Text.Multiline = true;
            this.tbSharedClipboard1Text.Name = "tbSharedClipboardText";
            this.tbSharedClipboard1Text.ReadOnly = true;
            this.tbSharedClipboard1Text.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbSharedClipboard1Text.Size = new System.Drawing.Size(162, 162);
            this.tbSharedClipboard1Text.TabIndex = 16;
            this.tbSharedClipboard1Text.Visible = false;
            // 
            // lbLocalName
            // 
            this.lbLocalName.AutoSize = true;
            this.lbLocalName.Location = new System.Drawing.Point(143, 109);
            this.lbLocalName.Name = "lbLocalName";
            this.lbLocalName.Size = new System.Drawing.Size(0, 13);
            this.lbLocalName.TabIndex = 23;
            // 
            // lbSharedName
            // 
            this.lbShared1Name.AutoSize = true;
            this.lbShared1Name.Location = new System.Drawing.Point(156, 344);
            this.lbShared1Name.Name = "lbSharedName";
            this.lbShared1Name.Size = new System.Drawing.Size(0, 13);
            this.lbShared1Name.TabIndex = 24;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 562);
            this.Controls.Add(this.lbShared1Name);
            this.Controls.Add(this.lbLocalName);
            this.Controls.Add(this.lbShared1Files);
            this.Controls.Add(this.lbShared1Image);
            this.Controls.Add(this.lbShared1Text);
            this.Controls.Add(this.lbSharedClipboard1FileDropList);
            this.Controls.Add(this.pbSharedClipboard1Image);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbSharedClipboard1Text);
            this.Controls.Add(this.lbLocalFiles);
            this.Controls.Add(this.lbLocalImage);
            this.Controls.Add(this.lbLocalText);
            this.Controls.Add(this.btnPasteUnregister);
            this.Controls.Add(this.btnPasteRegister);
            this.Controls.Add(this.tbPasteHotKey);
            this.Controls.Add(this.lbPasteKey);
            this.Controls.Add(this.lbLocalClipboardFileDropList);
            this.Controls.Add(this.pbLocalClipboardImage);
            this.Controls.Add(this.lbClipboard);
            this.Controls.Add(this.tbLocalClipboardText);
            this.Controls.Add(this.lbNotice);
            this.Controls.Add(this.btnCopyUnregister);
            this.Controls.Add(this.btnCopyRegister);
            this.Controls.Add(this.tbCopyHotKey);
            this.Controls.Add(this.lbCopyKey);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Dashboard";
            this.Text = "Shared Clipboard Dashboard";
            ((System.ComponentModel.ISupportInitialize)(this.pbLocalClipboardImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSharedClipboard1Image)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbCopyKey;
        private System.Windows.Forms.TextBox tbCopyHotKey;
        private System.Windows.Forms.Button btnCopyRegister;
        private System.Windows.Forms.Button btnCopyUnregister;
        private System.Windows.Forms.Label lbNotice;
        private System.Windows.Forms.Label lbClipboard;
        private System.Windows.Forms.TextBox tbLocalClipboardText;
        private System.Windows.Forms.PictureBox pbLocalClipboardImage;
        private System.Windows.Forms.ListBox lbLocalClipboardFileDropList;
        private System.Windows.Forms.Button btnPasteUnregister;
        private System.Windows.Forms.Button btnPasteRegister;
        private System.Windows.Forms.TextBox tbPasteHotKey;
        private System.Windows.Forms.Label lbPasteKey;
        private System.Windows.Forms.Label lbLocalText;
        private System.Windows.Forms.Label lbLocalImage;
        private System.Windows.Forms.Label lbLocalFiles;
        private System.Windows.Forms.Label lbShared1Files;
        private System.Windows.Forms.Label lbShared1Image;
        private System.Windows.Forms.Label lbShared1Text;
        private System.Windows.Forms.ListBox lbSharedClipboard1FileDropList;
        private System.Windows.Forms.PictureBox pbSharedClipboard1Image;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbSharedClipboard1Text;
        private System.Windows.Forms.Label lbLocalName;
        private System.Windows.Forms.Label lbShared1Name;
    }
}

