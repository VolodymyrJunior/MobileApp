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
    public class FormFragment : Fragment
    {
        private string typeProductSelected;
        private string vendorSelected;
        public List<string> typeProductList = new List<string>()
        {
            "Виберіть тип продукту",
            "Електричні прилади",
            "Побутова хімія",
            "Продукти харчування",
            "Меблі"
        };

        public List<string> vendorList = new List<string>()
        {
            "Виберіть фірму",
            "Asus",
            "Philips",
            "Samsung",
            "Iceman",
            "BRW",
            "VidiMost"
        };

        IOnFragmentInteractionListener onFragmentInteractionListener;

        public override void OnAttach(Context context)
        {
            base.OnAttach(context);

            var listener = context as IOnFragmentInteractionListener;
            if (listener != null)
            {
                onFragmentInteractionListener = listener;
                onFragmentInteractionListener.noChoosen = this.typeProductList[0];
            }
        }


        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
   
            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            View view = inflater.Inflate(Resource.Layout.FormFragment, container, false);

            Spinner typeProductSpinner = (Spinner)view.FindViewById(Resource.Id.typeProductPicker);

            var typeProductAdapter = new ArrayAdapter(view.Context, Android.Resource.Layout.SimpleSpinnerItem, typeProductList);
            typeProductAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);

            typeProductSpinner.Adapter = typeProductAdapter;
            typeProductSpinner.SetSelection(0);
            typeProductSpinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(typeProduct_ItemSelected);

            TextView typeProductLael = (TextView)view.FindViewById(Resource.Id.typeProductLabel);
            typeProductLael.Text = "Тип продукту:";

            TextView vendorLabel = (TextView)view.FindViewById(Resource.Id.vendorLabel);
            vendorLabel.Text = "Фірма:";

            Spinner vendorSpinner = (Spinner)view.FindViewById(Resource.Id.vendorPicker);

            var vendorAdapter = new ArrayAdapter(view.Context, Android.Resource.Layout.SimpleSpinnerItem, vendorList);
            vendorAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);

            vendorSpinner.Adapter = vendorAdapter;
            vendorSpinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(vendor_ItemSelected);
            vendorSpinner.SetSelection(0);

            Button saveButton = (Button)view.FindViewById(Resource.Id.saveButton);

            saveButton.Click += SaveButton_Click;

            Button cancelButton = (Button)view.FindViewById(Resource.Id.cancelButton);

            cancelButton.Click += CancelButton_Click;



            return view;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.vendorSelected = "";
            this.typeProductSelected = "";
            onFragmentInteractionListener.OnVendorChoosen((string)this.vendorSelected);
            onFragmentInteractionListener.OnTypeProductChoosen((string)this.typeProductSelected);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty((string)this.vendorSelected) &&
                !string.IsNullOrEmpty((string)this.typeProductSelected) &&
                this.vendorSelected != this.vendorList[0] &&
                this.typeProductSelected != this.typeProductList[0])
            {
                // this.vendorSelected = (string)item;
                 onFragmentInteractionListener.OnVendorChoosen((string)this.vendorSelected);
                onFragmentInteractionListener.OnTypeProductChoosen((string)this.typeProductSelected);
            }
            //throw new NotImplementedException();
        }

        private void typeProduct_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = sender as Spinner;
            var item = spinner?.GetItemAtPosition(e.Position);

            if (!string.IsNullOrEmpty((string)item))
            {
                this.typeProductSelected = (string)item;
                //onFragmentInteractionListener.OnTypeProductChoosen((string)item);
            }


        }

        private void vendor_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = sender as Spinner;
            var item = spinner?.GetItemAtPosition(e.Position);

            if (!string.IsNullOrEmpty((string)item))
            {
                this.vendorSelected = (string)item;
               // onFragmentInteractionListener.OnVendorChoosen((string)item);
            }
        }


        public interface IOnFragmentInteractionListener
        {
            string noChoosen { get; set; }

            void OnTypeProductChoosen(string typeProduct);

            void OnVendorChoosen(string vendor);
        }
    }
}