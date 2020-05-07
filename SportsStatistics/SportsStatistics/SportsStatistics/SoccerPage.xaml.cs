/*
        Programmeur: Nathan Comeau et Jonathan Zogona
        Date: 5/3/2020
        But:  Calculer des statistiques ou afficher des information concernant certains sports avec une
              application mobile multi-plateforme
 
        Solution: SportsStats.sln
        Projet:   SportsStats.csproj
        Classe:   SoccerPage.xaml.cs
 
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SportsStatistics
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SoccerPage : ContentPage
    {
        #region Champs

        private readonly string p_membres;
        private readonly string p_titre;
        private Label selectedDateTimeLabel;
        private DateTime date;
        private TimeSpan time;

        #endregion

        #region Constructeur

        public SoccerPage(string membres, string titre)
        {
            InitializeComponent();
            p_membres = membres;
            p_titre = titre;
            InitControls();
        }

        #endregion

        #region Initialiser les contrôles

        private void InitControls()
        {
            Label titleLabel = new Label
            {
                Text = p_titre,
                BackgroundColor = Color.Red,
                TextColor = Color.White,
                FontSize = 40,
                HorizontalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center
            };

            Label selectDateTimeLabel = new Label
            {
                Text = "Sélectionner date et heure du meilleur but de l'histoire : ",
                TextColor = Color.Black,
                FontSize = 18,
                HorizontalTextAlignment = TextAlignment.Start
            };


            DatePicker datePicker = new DatePicker
            {
                Format = "D"
            };

            TimePicker timePicker = new TimePicker
            {
                Format = "T"
            };

            selectedDateTimeLabel = new Label
            {
                Text = "",
                TextColor = Color.Green,
                FontSize = 18,
                HorizontalTextAlignment = TextAlignment.Start
            };

            Button backButton = new Button
            {
                Text = "Page précédente",
                TextColor = Color.Black,
                FontSize = 18,
                HorizontalOptions = LayoutOptions.Center
            };

            Label teamLabel = new Label
            {
                Text = p_membres,
                BackgroundColor = Color.Red,
                TextColor = Color.White,
                FontSize = 40,
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.End,
                HorizontalTextAlignment = TextAlignment.Center
            };

            date = datePicker.Date;
            time = timePicker.Time;

            datePicker.DateSelected += datePicker_DateSelected;
            timePicker.PropertyChanged += timePicker_PropertyChanged;
            backButton.Clicked += backButton_Clicked;

            this.Content = new StackLayout
            {
                Children =
                {
                    titleLabel,
                    selectDateTimeLabel,
                    selectedDateTimeLabel,
                    datePicker,
                    timePicker,
                    backButton,
                    teamLabel
                }
            };
        }

        #endregion

        #region DatePicker Date Selected

        void datePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            date = e.NewDate;
            selectedDateTimeLabel.Text = (date.Date + time).ToString("dddd, MMMM dd, yyyy, HH:mm:ss");
        }

        #endregion

        #region TimePicker Property Changed

        void timePicker_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == TimePicker.TimeProperty.PropertyName)
            {
                time = (sender as TimePicker).Time;
                selectedDateTimeLabel.Text = (date.Date + time).ToString("dddd, MMMM dd, yyyy, HH:mm:ss");
            }
        }

        #endregion

        #region Page Précédente

        async void backButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        #endregion
    }
}