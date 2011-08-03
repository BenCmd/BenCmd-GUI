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

namespace BCGUIConfig
{
    public class Permission
    {
        // Static
        public static List<Permission> LowRisk;
        public static List<Permission> MedRisk;
        public static List<Permission> HighRisk;

        public static Dictionary<String, Permission> Permissions;

        static Permission()
        {
            // Low risk
            LowRisk = new List<Permission>();
            LowRisk.Add(new Permission("canSpawn", "Can use /spawn"));
            LowRisk.Add(new Permission("canProtect", "Can protect chests/doors"));
            LowRisk.Add(new Permission("canReport", "Can use /report"));
            LowRisk.Add(new Permission("canListPlayers", "Can use /list"));
            LowRisk.Add(new Permission("canWarp", "Can use /warp"));
            LowRisk.Add(new Permission("canWarpOwnHomes", "Can warp to homes"));
            LowRisk.Add(new Permission("canEditOwnHomes", "Can set/delete homes"));
            LowRisk.Add(new Permission("canBackOnDeath", "Can use /back after dying"));

            // Medium Risk
            MedRisk = new List<Permission>();
            MedRisk.Add(new Permission("canSpawnItem", "Can use /item"));
            MedRisk.Add(new Permission("canMakeUnlDisp", "Can create unlimited dispensers"));
            MedRisk.Add(new Permission("canEditWarps", "Can create/delete warps"));
            MedRisk.Add(new Permission("canJail", "Can jail other players"));
            MedRisk.Add(new Permission("canUnjail", "Can unjail other players"));
            MedRisk.Add(new Permission("canWarpOtherHomes", "Can warp to other peoples' homes"));
            MedRisk.Add(new Permission("canWarpAnywhere", "Can warp to all warps"));
            MedRisk.Add(new Permission("canChangeTime", "Can use /time"));
            MedRisk.Add(new Permission("canMakeGod", "Can use /god"));
            MedRisk.Add(new Permission("canHeal", "Can use /heal"));
            MedRisk.Add(new Permission("canCheckOtherStatus", "Can check the status of others"));
            MedRisk.Add(new Permission("canSpawnMobs", "Can use /spawnmob"));
            MedRisk.Add(new Permission("canReloadConfig", "Can use /bencmd rel"));
            MedRisk.Add(new Permission("canSlowMode", "Can use /slow"));
            MedRisk.Add(new Permission("canMute", "Can mute players"));
            MedRisk.Add(new Permission("canUnmute", "Can unmute players"));
            MedRisk.Add(new Permission("canPoof", "Can use /poof"));
            MedRisk.Add(new Permission("canNopoof", "Can use /nopoof"));
            MedRisk.Add(new Permission("canOffline", "Can use /offline and /online"));
            MedRisk.Add(new Permission("canControlWeather", "Can use /storm"));
            MedRisk.Add(new Permission("canStrike", "Can use /strike"));
            MedRisk.Add(new Permission("canFly", "Overrides fly protection"));
            MedRisk.Add(new Permission("isTicketAdmin", "Is a ticket administrator"));
            MedRisk.Add(new Permission("canKick", "Can use /kick"));
            MedRisk.Add(new Permission("noKickDelay", "Overrides kick delay"));
            MedRisk.Add(new Permission("canTpSelf", "Can use /tp to teleport themself"));
            MedRisk.Add(new Permission("canTpOther", "Can use /tp to teleport others"));

            // High Risk
            HighRisk = new List<Permission>();
            HighRisk.Add(new Permission("canSetSpawn", "Can use /setspawn"));
            HighRisk.Add(new Permission("canClearInventory", "Can use /clrinv"));
            HighRisk.Add(new Permission("canKill", "Can use /kill"));
            HighRisk.Add(new Permission("canEditOtherHomes", "Can set/delete other peoples' homes"));
            HighRisk.Add(new Permission("isProtectionAdmin", "Is a protection administrator"));
            HighRisk.Add(new Permission("canControlMarket", "Can use /market"));
            HighRisk.Add(new Permission("isLandlord", "Can use /lot to set/edit lots"));
            HighRisk.Add(new Permission("canChangePerm", "Can use /user and /group"));
            HighRisk.Add(new Permission("*", "Has all permissions"));

            // All permissions
            Permissions = new Dictionary<String, Permission>();
            foreach (Permission p in LowRisk)
            {
                Permissions.Add(p.name, p);
            }
            foreach (Permission p in MedRisk)
            {
                Permissions.Add(p.name, p);
            }
            foreach (Permission p in HighRisk)
            {
                Permissions.Add(p.name, p);
            }
        }

        // Non-static
        public string name;
        public string desc;

        private Permission(string p, string d)
        {
            name = p;
            desc = d;
        }
    }
}
