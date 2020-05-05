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
        string membres;
        string titre;
        public FootballPage(string pMembres, string pTitre)
        {
            InitializeComponent();
            InitControls();
            membres = pMembres;
            titre = pTitre;
        }

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

            Entry completedPassesEntry = new Entry
            {
                
            };

            Label attemptedPasses = new Label
            {
                Text = "Passes tentées: ",
                FontSize = 18,
                HorizontalTextAlignment = TextAlignment.Start
            };

            Entry attemptedPassesEntry = new Entry
            {

            };

            this.Content = new StackLayout
            {
                Children =
                {
                    titleLabel,
                    completedPasses,
                    completedPassesEntry,
                    attemptedPasses,
                    attemptedPassesEntry
                }
               
            };
        }
    }
}