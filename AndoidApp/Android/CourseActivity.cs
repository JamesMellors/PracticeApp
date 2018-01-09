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
using Android.Support.V4.App;
using CoursesLibrary;
using Android.Support.V4.View;
using Android;

namespace AndroidApp
{
    
   [Activity(Label = "Course Activity")]
    public class CourseActivity : FragmentActivity
    {
        public const String DEFAULT_CATEGORY_TITLE_EXTRA = "DisplayCategoryTitleExtra";
        private const String DEFAULT_CATEGORY_TITLE = "Android";
        CourseManager courseManager;
        CoursePagerAdapter coursePagerAdapter;
        ViewPager viewPager;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.CourseActivity);
            string displayCategoryTitle = DEFAULT_CATEGORY_TITLE;
            Intent startUpIntent = this.Intent;
            if (startUpIntent != null)
            {
                String displayCategoryTitleExtra = startUpIntent.GetStringExtra(DEFAULT_CATEGORY_TITLE_EXTRA);
                if (displayCategoryTitleExtra != null)
                    displayCategoryTitle = displayCategoryTitleExtra;
            }
            courseManager = new CourseManager(displayCategoryTitle);
            courseManager.MoveFirst();

            coursePagerAdapter = new CoursePagerAdapter(SupportFragmentManager, courseManager);

            viewPager = FindViewById<ViewPager>(Resource.Id.coursePager);
            viewPager.Adapter = coursePagerAdapter;
        }
    }
}