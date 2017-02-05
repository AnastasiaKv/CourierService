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
using Android.Support.V7.App;
using Android.Util;
using System.Threading.Tasks;

namespace CourierService_MobileApp
{

    [Activity(Theme = "@style/MyTheme.Splash", MainLauncher = true, NoHistory = true, Label = "Courier", Icon = "@drawable/ico3")]
    public class SplashActivity : AppCompatActivity
    {
        static readonly string TAG = "X:" + typeof(SplashActivity).Name;
        private Intent intent;
        public override void OnCreate(Bundle savedInstanceState, PersistableBundle persistentState)
        {
            base.OnCreate(savedInstanceState, persistentState);
            Log.Debug(TAG, "SplashActivity.OnCreate");
        }

        protected override void OnResume()
        {
            base.OnResume();

            ISharedPreferences pref = Application.Context.GetSharedPreferences("UserInfo", FileCreationMode.Private);
            string userEmail = pref.GetString("Email", String.Empty);
            string userPassword = pref.GetString("Password", String.Empty);

            if (userEmail == String.Empty || userPassword == String.Empty)
            {
                //no saved credentials, take user to the loggin screen
                intent = new Intent(this, typeof(MainActivity));
                this.StartActivity(intent);
            }
            else
            {
                //There are saved credentials
                //query the database
                if (userEmail == "anastasia.kvartalna@gmail.com" && userPassword == "220794")
                {
                    //Successful, take the user to application
                    intent = new Intent(this, typeof(OrdersListActivity));
                    this.StartActivity(intent);
                }
                else
                {
                    //Unsuccessful, take user to loggin screen
                    ISharedPreferencesEditor edit = pref.Edit();
                    edit.Clear();
                    edit.Apply();

                    intent = new Intent(this, typeof(MainActivity));
                    this.StartActivity(intent);
                    this.Finish();
                }
            }

            Task startupWork = new Task(() => {
                Log.Debug(TAG, "Performing some startup work that takes a bit of time.");
                Task.Delay(20000);  // Simulate a bit of startup work.
                Log.Debug(TAG, "Working in the background - important stuff.");
            });

            startupWork.ContinueWith(t => {
                Log.Debug(TAG, "Work is finished - start next activity.");
                StartActivity(new Intent(Application.Context, typeof(MainActivity)));
            }, TaskScheduler.FromCurrentSynchronizationContext());

            startupWork.Start();
        }
    }
}