using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SnaaiV1
{
    //With this line of code we can choose wheter to compile teh XAML file in build- or runtime. .Compile = buildtime, .Skip = runtime
    [XamlCompilation(XamlCompilationOptions.Compile)]
    //This class has partial as attribute because there is a part of the class that is written in another file.
    public partial class TutorialPage2 : ContentPage 
    {
		public TutorialPage2 ()
		{
            //Finds the right XAML, parses it and inflates it to an object tree using Reflection.
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            Menuu.ItemTapped += async (sender, e) =>
            {
                var evnt = (SelectedItemChangedEventArgs)e;
                // text is casted to a string
                Notifier.Text = (string)evnt.SelectedItem;
                //This delay causes the Notifier text to remain on the screen for a certain time in mili seconds
                await Task.Delay(3000);
                //makes the string from Notifier empty, so it can be filled with different content
                Notifier.Text = "";

            };
        }

        //EventHandler for the next button so the app can switch between pages.
        //The async and await attributes mean that app will run asynchronous, so it can do multiple tasks at once. This makes the app run smooth.
        /*
        async void NextBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HomePage());
        }

        //EventHandlers for the tutorial buttons so the app can show messeges to the user if the buttons are tapped.
        void TapCheap(object sender, EventArgs args)
        {
            DisplayAlert("Cheap", "Een Cheap like kan gegeven worden als de maaltijd die post is volgens jou goedkoop te maken is!  ", "OK");
        }
        void TapHealthy(object sender, EventArgs args)
        {
            DisplayAlert("Healthy", "Een health like kan worden gegeven bij voedsel wat voor jou in het algemeen gezond is. Hopelijk is dat niet een diepvries pizza...", "OK");
        }
        void TapStrong(object sender, EventArgs args)
        {
            DisplayAlert("Strong", "Een Strong like mag je geven als het eten op de foto volgens jou goed is voor bijvoorbeeld sport, spieropbouw of lijnen.", "OK");
        }
        void TapJunk(object sender, EventArgs args)
        {
            DisplayAlert("Junk", "Zie jij een vette hamburger of een zak patat voorbij komen?? Geef dan een cheat like om aan te geven dat jij het gerecht ongezond vindt!", "OK");
        }
        */
    }
}