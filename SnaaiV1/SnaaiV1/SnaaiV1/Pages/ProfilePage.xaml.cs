using FFImageLoading.Forms;
using SnaaiV1.Pages;
using System;
using System.IO;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SnaaiV1
{
    [XamlCompilation(XamlCompilationOptions.Compile)] //With this line of code we can choose wheter to compile teh XAML file in build- or runtime. .Compile = buildtime, .Skip = runtime
    public partial class ProfilePage : ContentPage //This class has partial as attribute because there is a part of the class that is written in another file.
    {
        public double currentProgress;
        private static float progress;
		public ProfilePage ()
		{
            InitializeComponent(); //Finds the right XAML, parses it and inflates it to an object tree using Reflection.
            NavigationPage.SetHasNavigationBar(this, false);
            progressBar1 = this.FindByName<ProgressBar>("progressBar1");
            progressBar1.Progress = progress;
            AddPicture();
            
            /*var files = System.IO.Directory.GetFiles("Pictures");
            if (!files.Any())
                return;

            foreach (var file in files)
            {
                DisplayAlert("Permissions Denied", file, "OK");
                // ProfileImages.Children.Add(file);
            }*/
        }
       

        public void AddPicture() {
            // if arraylist is empty, return
            if (ImageList.images.Count <= 0)
            {
                return;
            }
            // for each string in imagelist, execute the following code
            foreach (String image64 in ImageList.images)
            {
                // convert string to byte
                byte[] imageBytes = Convert.FromBase64String(image64);
                // create post
                var postt = new post { };
                // set image source of the post
                postt.SetImageSource(imageBytes);
                // add post to the profile page
                ProfileImages.Children.Add(postt);

            }
        }

        

        


        //EventHandlers for all the buttons so the app can switch between pages.
        //The async and await attributes mean that app will run asynchronous, so it can do multiple tasks at once. This makes the app run smooth.
        async void HomeBtn_Clicked(object sender, EventArgs e)
        {
            progress += 0.1f;
            progressBar1.Progress += progress;

            await Navigation.PushAsync(new HomePage());
        }

        async void AddBtn_Clicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new AddPage());
        }

        async void SearchBtn_Clicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new SearchPage());
        }






        async void Message_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ReactiePage());
        }
    }
}