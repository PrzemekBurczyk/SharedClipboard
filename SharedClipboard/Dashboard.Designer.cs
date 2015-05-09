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
            this.lbKey = new System.Windows.Forms.Label();
            this.tbHotKey = new System.Windows.Forms.TextBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnUnregister = new System.Windows.Forms.Button();
            this.lbNotice = new System.Windows.Forms.Label();
            this.tbClipboardText = new System.Windows.Forms.TextBox();
            this.lbClipboard = new System.Windows.Forms.Label();
            this.pbClipboardImage = new System.Windows.Forms.PictureBox();
            this.lbClipboardFileDropList = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbClipboardImage)).BeginInit();
            this.SuspendLayout();
            // 
            // lbKey
            // 
            this.lbKey.AutoSize = true;
            this.lbKey.Location = new System.Drawing.Point(21, 15);
            this.lbKey.Name = "lbKey";
            this.lbKey.Size = new System.Drawing.Size(71, 13);
            this.lbKey.TabIndex = 0;
            this.lbKey.Text = "Paste Hotkey";
            // 
            // tbHotKey
            // 
            this.tbHotKey.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tbHotKey.Location = new System.Drawing.Point(108, 12);
            this.tbHotKey.Name = "tbHotKey";
            this.tbHotKey.Size = new System.Drawing.Size(286, 20);
            this.tbHotKey.TabIndex = 1;
            this.tbHotKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbHotKey_KeyDown);
            // 
            // btnRegister
            // 
            this.btnRegister.Enabled = false;
            this.btnRegister.Location = new System.Drawing.Point(400, 10);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(75, 23);
            this.btnRegister.TabIndex = 2;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnUnregister
            // 
            this.btnUnregister.Enabled = false;
            this.btnUnregister.Location = new System.Drawing.Point(480, 10);
            this.btnUnregister.Name = "btnUnregister";
            this.btnUnregister.Size = new System.Drawing.Size(75, 23);
            this.btnUnregister.TabIndex = 3;
            this.btnUnregister.Text = "Unregister";
            this.btnUnregister.UseVisualStyleBackColor = true;
            this.btnUnregister.Click += new System.EventHandler(this.btnUnregister_Click);
            // 
            // lbNotice
            // 
            this.lbNotice.AutoSize = true;
            this.lbNotice.Location = new System.Drawing.Point(12, 42);
            this.lbNotice.Name = "lbNotice";
            this.lbNotice.Size = new System.Drawing.Size(545, 13);
            this.lbNotice.TabIndex = 4;
            this.lbNotice.Text = "Please click the textbox and press keys.  The keys must be in combination with th" +
    "e Ctrl, Shift or Alt (e.g. Ctrl+Alt+T)";
            // 
            // tbClipboardText
            // 
            this.tbClipboardText.Location = new System.Drawing.Point(108, 68);
            this.tbClipboardText.Name = "tbClipboardText";
            this.tbClipboardText.Size = new System.Drawing.Size(447, 20);
            this.tbClipboardText.TabIndex = 5;
            // 
            // lbClipboard
            // 
            this.lbClipboard.AutoSize = true;
            this.lbClipboard.Location = new System.Drawing.Point(38, 71);
            this.lbClipboard.Name = "lbClipboard";
            this.lbClipboard.Size = new System.Drawing.Size(54, 13);
            this.lbClipboard.TabIndex = 6;
            this.lbClipboard.Text = "Clipboard ";
            // 
            // pbClipboardImage
            // 
            this.pbClipboardImage.Location = new System.Drawing.Point(330, 94);
            this.pbClipboardImage.Name = "pbClipboardImage";
            this.pbClipboardImage.Size = new System.Drawing.Size(225, 225);
            this.pbClipboardImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbClipboardImage.TabIndex = 7;
            this.pbClipboardImage.TabStop = false;
            // 
            // lbClipboardFileDropList
            // 
            this.lbClipboardFileDropList.FormattingEnabled = true;
            this.lbClipboardFileDropList.Location = new System.Drawing.Point(12, 94);
            this.lbClipboardFileDropList.Name = "lbClipboardFileDropList";
            this.lbClipboardFileDropList.Size = new System.Drawing.Size(312, 225);
            this.lbClipboardFileDropList.TabIndex = 8;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 331);
            this.Controls.Add(this.lbClipboardFileDropList);
            this.Controls.Add(this.pbClipboardImage);
            this.Controls.Add(this.lbClipboard);
            this.Controls.Add(this.tbClipboardText);
            this.Controls.Add(this.lbNotice);
            this.Controls.Add(this.btnUnregister);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.tbHotKey);
            this.Controls.Add(this.lbKey);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Dashboard";
            this.Text = "Shared Clipboard Dashboard";
            ((System.ComponentModel.ISupportInitialize)(this.pbClipboardImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbKey;
        private System.Windows.Forms.TextBox tbHotKey;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnUnregister;
        private System.Windows.Forms.Label lbNotice;
        private System.Windows.Forms.Label lbClipboard;
        private System.Windows.Forms.TextBox tbClipboardText;
        private System.Windows.Forms.PictureBox pbClipboardImage;
        private System.Windows.Forms.ListBox lbClipboardFileDropList;
    }
}

