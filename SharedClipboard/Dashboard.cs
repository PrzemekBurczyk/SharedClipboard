using Newtonsoft.Json;
using SharedClipboard.Manager;
using SharedClipboard.Utils;
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
        private const int baloonTipTime = 1000;


        private const int copyHotKeyRegisterId1 = 101;
        private HotKeyRegister copyHotKeyToRegister1 = null;

        private const int pasteHotKeyRegisterId1 = 102;
        private HotKeyRegister pasteHotKeyToRegister1 = null;


        private const int copyHotKeyRegisterId2 = 103;
        private HotKeyRegister copyHotKeyToRegister2 = null;

        private const int pasteHotKeyRegisterId2 = 104;
        private HotKeyRegister pasteHotKeyToRegister2 = null;


        private const int copyHotKeyRegisterId3 = 105;
        private HotKeyRegister copyHotKeyToRegister3 = null;

        private const int pasteHotKeyRegisterId3 = 106;
        private HotKeyRegister pasteHotKeyToRegister3 = null;


        private const int clipboardManagerId = 100;
        private ClipboardManager clipboardManager = null;

        Keys copyRegisterKey = Keys.None;
        Keys pasteRegisterKey = Keys.None;

        KeyModifiers copyRegisterModifiers = KeyModifiers.None;
        KeyModifiers pasteRegisterModifiers = KeyModifiers.None;

        private NotifyIcon trayIcon;
        private ContextMenu trayMenu;

        public Dashboard()
        {
            InitializeComponent();

            trayMenu = new ContextMenu();
            trayMenu.MenuItems.Add("Open", OnOpen);
            trayMenu.MenuItems.Add("Exit", OnExit);

            trayIcon = new NotifyIcon();
            trayIcon.Text = "Shared Clipboard";
            trayIcon.Icon = new Icon(SystemIcons.Application, 40, 40);
            trayIcon.Click += OnOpen;

            trayIcon.ContextMenu = trayMenu;
            trayIcon.Visible = true;

            Load += Dashboard_Load;
            Resize += Dashboard_Resize;
        }

        private void OnExit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Dashboard_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
        }

        private void OnOpen(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        void Dashboard_Load(object sender, EventArgs e)
        {
            lbLocalName.Text = Environment.MachineName;
            clipboardManager = new ClipboardManager(this.Handle, clipboardManagerId);
            clipboardManager.ClipboardChanged += new EventHandler(OnClipboardChanged);
            clipboardManager.SharedClipboardChanged += new EventHandler<ClipboardData>(OnSharedClipboardChanged);
            clipboardManager.ClipboardError += new EventHandler<ClipboardError>(OnClipboardError);
        }

        private void OnClipboardError(object sender, ClipboardError clipboardError)
        {
            switch (clipboardError.Reason)
            {
                case ErrorReason.TIMEOUT:
                    trayIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Error;
                    trayIcon.BalloonTipText = "Wasn't able to upload clipboard. Connection too slow.";
                    trayIcon.BalloonTipTitle = "Clipboard synchronization timeout";
                    trayIcon.ShowBalloonTip(baloonTipTime);
                    break;
                case ErrorReason.LOCKED:
                    trayIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
                    trayIcon.BalloonTipText = "Someone is uploading to this clipboard at the moment.";
                    trayIcon.BalloonTipTitle = "Selected clipboard is locked";
                    trayIcon.ShowBalloonTip(baloonTipTime);
                    break;
                case ErrorReason.NOT_REQUESTED:
                    trayIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Error;
                    trayIcon.BalloonTipText = "Problem occured while uploading clipboard.";
                    trayIcon.BalloonTipTitle = "Application error";
                    trayIcon.ShowBalloonTip(baloonTipTime);
                    break;
                default:
                    break;
            }
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
                copyHotKeyToRegister1 = new HotKeyRegister(this.Handle, copyHotKeyRegisterId1, this.copyRegisterModifiers, this.copyRegisterKey);
                // Register the HotKeyPressed event.
                copyHotKeyToRegister1.HotKeyPressed += new EventHandler<int>(CopyHotKeyPressed);

                // Register the hotkey.
                copyHotKeyToRegister2 = new HotKeyRegister(this.Handle, copyHotKeyRegisterId2, this.copyRegisterModifiers, this.copyRegisterKey + 1);
                // Register the HotKeyPressed event.
                copyHotKeyToRegister2.HotKeyPressed += new EventHandler<int>(CopyHotKeyPressed);

                // Register the hotkey.
                copyHotKeyToRegister3 = new HotKeyRegister(this.Handle, copyHotKeyRegisterId3, this.copyRegisterModifiers, this.copyRegisterKey + 2);
                // Register the HotKeyPressed event.
                copyHotKeyToRegister3.HotKeyPressed += new EventHandler<int>(CopyHotKeyPressed);

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

        void CopyHotKeyPressed(object sender, int id)
        {
            Console.WriteLine("COPY " + id);
            try
            {
                clipboardManager.PublishClipboard(id.ToString());
            }
            catch (FileUtils.FilesSizeLimitExceededException exception)
            {
                Console.WriteLine(exception.Message);
                trayIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
                trayIcon.BalloonTipText = "Cannot upload files of total size greater than " + FileUtils.MAX_FILES_SIZE_BYTES + " bytes.";
                trayIcon.BalloonTipTitle = "Clipboard too big";
                trayIcon.ShowBalloonTip(baloonTipTime);
            }
            catch (PreviousChangeUnfinishedException exception)
            {
                Console.WriteLine(exception.Message);
                trayIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
                trayIcon.BalloonTipText = "You are already uploading data to selected clipboard.";
                trayIcon.BalloonTipTitle = "Clipboard already in use";
                trayIcon.ShowBalloonTip(baloonTipTime);
            }
            catch (UnknownClipboardTypeException exception)
            {
                Console.WriteLine(exception.Message);
                trayIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
                trayIcon.BalloonTipText = "Cannot upload clipboard of this type.";
                trayIcon.BalloonTipTitle = "Clipboard type unknown";
                trayIcon.ShowBalloonTip(baloonTipTime);
            }
        }

        /// <summary>
        /// Handle the Click event of btnUnregister.
        /// </summary>
        private void btnCopyUnregister_Click(object sender, EventArgs e)
        {
            // Dispose the hotKeyToRegister.
            if (copyHotKeyToRegister1 != null)
            {
                copyHotKeyToRegister1.Dispose();
                copyHotKeyToRegister1 = null;
            }

            // Dispose the hotKeyToRegister.
            if (copyHotKeyToRegister2 != null)
            {
                copyHotKeyToRegister2.Dispose();
                copyHotKeyToRegister2 = null;
            }

            // Dispose the hotKeyToRegister.
            if (copyHotKeyToRegister3 != null)
            {
                copyHotKeyToRegister3.Dispose();
                copyHotKeyToRegister3 = null;
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
                pasteHotKeyToRegister1 = new HotKeyRegister(this.Handle, pasteHotKeyRegisterId1, this.pasteRegisterModifiers, this.pasteRegisterKey);
                // Register the HotKeyPressed event.
                pasteHotKeyToRegister1.HotKeyPressed += new EventHandler<int>(PasteHotKeyPressed);

                // Register the hotkey.
                pasteHotKeyToRegister2 = new HotKeyRegister(this.Handle, pasteHotKeyRegisterId2, this.pasteRegisterModifiers, this.pasteRegisterKey + 1);
                // Register the HotKeyPressed event.
                pasteHotKeyToRegister2.HotKeyPressed += new EventHandler<int>(PasteHotKeyPressed);

                // Register the hotkey.
                pasteHotKeyToRegister3 = new HotKeyRegister(this.Handle, pasteHotKeyRegisterId3, this.pasteRegisterModifiers, this.pasteRegisterKey + 2);
                // Register the HotKeyPressed event.
                pasteHotKeyToRegister3.HotKeyPressed += new EventHandler<int>(PasteHotKeyPressed);

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
            if (pasteHotKeyToRegister1 != null)
            {
                pasteHotKeyToRegister1.Dispose();
                pasteHotKeyToRegister1 = null;
            }

            // Dispose the hotKeyToRegister.
            if (pasteHotKeyToRegister2 != null)
            {
                pasteHotKeyToRegister2.Dispose();
                pasteHotKeyToRegister2 = null;
            }

            // Dispose the hotKeyToRegister.
            if (pasteHotKeyToRegister3 != null)
            {
                pasteHotKeyToRegister3.Dispose();
                pasteHotKeyToRegister3 = null;
            }

            // Update the UI.
            tbPasteHotKey.Enabled = true;
            btnPasteRegister.Enabled = true;
            btnPasteUnregister.Enabled = false;
        }

        void PasteHotKeyPressed(object sender, int id)
        {
            Console.WriteLine("PASTE " + id);
            clipboardManager.CopySharedToLocal(id - 1);
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (clipboardManager != null)
            {
                clipboardManager.HandleWndProc(ref m);
            }
        }

        void OnClipboardChanged(object sender, EventArgs e)
        {
            //if (this.WindowState == FormWindowState.Minimized)
            //{
            //    this.WindowState = FormWindowState.Normal;
            //}
            //this.Activate();

            if (Clipboard.ContainsText())
            {
                string text = Clipboard.GetText();

                tbLocalClipboardText.Text = text;
                tbLocalClipboardText.Visible = true;
                lbLocalText.Visible = true;

                pbLocalClipboardImage.Image = null;
                pbLocalClipboardImage.Visible = false;
                lbLocalImage.Visible = false;

                lbLocalClipboardFileDropList.Items.Clear();
                lbLocalClipboardFileDropList.Visible = false;
                lbLocalFiles.Visible = false;
            }
            else if (Clipboard.ContainsImage())
            {
                Bitmap image = (Bitmap)Clipboard.GetImage();

                tbLocalClipboardText.Text = null;
                tbLocalClipboardText.Visible = false;
                lbLocalText.Visible = false;

                pbLocalClipboardImage.Image = image;
                pbLocalClipboardImage.Visible = true;
                lbLocalImage.Visible = true;

                lbLocalClipboardFileDropList.Items.Clear();
                lbLocalClipboardFileDropList.Visible = false;
                lbLocalFiles.Visible = false;
            }
            else if (Clipboard.ContainsFileDropList())
            {
                tbLocalClipboardText.Text = null;
                tbLocalClipboardText.Visible = false;
                lbLocalText.Visible = false;

                pbLocalClipboardImage.Image = null;
                pbLocalClipboardImage.Visible = false;
                lbLocalImage.Visible = false;

                lbLocalClipboardFileDropList.Items.Clear();
                StringCollection filePaths = Clipboard.GetFileDropList();
                foreach (string filePath in filePaths)
                {
                    lbLocalClipboardFileDropList.Items.Add(filePath);
                }
                lbLocalClipboardFileDropList.Visible = true;
                lbLocalFiles.Visible = true;
            }
        }

        void OnSharedClipboardChanged(object sender, ClipboardData clipboardData)
        {
            BeginInvoke((MethodInvoker)delegate
            {
                if (clipboardData != null)
                {
                    Console.WriteLine("Shared clipboard changed:");
                    Console.WriteLine("    Id: " + clipboardData.Id);
                    Console.WriteLine("    Sender: " + clipboardData.Sender);
                    Console.WriteLine("    Type: " + clipboardData.Type);

                    if (clipboardData.Id == copyHotKeyRegisterId1.ToString())
                    {
                        lbShared1Name.Text = clipboardData.Sender;

                        switch (clipboardData.Type)
                        {
                            case ClipboardDataType.TEXT:
                                string text = clipboardData.Data;

                                tbSharedClipboard1Text.Text = text;
                                tbSharedClipboard1Text.Visible = true;
                                lbShared1Text.Visible = true;

                                pbSharedClipboard1Image.Image = null;
                                pbSharedClipboard1Image.Visible = false;
                                lbShared1Image.Visible = false;

                                lbSharedClipboard1FileDropList.Items.Clear();
                                lbSharedClipboard1FileDropList.Visible = false;
                                lbShared1Files.Visible = false;
                                break;
                            case ClipboardDataType.IMAGE:
                                Image image = ImageUtils.Base64ToImage(clipboardData.Data);

                                tbSharedClipboard1Text.Text = null;
                                tbSharedClipboard1Text.Visible = false;
                                lbShared1Text.Visible = false;

                                pbSharedClipboard1Image.Image = image;
                                pbSharedClipboard1Image.Visible = true;
                                lbShared1Image.Visible = true;

                                lbSharedClipboard1FileDropList.Items.Clear();
                                lbSharedClipboard1FileDropList.Visible = false;
                                lbShared1Files.Visible = false;
                                break;
                            case ClipboardDataType.FILES:
                                List<ClipboardFile> files = JsonConvert.DeserializeObject<List<ClipboardFile>>(clipboardData.Data);

                                tbSharedClipboard1Text.Text = null;
                                tbSharedClipboard1Text.Visible = false;
                                lbShared1Text.Visible = false;

                                pbSharedClipboard1Image.Image = null;
                                pbSharedClipboard1Image.Visible = false;
                                lbShared1Image.Visible = false;

                                lbSharedClipboard1FileDropList.Items.Clear();
                                foreach (ClipboardFile clipboardFile in files)
                                {
                                    lbSharedClipboard1FileDropList.Items.Add(clipboardFile.Name);
                                }
                                lbSharedClipboard1FileDropList.Visible = true;
                                lbShared1Files.Visible = true;
                                break;
                            default:
                                Console.WriteLine("Unknown clipboard data type");
                                break;
                        }
                    }
                    else if (clipboardData.Id == copyHotKeyRegisterId2.ToString())
                    {
                        lbShared2Name.Text = clipboardData.Sender;

                        switch (clipboardData.Type)
                        {
                            case ClipboardDataType.TEXT:
                                string text = clipboardData.Data;

                                tbSharedClipboard2Text.Text = text;
                                tbSharedClipboard2Text.Visible = true;
                                lbShared2Text.Visible = true;

                                pbSharedClipboard2Image.Image = null;
                                pbSharedClipboard2Image.Visible = false;
                                lbShared2Image.Visible = false;

                                lbSharedClipboard2FileDropList.Items.Clear();
                                lbSharedClipboard2FileDropList.Visible = false;
                                lbShared2Files.Visible = false;
                                break;
                            case ClipboardDataType.IMAGE:
                                Image image = ImageUtils.Base64ToImage(clipboardData.Data);

                                tbSharedClipboard2Text.Text = null;
                                tbSharedClipboard2Text.Visible = false;
                                lbShared2Text.Visible = false;

                                pbSharedClipboard2Image.Image = image;
                                pbSharedClipboard2Image.Visible = true;
                                lbShared2Image.Visible = true;

                                lbSharedClipboard2FileDropList.Items.Clear();
                                lbSharedClipboard2FileDropList.Visible = false;
                                lbShared2Files.Visible = false;
                                break;
                            case ClipboardDataType.FILES:
                                List<ClipboardFile> files = JsonConvert.DeserializeObject<List<ClipboardFile>>(clipboardData.Data);

                                tbSharedClipboard2Text.Text = null;
                                tbSharedClipboard2Text.Visible = false;
                                lbShared2Text.Visible = false;

                                pbSharedClipboard2Image.Image = null;
                                pbSharedClipboard2Image.Visible = false;
                                lbShared2Image.Visible = false;

                                lbSharedClipboard2FileDropList.Items.Clear();
                                foreach (ClipboardFile clipboardFile in files)
                                {
                                    lbSharedClipboard2FileDropList.Items.Add(clipboardFile.Name);
                                }
                                lbSharedClipboard2FileDropList.Visible = true;
                                lbShared2Files.Visible = true;
                                break;
                            default:
                                Console.WriteLine("Unknown clipboard data type");
                                break;
                        }
                    }
                    else if (clipboardData.Id == copyHotKeyRegisterId3.ToString())
                    {
                        lbShared3Name.Text = clipboardData.Sender;

                        switch (clipboardData.Type)
                        {
                            case ClipboardDataType.TEXT:
                                string text = clipboardData.Data;

                                tbSharedClipboard3Text.Text = text;
                                tbSharedClipboard3Text.Visible = true;
                                lbShared3Text.Visible = true;

                                pbSharedClipboard3Image.Image = null;
                                pbSharedClipboard3Image.Visible = false;
                                lbShared3Image.Visible = false;

                                lbSharedClipboard3FileDropList.Items.Clear();
                                lbSharedClipboard3FileDropList.Visible = false;
                                lbShared3Files.Visible = false;
                                break;
                            case ClipboardDataType.IMAGE:
                                Image image = ImageUtils.Base64ToImage(clipboardData.Data);

                                tbSharedClipboard3Text.Text = null;
                                tbSharedClipboard3Text.Visible = false;
                                lbShared3Text.Visible = false;

                                pbSharedClipboard3Image.Image = image;
                                pbSharedClipboard3Image.Visible = true;
                                lbShared3Image.Visible = true;

                                lbSharedClipboard3FileDropList.Items.Clear();
                                lbSharedClipboard3FileDropList.Visible = false;
                                lbShared3Files.Visible = false;
                                break;
                            case ClipboardDataType.FILES:
                                List<ClipboardFile> files = JsonConvert.DeserializeObject<List<ClipboardFile>>(clipboardData.Data);

                                tbSharedClipboard3Text.Text = null;
                                tbSharedClipboard3Text.Visible = false;
                                lbShared3Text.Visible = false;

                                pbSharedClipboard3Image.Image = null;
                                pbSharedClipboard3Image.Visible = false;
                                lbShared3Image.Visible = false;

                                lbSharedClipboard3FileDropList.Items.Clear();
                                foreach (ClipboardFile clipboardFile in files)
                                {
                                    lbSharedClipboard3FileDropList.Items.Add(clipboardFile.Name);
                                }
                                lbSharedClipboard3FileDropList.Visible = true;
                                lbShared3Files.Visible = true;
                                break;
                            default:
                                Console.WriteLine("Unknown clipboard data type");
                                break;
                        }
                    }
                }
            }, null);
        }

        /// <summary>
        /// Dispose ClipboardManager and HotKeyRegister when the form is closed.
        /// </summary>
        protected override void OnClosed(EventArgs e)
        {
            Console.WriteLine("Closing.");
            if (copyHotKeyToRegister1 != null)
            {
                copyHotKeyToRegister1.Dispose();
                copyHotKeyToRegister1 = null;
            }

            if (pasteHotKeyToRegister1 != null)
            {
                pasteHotKeyToRegister1.Dispose();
                pasteHotKeyToRegister1 = null;
            }

            if (clipboardManager != null)
            {
                clipboardManager.Dispose();
                clipboardManager = null;
            }

            if (trayIcon != null)
            {
                trayIcon.Dispose();
                trayIcon = null;
            }

            base.OnClosed(e);
        }
    }
}
