using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SnaaiV1
{
	[XamlCompilation(XamlCompilationOptions.Compile)] //With this line of code we can choose wheter to compile teh XAML file in build- or runtime. .Compile = buildtime, .Skip = runtime
    public partial class SearchPage : ContentPage //This class has partial as attribute because there is a part of the class that is written in another file.
    {
		public SearchPage ()
		{
            InitializeComponent(); //Finds the right XAML, parses it and inflates it to an object tree using Reflection.
            NavigationPage.SetHasNavigationBar(this, false);
        }

        //EventHandlers for all the buttons so the app can switch between pages.
        //The async and await attributes mean that app will run asynchronous, so it can do multiple tasks at once. This makes the app run smooth.
        async void ProfileBtn_Clicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new ProfilePage());
        }

        async void HomeBtn_Clicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new HomePage());
        }



        //EventHandlers for the 4 types of search criteria buttons that make them a different color when selected.
        /*
        void JunkBtn_Clicked(object sender, EventArgs e)
        {
            Color btnColor = JunkBtn.BackgroundColor;
            if (btnColor != (Color) Application.Current.Resources["greenColor"]) {
                JunkBtn.BackgroundColor = (Color)Application.Current.Resources["greenColor"];
            }
            else { JunkBtn.BackgroundColor = HomeBtn.BackgroundColor; }
        }

        void CheapBtn_Clicked(object sender, EventArgs e)
        {
            Color btnColor = CheapBtn.BackgroundColor;
            if (btnColor != (Color)Application.Current.Resources["greenColor"])
            {
                CheapBtn.BackgroundColor = (Color)Application.Current.Resources["greenColor"];
            }
            else { CheapBtn.BackgroundColor = HomeBtn.BackgroundColor; }
        }

        void StrongBtn_Clicked(object sender, EventArgs e)
        {
            Color btnColor = StrongBtn.BackgroundColor;
            if (btnColor != (Color)Application.Current.Resources["greenColor"])
            {
                StrongBtn.BackgroundColor = (Color)Application.Current.Resources["greenColor"];
            }
            else { StrongBtn.BackgroundColor = HomeBtn.BackgroundColor; }
        }

        void HealthyBtn_Clicked(object sender, EventArgs e)
        {
            Color btnColor = HealthyBtn.BackgroundColor;
            if (btnColor != (Color)Application.Current.Resources["greenColor"])
            {
                HealthyBtn.BackgroundColor = (Color)Application.Current.Resources["greenColor"];
            }
            else { HealthyBtn.BackgroundColor = HomeBtn.BackgroundColor; }
        }
        */
        // This code does not function properly, this picture won't become visible after being tapped.
        void TapCheap(object sender, EventArgs args)
        {
            if (cheap.IsVisible)
            {
                cheap.IsVisible = false;
            }
            else if (!cheap.IsVisible)
            {
                cheap.IsVisible = true;
            }
        }
        void TapHealthy(object sender, EventArgs args)
        {

        }
        void TapStrong(object sender, EventArgs args)
        {

        }
        void TapJunk(object sender, EventArgs args)
        {
        }


    }
}