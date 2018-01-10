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
using Android.Support.V4.Widget;

namespace AndroidApp
{
    
   [Activity(Label = "Course Activity", MainLauncher = true)]
    public class CourseActivity : FragmentActivity
    {
        public const String DEFAULT_CATEGORY_TITLE_EXTRA = "DisplayCategoryTitleExtra";
        private const String DEFAULT_CATEGORY_TITLE = "Android";
        CourseManager courseManager;
        CoursePagerAdapter coursePagerAdapter;
        ViewPager viewPager;
        CourseCategoryManager courseCategoryManager;
        DrawerLayout drawerLayout;
        ListView drawerListView;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            courseCategoryManager = new CourseCategoryManager();
            courseCategoryManager.MoveFirst();
            // Create your application here
            SetContentView(Resource.Layout.CourseActivity);
            string displayCategoryTitle = courseCategoryManager.Current.Title;
            //string displayCategoryTitle = DEFAULT_CATEGORY_TITLE;
            //Intent startUpIntent = this.Intent;
            //if (startUpIntent != null)
            //{
            //    String displayCategoryTitleExtra = startUpIntent.GetStringExtra(DEFAULT_CATEGORY_TITLE_EXTRA);
            //    if (displayCategoryTitleExtra != null)
            //        displayCategoryTitle = displayCategoryTitleExtra;
            //}


            courseManager = new CourseManager(displayCategoryTitle);
            courseManager.MoveFirst();

            coursePagerAdapter = new CoursePagerAdapter(SupportFragmentManager, courseManager);

            viewPager = FindViewById<ViewPager>(Resource.Id.coursePager);
            viewPager.Adapter = coursePagerAdapter;

            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawerLayout);
            drawerListView = FindViewById<ListView>(Resource.Id.categoryDrawerListView);

            drawerListView.Adapter =
                new CourseCatagoryManagerAdapter(this, Resource.Layout.SideNavigation, courseCategoryManager);

            drawerListView.SetItemChecked(0, true);
            drawerListView.ItemClick += DrawerListView_ItemClick;
        }

        private void DrawerListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            drawerLayout.CloseDrawer(drawerListView);
            courseCategoryManager.MoveTo(e.Position);
            courseManager = new CourseManager(courseCategoryManager.Current.Title);
            coursePagerAdapter.CourseManager = courseManager;

            viewPager.CurrentItem = 0;
        }
    }
}