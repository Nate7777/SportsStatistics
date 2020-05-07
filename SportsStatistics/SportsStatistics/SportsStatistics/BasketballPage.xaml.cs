/*
 * 
        Programmeur :       Nathan Comeau et Jonathan Zogona
        Date        :       5/3/2020
        But         :       Calculer des statistiques ou afficher des information concernant certains sports avec une
                            application mobile multi-plateforme
 
        Solution    :       SportsStats.sln
        Projet      :       SportsStats.csproj
        Classe      :       BasketballPage.xaml.cs
 *
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
    public partial class BasketballPage : ContentPage
    {
        #region Champs

        private readonly string p_membres;
        private readonly string p_titre;
        private Label switcherOnOffLabel;
        private Label sliderValueLabel;

        #endregion

        #region Contructeur

        public BasketballPage(string membres, string titre)
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

            Label threePointerLabel = new Label
            {
                Text = "Afficher meilleur marqueur de trois points ?",
                TextColor = Color.Black,
                FontSize = 18,
                HorizontalTextAlignment = TextAlignment.Start
            };

            Switch switcher = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                OnColor = Color.Red,
            };

            switcherOnOffLabel = new Label
            {
                Text = "",
                TextColor = Color.Green,
                FontSize = 18,
                HorizontalTextAlignment = TextAlignment.Start
            };

            Label pointsLabel = new Label
            {
                Text = "Nombre de points (25 et 40)",
                TextColor = Color.Black,
                FontSize = 18,
                HorizontalTextAlignment = TextAlignment.Start
            };

            Slider slider = new Slider
            {
                Maximum = 40,
                Minimum = 25,
                Value = 25
            };

            sliderValueLabel = new Label
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


            switcher.Toggled += switcher_Toggled;
            slider.ValueChanged += slider_ValuedChanged;
            backButton.Clicked += backButton_Clicked;

            this.Content = new StackLayout
            {
                Children =
                {
                    titleLabel,
                    threePointerLabel,
                    switcherOnOffLabel,
                    switcher,
                    pointsLabel,
                    sliderValueLabel,
                    slider,            
                    backButton,
                    teamLabel
                }
            };
        }

        #endregion

        #region Switcher Toggled

        void switcher_Toggled(object sender, ToggledEventArgs e)
        {
            switcherOnOffLabel.Text =  e.Value.ToString();
        }

        #endregion

        #region Slider Value Changed

        void slider_ValuedChanged(object sender, ValueChangedEventArgs e)
        {
            sliderValueLabel.Text = e.NewValue.ToString();
        }

        #endregion

        #region Page précédente

        async void backButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        #endregion
    }
}