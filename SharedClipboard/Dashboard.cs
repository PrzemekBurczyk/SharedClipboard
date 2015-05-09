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
        HotKeyRegister hotKeyToRegister = null;

        Keys registerKey = Keys.None;

        KeyModifiers registerModifiers = KeyModifiers.None;

        public Dashboard()
        {
            InitializeComponent();
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
                    tbHotKey.Text = string.Format("{0}+{1}",
                        this.registerModifiers, this.registerKey);

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
                hotKeyToRegister = new HotKeyRegister(this.Handle, 100,
                    this.registerModifiers, this.registerKey);

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

        /// <summary>
        /// Show a message box if the HotKeyPressed event is raised.
        /// </summary>
        void HotKeyPressed(object sender, EventArgs e)
        {
            //if (this.WindowState == FormWindowState.Minimized)
            //{
            //    this.WindowState = FormWindowState.Normal;
            //}
            //this.Activate();
            Console.WriteLine("HotKeyPressed");
            tbClipboard.Text = "Hot Key Pressed";
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


        /// <summary>
        /// Dispose the hotKeyToRegister when the form is closed.
        /// </summary>
        protected override void OnClosed(EventArgs e)
        {
            if (hotKeyToRegister != null)
            {
                hotKeyToRegister.Dispose();
                hotKeyToRegister = null;
            }

            base.OnClosed(e);
        }
    }
}
