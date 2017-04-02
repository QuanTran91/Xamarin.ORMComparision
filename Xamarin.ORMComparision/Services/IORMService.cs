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

namespace Xamarin.ORMComparision.Services
{
    public interface IORMService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfPeople"></param>
        /// <returns>Time to execute the operation</returns>
        TimeSpan InsertPeople(int numberOfPeople);

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Time to execute the operation</returns>
        TimeSpan GetPeople();
    }
}