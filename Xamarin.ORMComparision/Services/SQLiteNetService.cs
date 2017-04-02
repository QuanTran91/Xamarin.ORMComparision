using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using SQLite.Net;
using SQLite.Net.Platform.XamarinAndroid;
using SQLiteNetExtensions.Extensions;
using Xamarin.ORMComparision.Entities.SQLite;

namespace Xamarin.ORMComparision.Services
{
    public class SQLiteNetService : IORMService
    {
        private readonly string _pathToDatabase;
        public SQLiteNetService()
        {
            var docsFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            _pathToDatabase = System.IO.Path.Combine(docsFolder, "db_adonet.db");
            Connection.CreateTable<Person>();
            Connection.CreateTable<Address>();
        }

        private SQLiteConnection Connection => new SQLiteConnection(new SQLitePlatformAndroid(), _pathToDatabase);

        public TimeSpan InsertPeople(int numberOfPeople)
        {
            var sw = new Stopwatch();
            sw.Restart();

            //#1 : Slow way
            //var people = Enumerable.Range(0, numberOfPeople).Select(t => new Person
            //{
            //    Name = Guid.NewGuid().ToString(),
            //    FullName = Guid.NewGuid().ToString(),
            //    DateOfBirth = DateTimeOffset.Now,
            //    Addresses = new List<Address>
            //            {
            //                new Address {HomeAddress = Guid.NewGuid().ToString()},
            //                new Address {HomeAddress = Guid.NewGuid().ToString()}
            //            }
            //});

            //Connection.InsertAllWithChildren(people.ToList());


            //#2 : Faster way
            var connection = Connection;
            connection.RunInTransaction(() =>
            {
                var people = Enumerable.Range(0, numberOfPeople).Select(t => new Person
                {
                    Name = Guid.NewGuid().ToString(),
                    FullName = Guid.NewGuid().ToString(),
                    DateOfBirth = DateTimeOffset.Now,
                    Addresses = new List<Address>
                        {
                            new Address {HomeAddress = Guid.NewGuid().ToString()},
                            new Address {HomeAddress = Guid.NewGuid().ToString()}
                        }
                }).ToList();
                connection.InsertAll(people);
                var addresses = people.SelectMany(t =>
                {
                    foreach (var address in t.Addresses)
                    {
                        address.PersonId = t.Id;
                        address.Person = t;
                    }
                    return t.Addresses;
                });

                connection.InsertAll(addresses);
            });

            return sw.Elapsed;
        }

        public TimeSpan GetPeople()
        {
            var sw = new Stopwatch();
            sw.Restart();
            var result = Connection.GetAllWithChildren<Person>().ToList();
            return sw.Elapsed;
        }
    }
}