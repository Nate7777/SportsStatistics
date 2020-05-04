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
        public WelcomePage()
        {
            InitializeComponent();
            InitControls();
        }

        private void InitControls()
        {
            Label titleLabel = new Label
            {
                Text = "Sports",
                BackgroundColor = Color.Red,
                TextColor = Color.White,
                FontSize = 40,
                HorizontalOptions = LayoutOptions.Fill,
                HorizontalTextAlignment = TextAlignment.Center
            };

            Button basketballButton = new Button
            {
                ImageSource = "Images/basketball.jpg",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                WidthRequest = 180,
                HeightRequest = 140,
                ContentLayout = new ButtonContentLayout(ImagePosition.Right, -10)
            };

            Button footballButton = new Button
            {
                ImageSource = "Images/football.jpg",
                HorizontalOptions = LayoutOptions.Center,
                WidthRequest = 180,
                HeightRequest = 140,
                ContentLayout = new ButtonContentLayout(ImagePosition.Right, -10)
            };

            Button soccerButton = new Button
            {
                ImageSource = "Images/soccer.png",
                HorizontalOptions = LayoutOptions.Center,
                WidthRequest = 180,
                HeightRequest = 140,
                ContentLayout = new ButtonContentLayout(ImagePosition.Right, -10)
            };

            Button hockeyButton = new Button
            {
                ImageSource = "Images/hockey.png",
                HorizontalOptions = LayoutOptions.Center,
                WidthRequest = 180,
                HeightRequest = 140,
                ContentLayout = new ButtonContentLayout(ImagePosition.Right, -10)
            };

            Label teamLabel = new Label
            {
                Text = "Nathan & Jonathan Z",
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
        }
    }
}