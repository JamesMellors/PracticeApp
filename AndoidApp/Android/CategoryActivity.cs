using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CoursesLibrary;

namespace AndroidApp
{
    [Activity(Label = "Courses", MainLauncher = true)]
   
    public class CategoryActivity : ListActivity
    {
        
        CourseCategoryManager courseCategoryManager;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            //String[] catagoryTitles = { "C1", "C2", "C3" };
            //ListAdapter =
            //    new ArrayAdapter<String>(this, global::Android.Resource.Layout.SimpleListItem1, catagoryTitles);
            courseCategoryManager = new CourseCategoryManager();
            ListAdapter =
                new CourseCatagoryManagerAdapter(this, Android.Resource.Layout.SimpleListItem1, courseCategoryManager);
        }

        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {
            Intent intent = new Intent(this, typeof(CourseActivity));

            courseCategoryManager.MoveTo(position);
            string categoryTitle = courseCategoryManager.Current.Title;

            intent.PutExtra(CourseActivity.DEFAULT_CATEGORY_TITLE_EXTRA, categoryTitle);

            StartActivity(intent);
        }
    }
}