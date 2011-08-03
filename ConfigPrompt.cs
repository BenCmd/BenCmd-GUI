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

namespace BCGUIConfig
{
    public partial class ConfigPrompt : Form
    {
        public ConfigPrompt()
        {
            InitializeComponent();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            // Exit the GUI Config
            this.Close();
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            // Check that the directory specified exists
            if (System.IO.Directory.Exists(TextBoxEntry.Text))
            {
                string[] contents = System.IO.Directory.GetFiles(TextBoxEntry.Text);
                // Prepare a list of files that must be present
                Dictionary<string, bool> isPresent = new Dictionary<string, bool>();
                isPresent.Add("action.db", false);
                isPresent.Add("bank.db", false);
                isPresent.Add("channels.db", false);
                isPresent.Add("chest.db", false);
                isPresent.Add("disp.db", false);
                isPresent.Add("groups.db", false);
                isPresent.Add("homes.db", false);
                isPresent.Add("itembw.db", false);
                isPresent.Add("items.txt", false);
                isPresent.Add("kits.db", false);
                isPresent.Add("lever.db", false);
                isPresent.Add("lots.db", false);
                isPresent.Add("main.properties", false);
                isPresent.Add("npc.db", false);
                isPresent.Add("portals.db", false);
                isPresent.Add("prices.db", false);
                isPresent.Add("protection.db", false);
                isPresent.Add("shelves.db", false);
                isPresent.Add("sparea.db", false);
                isPresent.Add("tickets.db", false);
                isPresent.Add("users.db", false);
                isPresent.Add("warps.db", false);
                // Check for these files
                foreach (string file in contents)
                {
                    string typeOf = "";
                    foreach (KeyValuePair<string, bool> req in isPresent)
                    {
                        if (file.EndsWith(req.Key))
                        {
                            typeOf = req.Key;
                            break;
                        }
                    }
                    if (typeOf != "")
                    {
                        isPresent[typeOf] = true;
                    }
                }
                foreach (KeyValuePair<string, bool> req in isPresent)
                {
                    if (req.Value == false)
                    {
                        MessageBox.Show("That directory is missing one or more BenCmd files!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                try
                {
                    BenCmdInfo.initAll(TextBoxEntry.Text);
                }
                catch (System.IO.IOException)
                {
                    MessageBox.Show("There was an error reading from that configuration directory! Check that the BenCmd config is not open in another program and try again...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                catch (FormatException)
                {
                    MessageBox.Show("There was an error reading the data contained within the configuration files! The configuration may be corrupt or an invalid entry may have been used.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                catch (IndexOutOfRangeException)
                {
                    MessageBox.Show("There was an error reading the data contained within the configuration files! The configuration may be corrupt or an invalid entry may have been used.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                catch (Kajabity.Tools.Java.ParseException)
                {
                    MessageBox.Show("There was an error reading the data contained within the configuration files! The configuration may be corrupt or an invalid entry may have been used.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An unknown error was encountered:\n" + ex.ToString(), "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
                Properties.Settings.Default.LastPath = TextBoxEntry.Text;
                Properties.Settings.Default.Save();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("That directory doesn't exist! Check for misspellings and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonBrowse_Click(object sender, EventArgs e)
        {
            FBDConfig.SelectedPath = TextBoxEntry.Text;
            if (FBDConfig.ShowDialog() == DialogResult.OK)
            {
                TextBoxEntry.Text = FBDConfig.SelectedPath;
            }
        }

        private void TextBoxEntry_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Make the enter key press OK
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                ButtonOK.PerformClick();
            }
        }

        private void ConfigPrompt_Load(object sender, EventArgs e)
        {
            TextBoxEntry.Text = Properties.Settings.Default.LastPath;
        }
    }
}
