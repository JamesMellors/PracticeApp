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

namespace Android
{
    [Activity(Label = "Courses", MainLauncher = true)]
   
    public class CategoryActivity : ListActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            String[] catagoryTitles = { "C1", "C2", "C3" };
            //ListAdapter =
            //    new ArrayAdapter<String>(this, global::Android.Resource.Layout.sim, catagoryTitles;
        }
    }
}