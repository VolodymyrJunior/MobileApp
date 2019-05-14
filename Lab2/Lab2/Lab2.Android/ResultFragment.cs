using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace Lab2.Droid
{
    public class ResultFragment : Fragment
    {
       

        //IOnFragmentInteractionListener onFragmentInteractionListener;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            View view = inflater.Inflate(Resource.Layout.ResultFragment, container, false);
            return view;
        }

        public void SetTypeProduct(string typeProduct)
        {
            TextView resultTypeProduct = View.FindViewById(Resource.Id.typeProduct) as TextView;
            if (resultTypeProduct != null)
            {
                resultTypeProduct.Text = typeProduct;
            }
        }

        public void SetVendor(string vendor)
        {
            TextView resultVendor = View.FindViewById(Resource.Id.vendor) as TextView;
            if (resultVendor != null)
            {
                resultVendor.Text = vendor;
            }
        }
    }
}