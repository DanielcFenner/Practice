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

namespace practiceSloppyJoesDiscountSandwiches
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MakeTheMenu();
        }

        private void MakeTheMenu()
        {
            MenuItem[] menuItems = new MenuItem[5];
            for (int i = 0; i < menuItems.Length; i++)
            {
                if (i < 3)
                {
                    menuItems[i] = new MenuItem();
                }
                else
                {
                    menuItems[i] = new MenuItem()
                    {
                        Breads = new string[] { "plain bagel", "everything bagel", "chocolate chip sprinkle bagel", "onion and garlic bagel" }
                    };
                }
            }

            foodText1.Text = menuItems[0].GenerateMenuItem();
            priceText1.Text = menuItems[0].RandomPrice();
            foodText2.Text = menuItems[1].GenerateMenuItem();
            priceText2.Text = menuItems[1].RandomPrice();
            foodText3.Text = menuItems[2].GenerateMenuItem();
            priceText3.Text = menuItems[2].RandomPrice();
            foodText4.Text = menuItems[3].GenerateMenuItem();
            priceText4.Text = menuItems[3].RandomPrice();
            foodText5.Text = menuItems[4].GenerateMenuItem();
            priceText5.Text = menuItems[4].RandomPrice();

            MenuItem specialMenuItem = new MenuItem()
            {
                Proteins = new string[] { "Sauteed mushrooms", "Mushed chickpeas", "Crispy glazed tofu" },
                Breads = new string[] { "a gluten free roll", "burrito wrap", "naan bread" },
                Condiments = new string[] { "blazing hot cheeto sauce", "pesto", "blended dill pickle" }
            };

            foodText6.Text = specialMenuItem.GenerateMenuItem();
            priceText6.Text = specialMenuItem.RandomPrice();

            foodBonus.Text = $"Add triple cashew cheese sauce for {specialMenuItem.RandomPrice()}";
        }
    }
}
