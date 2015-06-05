﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Specialized;
using Quobject.SocketIoClientDotNet.Client;
using Newtonsoft.Json;
using SharedClipboard.Utils;
using System.IO;
using Newtonsoft.Json.Linq;

namespace SharedClipboard.Manager
{
    public class ClipboardManager : IDisposable
    {
        private class Events
        {
            public static string CLIPBOARD_CHANGE = "clipboard_change";
            public static string GET_CLIPBOARD_BY_ID = "get_clipboard_by_id";
            public static string ALL_CLIPBOARDS = "all_clipboards";
            public static string GET_ALL_CLIPBOARDS = "get_all_clipboards";
        }

        private static long MAX_IMAGE_SIZE_BYTES = 5242880; //5MB

        private static IntPtr HWND_MESSAGE = new IntPtr(-3);

        /// <summary>
        /// Adds the given window to the system-maintained clipboard format listener list.
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool AddClipboardFormatListener(IntPtr hwnd);

        /// <summary>
        /// Removes the given window from the system-maintained clipboard format listener list.
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool RemoveClipboardFormatListener(IntPtr hwnd);

        // See http://msdn.microsoft.com/en-us/library/ms633541%28v=vs.85%29.aspx
        // See http://msdn.microsoft.com/en-us/library/ms649033%28VS.85%29.aspx
        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        /// <summary>
        /// Specify whether this object is disposed.
        /// </summary>
        bool disposed = false;

        /// <summary>
        /// Sent when the contents of the clipboard have changed.
        /// </summary>
        private const int WM_CLIPBOARDUPDATE = 0x031D;

        /// <summary>
        /// A handle to the window that will receive WM_CLIPBOARDUPDATE messages generated by the
        /// hot key.
        /// </summary>
        public IntPtr Handle { get; private set; }

        /// <summary>
        /// A normal application can use any value between 0x0000 and 0xBFFF as the ID 
        /// but if you are writing a DLL, then you must use GlobalAddAtom to get a 
        /// unique identifier for your hot key. 
        /// </summary>
        public int ID { get; private set; }

        /// <summary>
        /// Raise an event when the clipboard changed.
        /// </summary>
        public event EventHandler ClipboardChanged;

        public event EventHandler<ClipboardData> SharedClipboardChanged;

        public Socket socket = null;

        private Dictionary<string, ClipboardData> sharedClipboard = new Dictionary<string,ClipboardData>();

        public ClipboardManager(IntPtr handle, int id)
        {
            this.Handle = handle;
            this.ID = id;

            //SetParent(Handle, HWND_MESSAGE); do we need this?
            AddClipboardFormatListener(Handle);

            InitializeServerConnection();
        }

        private void InitializeServerConnection()
        {
            socket = IO.Socket("http://127.0.0.1:3000");
            Console.WriteLine("Connecting to server...");

            socket.On(Socket.EVENT_CONNECT, () =>
            {
                Console.WriteLine("Connected to server.");
            });

            socket.On(Socket.EVENT_CONNECT_ERROR, () =>
            {
                Console.WriteLine("Connect error.");
            });

            socket.On(Socket.EVENT_CONNECT_TIMEOUT, () =>
            {
                Console.WriteLine("Connect timeout.");
            });

            socket.On(Socket.EVENT_DISCONNECT, () =>
            {
                Console.WriteLine("Disconnect.");
            });

            socket.On(Socket.EVENT_RECONNECTING, () =>
            {
                Console.WriteLine("Reconnecting.");
            });

            socket.On(Events.CLIPBOARD_CHANGE, (data) =>
            {
                ClipboardData clipboardData = JsonConvert.DeserializeObject<ClipboardData>(data.ToString());
                if (clipboardData != null)
                {
                    sharedClipboard[clipboardData.Id] = clipboardData;
                    if (SharedClipboardChanged != null)
                    {
                        SharedClipboardChanged(this, clipboardData);
                    }
                }
            });
        }

        public void Dispose()
        {
            Dispose(true);
            socket.Close();
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Unregister the clipboard listener.
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            // Protect from being called multiple times.
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                RemoveClipboardFormatListener(Handle);

                if (socket != null)
                {
                    socket.Disconnect();
                }
            }

            disposed = true;
        }

        public void HandleWndProc(ref System.Windows.Forms.Message m)
        {
            if (m.Msg == WM_CLIPBOARDUPDATE)
            {
                if (ClipboardChanged != null)
                {
                    ClipboardChanged(this, EventArgs.Empty);
                }
            }
        }

        internal void PublishClipboard()
        {
            bool emitEvent = false;
            ClipboardData clipboardData = new ClipboardData();
            clipboardData.Sender = Environment.MachineName;

            if (Clipboard.ContainsText())
            {
                string text = Clipboard.GetText();

                clipboardData.Data = text;
                clipboardData.Type = ClipboardDataType.TEXT;
                clipboardData.Id = "1";

                emitEvent = true;
            }
            else if (Clipboard.ContainsImage())
            {
                Bitmap image = (Bitmap)Clipboard.GetImage();

                clipboardData.Data = ImageUtils.ImageToBase64(image);
                clipboardData.Type = ClipboardDataType.IMAGE;
                clipboardData.Id = "1";

                emitEvent = true;
            }
            else if (Clipboard.ContainsFileDropList())
            {
                StringCollection filePaths = Clipboard.GetFileDropList();
                List<ClipboardFile> files = FileUtils.GetFilesFromPaths(filePaths);

                clipboardData.Data = JsonConvert.SerializeObject(files);
                clipboardData.Type = ClipboardDataType.FILES;
                clipboardData.Id = "1";

                emitEvent = true;
            }

            if (emitEvent)
            {
                socket.Emit(Events.CLIPBOARD_CHANGE, JsonConvert.SerializeObject(clipboardData));
            }
        }

        internal void CopySharedToLocal()
        {
            string Id = "1";
            ClipboardData clipboardData = sharedClipboard[Id];

            if (clipboardData != null)
            {
                switch (clipboardData.Type)
                {
                    case ClipboardDataType.TEXT:
                        Clipboard.SetText(clipboardData.Data);
                        break;
                    case ClipboardDataType.IMAGE:
                        Clipboard.SetImage(ImageUtils.Base64ToImage(clipboardData.Data));
                        break;
                    case ClipboardDataType.FILES:
                        StringCollection filePaths = new StringCollection();
                        List<ClipboardFile> files = JsonConvert.DeserializeObject<List<ClipboardFile>>(clipboardData.Data);
                        foreach(ClipboardFile clipboardFile in files)
                        {
                            string path = FileUtils.CreateTemporaryFile(clipboardFile.Name, clipboardFile.Data);
                            if (path != null)
                            {
                                filePaths.Add(path);
                            }
                        }
                        Clipboard.SetFileDropList(filePaths);
                        break;
                    default:
                        Console.WriteLine("Unknown clipboard data type");
                        break;
                }
            }
        }
    }

}
