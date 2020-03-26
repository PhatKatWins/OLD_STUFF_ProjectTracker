using ProjectTracker.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;

namespace ProjectTracker.ViewModel.Helpers
{
    static class DataBaseHelper
    {
        private static readonly string dataSaveFolder = Directory.GetCurrentDirectory() + @"\Data";
        private static readonly string dataFile = dataSaveFolder + @"\data.ptd";

        public static bool InsertUser(User user)
        {
            Directory.CreateDirectory(dataSaveFolder);

            using (SQLiteConnection conn = new SQLiteConnection(dataFile))
            {
                conn.CreateTable<User>();

                int affectedRows = conn.Insert(user);
                if (affectedRows == 1) return true;
            }

            return false;
        }

        public static User FindUser(User targetUser)
        {

            using(SQLiteConnection conn = new SQLiteConnection(dataFile))
            {
                conn.CreateTable<User>();

                var userList = conn.Table<User>().ToList();

                foreach (User user in userList)
                {
                    if(user.Name == targetUser.Name)
                    {
                        if (user.Number == targetUser.Number) return user;
                    }
                }
            }
            return null;
        }

        public static bool NumberExists(string number)
        {
            using(SQLiteConnection conn = new SQLiteConnection(dataFile))
            {
                conn.CreateTable<User>();

                var userList = conn.Table<User>();
                
                foreach(User user in userList)
                {
                    if (user.Number == number) return true;
                }
            }
            return false;
        }
    }
}
