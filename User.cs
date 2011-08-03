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
    public class User : IComparable<User>
    {
        public string name;
        public Dictionary<Permission, PermType> permissions;
        public List<String> unknownPermissions;

        public int CompareTo(User other)
        {
            return name.CompareTo(other.name);
        }

        public User(string n, Dictionary<Permission, PermType> p, List<String> s)
        {
            name = n;
            permissions = p;
            unknownPermissions = s;
        }

        public User(string n, string val)
        {
            name = n;
            permissions = new Dictionary<Permission, PermType>();
            unknownPermissions = new List<String>();
            string[] p = val.Split(',');
            foreach (string s in p)
            {
                if (s.StartsWith("-"))
                {
                    if (Permission.Permissions.ContainsKey(s.Remove(0, 1)))
                    {
                        permissions.Add(Permission.Permissions[s.Remove(0, 1)], PermType.Deny);
                    }
                    else
                    {
                        unknownPermissions.Add(s);
                    }
                }
                else if (Permission.Permissions.ContainsKey(s))
                {
                    permissions.Add(Permission.Permissions[s], PermType.Allow);
                }
                else
                {
                    unknownPermissions.Add(s);
                }
            }
        }

        public override string ToString()
        {
            string val = "";
            foreach (KeyValuePair<Permission, PermType> p in permissions)
            {
                String s = p.Key.name;
                if (p.Value == PermType.Deny)
                {
                    s = "-" + s;
                }
                if (val == "")
                {
                    val = s;
                }
                else
                {
                    val += "," + s;
                }
            }

            foreach (string s in unknownPermissions)
            {
                if (val == "")
                {
                    val = s;
                }
                else
                {
                    val += "," + s;
                }
            }
            return val;
        }

        public enum PermType
        {
            Allow, Deny
        }
    }
}
