using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System.IO;

namespace DatabaseApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            // xd Aleksei Narusberg
            SetContentView(Resource.Layout.activity_main);

            var databaseSevrice = new DatabaseService();
            databaseSevrice.CreateDatabase();
            databaseSevrice.CreateTable();
            var table = databaseSevrice.GetAllStocks();
            var listView = FindViewById<ListView>(Resource.Id.listView1);
            var button1 = FindViewById<Button>(Resource.Id.button1);
            var editText = FindViewById<EditText>(Resource.Id.)

            listView.Adapter = new CustomAdapter(this, table.ToList());

            
        }
    }

    
}