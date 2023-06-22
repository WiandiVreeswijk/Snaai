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
	public partial class ReactiePage : ContentPage
	{
		public ReactiePage ()
		{
        

			InitializeComponent ();
		}

        /*
       * when a button is being pushed a alert will be displayed
       */
        async void Tyrone_clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Tyrone_Health", "wat een gezonde maaltijd", "ok");
        }

        /*
        * when a button is being pushed a alert will be displayed
        */
        async void JouwReacties_clicked(object sender, EventArgs e)


        {// if the arraylist count is zero the following pop up will be dislayed
            if (CommentList.Comments.Count == 0)
            {
                await DisplayAlert("Jouw reactie", " je hebt nog geen reacties toegevoegd", "ok");
            }
            else
            {// a enchaned for loop that loops trough the comments.
                foreach (string i in CommentList.Comments)
                {
                    await DisplayAlert("Jouw reactie",i, "ok");
                }
            }
        }
        /*
      * when a button is being pushed a alert will be displayed
      */
        async void Megan_Fit_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Megan_Fit", "Dat ziet er gezond uit", "ok");
        }

        /*
       * when a button is being pushed a alert will be displayed
       */
        async void Bodybuilder_IFFB_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Bodybuilder_IFFB", "Dit recept bevat te weinig proteine is niet goed voor de gains", "ok");
        }

        /*
         * this method checks if the textfield has content. if that is not the case a pop up will show.
         */
        void Post_clicked(object sender, EventArgs e)
        {
            if (Reactie_Text.Text == null)
            {
                 DisplayAlert("Let op", "Voordat je een reactie kunt posten, moet deze nog in de tekstveld worden ingevuld.", "ok");
            }
            else
            {

                // the text of the entry will be added tot the arraylist and de entry will be emptied.
                CommentList.Comments.Add(Reactie_Text.Text);
                Reactie_Text.Text = "";
            }

        }
    }
}