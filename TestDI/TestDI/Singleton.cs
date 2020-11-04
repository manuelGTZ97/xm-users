using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace TestDI
{
    class Singleton
    {
        public ObservableCollection<User> Users{ get; }
        private Singleton() {
            Users = new ObservableCollection<User>();
            Users.Add(new User("test", "123456"));
        }

        private static Singleton _instance;

        public static Singleton GetInstance()
        {
            if(_instance == null)
            {
                _instance = new Singleton();
            }
            return _instance;
        }

        public void AddUser(String userName, String password) 
        {
            Users.Add(new User(userName, password));
        }

        
    }
}
