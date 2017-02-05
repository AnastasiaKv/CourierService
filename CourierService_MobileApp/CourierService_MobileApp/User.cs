using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace CourierService_MobileApp
{
    public class User
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public User(int id, string firstName, string lastName, string email, string password)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
        }

    }
}