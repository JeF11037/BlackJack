using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BlackJack
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Game : CarouselPage
    {
        TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();
        Strongbox strongbox = new Strongbox();
        public Game()
        {
            InitializeComponent();

            strongbox.PLAYER_score = new List<int>();
            strongbox.PAGE_page = new List<ContentPage>();

            tapGestureRecognizer.Tapped += TapGestureRecognizer_Tapped;

            ContentPage contentPage = new ContentPage();
            StackLayout stack = new StackLayout
            { 
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            for (int tick = 1; tick < 5; tick++)
            {
                int temp = 170173;
                switch (tick)
                {
                    case 1:
                        temp = 24;
                        break;
                    case 2:
                        temp = 32;
                        break;
                    case 3:
                        temp = 36;
                        break;
                    case 4:
                        temp = 52;
                        break;
                    default:
                        break;
                }
                Label lbl = new Label
                {
                    Text = temp.ToString(),
                    FontSize = Device.GetNamedSize(NamedSize.Header, typeof(Label)),
                    TextColor = Color.Black,
                };
                lbl.GestureRecognizers.Add(tapGestureRecognizer);
                stack.Children.Add(lbl);
            }
            contentPage.Content = stack;
            this.Children.Add(contentPage);
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if (strongbox.PAGE_page.Count > 0)
            {
                DeletePage();
            }
            Label lbl = (Label)sender;
            strongbox.DECK_size = int.Parse(lbl.Text);
            switch (strongbox.DECK_size)
            {
                case 24:
                    strongbox.DECK_deck = strongbox.DECK_decks[0];
                    strongbox.DECK_chosen = 0;
                    break;
                case 32:
                    strongbox.DECK_deck = strongbox.DECK_decks[1];
                    strongbox.DECK_chosen = 1;
                    break;
                case 36:
                    strongbox.DECK_deck = strongbox.DECK_decks[2];
                    strongbox.DECK_chosen = 2;
                    break;
                case 52:
                    strongbox.DECK_deck = strongbox.DECK_decks[3];
                    strongbox.DECK_chosen = 3;
                    break;
                default:
                    break;
            }
            for (int tick = 0; tick < 2; tick++)
            {
                strongbox.PAGE_page.Add(CreatePageByParams());
            }
            foreach (var el in strongbox.PAGE_page)
            {
                this.Children.Add(el);
            }
        }

        private ContentPage CreatePageByParams()
        {
            Random rnd = new Random();

            Label clr = new Label
            {
                Text = strongbox.CARD_color[rnd.Next(0, 2)],
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                TextColor = Color.Black
            };

            Label suit = new Label
            {
                Text = strongbox.DECK_suit[rnd.Next(0, 4)],
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                TextColor = Color.Black
            };

            int temp = rnd.Next(0, 10);
            try
            {
                temp = int.Parse(strongbox.DECK_decks[strongbox.DECK_chosen][rnd.Next(0, strongbox.DECK_decks[strongbox.DECK_chosen].Count)]);
            }
            catch (Exception)
            {
            }
            strongbox.PLAYER_score.Add(temp);

            Label value = new Label
            {
                Text = temp.ToString(),
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                TextColor = Color.Black
            };

            Button pass = new Button
            {
                Text = "PASS",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                TextColor = Color.Black,
                WidthRequest = 150,
                HeightRequest = 100,
                Margin = 25,
                CornerRadius = 10
            };

            pass.Clicked += Pass_Clicked;

            Button more = new Button
            {
                Text = "MORE",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                TextColor = Color.Black,
                WidthRequest = 150,
                HeightRequest = 100,
                Margin = 25,
                CornerRadius = 10
            };

            more.Clicked += More_Clicked;

            StackLayout stackvalue = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Orientation = StackOrientation.Horizontal,
            };

            Frame framevalue = new Frame
            {
                Content = stackvalue,
                CornerRadius = 10,
                BackgroundColor = Color.DarkOliveGreen,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Margin = new Thickness(50, 50, 50, 275)
            };

            StackLayout stackbuttons = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Orientation = StackOrientation.Horizontal,
            };

            StackLayout stackcard = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                BackgroundColor = Color.Green,
            };

            Frame framecard = new Frame
            {
                Content = stackcard,
                CornerRadius = 10,
                BackgroundColor = Color.DarkGreen,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
            };

            StackLayout stack = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
            };

            stackvalue.Children.Add(clr);
            stackvalue.Children.Add(suit);
            stackvalue.Children.Add(value);
            stackbuttons.Children.Add(more);
            stackbuttons.Children.Add(pass);
            stackcard.Children.Add(framevalue);
            stack.Children.Add(framecard);
            stack.Children.Add(stackbuttons);

            ContentPage contentPage = new ContentPage
            {
                Content = stack
            };
            return contentPage;
        }

        private void DeletePage()
        {
            try
            {
                foreach (var el in strongbox.PAGE_page)
                {
                    this.Children.Remove(el);
                }
                strongbox.PAGE_page.Clear();
                strongbox.DECK_deck.Clear();
            }
            catch (Exception)
            {
            }
        }

        private void More_Clicked(object sender, EventArgs e)
        {
            ContentPage contentPage = CreatePageByParams();
            strongbox.PAGE_page.Add(contentPage);
            this.Children.Add(contentPage);
        }

        private async void Pass_Clicked(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int temp = rnd.Next(0, 25);
            await DisplayAlert("Result", "Your result: " + strongbox.PLAYER_score.Sum().ToString() + "\nYour opponent result: " + temp, "OK");
            if (strongbox.PLAYER_score.Sum() > temp && strongbox.PLAYER_score.Sum() < 22)
            {
                await DisplayAlert("Winner", "You Won!", "OK");
            }
            else
            {
                await DisplayAlert("Winner", "Your opponent Won!", "OK");
            }
            DeletePage();
        }

        
    }
}