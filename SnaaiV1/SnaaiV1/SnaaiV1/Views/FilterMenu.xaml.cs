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
	public partial class FilterMenu : ContentView
	{
        public event EventHandler ItemTapped;
        // isAnimating boolean to animate the menu when is deems necessary
        private bool _isAnimating = false;
        // The animationdelay gives the animation a certain speed
        // uint cant be negative 
        private uint _animationDelay = 300;
        public FilterMenu ()
		{
			InitializeComponent ();
            // buttons to open the menu en to close it will be turned visible/not visible, these visibilities will be changed whenever one of these buttons is pressed
            InnerButtonClose.IsVisible = false;
            InnerButtonMenu.IsVisible = true;
            // functies will be called to handle certain functions. Such as what happens when you open the menu or close it.
            HandleMenuCenterClicked();
            HandleCloseClicked();

            HandleOptionsClicked();

        }

        //functions to let the different options show content
        private void HandleOptionsClicked()
        {
            // different options in the filtermenu, each with their individual tests
            HandleOptionClicked(N, "");
            HandleOptionClicked(NE, "Het doel van Snaai is het beoordelen van elkaars voedingskeuzes, hierdoor wordt er meer nagedacht over de definitie van gezond");
            HandleOptionClicked(E, "Door op dit icoontje te drukken ga je terug naar de homepagina van Snaai");
            HandleOptionClicked(SE, "De Message knop wordt gebruikt voor het plaatsen en lezen van reacties");
            HandleOptionClicked(S, "");
            HandleOptionClicked(SW, "Een Cheap like kan gegeven worden als de maaltijd die post is volgens jou goedkoop te maken is! ");
            HandleOptionClicked(W, "Een Strong like mag je geven als het eten op de foto volgens jou goed is voor bijvoorbeeld sport, spieropbouw of lijnen");
            HandleOptionClicked(NW, "Een health like kan worden gegeven bij voedsel wat voor jou in het algemeen gezond is. Hopelijk is dat niet een diepvries pizza...");

        }
        // functie om een optie een bepaalde actie uit te laten voeren
        // function to let an option perform a certain action
        private void HandleOptionClicked(Image image, string value)
        {
            // if you press an image, this will be recognized as a button and functions can be added.
            image.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() =>
                {
                    // if item not null, then invoke the selected items value, which will be a string
                    // if an image is pressed, the menu closes
                    ItemTapped?.Invoke(this, new SelectedItemChangedEventArgs(value));
                    CloseMenu();
                }),
                // 1 press on the image is needed to activate the command
                NumberOfTapsRequired = 1
            });
        }
        // if the close button is pressed, the menu will be closed
        private void HandleCloseClicked()
        {
            InnerButtonClose.GestureRecognizers.Add(new TapGestureRecognizer
            {
                //uses a new thread to wait until the menu is closed, while this thread continues 
                
                Command = new Command(async () =>
                {
                    await CloseMenu();
                }),
                NumberOfTapsRequired = 1
            });

        }
        //function to give an animation to the closing of the filtermenu
        // task is given to a thread
        private async Task CloseMenu()
        {
            // als er nog geen animatie is, voeg dan een animatie toe bij het afsluiten van het menu
            // if there is no animation yet, execute following code
            if (!_isAnimating)
            {

                _isAnimating = true;
                // the buttons at the beginning is visible again
                InnerButtonMenu.IsVisible = true;
                InnerButtonClose.IsVisible = true;
                await HideButtons();
                // the buttons will be rotated within the animation with a given animationDelay, this allows the buttons to rotate with a certain speed
                // rotated to 0 degrees
                InnerButtonClose.RotateTo(0, _animationDelay);
                // fade to not visible = 0
                InnerButtonClose.FadeTo(0, _animationDelay);
                InnerButtonMenu.RotateTo(0, _animationDelay);
                // fade to visible = 1
                InnerButtonMenu.FadeTo(1, _animationDelay);
                // with the use of easing a bouncing effect is added to the outer circle of the menu
                await OuterCircle.ScaleTo(1, 1000, Easing.BounceOut);
                InnerButtonClose.IsVisible = false;
                // after the animation is done, the isAnimating boolean is set to false
                _isAnimating = false;
            }
        }
        // function to open the filtermenu and the animation that is used
        private void HandleMenuCenterClicked()
        {
            InnerButtonMenu.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(async () =>
                {
                    if (!_isAnimating)
                    {
                        _isAnimating = true;

                        InnerButtonClose.IsVisible = true;
                        InnerButtonMenu.IsVisible = true;
                        // rotate 360 degrees
                        InnerButtonMenu.RotateTo(360, _animationDelay);
                        InnerButtonMenu.FadeTo(0, _animationDelay);
                        InnerButtonClose.RotateTo(360, _animationDelay);
                        InnerButtonClose.FadeTo(1, _animationDelay);

                        await OuterCircle.ScaleTo(5, 1000, Easing.BounceIn);
                        await ShowButtons();
                        InnerButtonMenu.IsVisible = false;

                        _isAnimating = false;

                    }
                }),
                NumberOfTapsRequired = 1
            });

        }

        private async Task HideButtons()
        {
            //unsigned  cant be negative
            var speed = 25U;
            // sets the boolean FadeTo to false (0) in the first parameter. The second parameter is a given speed
            // this is done for all the images
            await N.FadeTo(0, speed);
            await NE.FadeTo(0, speed);
            await E.FadeTo(0, speed);
            await SE.FadeTo(0, speed);
            await S.FadeTo(0, speed);
            await SW.FadeTo(0, speed);
            await W.FadeTo(0, speed);
            await NW.FadeTo(0, speed);
        }

        private async Task ShowButtons()
        {
            // sets the boolean FadeTo to true (1) in the first parameter. The second parameter is a given speed
            // this is done for all the images
            var speed = 25U;
            await N.FadeTo(1, speed);
            await NE.FadeTo(1, speed);
            await E.FadeTo(1, speed);
            await SE.FadeTo(1, speed);
            await S.FadeTo(1, speed);
            await SW.FadeTo(1, speed);
            await W.FadeTo(1, speed);
            await NW.FadeTo(1, speed);
        }
    }
}