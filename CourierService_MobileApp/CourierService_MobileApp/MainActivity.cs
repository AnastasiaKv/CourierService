using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Threading;
using Android.Views.InputMethods;

namespace CourierService_MobileApp
{
    [Activity(Label = "Account")]
    public class MainActivity : Activity
    {
        private TextView mTxtEmail;
        private TextView mTxtPassword;

        private Button mBtnLogin;
        private TextView mTxtRegister;
        private ProgressBar mProgressBar;
        private RelativeLayout mRelativeLayout;

        private User mUser;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            this.Window.RequestFeature(WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);

            mTxtEmail = FindViewById<TextView>(Resource.Id.txtEmail);
            mTxtPassword = FindViewById<TextView>(Resource.Id.txtPassword);
            mBtnLogin = FindViewById<Button>(Resource.Id.btnLogin);
            mProgressBar = FindViewById<ProgressBar>(Resource.Id.accountProgressBar);
            mTxtRegister = FindViewById<TextView>(Resource.Id.txtSignUp);
            mRelativeLayout = FindViewById<RelativeLayout>(Resource.Id.mainView);

            mBtnLogin.Click += mBtnLogin_Click;
            mTxtRegister.Click += mTxtRegister_Click;
            mRelativeLayout.Click += mRelativeLayout_Click;

        }

        void mRelativeLayout_Click(object sender, EventArgs e)
        {
            InputMethodManager inputManager = (InputMethodManager)this.GetSystemService(Activity.InputMethodService);
            inputManager.HideSoftInputFromWindow(this.CurrentFocus.WindowToken, HideSoftInputFlags.None);
        }

        private void mTxtRegister_Click(object sender, EventArgs e)
        {
            //pull up dialog
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            DialogSignUp signUpDialog = new DialogSignUp();
            signUpDialog.Show(transaction, "dialog fragment");

            signUpDialog.mOnSignUpComplete += signUpDialog_mOnSignUpComplete;
        }

        private void mBtnLogin_Click(object sender, EventArgs e)
        {
            mProgressBar.Visibility = ViewStates.Visible;
            Thread thread = new Thread(ActLikeARequest);
            thread.Start();

            mUser = new User(1, "Anastasia", "Kvartalna", mTxtEmail.Text, mTxtPassword.Text);
            //intent.PutExtra("User", JsonConvert.SerializeObject(mUser));

            ISharedPreferences pref = Application.Context.GetSharedPreferences("UserInfo", FileCreationMode.Private);
            ISharedPreferencesEditor edit = pref.Edit();

            edit.PutString("Email", mUser.Email.Trim());
            edit.PutString("Password", mUser.Password.Trim());
            edit.PutString("FirstName", mUser.FirstName.Trim());
            edit.PutString("LastName", mUser.LastName.Trim());
            edit.Apply();

            Intent intent = new Intent(this, typeof(OrdersListActivity));
            this.StartActivity(intent);

            this.OverridePendingTransition(Android.Resource.Animation.SlideInLeft, Android.Resource.Animation.SlideOutRight);
        }

        private void signUpDialog_mOnSignUpComplete(object sender, OnSignUpEventArgs e)
        {
            //simulation of server request
            mProgressBar.Visibility = ViewStates.Visible;
            Thread thread = new Thread(ActLikeARequest);
            thread.Start();
            mUser = new User(1, e.FirstName, e.LastName, e.Email, e.Password);
            //intent.PutExtra("User", JsonConvert.SerializeObject(mUser));

            ISharedPreferences pref = Application.Context.GetSharedPreferences("UserInfo", FileCreationMode.Private);
            ISharedPreferencesEditor edit = pref.Edit();

            edit.PutString("Email", mUser.Email.Trim());
            edit.PutString("Password", mUser.Password.Trim());
            edit.PutString("FirstName", mUser.FirstName.Trim());
            edit.PutString("LastName", mUser.LastName.Trim());
            edit.Apply();

            Intent intent = new Intent(this, typeof(OrdersListActivity));
            this.StartActivity(intent);
            this.OverridePendingTransition(Android.Resource.Animation.SlideInLeft, Android.Resource.Animation.SlideOutRight);
        }

        private void ActLikeARequest()
        {
            Thread.Sleep(3000);
            RunOnUiThread(() => { mProgressBar.Visibility = ViewStates.Invisible; });
        }

    }
}

