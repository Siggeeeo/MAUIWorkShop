using System.Reflection;

namespace MAUIWorkShop
{
    public partial class MainPage : ContentPage
    {
        Random random = new Random();
        int Hemlig;
        int Försök = 0;
        int Maxvärde = 100;

        public MainPage()
        {
            InitializeComponent();

            StartGame();
        }
        void StartGame()
        {
            Hemlig = random.Next(1, Maxvärde+ 1);
            Försök = 0;

            FeedMe.IsEnabled = false;
            GissaKnapp.IsEnabled = false;

            Feedback.Text = "Välj svårighetsgrad";
            FeedMe.Text = "";

            StartaOm.IsVisible = false;
            Picker.SelectedIndex = -1;
            Indikator.IsVisible= false;
        }

        private void OnUserGuess(object? sender, EventArgs e)
        {
            String Inmatning = FeedMe.Text;

            if (!int.TryParse(Inmatning, out int gissning))
            {
                Feedback.Text = "Skriv ett heltal";
                return;
            }

            if (gissning < 1 || gissning > Maxvärde)
            {
                Feedback.Text = $"Talet måste vara 1-{Maxvärde}";
                return;
            }
            Försök++;

            if (gissning == Hemlig)
            {
                Feedback.Text = $"Rätt det tog {Försök} Försök";
                FeedMe.IsEnabled = false;
                StartaOm.IsVisible = true;
                GissaKnapp.IsEnabled = false;
                Indikator.IsVisible = true;
                Indikator.Color = Colors.Green;

            }
            else if (gissning < Hemlig)
            {
                Feedback.Text = "Fel, för lågt gissa igen!";
                Indikator.IsVisible = true;
                Indikator.Color = Colors.Red;
            }
            else
            {
                Feedback.Text = "Fel, för högt gissa igen";
                Indikator.IsVisible = true;
                Indikator.Color = Colors.Red;

            }
            FeedMe.Text = "";
        }
        private void OnReset (Object sender, EventArgs e)
        {
            StartGame();
        }
        private void Difficulty(object? sender, EventArgs e)
        {
            if (Picker.SelectedIndex == 0)
                Maxvärde = 25;
            else if (Picker.SelectedIndex == 1)
                Maxvärde = 50;
            else
                Maxvärde = 100;

                Hemlig = random.Next(1, Maxvärde + 1);
            Försök = 0;

            FeedMe.IsEnabled = true;
            GissaKnapp.IsEnabled = true;

            FeedMe.Text = "";
            Feedback.Text = $"Gissa ett tal mellan 1-{Maxvärde}";
        }
    }
    }

