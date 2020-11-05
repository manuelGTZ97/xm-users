using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TestDI.Models;
using TestDI.ViewModels;

namespace TestDI
{
    class Singleton
    {
        public ObservableCollection<User> Users { get; set; }
        private Singleton()
        {
            Users = new ObservableCollection<User>();
            Users.Add(new User("test", "test"));
        }

        private static Singleton _instance;

        public static Singleton GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Singleton();
            }
            return _instance;
        }
    }
}
