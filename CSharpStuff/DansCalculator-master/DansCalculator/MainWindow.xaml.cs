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

namespace DansCalculator
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

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e) // allows the window to be moved by click and holding anywhere on the window. We need this since we have WindowStyle = none
        {
            base.OnMouseLeftButtonDown(e);

            // Begin dragging the window
            this.DragMove();
        }

        private void btnX_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnUnderscore_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnZero_Click(object sender, RoutedEventArgs e)
        {
            ButtonInput(0m);
        }

        private void btnOne_Click(object sender, RoutedEventArgs e)
        {
            ButtonInput(1m);
        }

        private void btnTwo_Click(object sender, RoutedEventArgs e)
        {
            ButtonInput(2m);
        }

        private void btnThree_Click(object sender, RoutedEventArgs e)
        {
            ButtonInput(3m);
        }

        private void btnFour_Click(object sender, RoutedEventArgs e)
        {
            ButtonInput(4m);
        }

        private void btnFive_Click(object sender, RoutedEventArgs e)
        {
            ButtonInput(5m);
        }

        private void btnSix_Click(object sender, RoutedEventArgs e)
        {
            ButtonInput(6m);
        }

        private void btnSeven_Click(object sender, RoutedEventArgs e)
        {
            ButtonInput(7m);
        }

        private void btnEight_Click(object sender, RoutedEventArgs e)
        {
            ButtonInput(8m);
        }

        private void btnNine_Click(object sender, RoutedEventArgs e)
        {
            ButtonInput(9m);
        }

        private void btnDot_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            ButtonInputOp("+");
        }

        private void btnSubtract_Click(object sender, RoutedEventArgs e)
        {
            ButtonInputOp("-");
        }

        private void btnMultiply_Click(object sender, RoutedEventArgs e)
        {
            ButtonInputOp("*");
        }

        private void btnDivide_Click(object sender, RoutedEventArgs e)
        {
            ButtonInputOp("/");
        }

        private void btnEquals_Click(object sender, RoutedEventArgs e)
        {
            ButtonInputEquals();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            number1 = 0;
            number2 = 0;
            op = "";
            numberArea.Text = "0";

        }
    }
}
