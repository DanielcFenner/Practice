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

namespace CanadaPostOptimizerWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        double[] price = {
                0.92, 1.30, 1.94, 3.19, // Canada 0-30g, 30-50g, Oversized up to 100g and Oversized up to 200g
                1.30, 1.94, 3.19, 5.57, // US 0-30g, 30-50g, Oversized up to 100g and Oversized up to 200g
                2.71, 3.88, 6.39, 11.14 }; // Inernational 0-30g, 30-50g, Oversized up to 100g and Oversized up to 200g

        int priceSelector = 0;
        bool zeroToThirty = false;

        private string GetStamps()
        {
            if (price[priceSelector] == 0.92) return optimalStampsText.Text = "1 Canadian";
            else if (price[priceSelector] == 1.30) return optimalStampsText.Text = "1 US";
            else if (price[priceSelector] == 1.94) return optimalStampsText.Text = "1 Canadian + 1 US";
            else if (price[priceSelector] == 3.19) return optimalStampsText.Text = "1 Canadian + 2 US";
            else if (price[priceSelector] == 5.57) return optimalStampsText.Text = "5 Canadian + 1 US";
            else if (price[priceSelector] == 2.71) return optimalStampsText.Text = "1 International";
            else if (price[priceSelector] == 3.88) return optimalStampsText.Text = "3 US";
            else if (price[priceSelector] == 6.39) return optimalStampsText.Text = "7 Canadian";
            else if (price[priceSelector] == 11.14) return optimalStampsText.Text = "2 Canadian + 1 US + 3 International";
            else return optimalStampsText.Text = "Something broke";

            /*  0.92, 1.30, 1.94, 3.19, // Canada 0-30g, 30-50g, Oversized up to 100g and Oversized up to 200g
              1.30, 1.94, 3.19, 0.57, // US 0-30g, 30-50g, Oversized up to 100g and Oversized up to 200g
              2.71, 3.88, 6.39, 11.14 }; // Inernational 0-30g, 30-50g, Oversized up to 100g and Oversized up to 200g*/
        }

        private void canadaButton_Click(object sender, RoutedEventArgs e)
        {
            destinationPanel.Visibility = Visibility.Collapsed;
            weightPanel.Visibility = Visibility.Visible;
            infoText.Text = "Canada";
        }

        private void usButton_Click(object sender, RoutedEventArgs e)
        {
            destinationPanel.Visibility = Visibility.Collapsed;
            weightPanel.Visibility = Visibility.Visible;
            infoText.Text = "US";
            priceSelector += 4;
        }

        private void internationalButton_Click(object sender, RoutedEventArgs e)
        {
            destinationPanel.Visibility = Visibility.Collapsed;
            weightPanel.Visibility = Visibility.Visible;
            infoText.Text = "International";
            priceSelector += 8;
        }

        private void thirtyButton_Click(object sender, RoutedEventArgs e)
        {
            weightPanel.Visibility = Visibility.Collapsed;
            oversizedPanel.Visibility = Visibility.Visible;
            infoText.Text += " 0-30g";
            zeroToThirty = true;
        }

        private void fiftyButton_Click(object sender, RoutedEventArgs e)
        {
            weightPanel.Visibility = Visibility.Collapsed;
            oversizedPanel.Visibility = Visibility.Visible;
            infoText.Text += " 30-50g";
            priceSelector += 1;
        }

        private void hundredButton_Click(object sender, RoutedEventArgs e)
        {
            infoText.Text += " 50-100g Oversized (all lettermail over 50g counts as Oversized)";
            priceSelector += 2;
            GetStamps();
            infoText.Text += $" | Price: {price[priceSelector]:C}";
            weightPanel.Visibility = Visibility.Collapsed;
            optimalStampsPanel.Visibility = Visibility.Visible;
        }

       

        private void twoHunderedButton_Click(object sender, RoutedEventArgs e)
        {
            infoText.Text += " 100-200g Oversized (all lettermail over 50g counts as Oversized)";
            priceSelector += 3;
            GetStamps();
            infoText.Text += $" | Price: {price[priceSelector]:C}";
            weightPanel.Visibility = Visibility.Collapsed;
            optimalStampsPanel.Visibility = Visibility.Visible;
        }

        private void oversizedButtonYes_Click(object sender, RoutedEventArgs e)
        {
            if (zeroToThirty)
            {
                priceSelector += 2;
            }
            else
            {
                priceSelector += 1;
            }

            infoText.Text += " Oversized";
            GetStamps();
            infoText.Text += $" | Price: {price[priceSelector]:C}";
            oversizedPanel.Visibility = Visibility.Collapsed;
            optimalStampsPanel.Visibility = Visibility.Visible;

        }

        private void oversizedButtonNo_Click(object sender, RoutedEventArgs e)
        {
            GetStamps();
            infoText.Text += $" | Price: {price[priceSelector]:C}";
            oversizedPanel.Visibility = Visibility.Collapsed;
            optimalStampsPanel.Visibility = Visibility.Visible;
        }

        private void resetButton_Click(object sender, RoutedEventArgs e)
        {
            priceSelector = 0;
            zeroToThirty = false;
            optimalStampsText.Text = "";
            infoText.Text = "";

            optimalStampsPanel.Visibility = Visibility.Collapsed;
            oversizedPanel.Visibility = Visibility.Collapsed;
            weightPanel.Visibility = Visibility.Collapsed;
            destinationPanel.Visibility = Visibility.Visible;
        }
    }
}
