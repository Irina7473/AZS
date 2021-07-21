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

namespace AZS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SelectFuel.SelectedIndex = 0;
            Fuel_Quantity.IsEnabled = false;
            Fuel_Summa.IsEnabled = false;
        }

        private double _fuelQuantity = 0;
        private double _fuelPayment = 0;
        private double _cafePayment = 0;
        private double _totalPayment = 0;
        private double _dayPayment = 0;

        private void SelectFuel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var select = ((TextBlock)SelectFuel.SelectedItem).Text;                       
            if (select == "АИ-92") Fuel_Price.Text = "42,74";            
            if (select == "АИ-95") Fuel_Price.Text = "46,38";            
            if (select == "АИ-98") Fuel_Price.Text = "48,38";            
            if (select == "ДТ") Fuel_Price.Text = "48,91";            
        }

        private void Fuel_Quantity_TextChanged(object sender, TextChangedEventArgs e)
        {
            _fuelQuantity = double.Parse(Fuel_Quantity.Text);
            var price = Double.Parse(Fuel_Price.Text);
            _fuelPayment = Math.Round(_fuelQuantity * price, 2);
            Result_Fuel.Text = _fuelPayment.ToString();
        }

        private void Fuel_Summa_TextChanged(object sender, TextChangedEventArgs e)
        {
            _fuelPayment = Math.Round(Double.Parse(Fuel_Summa.Text), 2);
            var price = Double.Parse(Fuel_Price.Text);
            _fuelQuantity = Math.Round(_fuelPayment / price, 2);
            Result_Fuel.Text = _fuelQuantity.ToString();            
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton pressed = (RadioButton)sender;
            pressed.IsChecked = true;
            if (pressed==Option_Quantity)
            {                
                Result_Fuel.Text = "0";
                Fuel_Summa.Text = "0";
                Fuel_Summa.IsEnabled = false;
                Fuel_Quantity.IsEnabled = true;
                Option_Fuel.Text = "Топливо к оплате, рублей";
            }
            if (pressed==Option_Summa)
            {
                Result_Fuel.Text = "0";
                Fuel_Quantity.Text = "0";
                Fuel_Quantity.IsEnabled = false;
                Fuel_Summa.IsEnabled = true;
                Option_Fuel.Text = "Топливо к выдаче, литров";
            }
        }

        private void Goods01_Checked(object sender, RoutedEventArgs e)
        {
            Quantity01.IsEnabled = true;
        }

        private void Goods01_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                var summa = double.Parse(Summa01.Text);
                _cafePayment -= summa;
                Result_Cafe.Text = _cafePayment.ToString();
                Summa01.Text = "0";
                Quantity01.Text = "0";
            }
            catch { }
            Quantity01.IsEnabled = false;        
        }

        /*
        private void Quantity_TextChanged(object sender, TextChangedEventArgs e)
        {
            double digit =0;
            double quantity = 0;
            double price = 0;
            double summa = 0;

            var symbol = (TextBox)sender;
            foreach (char d in symbol.Name)
                if (char.IsDigit(d)) digit = d;
            if (digit==1)
            {
                quantity = double.Parse(Quantity1.Text);
                price = Double.Parse(Price01.Text);
                summa = Math.Round(quantity * price, 2);
                Summa01.Text = summa.ToString();
            }
            else if (digit == 2)
            {
                quantity = double.Parse(Quantity2.Text);
                price = Double.Parse(Price02.Text);
                summa = Math.Round(quantity * price, 2);
                Summa02.Text = summa.ToString();
            }

            _cafePayment += summa;
            Result_Cafe.Text = _cafePayment.ToString();            
        }*/

        private void Quantity01_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                var quantity = double.Parse(Quantity01.Text);
                var price = Double.Parse(Price01.Text);
                var summa = Math.Round(quantity * price, 2);
                Summa01.Text = summa.ToString();
                _cafePayment += summa;
                Result_Cafe.Text = _cafePayment.ToString();
            }
            catch { }
        }

       private void Payment_Click(object sender, RoutedEventArgs e)
        {
            _totalPayment = _fuelPayment + _cafePayment;
            Result_Total.Text = _totalPayment.ToString();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _dayPayment += _totalPayment;
            Day_Income.Text = _dayPayment.ToString();
                        
            Fuel_Quantity.Text = "0";
            Fuel_Summa.Text = "0";
            
            Goods01.IsChecked = false;
            Goods02.IsChecked = false;
            Goods03.IsChecked = false;
            Goods04.IsChecked = false;
            Goods05.IsChecked = false;

            _fuelQuantity = 0;
            _fuelPayment = 0;
            _cafePayment = 0;
            _totalPayment = 0;

            Result_Fuel.Text = "0";
            Result_Cafe.Text = "0";
            Result_Total.Text = "0";            
        }
                    

        private void Goods02_Checked(object sender, RoutedEventArgs e)
        {
            Quantity02.IsEnabled = true;
        }               

        private void Goods02_Unchecked(object sender, RoutedEventArgs e)
        {
            try 
            { 
            var summa = double.Parse(Summa02.Text);
            _cafePayment -= summa;
            Result_Cafe.Text = _cafePayment.ToString();
            Summa02.Text = "0";
            Quantity02.Text = "0";
            }
            catch { }
            Quantity02.IsEnabled = false;
        }

        private void Goods03_Checked(object sender, RoutedEventArgs e)
        {
            Quantity03.IsEnabled = true;
        }

        private void Goods03_Unchecked(object sender, RoutedEventArgs e)
        {
            try 
            { 
            var summa = double.Parse(Summa03.Text);
            _cafePayment -= summa;
            Result_Cafe.Text = _cafePayment.ToString();
            Summa03.Text = "0";
            Quantity03.Text = "0";
            }
            catch { }
            Quantity03.IsEnabled = false;
        }

        private void Goods04_Checked(object sender, RoutedEventArgs e)
        {
            Quantity04.IsEnabled = true;
        }
        
        private void Goods04_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            { 
            var summa = double.Parse(Summa04.Text);
            _cafePayment -= summa;
            Result_Cafe.Text = _cafePayment.ToString();
            Summa04.Text = "0";
            Quantity04.Text = "0";
            }
            catch { }
            Quantity04.IsEnabled = false;
        }

        private void Goods05_Checked(object sender, RoutedEventArgs e)
        {
            Quantity05.IsEnabled = true;
        }

        private void Goods05_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                var summa = double.Parse(Summa05.Text);
                _cafePayment -= summa;
                Result_Cafe.Text = _cafePayment.ToString();
                Summa05.Text = "0";
                Quantity05.Text = "0";
            }
            catch { }
            Quantity05.IsEnabled = false;
        }

        private void Goods06_Checked(object sender, RoutedEventArgs e)
        {
           
        }

        private void Goods06_Unchecked(object sender, RoutedEventArgs e)
        {
            
        }

        private void Goods07_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Goods07_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void Goods08_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Goods08_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void Goods09_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Goods09_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void Goods10_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Goods10_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void Goods11_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Goods11_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void Goods12_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Goods12_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void Goods13_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Goods13_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void Goods14_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Goods14_Unchecked(object sender, RoutedEventArgs e)
        {

        }


        private void Quantity02_TextChanged(object sender, TextChangedEventArgs e)
        {
            var quantity = double.Parse(Quantity02.Text);
            var price = Double.Parse(Price02.Text);
            var summa = Math.Round(quantity * price, 2);
            Summa02.Text = summa.ToString();
            _cafePayment += summa;
            Result_Cafe.Text = _cafePayment.ToString();
        }


        private void Quantity03_TextChanged(object sender, TextChangedEventArgs e)
        {
            var quantity = double.Parse(Quantity03.Text);
            var price = Double.Parse(Price03.Text);
            var summa = Math.Round(quantity * price, 2);
            Summa03.Text = summa.ToString();
            _cafePayment += summa;
            Result_Cafe.Text = _cafePayment.ToString();
        }

        private void Quantity04_TextChanged(object sender, TextChangedEventArgs e)
        {
            var quantity = double.Parse(Quantity04.Text);
            var price = Double.Parse(Price04.Text);
            var summa = Math.Round(quantity * price, 2);
            Summa04.Text = summa.ToString();
            _cafePayment += summa;
            Result_Cafe.Text = _cafePayment.ToString();
        }

        private void Quantity05_TextChanged(object sender, TextChangedEventArgs e)
        {
            var quantity = double.Parse(Quantity05.Text);
            var price = Double.Parse(Price05.Text);
            var summa = Math.Round(quantity * price, 2);
            Summa05.Text = summa.ToString();
            _cafePayment += summa;
            Result_Cafe.Text = _cafePayment.ToString();
        }

        private void Quantity06_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Quantity07_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Quantity08_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Quantity09_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Quantity10_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Quantity11_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Quantity12_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Quantity13_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Quantity14_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}