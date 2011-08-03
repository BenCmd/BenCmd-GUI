/**
 * BenCmd Configuration Utility v1.0.0
 * Copyright (C) 2011 Benjamin C. Thomas (ben_dude56)
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;

namespace BCGUIConfig
{
    public partial class MainWindow : Form
    {
        private Dictionary<Permission, CheckBox> UAllow;
        private Dictionary<Permission, CheckBox> UDeny;
        private bool ULoading = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            if (new ConfigPrompt().ShowDialog() != DialogResult.OK)
            {
                this.Close();
                return;
            }
            InitP();
            InitVal();
            InitTT();
        }

        private void InitP()
        {
            UAllow = new Dictionary<Permission, CheckBox>();
            UDeny = new Dictionary<Permission, CheckBox>();
            TableUPerms.RowCount = Permission.Permissions.Count;
            TableUPerms.Size = new Size(TableUPerms.Width, TableUPerms.RowCount * 25);
            TableUPerms.RowStyles.Clear();
            for (int i = 0; i < Permission.Permissions.Count; i++)
            {
                TableUPerms.RowStyles.Add(new RowStyle(SizeType.Absolute, 25));
                Permission p = Permission.Permissions.Values.ToArray()[i];
                Label l = new Label();
                TableUPerms.Controls.Add(l, 0, i);
                l.Text = p.desc;
                l.Anchor = AnchorStyles.Left;
                l.AutoSize = true;
                CheckBox a = new CheckBox();
                TableUPerms.Controls.Add(a, 1, i);
                a.Text = "";
                a.CheckedChanged += new EventHandler(UPerm_CheckedChanged);
                UAllow.Add(p, a);
                CheckBox d = new CheckBox();
                TableUPerms.Controls.Add(d, 2, i);
                d.Text = "";
                d.CheckedChanged += new EventHandler(UPerm_CheckedChanged);
                UDeny.Add(p, d);
            }
        }

        private void InitVal()
        {
            advancedViewToolStripMenuItem.Checked = Properties.Settings.Default.AdvancedView;
            if (BenCmdInfo.daySpeed > 200)
            {
                BarDay.Value = 200;
                TextDay.Text = BenCmdInfo.daySpeed.ToString();
            }
            else
            {
                BarDay.Value = BenCmdInfo.daySpeed;
                TextDay.Text = BenCmdInfo.daySpeed.ToString();
            }
            if (BenCmdInfo.nightSpeed > 200)
            {
                BarNight.Value = 200;
                TextNight.Text = BenCmdInfo.nightSpeed.ToString();
            }
            else
            {
                BarNight.Value = BenCmdInfo.nightSpeed;
                TextNight.Text = BenCmdInfo.nightSpeed.ToString();
            }
            CheckFSpread.Checked = BenCmdInfo.allowFireSpread;
            CheckFDamage.Checked = BenCmdInfo.allowFireDamage;
            if (BenCmdInfo.allowFireSpread && BenCmdInfo.allowFireDamage)
            {
                CheckFireProtect.CheckState = CheckState.Unchecked;
            }
            else if (BenCmdInfo.allowFireSpread || BenCmdInfo.allowFireDamage)
            {
                CheckFireProtect.CheckState = CheckState.Indeterminate;
            }
            else
            {
                CheckFireProtect.CheckState = CheckState.Checked;
            }
            CheckCreeperPassive.Checked = BenCmdInfo.creepersPassive;
            CheckTNTProtect.Checked = !BenCmdInfo.allowTNT;
            CheckFlyProtect.Checked = !BenCmdInfo.allowFlight;
            CheckGraves.Checked = BenCmdInfo.gravesEnabled;
            PanelGrave.Enabled = BenCmdInfo.gravesEnabled;
            CheckChannels.Checked = BenCmdInfo.channelsEnabled;
            CheckChannels.Enabled = !BenCmdInfo.externalChat;
            CheckExtChat.Checked = BenCmdInfo.externalChat;
            CheckExtMP.Checked = BenCmdInfo.externalMaxPlayers;
            TextBoxGrave.Text = BenCmdInfo.graveDuration.ToString();
            CheckRADisp.Checked = BenCmdInfo.redstoneUnlDisp;
            switch (BenCmdInfo.pluginCheckFailLevel)
            {
                case 0:
                    RadioMinor.Checked = true;
                    break;
                case 1:
                    RadioMid.Checked = true;
                    break;
                case 2:
                    RadioSevere.Checked = true;
                    break;
                default:
                    RadioNone.Checked = true;
                    break;
            }
            CheckReserve.Checked = BenCmdInfo.reserveActive;
            CheckIndReserve.Checked = BenCmdInfo.indefActive;
            TextBoxMax.Text = BenCmdInfo.maxPlayers.ToString();
            TextBoxRMax.Text = BenCmdInfo.maxReserve.ToString();
            TextBoxRMax.Enabled = BenCmdInfo.reserveActive;
            ListUsers.Items.Clear();
            List<User> users = new List<User>();
            users.AddRange(UserManager.users.Values);
            users.Sort();
            foreach (User u in users)
            {
                ListUsers.Items.Add(u.name);
            }
            UPermEnabled(false);
        }

        private void UPermEnabled(bool enabled)
        {
            ULoading = true;
            foreach (CheckBox c in UAllow.Values)
            {
                if (!enabled)
                {
                    c.Checked = false;
                }
                c.Enabled = enabled;
            }
            foreach (CheckBox c in UDeny.Values)
            {
                if (!enabled)
                {
                    c.Checked = false;
                }
                c.Enabled = enabled;
            }
            ButtonRemoveUser.Enabled = enabled;
            ULoading = false;
        }

        private void InitTT()
        {
            TTProvider.SetToolTip(BarDay, "The speed at which day progresses.");
            TTProvider.SetToolTip(TextDay, "The speed at which day progresses.");
            TTProvider.SetToolTip(BarNight, "The speed at which night progresses.");
            TTProvider.SetToolTip(TextNight, "The speed at which night progresses.");
            TTProvider.SetToolTip(CheckFireProtect, "Enables/disables fire protection. A box typically means that fire can spread,\nbut will cause no damage.");
            TTProvider.SetToolTip(CheckTNTProtect, "Enables/disables the blocking of TNT detonations.");
            TTProvider.SetToolTip(CheckCreeperPassive, "Enables/disables friendly creepers. Friendly creepers will never target a player.");
            TTProvider.SetToolTip(CheckFlyProtect, "Enables/disables BenCmd's attempts to prevent players from using flymods.");
            TTProvider.SetToolTip(CheckGraves, "Enables/disables graves. Graves will store a player's items until they log off or\nthe grave timeout runs out.");
            TTProvider.SetToolTip(CheckChannels, "Enables/disables the use of chat channels. Chat channels allow players to chat in\nseparate \"chat channels\" from others.");
            TTProvider.SetToolTip(CheckRADisp, "Enables/disables the ability for redstone to activate an unlimited dispenser.");
            TTProvider.SetToolTip(CheckFSpread, "Checking this allows fire to spread. This is a sub-option of the fire protection\nsystem.");
            TTProvider.SetToolTip(CheckFDamage, "Checking this allows fire to destroy blocks. This is a sub-option of the fire \nprotection system.");
            TTProvider.SetToolTip(CheckExtChat, "Makes BenCmd ignore all player chat, allowing the use of an external chat plugin.");
            TTProvider.SetToolTip(TextBoxGrave, "The time (in seconds) from the time a grave appears until it is destroyed.");
            TTProvider.SetToolTip(RadioMinor, "Controls the level of plugin conflict at which BenCmd will refuse to start.");
            TTProvider.SetToolTip(RadioMid, "Controls the level of plugin conflict at which BenCmd will refuse to start.");
            TTProvider.SetToolTip(RadioSevere, "Controls the level of plugin conflict at which BenCmd will refuse to start.");
            TTProvider.SetToolTip(RadioNone, "Controls the level of plugin conflict at which BenCmd will refuse to start.");
        }

        private void TextDay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                this.Focus();
                return;
            }
            if (e.KeyChar != '\b' && !Char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
                SystemSounds.Beep.Play();
            }
        }

        private void BarDay_Scroll(object sender, EventArgs e)
        {
            TextDay.Text = BarDay.Value.ToString();
            BenCmdInfo.daySpeed = (short)BarDay.Value;
        }

        private void TextDay_TextChanged(object sender, EventArgs e)
        {
            if (TextDay.Text == "")
            {
                BarDay.Value = 0;
            }
            else if (Convert.ToInt32(TextDay.Text) <= 200)
            {
                BarDay.Value = Convert.ToInt32(TextDay.Text);
            }
            else
            {
                BarDay.Value = 200;
            }
            BenCmdInfo.daySpeed = (short)BarDay.Value;
        }

        private void BarNight_Scroll(object sender, EventArgs e)
        {
            TextNight.Text = BarNight.Value.ToString();
            BenCmdInfo.nightSpeed = (short)BarDay.Value;
        }

        private void TextNight_TextChanged(object sender, EventArgs e)
        {
            if (TextNight.Text == "")
            {
                BarNight.Value = 0;
            }
            else if (Convert.ToInt32(TextNight.Text) <= 200)
            {
                BarNight.Value = Convert.ToInt32(TextNight.Text);
            }
            else
            {
                BarNight.Value = 200;
            }
            BenCmdInfo.nightSpeed = (short)BarNight.Value;
        }

        private void TextNight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                this.Focus();
                return;
            }
            if (e.KeyChar != '\b' && !Char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
                SystemSounds.Beep.Play();
            }
        }

        private void openConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (MessageBox.Show("Would you like to save this configuration first?", "BenCmd GUI Configuration", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
            {
                case DialogResult.Yes:
                    BenCmdInfo.saveAll();
                    goto case DialogResult.No;
                case DialogResult.No:
                    if (new ConfigPrompt().ShowDialog() == DialogResult.OK)
                    {
                        InitVal();
                    }
                    break;
            }
        }

        private void advancedViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            advancedViewToolStripMenuItem.Checked = !Properties.Settings.Default.AdvancedView;
            Properties.Settings.Default.AdvancedView = !Properties.Settings.Default.AdvancedView;
        }

        private void advancedViewToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            GBAdv.Visible = advancedViewToolStripMenuItem.Checked;
        }

        private void CheckFireProtect_CheckedChanged(object sender, EventArgs e)
        {
            bool cont;
            if (BenCmdInfo.allowFireSpread && BenCmdInfo.allowFireDamage)
            {
                cont = (CheckFireProtect.CheckState != CheckState.Unchecked);
            }
            else if (BenCmdInfo.allowFireSpread || BenCmdInfo.allowFireDamage)
            {
                cont = (CheckFireProtect.CheckState != CheckState.Indeterminate);
            }
            else
            {
                cont = (CheckFireProtect.CheckState != CheckState.Checked);
            }
            if (cont)
            {
                CheckFSpread.Checked = !CheckFireProtect.Checked;
                CheckFDamage.Checked = !CheckFireProtect.Checked;
            }
        }

        private void CheckTNTProtect_CheckedChanged(object sender, EventArgs e)
        {
            BenCmdInfo.allowTNT = !CheckTNTProtect.Checked;
        }

        private void CheckCreeperPassive_CheckedChanged(object sender, EventArgs e)
        {
            BenCmdInfo.creepersPassive = CheckCreeperPassive.Checked;
        }

        private void CheckFlyProtect_CheckedChanged(object sender, EventArgs e)
        {
            BenCmdInfo.allowFlight = !CheckFlyProtect.Checked;
        }

        private void CheckGraves_CheckedChanged(object sender, EventArgs e)
        {
            BenCmdInfo.gravesEnabled = CheckGraves.Checked;
            PanelGrave.Enabled = CheckGraves.Checked;
        }

        private void CheckChannels_CheckedChanged(object sender, EventArgs e)
        {
            BenCmdInfo.channelsEnabled = CheckChannels.Checked;
        }

        private void CheckExtChat_CheckedChanged(object sender, EventArgs e)
        {
            BenCmdInfo.externalChat = CheckExtChat.Checked;
            CheckChannels.Enabled = !BenCmdInfo.externalChat;
        }

        private void CheckFSpread_CheckedChanged(object sender, EventArgs e)
        {
            BenCmdInfo.allowFireSpread = CheckFSpread.Checked;
            if (BenCmdInfo.allowFireSpread && BenCmdInfo.allowFireDamage)
            {
                CheckFireProtect.CheckState = CheckState.Unchecked;
            }
            else if (BenCmdInfo.allowFireSpread || BenCmdInfo.allowFireDamage)
            {
                CheckFireProtect.CheckState = CheckState.Indeterminate;
            }
            else
            {
                CheckFireProtect.CheckState = CheckState.Checked;
            }
        }

        private void CheckFDamage_CheckedChanged(object sender, EventArgs e)
        {
            BenCmdInfo.allowFireDamage = CheckFDamage.Checked;
            if (BenCmdInfo.allowFireSpread && BenCmdInfo.allowFireDamage)
            {
                CheckFireProtect.CheckState = CheckState.Unchecked;
            }
            else if (BenCmdInfo.allowFireSpread || BenCmdInfo.allowFireDamage)
            {
                CheckFireProtect.CheckState = CheckState.Indeterminate;
            }
            else
            {
                CheckFireProtect.CheckState = CheckState.Checked;
            }
        }

        private void TextBoxGrave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                this.Focus();
                return;
            }
            if (e.KeyChar != '\b' && !Char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
                SystemSounds.Beep.Play();
            }
        }

        private void TextBoxGrave_TextChanged(object sender, EventArgs e)
        {
            if (TextBoxGrave.Text == "")
            {
                BenCmdInfo.graveDuration = 0;
            }
            else
            {
                BenCmdInfo.graveDuration = Convert.ToInt32(TextBoxGrave.Text, 10);
            }
        }

        private void CheckRADisp_CheckedChanged(object sender, EventArgs e)
        {
            BenCmdInfo.redstoneUnlDisp = CheckRADisp.Checked;
        }

        private void RadioNone_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioNone.Checked)
            {
                BenCmdInfo.pluginCheckFailLevel = 3;
                MessageBox.Show("This option may allow for situations where your world and/or BenCmd databases may become corrupt! Please do not submit bug reports when using this level, as plugins classified under the \"severe\" level are known to cause serious problems...", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (MessageBox.Show("Would you like to save this configuration first?", "BenCmd GUI Configuration", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
            {
                case DialogResult.Yes:
                    BenCmdInfo.saveAll();
                    goto case DialogResult.No;
                case DialogResult.No:
                    this.Close();
                    break;
            }
        }

        private void RadioSevere_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioSevere.Checked)
            {
                BenCmdInfo.pluginCheckFailLevel = 2;
            }
        }

        private void RadioMid_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioMid.Checked)
            {
                BenCmdInfo.pluginCheckFailLevel = 1;
            }
        }

        private void RadioMinor_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioMinor.Checked)
            {
                BenCmdInfo.pluginCheckFailLevel = 0;
            }
        }

        private void saveConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BenCmdInfo.saveAll();
        }

        private void CheckExtMP_CheckedChanged(object sender, EventArgs e)
        {
            BenCmdInfo.externalMaxPlayers = CheckExtMP.Checked;
            GBMP.Enabled = !CheckExtMP.Checked;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new About().ShowDialog();
        }

        private void CheckReserve_CheckedChanged(object sender, EventArgs e)
        {
            BenCmdInfo.reserveActive = CheckReserve.Checked;
            PanelRMax.Enabled = CheckReserve.Checked;
        }

        private void CheckIndReserve_CheckedChanged(object sender, EventArgs e)
        {
            BenCmdInfo.indefActive = CheckIndReserve.Checked;
        }

        private void TextBoxMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                this.Focus();
                return;
            }
            if (e.KeyChar != '\b' && !Char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
                SystemSounds.Beep.Play();
            }
        }

        private void TextBoxRMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                this.Focus();
                return;
            }
            if (e.KeyChar != '\b' && !Char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
                SystemSounds.Beep.Play();
            }
        }

        private void TextBoxMax_TextChanged(object sender, EventArgs e)
        {
            BenCmdInfo.maxPlayers = Convert.ToInt32(TextBoxMax.Text, 10);
        }

        private void TextBoxRMax_TextChanged(object sender, EventArgs e)
        {
            BenCmdInfo.maxReserve = Convert.ToInt32(TextBoxRMax.Text, 10);
        }

        private void UPerm_CheckedChanged(object sender, EventArgs e)
        {
            if (!ULoading)
            {
                foreach (KeyValuePair<Permission, CheckBox> kvp in UAllow)
                {
                    if (kvp.Value == sender)
                    {
                        if (UDeny[kvp.Key].Checked)
                        {
                            UDeny[kvp.Key].Checked = false;
                        }
                    }
                }
                SaveUPerms(ListUsers.Items[ListUsers.SelectedIndex].ToString());
                PopulateUPerms(ListUsers.Items[ListUsers.SelectedIndex].ToString());
            }
        }

        private void PopulateUPerms(string user)
        {
            ULoading = true;
            User u = UserManager.users[user];
            foreach (Permission p in Permission.Permissions.Values)
            {
                if (u.permissions.ContainsKey(p))
                {
                    if (u.permissions[p] == User.PermType.Allow)
                    {
                        UAllow[p].Checked = true;
                        UDeny[p].Checked = false;
                    }
                    else
                    {
                        UAllow[p].Checked = false;
                        UDeny[p].Checked = true;
                    }
                }
                else
                {
                    UAllow[p].Checked = false;
                    UDeny[p].Checked = false;
                }
            }
            ULoading = false;
        }

        private void SaveUPerms(string user)
        {
            User u = UserManager.users[user];
            u.permissions.Clear();
            foreach (Permission p in Permission.Permissions.Values)
            {
                if (UDeny[p].Checked)
                {
                    u.permissions.Add(p, User.PermType.Deny);
                }
                else if (UAllow[p].Checked)
                {
                    u.permissions.Add(p, User.PermType.Allow);
                }
            }
            UserManager.saveUser(u);
        }

        private void ListUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListUsers.SelectedIndex == -1)
            {
                UPermEnabled(false);
            }
            else
            {
                UPermEnabled(true);
                PopulateUPerms(ListUsers.Items[ListUsers.SelectedIndex].ToString());
            }
        }

        private void ButtonRemoveUser_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to remove that user?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                UserManager.remUser(UserManager.users[ListUsers.Items[ListUsers.SelectedIndex].ToString()]);
                ListUsers.Items.Remove(ListUsers.Items[ListUsers.SelectedIndex]);
                ListUsers.SelectedIndex = -1;
            }
        }

        private void ButtonNewUser_Click(object sender, EventArgs e)
        {
            string name = new NamePrompt().Show("Enter a username:", "Enter username", true);
            if (name != "")
            {
                UserManager.addUser(name);
                ListUsers.Items.Add(name);
                ListUsers.SelectedIndex = ListUsers.Items.Count - 1;
            }
        }

        private void TextBoxSearch_TextChanged(object sender, EventArgs e)
        {
            string cName;
            if (ListUsers.SelectedIndex != -1)
            {
                cName = ListUsers.Items[ListUsers.SelectedIndex].ToString().ToLower();
            }
            else
            {
                cName = "";
            }
            ListUsers.Items.Clear();
            List<User> users = new List<User>();
            users.AddRange(UserManager.users.Values);
            users.Sort();
            foreach (User u in users)
            {
                if (u.name.ToLower().Contains(TextBoxSearch.Text.ToLower()))
                {
                    ListUsers.Items.Add(u.name);
                }
            }
            
            if (ListUsers.Items.Contains(cName))
            {
                ListUsers.SelectedItem = cName;
            }
            else
            {
                UPermEnabled(false);
            }
        }
    }
}
