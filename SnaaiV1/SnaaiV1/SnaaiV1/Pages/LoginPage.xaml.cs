using System;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;

namespace SnaaiV1
{
    [XamlCompilation(XamlCompilationOptions.Compile)] //With this line of code we can choose wheter to compile teh XAML file in build- or runtime. .Compile = buildtime, .Skip = runtime
    public partial class LoginPage : ContentPage //This class has partial as attribute because there is a part of the class that is written in another file.
    {
        public LoginPage()
		{
			InitializeComponent(); //Finds the right XAML, parses it and inflates it to an object tree using Reflection.
            NavigationPage.SetHasNavigationBar(this, false); //Disables the NavBar for this page.
        }


        //EventHandler for the login button so the app can switch between pages.
        //The async and await attributes mean that app will run asynchronous, so it can do multiple tasks at once. This makes the app run smooth.
        async void LoginBtn_Clicked(object sender, EventArgs e)
        {

            await Navigation.PopAsync();
            await Navigation.PushAsync(new TutorialPage2());

            await Navigation.PushAsync(new HomePage());

        }
    }
}
