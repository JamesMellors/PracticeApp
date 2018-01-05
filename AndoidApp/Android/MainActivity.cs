using Android.App;
using Android.Widget;
using Android.OS;
using System;

namespace Android
{
    [Activity(Label = "Android", MainLauncher = true)]
    public class MainActivity : Activity
    {
        Button buttonNext;
        Button buttonPrev;
        TextView textTitle;
        ImageView imageContent;
        TextView textDesc;



        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            buttonNext = FindViewById<Button>(Resource.Id.buttonNext);
            buttonPrev = FindViewById<Button>(Resource.Id.buttonPrev);
            textTitle = FindViewById<TextView>(Resource.Id.textTitle);
            imageContent = FindViewById<ImageView>(Resource.Id.imageContent);
            textDesc = FindViewById<TextView>(Resource.Id.textDesc);

            buttonNext.Click += buttonNext_Click;
            buttonPrev.Click += buttonPrev_Click;

        }

        private void buttonPrev_Click(object sender, EventArgs e)
        {
            textTitle.Text = "Prev Button";
            textDesc.Text = "This is a test ------------test---------test-------test";
            imageContent.SetImageResource(Resource.Drawable.ps_top_card_02);
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            textTitle.Text = "Next Button";
            textDesc.Text = "This is a test ------------test---------test-------test22222";
            imageContent.SetImageResource(Resource.Drawable.ps_top_card_02);
        }
    }
}

