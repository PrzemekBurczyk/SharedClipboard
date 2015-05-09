using System;
using System.Collections.Generic;
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
        private const int hotKeyRegisterId = 100;
        private HotKeyRegister hotKeyToRegister = null;

        private const int clipboardManagerId = 101;
        private ClipboardManager clipboardManager = null;

        Keys registerKey = Keys.None;

        KeyModifiers registerModifiers = KeyModifiers.None;

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
        private void tbHotKey_KeyDown(object sender, KeyEventArgs e)
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
                    this.registerKey = key;
                    this.registerModifiers = modifiers;

                    // Display the pressed key in the textbox.
                    tbHotKey.Text = string.Format("{0}+{1}", this.registerModifiers, this.registerKey);

                    // Enable the button.
                    btnRegister.Enabled = true;
                }
            }
        }


        /// <summary>
        /// Handle the Click event of btnRegister.
        /// </summary>
        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                // Register the hotkey.
                hotKeyToRegister = new HotKeyRegister(this.Handle, hotKeyRegisterId, this.registerModifiers, this.registerKey);

                // Register the HotKeyPressed event.
                hotKeyToRegister.HotKeyPressed += new EventHandler(HotKeyPressed);

                // Update the UI.
                btnRegister.Enabled = false;
                tbHotKey.Enabled = false;
                btnUnregister.Enabled = true;
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

        void HotKeyPressed(object sender, EventArgs e)
        {
            Console.WriteLine("HotKeyPressed");
        }


        /// <summary>
        /// Handle the Click event of btnUnregister.
        /// </summary>
        private void btnUnregister_Click(object sender, EventArgs e)
        {
            // Dispose the hotKeyToRegister.
            if (hotKeyToRegister != null)
            {
                hotKeyToRegister.Dispose();
                hotKeyToRegister = null;
            }

            // Update the UI.
            tbHotKey.Enabled = true;
            btnRegister.Enabled = true;
            btnUnregister.Enabled = false;
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
            Console.WriteLine("Clipboard changed");
        }

        /// <summary>
        /// Dispose ClipboardManager and HotKeyRegister when the form is closed.
        /// </summary>
        protected override void OnClosed(EventArgs e)
        {
            if (hotKeyToRegister != null)
            {
                hotKeyToRegister.Dispose();
                hotKeyToRegister = null;
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
