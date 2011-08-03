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
    class UserManager
    {
        private static JavaProperties prop;
        public static Dictionary<String, User> users;

        public static void initUsers()
        {
            System.IO.FileStream f;
            prop = new JavaProperties();
            prop.Load(f = System.IO.File.OpenRead(BenCmdInfo.configloc + "users.db"));
            f.Close();
            System.Collections.IEnumerator properties = prop.PropertyNames();
            properties.MoveNext();
            Object key;
            users = new Dictionary<String, User>();
            try
            {
                while (true)
                {
                    key = properties.Current;
                    String k = (String)key;
                    users.Add(k, new User(k, prop.GetProperty(k)));
                    properties.MoveNext();
                }
            }
            catch (InvalidOperationException)
            {
            }
        }

        public static void remUser(User u)
        {
            users.Remove(u.name);
            prop.Remove(u.name);
        }

        public static void addUser(string n)
        {
            users.Add(n, new User(n, ""));
            saveUser(users[n]);
        }

        public static void saveUsers()
        {
            System.IO.FileStream f;
            System.IO.File.WriteAllText(BenCmdInfo.configloc + "users.db", "");
            prop.Store(f = System.IO.File.OpenWrite(BenCmdInfo.configloc + "users.db"), "BenCmd User Permissions File");
            f.Close();
        }

        public static void saveUser(User u)
        {
            prop.SetProperty(u.name, u.ToString());
        }
    }
}
