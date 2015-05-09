﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace SharedClipboard
{
    public class ClipboardManager : IDisposable
    {
        
        public static IntPtr HWND_MESSAGE = new IntPtr(-3);

        /// <summary>
        /// Adds the given window to the system-maintained clipboard format listener list.
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AddClipboardFormatListener(IntPtr hwnd);

        /// <summary>
        /// Removes the given window from the system-maintained clipboard format listener list.
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool RemoveClipboardFormatListener(IntPtr hwnd);

        // See http://msdn.microsoft.com/en-us/library/ms633541%28v=vs.85%29.aspx
        // See http://msdn.microsoft.com/en-us/library/ms649033%28VS.85%29.aspx
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

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

        public ClipboardManager(IntPtr handle, int id)
        {
            this.Handle = handle;
            this.ID = id;

            //SetParent(Handle, HWND_MESSAGE); do we need this?
            AddClipboardFormatListener(Handle);
        }

        public void Dispose()
        {
            Dispose(true);
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
                //IDataObject iData = Clipboard.GetDataObject();      // Clipboard's data.

                ///* Depending on the clipboard's current data format we can process the data differently. 
                // * Feel free to add more checks if you want to process more formats. */
                //if (iData.GetDataPresent(DataFormats.Text))
                //{
                //    string text = (string)iData.GetData(DataFormats.Text);
                //    // do something with it
                //}
                //else if (iData.GetDataPresent(DataFormats.Bitmap))
                //{
                //    Bitmap image = (Bitmap)iData.GetData(DataFormats.Bitmap);
                //    // do something with it
                //}
            }
        }
    }

}
