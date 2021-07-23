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
            Goods06.IsChecked = false;
            Goods07.IsChecked = false;
            Goods08.IsChecked = false;
            Goods09.IsChecked = false;
            Goods10.IsChecked = false;
            Goods11.IsChecked = false;
            Goods12.IsChecked = false;
            Goods13.IsChecked = false;
            Goods14.IsChecked = false;
            
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
            Quantity06.IsEnabled = true;
        }

        private void Goods06_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                var summa = double.Parse(Summa06.Text);
                _cafePayment -= summa;
                Result_Cafe.Text = _cafePayment.ToString();
                Summa06.Text = "0";
                Quantity06.Text = "0";
            }
            catch { }
            Quantity06.IsEnabled = false;
        }

        private void Goods07_Checked(object sender, RoutedEventArgs e)
        {
            Quantity07.IsEnabled = true;
        }

        private void Goods07_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                var summa = double.Parse(Summa07.Text);
                _cafePayment -= summa;
                Result_Cafe.Text = _cafePayment.ToString();
                Summa07.Text = "0";
                Quantity07.Text = "0";
            }
            catch { }
            Quantity07.IsEnabled = false;
        }

        private void Goods08_Checked(object sender, RoutedEventArgs e)
        {
            Quantity08.IsEnabled = true;
        }

        private void Goods08_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                var summa = double.Parse(Summa08.Text);
                _cafePayment -= summa;
                Result_Cafe.Text = _cafePayment.ToString();
                Summa08.Text = "0";
                Quantity08.Text = "0";
            }
            catch { }
            Quantity08.IsEnabled = false;
        }

        private void Goods09_Checked(object sender, RoutedEventArgs e)
        {
            Quantity09.IsEnabled = true;
        }

        private void Goods09_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                var summa = double.Parse(Summa09.Text);
                _cafePayment -= summa;
                Result_Cafe.Text = _cafePayment.ToString();
                Summa09.Text = "0";
                Quantity09.Text = "0";
            }
            catch { }
            Quantity09.IsEnabled = false;
        }

        private void Goods10_Checked(object sender, RoutedEventArgs e)
        {
            Quantity10.IsEnabled = true;
        }
        
        private void Goods10_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                var summa = double.Parse(Summa10.Text);
                _cafePayment -= summa;
                Result_Cafe.Text = _cafePayment.ToString();
                Summa10.Text = "0";
                Quantity10.Text = "0";
            }
            catch { }
            Quantity10.IsEnabled = false;
        }

        private void Goods11_Checked(object sender, RoutedEventArgs e)
        {
            Quantity11.IsEnabled = true;
        }

        private void Goods11_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                var summa = double.Parse(Summa11.Text);
                _cafePayment -= summa;
                Result_Cafe.Text = _cafePayment.ToString();
                Summa11.Text = "0";
                Quantity11.Text = "0";
            }
            catch { }
            Quantity11.IsEnabled = false;
        }

        private void Goods12_Checked(object sender, RoutedEventArgs e)
        {
            Quantity12.IsEnabled = true;
        }

        private void Goods12_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                var summa = double.Parse(Summa12.Text);
                _cafePayment -= summa;
                Result_Cafe.Text = _cafePayment.ToString();
                Summa12.Text = "0";
                Quantity12.Text = "0";
            }
            catch { }
            Quantity12.IsEnabled = false;
        }

        private void Goods13_Checked(object sender, RoutedEventArgs e)
        {
            Quantity13.IsEnabled = true;
        }

        private void Goods13_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                var summa = double.Parse(Summa13.Text);
                _cafePayment -= summa;
                Result_Cafe.Text = _cafePayment.ToString();
                Summa13.Text = "0";
                Quantity13.Text = "0";
            }
            catch { }
            Quantity13.IsEnabled = false;
        }

        private void Goods14_Checked(object sender, RoutedEventArgs e)
        {
            Quantity14.IsEnabled = true;
        }

        private void Goods14_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                var summa = double.Parse(Summa14.Text);
                _cafePayment -= summa;
                Result_Cafe.Text = _cafePayment.ToString();
                Summa14.Text = "0";
                Quantity14.Text = "0";
            }
            catch { }
            Quantity14.IsEnabled = false;
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
            var quantity = double.Parse(Quantity06.Text);
            var price = Double.Parse(Price06.Text);
            var summa = Math.Round(quantity * price, 2);
            Summa06.Text = summa.ToString();
            _cafePayment += summa;
            Result_Cafe.Text = _cafePayment.ToString();
        }

        private void Quantity07_TextChanged(object sender, TextChangedEventArgs e)
        {
            var quantity = double.Parse(Quantity07.Text);
            var price = Double.Parse(Price07.Text);
            var summa = Math.Round(quantity * price, 2);
            Summa07.Text = summa.ToString();
            _cafePayment += summa;
            Result_Cafe.Text = _cafePayment.ToString();
        }

        private void Quantity08_TextChanged(object sender, TextChangedEventArgs e)
        {
            var quantity = double.Parse(Quantity08.Text);
            var price = Double.Parse(Price08.Text);
            var summa = Math.Round(quantity * price, 2);
            Summa08.Text = summa.ToString();
            _cafePayment += summa;
            Result_Cafe.Text = _cafePayment.ToString();
        }

        private void Quantity09_TextChanged(object sender, TextChangedEventArgs e)
        {
            var quantity = double.Parse(Quantity09.Text);
            var price = Double.Parse(Price09.Text);
            var summa = Math.Round(quantity * price, 2);
            Summa09.Text = summa.ToString();
            _cafePayment += summa;
            Result_Cafe.Text = _cafePayment.ToString();
        }

        private void Quantity10_TextChanged(object sender, TextChangedEventArgs e)
        {
            var quantity = double.Parse(Quantity10.Text);
            var price = Double.Parse(Price10.Text);
            var summa = Math.Round(quantity * price, 2);
            Summa10.Text = summa.ToString();
            _cafePayment += summa;
            Result_Cafe.Text = _cafePayment.ToString();
        }

        private void Quantity11_TextChanged(object sender, TextChangedEventArgs e)
        {
            var quantity = double.Parse(Quantity11.Text);
            var price = Double.Parse(Price11.Text);
            var summa = Math.Round(quantity * price, 2);
            Summa11.Text = summa.ToString();
            _cafePayment += summa;
            Result_Cafe.Text = _cafePayment.ToString();
        }

        private void Quantity12_TextChanged(object sender, TextChangedEventArgs e)
        {
            var quantity = double.Parse(Quantity12.Text);
            var price = Double.Parse(Price12.Text);
            var summa = Math.Round(quantity * price, 2);
            Summa12.Text = summa.ToString();
            _cafePayment += summa;
            Result_Cafe.Text = _cafePayment.ToString();
        }

        private void Quantity13_TextChanged(object sender, TextChangedEventArgs e)
        {
            var quantity = double.Parse(Quantity13.Text);
            var price = Double.Parse(Price13.Text);
            var summa = Math.Round(quantity * price, 2);
            Summa13.Text = summa.ToString();
            _cafePayment += summa;
            Result_Cafe.Text = _cafePayment.ToString();
        }

        private void Quantity14_TextChanged(object sender, TextChangedEventArgs e)
        {
            var quantity = double.Parse(Quantity14.Text);
            var price = Double.Parse(Price14.Text);
            var summa = Math.Round(quantity * price, 2);
            Summa14.Text = summa.ToString();
            _cafePayment += summa;
            Result_Cafe.Text = _cafePayment.ToString();
        }
    }
}