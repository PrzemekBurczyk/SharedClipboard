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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbSharedClipboardFileDropList = new System.Windows.Forms.ListBox();
            this.pbSharedClipboardImage = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbSharedClipboardText = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbLocalClipboardImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSharedClipboardImage)).BeginInit();
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
            this.pbLocalClipboardImage.Location = new System.Drawing.Point(198, 149);
            this.pbLocalClipboardImage.Name = "pbLocalClipboardImage";
            this.pbLocalClipboardImage.Size = new System.Drawing.Size(162, 162);
            this.pbLocalClipboardImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLocalClipboardImage.TabIndex = 7;
            this.pbLocalClipboardImage.TabStop = false;
            // 
            // lbLocalClipboardFileDropList
            // 
            this.lbLocalClipboardFileDropList.FormattingEnabled = true;
            this.lbLocalClipboardFileDropList.HorizontalScrollbar = true;
            this.lbLocalClipboardFileDropList.Location = new System.Drawing.Point(383, 149);
            this.lbLocalClipboardFileDropList.Name = "lbLocalClipboardFileDropList";
            this.lbLocalClipboardFileDropList.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lbLocalClipboardFileDropList.Size = new System.Drawing.Size(162, 160);
            this.lbLocalClipboardFileDropList.TabIndex = 8;
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
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Text";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(198, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Image";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(383, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Files";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(383, 367);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Files";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(198, 365);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Image";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 368);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Text";
            // 
            // lbSharedClipboardFileDropList
            // 
            this.lbSharedClipboardFileDropList.FormattingEnabled = true;
            this.lbSharedClipboardFileDropList.HorizontalScrollbar = true;
            this.lbSharedClipboardFileDropList.Location = new System.Drawing.Point(383, 384);
            this.lbSharedClipboardFileDropList.Name = "lbSharedClipboardFileDropList";
            this.lbSharedClipboardFileDropList.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lbSharedClipboardFileDropList.Size = new System.Drawing.Size(162, 160);
            this.lbSharedClipboardFileDropList.TabIndex = 19;
            // 
            // pbSharedClipboardImage
            // 
            this.pbSharedClipboardImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbSharedClipboardImage.Location = new System.Drawing.Point(198, 384);
            this.pbSharedClipboardImage.Name = "pbSharedClipboardImage";
            this.pbSharedClipboardImage.Size = new System.Drawing.Size(162, 162);
            this.pbSharedClipboardImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSharedClipboardImage.TabIndex = 18;
            this.pbSharedClipboardImage.TabStop = false;
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
            this.tbSharedClipboardText.Location = new System.Drawing.Point(14, 384);
            this.tbSharedClipboardText.Multiline = true;
            this.tbSharedClipboardText.Name = "tbSharedClipboardText";
            this.tbSharedClipboardText.ReadOnly = true;
            this.tbSharedClipboardText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbSharedClipboardText.Size = new System.Drawing.Size(162, 162);
            this.tbSharedClipboardText.TabIndex = 16;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 562);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbSharedClipboardFileDropList);
            this.Controls.Add(this.pbSharedClipboardImage);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbSharedClipboardText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
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
            ((System.ComponentModel.ISupportInitialize)(this.pbSharedClipboardImage)).EndInit();
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox lbSharedClipboardFileDropList;
        private System.Windows.Forms.PictureBox pbSharedClipboardImage;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbSharedClipboardText;
    }
}

