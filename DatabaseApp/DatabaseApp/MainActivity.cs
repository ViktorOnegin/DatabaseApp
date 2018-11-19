using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System.IO;
using SQLite;

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

            string databese = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Narusberg_database.db3");
            var db = new SQLiteConnection(databese);

            db.CreateTable<Stock>();

            if (db.Table<Stock>().Count() == 0)
            {
                var newStock = new Stock();
                newStock.Symbol = "AAPL";
                db.Insert(newStock);
                newStock.Symbol = "LAAP";
                db.Insert(newStock);
                newStock.Symbol = "PAAL";
                db.Insert(newStock);
                newStock.Symbol = "ALPA";
                db.Insert(newStock);
                newStock.Symbol = "PALA";
                db.Insert(newStock);
            }

            var table = db.Table<Stock>();
            foreach (var s in table)
            {
                System.Diagnostics.Debug.WriteLine(s.ID + " " + s.Symbol);
            }
        }
    }

    public class Stock
    {   [PrimaryKey, AutoIncrement, Column("_ID")]
        public int ID { get; set; }
        [MaxLength(8)]
        public string Symbol { get; set; }
    }
}