using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Realms;
using Xamarin.ORMComparision.Entities.Realm;

namespace Xamarin.ORMComparision.Services
{
    public class RealmService : IORMService
    {
        private readonly Realm _realm;

        public RealmService()
        {
            _realm = Realm.GetInstance();
        }

        public TimeSpan InsertPeople(int numberOfPeople)
        {
            var sw = new Stopwatch();
            sw.Restart();

            _realm.Write(() =>
            {
                for (var index = 0; index < numberOfPeople; index++)
                {
                    var person = new Person
                    {
                        Name = Guid.NewGuid().ToString(),
                        FullName = Guid.NewGuid().ToString()
                    };
                    person.Addresses.Add(new Address {HomeAddress = "Address " + index + " " + Guid.NewGuid()});
                    person.Addresses.Add(new Address {HomeAddress = "Address " + (index +1) + " " + Guid.NewGuid()});
                    _realm.Add(person);
                }
            });

            return sw.Elapsed;
        }

        public TimeSpan GetPeople()
        {
            var sw = new Stopwatch();
            sw.Restart();
            var people = _realm.All<Person>().ToList();
            return sw.Elapsed;
        }
    }
}