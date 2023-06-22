using FFImageLoading.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SnaaiV1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class post : ContentView
	{
		public post ()
		{
			InitializeComponent ();
		}

        public void Like_Clicked(CachedImage notSelectedLikeButton, CachedImage likeButton, Label likesLabel)
        {
            // if the like button is not selected(grey) execute the following code
            if (notSelectedLikeButton.Opacity == 1)
            {
                // hide the grey button by setting the opacity to 0 and show the green button by setting the opacity to 1
                likeButton.Opacity = 1;
                notSelectedLikeButton.Opacity = 0;
                // integer which stores the number of likes
                int numberOfLikes = 0;
                // get the number of the likesLabel and parse it to an integer
                if (Int32.TryParse(likesLabel.Text, out numberOfLikes))
                {
                    // increase the number of like by 1
                    numberOfLikes++;
                    // set the likesLabel to the number of likes
                    likesLabel.Text = numberOfLikes.ToString();
                }

            }
            // if the like button is selected(green) execute the following code 
            else
            {
                // hide the green button by setting the opacity to 0 and show the grey button by setting the opacity to 1
                likeButton.Opacity = 0;
                notSelectedLikeButton.Opacity = 1;
                likesLabel.TextColor = (Color)Application.Current.Resources["greenColor"];

                int numberOfLikes = 0;
                // get the number of the likesLabel and parse it to an integer
                if (Int32.TryParse(likesLabel.Text, out numberOfLikes))
                {
                    // decrease the number of like by 1
                    numberOfLikes--;
                    // set the likesLabel to the number of likes
                    likesLabel.Text = numberOfLikes.ToString();
                }
            }
        }

        // set the image source with bytes (images taken with the camera)
        public void SetImageSource(byte[] imageBytes) {
            image.Source = ImageSource.FromStream(() => new MemoryStream(imageBytes));
        }
        // set the image source (images in the application resources)
        public void SetImage(ImageSource source) {
            image.Source = source;
        }

        void Healthy_Clicked(object sender, EventArgs e)
        {
            Like_Clicked(healthyNotSelectedBtn, healthyBtn, healthyNumberOfLikes);
        }
        void Strong_Clicked(object sender, EventArgs e)
        {
            Like_Clicked(strongNotSelectedBtn, strongBtn, strongNumberOfLikes);
        }

        void Cheap_Clicked(object sender, EventArgs e)
        {
            Like_Clicked(cheapNotSelectedBtn, cheapBtn, cheapNumberOfLikes);
        }
       async void Message_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ReactiePage());
        }
    }
}