using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;




namespace ProiectMobile
{
    public class UsersDataAccess
    {
        private SQLiteConnection database;
        private static object collisionLock = new object();
        public ObservableCollection<User> Users { get; set; }

        public UsersDataAccess()
        {
            database = DependencyService.Get<ISQLiteDb>().DbConnection();
            database.CreateTable<User>();
            this.Users = new ObservableCollection<User>(database.Table<User>());

            if (!database.Table<User>().Any())
            {
                AddNewUser();
            }
        }

        public void AddNewUser()
        {
            this.Users.Add(new User
            {
                Name = "",
                Email = "",
                Phone = ""
            });
            
        }

        public void SaveUser()
        {
            lock (collisionLock)
            {
                foreach (var userInstance in this.Users)
                {              
                        if (userInstance.Id != 0)
                        {
                            database.Update(userInstance);
                        }
                        else
                        {
                            database.Insert(userInstance);
                        }                    
                }
            }
        }

        public int DeleteUser(User userInstance)
        {
            var id = userInstance.Id;
            if (id !=0)
            {
                lock (collisionLock)
                {
                    database.Delete<User>(id);
                }
            }
            this.Users.Remove(userInstance);
            return id;
        }
    }
}
