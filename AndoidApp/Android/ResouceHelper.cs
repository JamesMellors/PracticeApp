using Android;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace AndroidApp
{
    public static class ResouceHelper
    {
        static Dictionary<string, int> resourceDictionary = new Dictionary<string, int>();
        public static int TranslateDrawable(String drawableName)
        {
            int resourceValue = -1;

            switch (drawableName)
            {
                case "ps_top_card_01" :
                    resourceValue = Resource.Drawable.ps_top_card_01;
                    break;
                case "ps_top_card_02":
                    resourceValue = Resource.Drawable.ps_top_card_02;
                    break;
                case "ps_top_card_03":
                    resourceValue = Resource.Drawable.ps_top_card_03;
                    break;
                case "ps_top_card_04":
                    resourceValue = Resource.Drawable.ps_top_card_04;
                    break;
            }

            return resourceValue;
        }

        public static int TranslateDrawableWithReflection(String drawableName)
        {
            int resourseValue = -1;
            if (resourceDictionary.ContainsKey(drawableName))
            {
                resourseValue = resourceDictionary[drawableName];
            }
            else
            {
                Type drawableType = typeof(Resource.Drawable);
                FieldInfo resourceFieldInfo = drawableType.GetField(drawableName);
                resourseValue = (int)resourceFieldInfo.GetValue(null);
                resourceDictionary.Add(drawableName, resourseValue);
            }
            

                return resourseValue;
        }
    }

   
}