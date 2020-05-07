/*
        Programmeur: Nathan Comeau et Jonathan Zogona
        Date: 5/3/2020
        But:  Calculer des statistiques ou afficher des information concernant certains sports avec une
              application mobile multi-plateforme
 
        Solution: SportsStats.sln
        Projet:   SportsStats.csproj
        Classe:   WelcomePage.xaml.cs
 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using static Xamarin.Forms.Button;
using static Xamarin.Forms.Button.ButtonContentLayout;

namespace SportsStatistics
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WelcomePage : ContentPage
    {
        private readonly string membres = "Nathan & Jonathan Z.";
        private readonly string[] titres = { "Sports", "Basketball", "Football", "Soccer", "Hockey" };

        Button basketballButton;
        Button footballButton;
        Button hockeyButton;
        Button soccerButton;
        public WelcomePage()
        {
            InitializeComponent();
            InitControls();
        }

        #region Methode pour initialiser les contrôles
        private void InitControls()
        {
            Label titleLabel = new Label
            {
                Text = titres[0],
                BackgroundColor = Color.Red,
                TextColor = Color.White,
                FontSize = 40,
                HorizontalOptions = LayoutOptions.Fill,
                HorizontalTextAlignment = TextAlignment.Center
            };

            basketballButton = new Button
            {
                ImageSource = "Images/basketball.jpg",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                WidthRequest = 180,
                HeightRequest = 140,
                ContentLayout = new ButtonContentLayout(ImagePosition.Right, -10)
            };

            footballButton = new Button
            {
                ImageSource = "Images/football.jpg",
                HorizontalOptions = LayoutOptions.Center,
                WidthRequest = 180,
                HeightRequest = 140,
                ContentLayout = new ButtonContentLayout(ImagePosition.Right, -10)
            };

            soccerButton = new Button
            {
                ImageSource = "Images/soccer.png",
                HorizontalOptions = LayoutOptions.Center,
                WidthRequest = 180,
                HeightRequest = 140,
                ContentLayout = new ButtonContentLayout(ImagePosition.Right, -10)
            };

            hockeyButton = new Button
            {
                ImageSource = "Images/hockey.png",
                HorizontalOptions = LayoutOptions.Center,
                WidthRequest = 180,
                HeightRequest = 140,
                ContentLayout = new ButtonContentLayout(ImagePosition.Right, -10)
            };

            Label teamLabel = new Label
            {
                Text = membres,
                BackgroundColor = Color.Red,
                TextColor = Color.White,
                FontSize = 40,
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.End,
                HorizontalTextAlignment = TextAlignment.Center
            };

            this.Content = new StackLayout
            {
                Children =
                {
                    titleLabel,
                    basketballButton,
                    footballButton,
                    soccerButton,
                    hockeyButton,
                    teamLabel
                }
            };

            basketballButton.Clicked += sportButton_Clicked;
            footballButton.Clicked += sportButton_Clicked;
            soccerButton.Clicked += sportButton_Clicked;
            hockeyButton.Clicked += sportButton_Clicked;
        }

        #endregion

        #region Methode clique pour les boutons des sports
        async void sportButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (sender == basketballButton)
                {
                    await Navigation.PushAsync(new BasketballPage(membres, titres[1]));
                }
                else if(sender == footballButton)
                {
                    await Navigation.PushAsync(new FootballPage(membres, titres[2]));
                }
                else if(sender == soccerButton)
                {
                    await Navigation.PushAsync(new SoccerPage(membres, titres[3]));
                }
                else
                {
                    await Navigation.PushAsync(new HockeyPage(membres, titres[4]));
                }
            }
            catch(Exception ex)
            {
                await DisplayAlert("Erreur", ex.ToString(), "Annuler");
            }
        }
        #endregion
    }
}