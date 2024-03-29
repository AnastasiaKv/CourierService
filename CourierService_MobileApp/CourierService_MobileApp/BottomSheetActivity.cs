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
using Android.Support.Design.Widget;

namespace CourierService_MobileApp
{
    [Activity(Label = "BottomSheetActivity", Theme = "@style/Theme.DesignDemo2")]
    public class BottomSheetActivity : AppCompatActivity
    {
        private TextView mTxtAddress;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Activity_BottomSheet);

            LinearLayout sheet = FindViewById<LinearLayout>(Resource.Id.bottom_sheet);
            BottomSheetBehavior bottomSheetBehavior = BottomSheetBehavior.From(sheet);
            mTxtAddress = FindViewById<TextView>(Resource.Id.txtBottomAddress);
            mTxtAddress.Text = Convert.ToString("From:  6 Latviyska St., Lviv\nTo:    10 Symska St. Lviv");

            bottomSheetBehavior.PeekHeight = 300;
            bottomSheetBehavior.Hideable = true;

            bottomSheetBehavior.SetBottomSheetCallback(new MyBottomSheetCallBack());

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += (o, e) =>
            {
                bottomSheetBehavior.State = BottomSheetBehavior.StateCollapsed;
            };
        }

        public class MyBottomSheetCallBack : BottomSheetBehavior.BottomSheetCallback
        {
            public override void OnSlide(View bottomSheet, float slideOffset)
            {
                //Sliding
            }

            public override void OnStateChanged(View bottomSheet, int newState)
            {
                //State changed
            }
        }
    }
}