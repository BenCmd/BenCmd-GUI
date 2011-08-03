using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace BCGUIConfig
{
    public partial class NamePrompt : Form
    {
        private const int SC_CLOSE = 0xF060;
        private const int MF_GRAYED = 0x1;

        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("user32.dll")]
        private static extern int EnableMenuItem(IntPtr hMenu, int wIDEnableItem, int wEnable);

        public NamePrompt()
        {
            InitializeComponent();
        }

        public String Show(string prompt, string title, bool allowCancel)
        {
            LabelPrompt.Text = prompt;
            this.Text = title;
            ButtonCancel.Enabled = allowCancel;
            if (ShowDialog() == DialogResult.OK)
            {
                return TextBoxInput.Text;
            }
            else
            {
                return "";
            }
        }

        private void NamePrompt_Load(object sender, EventArgs e)
        {
            if (!ButtonCancel.Enabled)
            {
                EnableMenuItem(GetSystemMenu(this.Handle, false), SC_CLOSE, MF_GRAYED);
            }
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
