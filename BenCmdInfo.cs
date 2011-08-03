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
using System.Linq;
using System.Text;
using Kajabity.Tools.Java;

namespace BCGUIConfig
{
    class BenCmdInfo
    {
        public static string configloc;
        private static JavaProperties prop;
        public static short daySpeed;
        public static short nightSpeed;
        public static bool allowFireSpread;
        public static bool allowFireDamage;
        public static bool creepersPassive;
        public static bool allowTNT;
        public static bool allowFlight;
        public static bool gravesEnabled;
        public static bool channelsEnabled;
        public static bool externalChat;
        public static bool externalMaxPlayers;
        public static int graveDuration;
        public static bool redstoneUnlDisp;
        public static byte pluginCheckFailLevel;
        public static bool reserveActive;
        public static bool indefActive;
        public static int maxPlayers;
        public static int maxReserve;

        public static void initAll(string config)
        {
            initMain(config);
            UserManager.initUsers();
        }

        public static void initMain(string config)
        {
            System.IO.FileStream f;
            if (config.EndsWith("\\"))
            {
                configloc = config;
            }
            else
            {
                configloc = config + "\\";
            }
            prop = new JavaProperties();
            prop.Load(f = System.IO.File.OpenRead(configloc + "main.properties"));
            f.Close();
            daySpeed = Convert.ToInt16(prop.GetProperty("daySpeed", "100"), 10);
            nightSpeed = Convert.ToInt16(prop.GetProperty("nightSpeed", "100"), 10);
            allowFireSpread = (prop.GetProperty("allowFireSpread", "false") == "true");
            allowFireDamage = (prop.GetProperty("allowFireDamage", "false") == "true");
            creepersPassive = (prop.GetProperty("creepersPassive", "false") == "true");
            allowTNT = (prop.GetProperty("allowTNT", "false") == "true");
            allowFlight = (prop.GetProperty("allowFlight", "false") == "true");
            gravesEnabled = (prop.GetProperty("gravesEnabled", "true") == "true");
            channelsEnabled = (prop.GetProperty("channelsEnabled", "false") == "true");
            externalChat = (prop.GetProperty("externalChat", "false") == "true");
            externalMaxPlayers = (prop.GetProperty("externalMaxPlayers", "false") == "true");
            graveDuration = Convert.ToInt32(prop.GetProperty("graveDuration", "180"), 10);
            redstoneUnlDisp = (prop.GetProperty("redstoneUnlDisp", "true") == "true");
            pluginCheckFailLevel = Convert.ToByte(prop.GetProperty("pluginCheckFailLevel", "1"), 10);
            reserveActive = (prop.GetProperty("reserveActive", "true") == "true");
            indefActive = (prop.GetProperty("indefActive", "true") == "true");
            maxPlayers = Convert.ToInt16(prop.GetProperty("maxPlayers", "10"), 10);
            maxReserve = Convert.ToInt16(prop.GetProperty("maxReserve", "4"), 10);
        }

        public static void saveAll()
        {
            saveMain();
            UserManager.saveUsers();
        }

        public static void saveMain()
        {
            System.IO.FileStream f;
            prop.SetProperty("daySpeed", daySpeed.ToString());
            prop.SetProperty("nightSpeed", nightSpeed.ToString());
            prop.SetProperty("allowFireSpread", (allowFireSpread) ? "true" : "false");
            prop.SetProperty("allowFireDamage", (allowFireDamage) ? "true" : "false");
            prop.SetProperty("creepersPassive", (creepersPassive) ? "true" : "false");
            prop.SetProperty("allowTNT", (allowTNT) ? "true" : "false");
            prop.SetProperty("allowFlight", (allowFlight) ? "true" : "false");
            prop.SetProperty("gravesEnabled", (gravesEnabled) ? "true" : "false");
            prop.SetProperty("channelsEnabled", (channelsEnabled) ? "true" : "false");
            prop.SetProperty("externalChat", (externalChat) ? "true" : "false");
            prop.SetProperty("externalMaxPlayers", (externalMaxPlayers) ? "true" : "false");
            prop.SetProperty("graveDuration", graveDuration.ToString());
            prop.SetProperty("redstoneUnlDisp", (redstoneUnlDisp) ? "true" : "false");
            prop.SetProperty("pluginCheckFailLevel", pluginCheckFailLevel.ToString());
            prop.SetProperty("reserveActive", (reserveActive) ? "true" : "false");
            prop.SetProperty("indefActive", (indefActive) ? "true" : "false");
            prop.SetProperty("maxPlayers", maxPlayers.ToString());
            prop.SetProperty("maxReserve", maxReserve.ToString());
            prop.Store(f = System.IO.File.OpenWrite(configloc + "main.properties"), "-BenCmd Main Config-");
            f.Close();
        }
    }
}
