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
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace Xamarin.ORMComparision.Entities.SQLite
{
    public class Address
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [ForeignKey(typeof(Person))]
        public int PersonId { get; set; }
        public string HomeAddress { get; set; }

        [ManyToOne]
        public Person Person { get; set; }
    }
}