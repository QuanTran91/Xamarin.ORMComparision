using System;
using System.Collections.Generic;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace Xamarin.ORMComparision.Entities.SQLite
{
    public class Person
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.CascadeRead | CascadeOperation.CascadeInsert)]
        public List<Address> Addresses { get; set; }
    }
}