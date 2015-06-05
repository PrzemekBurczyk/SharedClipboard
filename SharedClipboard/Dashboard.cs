using SharedClipboard.Manager;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharedClipboard
{
    public partial class Dashboard : Form
    {
        private const int copyHotKeyRegisterId = 100;
        private HotKeyRegister copyHotKeyToRegister = null;

        private const int pasteHotKeyRegisterId = 101;
        private HotKeyRegister pasteHotKeyToRegister = null;

        private const int clipboardManagerId = 102;
        private ClipboardManager clipboardManager = null;

        Keys copyRegisterKey = Keys.None;
        Keys pasteRegisterKey = Keys.None;

        KeyModifiers copyRegisterModifiers = KeyModifiers.None;
        KeyModifiers pasteRegisterModifiers = KeyModifiers.None;

        public Dashboard()
        {
            InitializeComponent();

            Load += Dashboard_Load;
        }

        void Dashboard_Load(object sender, EventArgs e)
        {
            clipboardManager = new ClipboardManager(this.Handle, clipboardManagerId);
            clipboardManager.ClipboardChanged += new EventHandler(ClipboardChanged);
        }


        /// <summary>
        /// Handle the KeyDown of tbHotKey. In this event handler, check the pressed keys.
        /// The keys that must be pressed in combination with the key Ctrl, Shift or Alt,
        /// like Ctrl+Alt+T.
        /// </summary>
        private void tbCopyHotKey_KeyDown(object sender, KeyEventArgs e)
        {
            // The key event should not be sent to the underlying control.
            e.SuppressKeyPress = true;

            // Check whether the modifier keys are pressed.
            if (e.Modifiers != Keys.None)
            {
                Keys key = Keys.None;
                KeyModifiers modifiers = HotKeyRegister.GetModifiers(e.KeyData, out key);

                // If the pressed key is valid...
                if (key != Keys.None)
                {
                    this.copyRegisterKey = key;
                    this.copyRegisterModifiers = modifiers;

                    // Display the pressed key in the textbox.
                    tbCopyHotKey.Text = string.Format("{0}+{1}", this.copyRegisterModifiers, this.copyRegisterKey);

                    // Enable the button.
                    btnCopyRegister.Enabled = true;
                }
            }
        }


        /// <summary>
        /// Handle the Click event of btnRegister.
        /// </summary>
        private void btnCopyRegister_Click(object sender, EventArgs e)
        {
            try
            {
                // Register the hotkey.
                copyHotKeyToRegister = new HotKeyRegister(this.Handle, copyHotKeyRegisterId, this.copyRegisterModifiers, this.copyRegisterKey);

                // Register the HotKeyPressed event.
                copyHotKeyToRegister.HotKeyPressed += new EventHandler(CopyHotKeyPressed);

                // Update the UI.
                btnCopyRegister.Enabled = false;
                tbCopyHotKey.Enabled = false;
                btnCopyUnregister.Enabled = true;
            }
            catch (ArgumentException argumentException)
            {
                MessageBox.Show(argumentException.Message);
            }
            catch (ApplicationException applicationException)
            {
                MessageBox.Show(applicationException.Message);
            }
        }

        void CopyHotKeyPressed(object sender, EventArgs e)
        {
            Console.WriteLine("COPY");
            clipboardManager.PublishClipboard();
        }


        /// <summary>
        /// Handle the Click event of btnUnregister.
        /// </summary>
        private void btnCopyUnregister_Click(object sender, EventArgs e)
        {
            // Dispose the hotKeyToRegister.
            if (copyHotKeyToRegister != null)
            {
                copyHotKeyToRegister.Dispose();
                copyHotKeyToRegister = null;
            }

            // Update the UI.
            tbCopyHotKey.Enabled = true;
            btnCopyRegister.Enabled = true;
            btnCopyUnregister.Enabled = false;
        }

        private void tbPasteHotKey_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            // The key event should not be sent to the underlying control.
            e.SuppressKeyPress = true;

            // Check whether the modifier keys are pressed.
            if (e.Modifiers != Keys.None)
            {
                Keys key = Keys.None;
                KeyModifiers modifiers = HotKeyRegister.GetModifiers(e.KeyData, out key);

                // If the pressed key is valid...
                if (key != Keys.None)
                {
                    this.pasteRegisterKey = key;
                    this.pasteRegisterModifiers = modifiers;

                    // Display the pressed key in the textbox.
                    tbPasteHotKey.Text = string.Format("{0}+{1}", this.pasteRegisterModifiers, this.pasteRegisterKey);

                    // Enable the button.
                    btnPasteRegister.Enabled = true;
                }
            }
        }

        private void btnPasteRegister_Click(object sender, System.EventArgs e)
        {
            try
            {
                // Register the hotkey.
                pasteHotKeyToRegister = new HotKeyRegister(this.Handle, pasteHotKeyRegisterId, this.pasteRegisterModifiers, this.pasteRegisterKey);

                // Register the HotKeyPressed event.
                pasteHotKeyToRegister.HotKeyPressed += new EventHandler(PasteHotKeyPressed);

                // Update the UI.
                btnPasteRegister.Enabled = false;
                tbPasteHotKey.Enabled = false;
                btnPasteUnregister.Enabled = true;
            }
            catch (ArgumentException argumentException)
            {
                MessageBox.Show(argumentException.Message);
            }
            catch (ApplicationException applicationException)
            {
                MessageBox.Show(applicationException.Message);
            }
        }

        private void btnPasteUnregister_Click(object sender, System.EventArgs e)
        {
            // Dispose the hotKeyToRegister.
            if (pasteHotKeyToRegister != null)
            {
                pasteHotKeyToRegister.Dispose();
                pasteHotKeyToRegister = null;
            }

            // Update the UI.
            tbPasteHotKey.Enabled = true;
            btnPasteRegister.Enabled = true;
            btnPasteUnregister.Enabled = false;
        }

        void PasteHotKeyPressed(object sender, EventArgs e)
        {
            Console.WriteLine("PASTE");
            clipboardManager.CopySharedToLocal();
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (clipboardManager != null)
            {
                clipboardManager.HandleWndProc(ref m);
            }
        }

        void ClipboardChanged(object sender, EventArgs e)
        {
            //if (this.WindowState == FormWindowState.Minimized)
            //{
            //    this.WindowState = FormWindowState.Normal;
            //}
            //this.Activate();
            IDataObject data = Clipboard.GetDataObject();

            if (Clipboard.ContainsText())
            {
                string text = Clipboard.GetText();
                tbClipboardText.Text = text;
            }
            else if (Clipboard.ContainsImage())
            {
                Bitmap image = (Bitmap) Clipboard.GetImage();
                pbClipboardImage.Image = image;
            }
            else if (Clipboard.ContainsFileDropList())
            {
                lbClipboardFileDropList.Items.Clear();
                StringCollection filePaths = Clipboard.GetFileDropList();
                foreach (string filePath in filePaths)
                {
                    lbClipboardFileDropList.Items.Add(filePath);
                }
            }
        }

        /// <summary>
        /// Dispose ClipboardManager and HotKeyRegister when the form is closed.
        /// </summary>
        protected override void OnClosed(EventArgs e)
        {
            if (copyHotKeyToRegister != null)
            {
                copyHotKeyToRegister.Dispose();
                copyHotKeyToRegister = null;
            }

            if (pasteHotKeyToRegister != null)
            {
                pasteHotKeyToRegister.Dispose();
                pasteHotKeyToRegister = null;
            }

            if (clipboardManager != null)
            {
                clipboardManager.Dispose();
                clipboardManager = null;
            }

            base.OnClosed(e);
        }
    }
}
