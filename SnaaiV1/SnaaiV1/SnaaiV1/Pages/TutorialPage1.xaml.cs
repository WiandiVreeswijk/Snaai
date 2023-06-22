using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SnaaiV1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TutorialPage1 : ContentPage
    {
        public TutorialPage1()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
        async void NextBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TutorialPage2());
        }
        async void HomeButton_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Home", "Op de homepagina staan alle foto's van de personen die jij volgt", "ok");
        }
    }
} 