using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lab
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResultDb : ContentPage
    {
        public List<Choose> Results;
        public ResultDb()
        {
            Results = (List<Choose>)App.Database.GetItems();
            if (Results.Count == 0)
            {
                Label Empty = new Label
                {
                    Text = "База даних порожня",
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center
                };
                this.Content = Empty;
            }
            else
            {
                //this.BindingContext = this;

                ListView listView = new ListView
                {
                    HasUnevenRows = true,
                    ItemsSource = Results,

                    ItemTemplate = new DataTemplate(() =>
                    {
                        Label typeProductLabel = new Label { FontSize = 25 };
                        typeProductLabel.SetBinding(Label.TextProperty, "typeProduct");

                        Label vendorLabel = new Label { FontSize = 25 };
                        vendorLabel.SetBinding(Label.TextProperty, "vendor");

                        Label dateLabel = new Label { FontSize = 25 };
                        dateLabel.SetBinding(Label.TextProperty, "dateAdded");

                        return new ViewCell
                        {
                            View = new StackLayout
                            {
                                Padding = new Thickness(5, 5),
                                Orientation = StackOrientation.Vertical,
                                Children = { typeProductLabel, vendorLabel, dateLabel }
                            }
                        };
                    })
                };
                this.Content = new StackLayout { Children = { listView } };

            }
        }

        protected override void OnAppearing()
        {
          // DB db = new DB();
           // chooseList.ItemsSource = db.GetItems();
            base.OnAppearing();
        }
    }
}