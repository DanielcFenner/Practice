using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
namespace MatchGame
{
   
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        DispatcherTimer timer = new DispatcherTimer();
        int tenthsOfSecondsElapsed;
        int matchesFound;
        public MainWindow()
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromSeconds(.1);
            timer.Tick += Timer_Tick;           
            SetUpGame();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            tenthsOfSecondsElapsed++;
            timeTextBlock.Text = (tenthsOfSecondsElapsed / 10F).ToString("0.0s");
            matchesFoundText.Text = matchesFound.ToString();
            if (matchesFound == 8)
            {
                timer.Stop();
                timeTextBlock.Text = timeTextBlock.Text + " - Play again?";
            }    
        }

        private void SetUpGame()
        {
            Random random = new Random();

            List<string> animalEmoji = new List<string>()
            {
                "🦦","🦦",
                "🦈","🦈",
                "🐬","🐬",
                "🐋","🐋",
                "🐟","🐟",
                "🐠","🐠",
                "🦐","🦐",
                "🐙","🐙",
            };

            foreach (Emoji.Wpf.TextBlock textBlock in mainGrid.Children.OfType<Emoji.Wpf.TextBlock>()) // for each text block in the main grid
            {
                int index = random.Next(animalEmoji.Count); // create a random index number equal to the amount of emojis in the animalEmoji list
                string nextEmoji = animalEmoji[index]; // make a string variable that includes the animalEmoji list and the random index
                textBlock.Text = nextEmoji; // set the text block text to the random indexed animalEmoji
                animalEmoji.RemoveAt(index); // remove that emoji so it gets taken out of the loop and won't create a duplicate
                textBlock.Opacity = 0;

            }

            timer.Start();
            tenthsOfSecondsElapsed = 0;
            matchesFound = 0;
          
        }



        Emoji.Wpf.TextBlock lastTextBlockClicked;
        bool findingMatch = false;


        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Emoji.Wpf.TextBlock textBlock = sender as Emoji.Wpf.TextBlock;
            if (textBlock.Opacity == 100)
            {
                findingMatch = false;
            }
            else if (findingMatch == false) // if finding match is false, then allow us to search for the 2nd emoji and shows first click
            {
                textBlock.Opacity = 100;
                lastTextBlockClicked = textBlock;
                findingMatch = true; // findingMatch allows us to know when the user has already clicked one and is in the process of finding a match
            }
            else if (textBlock.Text == lastTextBlockClicked.Text) // shows the emoji if it's the same as the last box that was clicked
            {
                matchesFound++;
                textBlock.Opacity = 100;
                findingMatch = false;
            }
            else // makes them hidden
            {
                lastTextBlockClicked.Opacity = 0;
                findingMatch = false;
            }
        }

        private void TimeTextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (matchesFound == 8)
            {
                SetUpGame();
            }
        }
    }
}
