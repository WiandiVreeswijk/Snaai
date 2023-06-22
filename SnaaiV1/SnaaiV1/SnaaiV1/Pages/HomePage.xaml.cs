using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FFImageLoading.Forms;
using SnaaiV1.Pages;
using System.IO;

namespace SnaaiV1
{
    //With this line of code we can choose wheter to compile teh XAML file in build- or runtime. .Compile = buildtime, .Skip = runtime
    [XamlCompilation(XamlCompilationOptions.Compile)]
    //This class has partial as attribute because there is a part of the class that is written in another file.
    public partial class HomePage : ContentPage 
    {
		public HomePage ()
		{
            //Finds the right XAML, parses it and inflates it to an object tree using Reflection.
            InitializeComponent();
            //Disables the NavBar for this page.
            NavigationPage.SetHasNavigationBar(this, false); 
            AddPicture();
            var post = new post { };
            post.SetImage("hamburger.jpg");
            homeImages.Children.Add(post);
            var post2 = new post { };
            post2.SetImage("healthymeal.png");
            homeImages.Children.Add(post2);
        }

        //EventHandlers for all the buttons so the app can switch between pages.
        //The async and await attributes mean that app will run asynchronous, so it can do multiple tasks at once. This makes the app run smooth.
        async void ProfileBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProfilePage());
            
        }

        async void SearchBtn_Clicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new SearchPage());
        }

        async void AddBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddPage());
        }

        async void Info_Clicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new TutorialPage2());
        }

        async void MessageBtn_Clicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new ReactiePage());

        }

        public void AddPicture()
        {
            // if arraylist is empty, return
            if (ImageList.images.Count <= 0) {
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
                // add post to the home page
                homeImages.Children.Add(postt);

            }
        }


        /*   public void Like_Clicked(CachedImage notSelectedLikeButton, CachedImage likeButton, Label likesLabel)
            {
                if (notSelectedLikeButton.Opacity == 1)
                {
                    likeButton.Opacity = 1;
                    notSelectedLikeButton.Opacity = 0;
                    int numberOfLikes = 0;

                    if (Int32.TryParse(likesLabel.Text, out numberOfLikes))
                    {
                        numberOfLikes++;
                        likesLabel.Text = numberOfLikes.ToString();
                    }

                }
                else
                {
                    likeButton.Opacity = 0;
                    notSelectedLikeButton.Opacity = 1;
                    healthyNumberOfLikes1.TextColor = (Color)Application.Current.Resources["greenColor"];

                    int numberOfLikes = 0;

                    if (Int32.TryParse(likesLabel.Text, out numberOfLikes))
                    {
                        numberOfLikes--;
                        likesLabel.Text = numberOfLikes.ToString();
                    }
                }
            }

            void Healthy_Clicked_1(object sender, EventArgs e)
            {
                Like_Clicked(healthyNotSelectedBtn1, healthyBtn1, healthyNumberOfLikes1);
            }
            void Strong_Clicked_1(object sender, EventArgs e)
            {
                Like_Clicked(strongNotSelectedBtn1, strongBtn1, strongNumberOfLikes1);
            }

            void Cheap_Clicked_1(object sender, EventArgs e)
            {
                Like_Clicked(cheapNotSelectedBtn1, cheapBtn1, cheapNumberOfLikes1);
            }

            void Junk_Clicked_1(object sender, EventArgs e)
            {
                Like_Clicked(junkNotSelectedBtn1, junkBtn1, junkNumberOfLikes1);
            }


            void Healthy_Clicked_2(object sender, EventArgs e)
            {
                Like_Clicked(healthyNotSelectedBtn2, healthyBtn2, healthyNumberOfLikes2);
            }
            void Strong_Clicked_2(object sender, EventArgs e)
            {
                Like_Clicked(strongNotSelectedBtn2, strongBtn2, strongNumberOfLikes2);
            }

            void Cheap_Clicked_2(object sender, EventArgs e)
            {
                Like_Clicked(cheapNotSelectedBtn2, cheapBtn2, cheapNumberOfLikes2);
            }

            void Junk_Clicked_2(object sender, EventArgs e)
            {
                Like_Clicked(junkNotSelectedBtn2, junkBtn2, junkNumberOfLikes2);
            }


            void Healthy_Clicked_3(object sender, EventArgs e)
            {
                Like_Clicked(healthyNotSelectedBtn3, healthyBtn3, healthyNumberOfLikes3);
            }
            void Strong_Clicked_3(object sender, EventArgs e)
            {
                Like_Clicked(strongNotSelectedBtn3, strongBtn3, strongNumberOfLikes3);
            }

            void Cheap_Clicked_3(object sender, EventArgs e)
            {
                Like_Clicked(cheapNotSelectedBtn3, cheapBtn3, cheapNumberOfLikes3);
            }

            void Junk_Clicked_3(object sender, EventArgs e)
            {
                Like_Clicked(junkNotSelectedBtn3, junkBtn3, junkNumberOfLikes3);
            }*/
    }
}