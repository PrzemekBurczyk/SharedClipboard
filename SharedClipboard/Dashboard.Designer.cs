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
            this.tbClipboardText = new System.Windows.Forms.TextBox();
            this.lbClipboard = new System.Windows.Forms.Label();
            this.pbClipboardImage = new System.Windows.Forms.PictureBox();
            this.lbClipboardFileDropList = new System.Windows.Forms.ListBox();
            this.btnPasteUnregister = new System.Windows.Forms.Button();
            this.btnPasteRegister = new System.Windows.Forms.Button();
            this.tbPasteHotKey = new System.Windows.Forms.TextBox();
            this.lbPasteKey = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbClipboardImage)).BeginInit();
            this.SuspendLayout();
            // 
            // lbCopyKey
            // 
            this.lbCopyKey.AutoSize = true;
            this.lbCopyKey.Location = new System.Drawing.Point(21, 15);
            this.lbCopyKey.Name = "lbCopyKey";
            this.lbCopyKey.Size = new System.Drawing.Size(68, 13);
            this.lbCopyKey.TabIndex = 0;
            this.lbCopyKey.Text = "Copy Hotkey";
            // 
            // tbCopyHotKey
            // 
            this.tbCopyHotKey.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tbCopyHotKey.Location = new System.Drawing.Point(108, 12);
            this.tbCopyHotKey.Name = "tbCopyHotKey";
            this.tbCopyHotKey.Size = new System.Drawing.Size(286, 20);
            this.tbCopyHotKey.TabIndex = 1;
            this.tbCopyHotKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbCopyHotKey_KeyDown);
            // 
            // btnCopyRegister
            // 
            this.btnCopyRegister.Enabled = false;
            this.btnCopyRegister.Location = new System.Drawing.Point(400, 10);
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
            this.btnCopyUnregister.Location = new System.Drawing.Point(480, 10);
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
            this.lbNotice.Location = new System.Drawing.Point(12, 68);
            this.lbNotice.Name = "lbNotice";
            this.lbNotice.Size = new System.Drawing.Size(545, 13);
            this.lbNotice.TabIndex = 4;
            this.lbNotice.Text = "Please click the textbox and press keys.  The keys must be in combination with th" +
    "e Ctrl, Shift or Alt (e.g. Ctrl+Alt+T)";
            // 
            // tbClipboardText
            // 
            this.tbClipboardText.Location = new System.Drawing.Point(108, 94);
            this.tbClipboardText.Name = "tbClipboardText";
            this.tbClipboardText.Size = new System.Drawing.Size(447, 20);
            this.tbClipboardText.TabIndex = 5;
            // 
            // lbClipboard
            // 
            this.lbClipboard.AutoSize = true;
            this.lbClipboard.Location = new System.Drawing.Point(38, 97);
            this.lbClipboard.Name = "lbClipboard";
            this.lbClipboard.Size = new System.Drawing.Size(54, 13);
            this.lbClipboard.TabIndex = 6;
            this.lbClipboard.Text = "Clipboard ";
            // 
            // pbClipboardImage
            // 
            this.pbClipboardImage.Location = new System.Drawing.Point(330, 120);
            this.pbClipboardImage.Name = "pbClipboardImage";
            this.pbClipboardImage.Size = new System.Drawing.Size(225, 225);
            this.pbClipboardImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbClipboardImage.TabIndex = 7;
            this.pbClipboardImage.TabStop = false;
            // 
            // lbClipboardFileDropList
            // 
            this.lbClipboardFileDropList.FormattingEnabled = true;
            this.lbClipboardFileDropList.Location = new System.Drawing.Point(12, 120);
            this.lbClipboardFileDropList.Name = "lbClipboardFileDropList";
            this.lbClipboardFileDropList.Size = new System.Drawing.Size(312, 225);
            this.lbClipboardFileDropList.TabIndex = 8;
            // 
            // btnPasteUnregister
            // 
            this.btnPasteUnregister.Enabled = false;
            this.btnPasteUnregister.Location = new System.Drawing.Point(480, 36);
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
            this.btnPasteRegister.Location = new System.Drawing.Point(400, 36);
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
            this.tbPasteHotKey.Location = new System.Drawing.Point(108, 38);
            this.tbPasteHotKey.Name = "tbPasteHotKey";
            this.tbPasteHotKey.Size = new System.Drawing.Size(286, 20);
            this.tbPasteHotKey.TabIndex = 10;
            this.tbPasteHotKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbPasteHotKey_KeyDown);
            // 
            // lbPasteKey
            // 
            this.lbPasteKey.AutoSize = true;
            this.lbPasteKey.Location = new System.Drawing.Point(21, 41);
            this.lbPasteKey.Name = "lbPasteKey";
            this.lbPasteKey.Size = new System.Drawing.Size(71, 13);
            this.lbPasteKey.TabIndex = 9;
            this.lbPasteKey.Text = "Paste Hotkey";
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 359);
            this.Controls.Add(this.btnPasteUnregister);
            this.Controls.Add(this.btnPasteRegister);
            this.Controls.Add(this.tbPasteHotKey);
            this.Controls.Add(this.lbPasteKey);
            this.Controls.Add(this.lbClipboardFileDropList);
            this.Controls.Add(this.pbClipboardImage);
            this.Controls.Add(this.lbClipboard);
            this.Controls.Add(this.tbClipboardText);
            this.Controls.Add(this.lbNotice);
            this.Controls.Add(this.btnCopyUnregister);
            this.Controls.Add(this.btnCopyRegister);
            this.Controls.Add(this.tbCopyHotKey);
            this.Controls.Add(this.lbCopyKey);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Dashboard";
            this.Text = "Shared Clipboard Dashboard";
            ((System.ComponentModel.ISupportInitialize)(this.pbClipboardImage)).EndInit();
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
        private System.Windows.Forms.TextBox tbClipboardText;
        private System.Windows.Forms.PictureBox pbClipboardImage;
        private System.Windows.Forms.ListBox lbClipboardFileDropList;
        private System.Windows.Forms.Button btnPasteUnregister;
        private System.Windows.Forms.Button btnPasteRegister;
        private System.Windows.Forms.TextBox tbPasteHotKey;
        private System.Windows.Forms.Label lbPasteKey;
    }
}

