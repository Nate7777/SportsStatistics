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
        #region Membres

        string membres;
        string titre;

        Label title;
        Label favoriteTeam;
        Label favoriteTeamDisplay;
        Picker teamPicker;
        Button pagePrecedenteButton;
        Label teamLabel;

        List<string> teams = new List<string>();

        #endregion

        #region Constructeur

        public HockeyPage(string pMembres, string pTitre)
        {
            membres = pMembres;
            titre = pTitre;
            InitList();
            InitControls();
        }

        #endregion

        #region Methode pour initialiser la liste

        private void InitList()
        {
            teams.Add("Montreal Canadiens");
            teams.Add("Boston Bruins");
            teams.Add("Toronto Maple Leafs");
            teams.Add("New York Rangers");
            teams.Add("Chicago Blackhawks");
            teams.Add("Detroit Red Wings");
        }

        #endregion

        #region Methode pour initialiser les controles
        public void InitControls()
        {
            title = new Label
            {
                Text = titre,
                BackgroundColor = Color.Red,
                FontSize = 40,
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.Fill,
                HorizontalTextAlignment = TextAlignment.Center
            };

            favoriteTeam = new Label
            {
                Text = "Votre équipe préférée: ",
                TextColor = Color.Black,
                FontSize = 18,
                HorizontalTextAlignment = TextAlignment.Center
            };

            favoriteTeamDisplay = new Label
            {
                TextColor = Color.Red,
                FontSize = 16,
                HorizontalTextAlignment = TextAlignment.Center
            };

            teamPicker = new Picker
            {
                Title = "Veuillez choisir votre équipe préférée",
                ItemsSource = teams
            };

            pagePrecedenteButton = new Button
            {
                Text = "Page précédente",
                HorizontalOptions = LayoutOptions.Center,
                WidthRequest = 150
            };

            teamLabel = new Label
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
                    favoriteTeamDisplay,
                    teamPicker,
                    pagePrecedenteButton,
                    teamLabel
                }
            };

            teamPicker.SelectedIndexChanged += TeamPicker_SelectedIndexChanged;
            pagePrecedenteButton.Clicked += PagePrecedenteButton_Clicked;
        }

        #endregion

        #region Methode clique pour le bouton page precedente

        async void PagePrecedenteButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                await Navigation.PopAsync();
            }
            catch(Exception ex)
            {
                await DisplayAlert("Erreur", ex.ToString(), "Annuler");
            }
        }

        #endregion

        #region Selected index changed pour le Picker
        private void TeamPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            favoriteTeamDisplay.Text = teamPicker.SelectedItem.ToString();
        }

        #endregion
    }
}