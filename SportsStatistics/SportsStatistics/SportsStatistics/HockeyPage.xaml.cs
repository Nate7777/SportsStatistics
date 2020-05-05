/*
        Programmeur: Nathan Comeau et Jonathan Zogona
        Date: 5/3/2020
        But:  Calculer des statistiques ou afficher des information concernant certains sports avec une
              application mobile multi-plateforme
 
        Solution: SportsStats.sln
        Projet:   SportsStats.csproj
        Classe:   HockeyPage.xaml.cs
 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SportsStatistics
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HockeyPage : ContentPage
    {
        string membres;
        string titre;
        System.Collections.IList teams;

        public HockeyPage(string pMembres, string pTitre)
        {
            InitializeComponent();
            InitControls();
            InitList();
            membres = pMembres;
            titre = pTitre;
        }

        private void InitList()
        {
            teams.Add("Montreal Canadiens");
            teams.Add("Boston Bruins");
            teams.Add("Toronto Maple Leafs");
            teams.Add("New York Rangers");
            teams.Add("Chicago Blackhawks");
            teams.Add("Detroit Red Wings");
        }

        public void InitControls()
        {
            Label title = new Label
            {
                Text = titre,
                BackgroundColor = Color.Red,
                FontSize = 40,
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.Fill,
                HorizontalTextAlignment = TextAlignment.Center
            };

            Label favoriteTeam = new Label
            {
                Text = "Votre équipe préférée: ",
                TextColor = Color.Black,
                FontSize = 18,
                HorizontalTextAlignment = TextAlignment.Center
            };

            Picker teamPicker = new Picker
            {
                Title = "Veuillez choisir votre équipe préférée",
                ItemsSource = teams
            };

            Button pagePrecedenteButton = new Button
            {
                Text = "Page précédente",
                HorizontalOptions = LayoutOptions.Center,
                WidthRequest = 70
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
                    title,
                    favoriteTeam,
                    teamPicker,
                    pagePrecedenteButton,
                    teamLabel
                }
            };
        }


    }
}