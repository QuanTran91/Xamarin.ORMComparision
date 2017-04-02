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
    public class Person : RealmObject
    {
        public string Name { get; set; }
        public string FullName { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }

        public IList<Address> Addresses { get; }
    }
}