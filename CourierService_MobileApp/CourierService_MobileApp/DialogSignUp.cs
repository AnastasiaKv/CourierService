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
    public class OnSignUpEventArgs : EventArgs
    {
        private string mFirstName;
        private string mLastName;
        private string mEmail;
        private string mPassword;

        public string FirstName
        {
            get { return mFirstName; }
            set { mFirstName = value; }
        }

        public string LastName
        {
            get { return mLastName; }
            set { mLastName = value; }
        }

        public string Email
        {
            get { return mEmail; }
            set { mEmail = value; }
        }

        public string Password
        {
            get { return mPassword; }
            set { mPassword = value; }
        }

        public OnSignUpEventArgs(string firstName, string lastName, string email, string password) : base()
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
        }

    }
    class DialogSignUp : DialogFragment
    {
        private EditText mTxtFirstName;
        private EditText mTxtLastName;
        private EditText mTxtEmail;
        private EditText mTxtPassword;
        private Button mBtnRegister;

        public event EventHandler<OnSignUpEventArgs> mOnSignUpComplete;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.DialogSignUp, container, false);

            mTxtLastName = view.FindViewById<EditText>(Resource.Id.txtRLastName);
            mTxtFirstName = view.FindViewById<EditText>(Resource.Id.txtRFirstName);
            mTxtEmail = view.FindViewById<EditText>(Resource.Id.txtREmail);
            mTxtPassword = view.FindViewById<EditText>(Resource.Id.txtRPassword);

            mBtnRegister = view.FindViewById<Button>(Resource.Id.btnDialogRegister);

            mBtnRegister.Click += (object sender, EventArgs args) =>
            {
                //User has clicked the sign up button
                mOnSignUpComplete.Invoke(this, new OnSignUpEventArgs(mTxtFirstName.Text, mTxtLastName.Text, mTxtEmail.Text, mTxtPassword.Text));
                this.Dismiss();
            };

            return view;
        }


        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle);//set the title bar to invisible

            base.OnActivityCreated(savedInstanceState);

            Dialog.Window.Attributes.WindowAnimations = Resource.Style.dialog_animation; //set the animation
        }
    }
}