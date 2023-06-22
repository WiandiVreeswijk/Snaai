using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SnaaiV1.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Reactielijst : ContentPage
    {
        public ObservableCollection<string> Items { get; set; }
     
        String persoon1 = "Tyrone";
        String persoon2 = "healthy";
        String persoon3 = "this";
        String persoon4 = "gezonde";
        String persoon5 = "healthyboy442";


        public Reactielijst()
        {
            InitializeComponent();

            Items = new ObservableCollection<string>
            {
                persoon1,
                persoon2,
                persoon3,
                persoon4,
                persoon5

            };
			
			MyListView.ItemsSource = Items;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            if (e.Item.ToString() == persoon1) { await DisplayAlert(persoon1, "An item was tapped.", "OK"); }
            if (e.Item.ToString() == persoon2)
            {
                await DisplayAlert(persoon2, "3robi pauw", "OK");
            }

            if (e.Item.ToString() == persoon3) { await DisplayAlert(persoon3, "beeeeing.", "OK"); }
            if (e.Item.ToString() == persoon4)
            { await DisplayAlert(persoon4, "lekker bezig", "OK"); }

            if (e.Item.ToString() == persoon5) { await DisplayAlert(persoon1, "ziet er goed uit.", "OK"); }


            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
        async void LoginBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HomePage());
        }
    }
}
