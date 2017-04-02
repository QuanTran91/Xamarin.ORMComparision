using Android.App;
using Android.Widget;
using Android.OS;
using Xamarin.ORMComparision.Services;

namespace Xamarin.ORMComparision
{
    [Activity(Label = "Xamarin.ORMComparision", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private int _numberOfPeople = 1000;
        private IORMService _realmService;
        private IORMService _sqliteService;
        private TextView _outPutTextView;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);
            _realmService = new RealmService();
            _sqliteService = new SQLiteNetService();

            var realmInsertButon = FindViewById<Button>(Resource.Id.addPersonRealmBtn);
            realmInsertButon.Click += RealmInsertButon_Click;
            var realmGetButon = FindViewById<Button>(Resource.Id.getPersonRealmBtn);
            realmGetButon.Click += RealmGetButon_Click;
            var sqliteInsertButon = FindViewById<Button>(Resource.Id.addPersonSqliteBtn);
            sqliteInsertButon.Click += SqliteInsertButon_Click;
            var sqliteGetButon = FindViewById<Button>(Resource.Id.getPersonSqliteBtn);
            sqliteGetButon.Click += SqliteGetButon_Click;

            _outPutTextView = FindViewById<TextView>(Resource.Id.outputTextView);
        }

        private void SqliteGetButon_Click(object sender, System.EventArgs e)
        {
            _outPutTextView.Append("Get Sqlite take: " + _sqliteService.GetPeople() + "\n");
        }

        private void SqliteInsertButon_Click(object sender, System.EventArgs e)
        {
            _outPutTextView.Append("Insert Sqlite take: " + _sqliteService.InsertPeople(_numberOfPeople) + "\n");

        }

        private void RealmGetButon_Click(object sender, System.EventArgs e)
        {
            _outPutTextView.Append("Get Realm take: " + _realmService.GetPeople() + "\n");

        }

        private void RealmInsertButon_Click(object sender, System.EventArgs e)
        {
            _outPutTextView.Append("Insert Realm take: " + _realmService.InsertPeople(_numberOfPeople) + "\n");
        }
    }
}

