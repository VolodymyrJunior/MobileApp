using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Lab2
{
    public partial class MainPage : ContentPage
    {

        private string typeProduct = "";
        private string vendor = "";
        public MainPage()
        {
            InitializeComponent();
        }

        private void Types_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.typeProduct = Types.SelectedItem.ToString();
        }

        private void Vendors_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.vendor = Vendors.SelectedItem.ToString();
        }

        private void Cancel_Clicked(object sender, EventArgs e)
        {
            Vendors.SelectedIndexChanged -= Vendors_SelectedIndexChanged;
            Types.SelectedIndexChanged -= Types_SelectedIndexChanged;

            Vendors.SelectedItem = null;
            Types.SelectedItem = null;

            Vendors.SelectedIndexChanged += Vendors_SelectedIndexChanged;
            Types.SelectedIndexChanged += Types_SelectedIndexChanged;

            this.typeProduct = "";
            this.vendor = "";
        }

        private void Send_Clicked(object sender, EventArgs e)
        {
            string result;

            if (this.typeProduct.Length != 0 && this.vendor.Length != 0)
            {
                result = "Тип товару: " + this.typeProduct + "\nФірма: " + this.vendor;
            }
            else
            {
                result = "Виберіть опції";
            }


            DisplayAlert("Ви вибрали", result, "Закрити");
        }

    }
}
