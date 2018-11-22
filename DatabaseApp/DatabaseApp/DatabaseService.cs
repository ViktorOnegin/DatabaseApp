using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;

namespace DatabaseApp
{
    public class DatabaseService
    {
        SQLiteConnection db;

        public void CreateDatabase()
        {
            string databese = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Narusberg_database.db3");
            db = new SQLiteConnection(databese);
            db.CreateTable<Stock>();
        }

        public void CreateTable()
        {
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
        }

        public TableQuery <Stock> GetAllStocks()
        {
            var table = db.Table<Stock>();
            return table;
        }
    }
}