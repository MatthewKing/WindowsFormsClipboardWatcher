using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WindowsFormsClipboardWatcher
{
    /// <summary>
    /// Provides the <see cref="ClipboardUpdate"/> event,
    /// which notifies the subscriber every time the Windows clipboard is updated.
    /// </summary>
    public static class ClipboardWatcher
    {
        /// <summary>
        /// Raised whenever the clipboard is updated.
        /// </summary>
        public static event EventHandler ClipboardUpdate;

        /// <summary>
        /// Gets the shared instance of the <see cref="ClipboardWatcherForm"/>.
        /// </summary>
        private static ClipboardWatcherForm Instance { get; }

        /// <summary>
        /// Initializes static members for the <see cref="ClipboardWatcher"/> class.
        /// </summary>
        static ClipboardWatcher()
        {
            Instance = new ClipboardWatcherForm();
        }

        private sealed class ClipboardWatcherForm : Form
        {
            public ClipboardWatcherForm()
            {
                NativeMethods.SetParent(Handle, new IntPtr(-3)); // HWND_MESSAGE
                NativeMethods.AddClipboardFormatListener(Handle);
            }

            protected override void WndProc(ref Message m)
            {
                if (m.Msg == 0x031D) // WM_CLIPBOARDUPDATE
                {
                    ClipboardUpdate?.Invoke(null, EventArgs.Empty);
                }

                base.WndProc(ref m);
            }

            private static class NativeMethods
            {
                [DllImport("user32.dll", SetLastError = true)]
                [return: MarshalAs(UnmanagedType.Bool)]
                public static extern bool AddClipboardFormatListener(IntPtr hwnd);

                [DllImport("user32.dll", SetLastError = true)]
                public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
            }
        }
    }
}
