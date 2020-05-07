/*
        Programmeur: Nathan Comeau et Jonathan Zogona
        Date: 5/3/2020
        But:  Calculer des statistiques ou afficher des information concernant certains sports avec une
              application mobile multi-plateforme
 
        Solution: SportsStats.sln
        Projet:   SportsStats.csproj
        Classe:   FootballPage.xaml.cs
 
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
    public partial class FootballPage : ContentPage
    {
        #region Membres

        string membres;
        string titre;

        Button calculerPourcentageCompletion;
        Entry completedPassesEntry;
        Entry attemptedPassesEntry;
        Label completionPercentage;
        Label completionPercentageDisplay;
        Button pagePrecedente;

        #endregion

        #region Constructeur
        public FootballPage(string pMembres, string pTitre)
        {
            membres = pMembres;
            titre = pTitre;
            InitControls();
        }

        #endregion

        #region Methode pour initialiser les contrôles
        private void InitControls()
        {
            Label titleLabel = new Label
            {
                Text = titre,
                BackgroundColor = Color.Red,
                TextColor = Color.White,
                FontSize = 40,
                HorizontalOptions = LayoutOptions.Fill,
                HorizontalTextAlignment = TextAlignment.Center
            };

            Label completedPasses = new Label
            {
                Text = "Passes completées: ",
                FontSize = 18,
                HorizontalTextAlignment = TextAlignment.Start
            };

            completedPassesEntry = new Entry
            {
                
            };

            Label attemptedPasses = new Label
            {
                Text = "Passes tentées: ",
                FontSize = 18,
                HorizontalTextAlignment = TextAlignment.Start
            };

            attemptedPassesEntry = new Entry
            {

            };

            calculerPourcentageCompletion = new Button
            {
                Text = "Calculer le pourcentage de completion de passes",
                HorizontalOptions = LayoutOptions.Center,
                WidthRequest = 280
            };

            completionPercentage = new Label
            {
                Text = "Pourcentage de passes completées",
                FontSize = 18,
                HorizontalTextAlignment = TextAlignment.Start
            };

            completionPercentageDisplay = new Label
            {
                FontSize = 18,
                HorizontalTextAlignment = TextAlignment.Start,
                TextColor = Color.Red
            };

            pagePrecedente = new Button
            {
                Text = "Page précédente",
                HorizontalOptions = LayoutOptions.Center,
                WidthRequest = 150,
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
                    completedPasses,
                    completedPassesEntry,
                    attemptedPasses,
                    attemptedPassesEntry,
                    calculerPourcentageCompletion,
                    completionPercentage,
                    completionPercentageDisplay,
                    pagePrecedente
                }
               
            };

            calculerPourcentageCompletion.Clicked += CalculerPourcentageCompletion_Clicked;
            pagePrecedente.Clicked += PagePrecedente_Clicked;
        }

        #endregion

        #region Methode clique pour le bouton page précédente

        async void PagePrecedente_Clicked(object sender, EventArgs e)
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

        #region Methode clique pour le bouton calculer le pourcentage 

        private void CalculerPourcentageCompletion_Clicked(object sender, EventArgs e)
        {
            try
            {
                if(completedPassesEntry.Text != String.Empty || attemptedPassesEntry.Text != String.Empty)
                {
                    completionPercentageDisplay.Text = ((decimal.Parse(completedPassesEntry.Text) / decimal.Parse(attemptedPassesEntry.Text))).ToString("P");
                }
                else
                {
                    DisplayAlert("Erreur", "Veuillez entrer des chiffres", "Annuler");
                }
            }
            catch(Exception ex)
            {
                DisplayAlert("Erreur", ex.ToString(), "Annuler");
            }
        }

        #endregion
    }
}