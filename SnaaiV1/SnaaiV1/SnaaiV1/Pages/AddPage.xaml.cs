using Plugin.Media;
using Plugin.Media.Abstractions;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnaaiV1.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SnaaiV1.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddPage : ContentPage
	{
		public AddPage ()
		{
            //Finds the right XAML, parses it and inflates it to an object tree using Reflection.
            InitializeComponent();
            //Clicked calls an eventhandler
            CameraButton.Clicked += CameraButton_Clicked;
            AskPermission();
            //Disables the NavBar for this page.
            NavigationPage.SetHasNavigationBar(this, false);
            PostImage.IsVisible = false;

        }
        async void HomeBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HomePage());
        }

        async void ProfileBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProfilePage());
        }

        async void SearchBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SearchPage());
        }

        // asks the user permission to access the camera and storage
        private async void AskPermission() { 
            // creates variable with the current status of the camera/storage permission
            var cameraStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Camera);
            var storageStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage);
            // if camera/storage permission is not granted execute the code within the if statement
            if (cameraStatus != PermissionStatus.Granted || storageStatus != PermissionStatus.Granted)
            {
                // call permission request and give back results
                var results = await CrossPermissions.Current.RequestPermissionsAsync(new[] { Permission.Camera, Permission.Storage });
                cameraStatus = results[Permission.Camera];
                storageStatus = results[Permission.Storage];
            }
        }
        
        async void PostImage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HomePage());
        }
        private async void CameraButton_Clicked(object sender, EventArgs e)
        {
            // checks camera/storage permission status 
            var cameraStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Camera);
            var storageStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage);


            // if camera and storage permission is granted execute the code within the if statement

            if (cameraStatus == PermissionStatus.Granted && storageStatus == PermissionStatus.Granted)
            {
                // creates variable file which can store the image that is being taken
                var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                {
                    // the parametes within these brackets can be found in the StoreCameraMediaOptions
                    // sets image size to small
                    PhotoSize = PhotoSize.Small,
                    // saves image to the gallery
                    SaveToAlbum = true
                });
                // if file does not contain an image do not execute the code after return
                if (file == null)
                    return;
                // creates variable which can store the stream of the image file
                var picStream = file.GetStream();
                // creates variable which can store a byte with the length file stream
                var picBytes = new byte[picStream.Length];
                // 
                await picStream.ReadAsync(picBytes, 0, (int)picStream.Length);
                // converts picBytes to a string
                string base64driverProfile = System.Convert.ToBase64String(picBytes);
                // sets image source
                image.Source = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    file.Dispose();
                    return stream;
                });
                // adds image source to arraylist
                ImageList.images.Add(base64driverProfile);


                // sets postimage button visible so you can post the picture
                PostImage.IsVisible = true;
            }
            else
            {
                // display this alert when permissions are not granted
                await DisplayAlert("Permissions Denied", "Unable to take photos.", "OK");            
            }

            
            
        }

   

    }
}