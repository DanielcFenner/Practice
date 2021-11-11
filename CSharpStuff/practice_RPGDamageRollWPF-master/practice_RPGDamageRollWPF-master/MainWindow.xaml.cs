using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace practcing_RPGDamageRollWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static Random random = new Random();
        SwordDamage swordDamage = new SwordDamage(random.Next(1, 7) + random.Next(1, 7) + random.Next(1, 7));
        public MainWindow()
        {
            InitializeComponent();
            swordDamage.Magic = false;
            swordDamage.Flaming = false;
        }

        public void RollDice()
        {
            swordDamage.Roll = random.Next(1, 7) + random.Next(1, 7) + random.Next(1, 7);
            DisplayDamage();
        }

        void DisplayDamage()
        {
            damageOutputTextBlock.Text = $"Rolled {swordDamage.Roll} and hit for {swordDamage.Damage} HP";           
        }

        private void flamingCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            swordDamage.Flaming = true;
        }

        private void flamingCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            swordDamage.Flaming = false;
        }

        private void magicCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            swordDamage.Magic = true; ;
        }

        private void magicCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            swordDamage.Magic = false;
        }

        private void rollButton_Click(object sender, RoutedEventArgs e)
        {
            RollDice();
            DisplayDamage();
        }

       
    }
}
