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
using Android.Graphics;

namespace CourierService_MobileApp.Resources.Helpers
{
    public static class Orders
    {
        private static Random RANDOM = new Random();

        public static int RandomOrdersDrawable
        {
            get
            {
                switch (RANDOM.Next(4))
                {
                    default:
                    case 0:
                        return Resource.Drawable.ico13;
                    case 1:
                        return Resource.Drawable.ico14;
                    case 2:
                        return Resource.Drawable.ico17;
                    case 3:
                        return Resource.Drawable.ico30;
                }
            }
        }
        public static List<string> OrdersStrings
        {
            get
            {
                return new List<string>()
                {
                    "Express delivery of documents",
                    "Festive flower delivery",
                    "Delivery of office equipment",
                    "Furniture transportation",
                    "Delivery of of airline tickets",
                    "Transporting fragile items"
                };
            }
        }

        public static int CalculateInSampleSize(BitmapFactory.Options options, int reqWidth, int reqHeight)
        {
            // Raw height and width of image
            int height = options.OutHeight;
            int width = options.OutWidth;
            int inSampleSize = 1;

            if (height > reqHeight || width > reqWidth)
            {

                // Calculate ratios of height and width to requested height and
                // width
                int heightRatio = height / reqHeight;
                int widthRatio = width / reqWidth;

                // Choose the smallest ratio as inSampleSize value, this will
                // guarantee
                // a final image with both dimensions larger than or equal to the
                // requested height and width.
                inSampleSize = heightRatio < widthRatio ? heightRatio : widthRatio;
            }

            return inSampleSize;
        }
    }
}