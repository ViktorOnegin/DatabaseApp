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

namespace DatabaseApp
{
    class CustomAdapter : BaseAdapter<Stock>
    {
        List<Stock> items;
        Activity context;

        public CustomAdapter(Activity context, List<Stock> items) : base()
        {
            this.context = context;
            this.items = items;
        }

        public override Stock this[int position]
        {
            get { return items[position]; }
        }

        public override int Count { get { return items.Count; } }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;
            if (view == null)
                view = context.LayoutInflater.Inflate(Resource.Layout.layout1, null);
            view.FindViewById<TextView>(Resource.Id.text1).Text = items[position].Symbol;


            return view;
        }

        
    }
}