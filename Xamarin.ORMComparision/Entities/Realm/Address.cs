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
using Realms;

namespace Xamarin.ORMComparision.Entities.Realm
{
    public class Address:RealmObject
    {
        public string HomeAddress { get; set; }
    }
}