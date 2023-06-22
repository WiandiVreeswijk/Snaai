using Xamarin.Forms;

namespace SnaaiV1
{
	public partial class App : Application //This class has partial as attribute because there is a part of the class that is written in another file.
    {
		public App ()
		{
            //Finds the right XAML, parses it and inflates it to an object tree using Reflection.
            InitializeComponent();
            //Sets the startup page for this app, in this case a NavigationPage that start on the LoginPage.
            //The NavigationPage is a class that alows the app to easely switch between different pages.
            MainPage = new NavigationPage(new LoginPage()); 
        }

		protected override void OnStart ()
		{
			// Handle when your app starts

		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
