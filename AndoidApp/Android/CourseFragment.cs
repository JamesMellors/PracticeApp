using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using CoursesLibrary;

namespace Android
{
    public class CourseFragment : Fragment
    {

        TextView textTitle;
        ImageView imageContent;
        TextView textDesc;

        public Course Course { get; set; }
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            View rootView = inflater.Inflate(Resource.Layout.CourseFragment, container, false);

            textTitle = rootView.FindViewById<TextView>(Resource.Id.textTitle);
            imageContent = rootView.FindViewById<ImageView>(Resource.Id.imageContent);
            textDesc = rootView.FindViewById<TextView>(Resource.Id.textDesc);


            textTitle.Text = Course.Title;
            textDesc.Text = Course.Description;

            imageContent.SetImageResource(ResouceHelper.TranslateDrawableWithReflection(Course.Image));

            return rootView;
        }
    }
}