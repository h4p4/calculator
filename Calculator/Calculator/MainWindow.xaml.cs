
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Button> Buttons = new ObservableCollection<Button>();
        private Button AllClear;
        public MainWindow()
        {
            InitializeComponent();

            InitButtons();

            foreach (var b in Buttons)
                b.Click += new RoutedEventHandler(ButtonClick);
            AllClear.Click += new RoutedEventHandler(ClearField);
        }

        private void ClearField(object sender, RoutedEventArgs e)
        {
            CalcTBlock.Text = String.Empty; 
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {

            if ((sender as Button).Content == "=")
            {
                try
                {
                    CalcTBlock.Text = new DataTable().Compute(CalcTBlock.Text, null).ToString();
                    if (CalcTBlock.Text.Contains(','))
                        CalcTBlock.Text = CalcTBlock.Text.Replace(',', '.');
                }
                catch (Exception) { }
                return;
            }
            CalcTBlock.Text += (sender as Button).Content.ToString();

        }

        void InitButtons()
        {
            // Number buttons
            for (int value = 1, row = 2; row <= 4; row++)
            {
                for (int col = 0; col <= 2; col++)
                {
                    Buttons.Add(NewButton(value.ToString(), "NumberButton" + value.ToString(), row, col));
                    value++;
                }
            }
            Buttons.Add(NewButton("0", "NumberButton0", 5, 1));

            // Calculation buttons
            Buttons.Add(NewButton(".", "CalculationButtonDot", 5, 0));
            Buttons.Add(NewButton("=", "CalculationButtonEquals", 5, 2));
            Buttons.Add(NewButton("/", "CalculationButtonDivide", 2, 3));
            Buttons.Add(NewButton("*", "CalculationButtonMultiply", 3, 3));
            Buttons.Add(NewButton("-", "CalculationButtonMinus", 4, 3));
            Buttons.Add(NewButton("+", "CalculationButtonPlus", 5, 3));
            Buttons.Add(NewButton("(", "CalculationButtonOpenBracket", 1, 0));
            Buttons.Add(NewButton(")", "CalculationButtonCloseBracket", 1, 1));
            Buttons.Add(NewButton("%", "CalculationButtonPercent", 1, 2));

            // Other buttons
            AllClear = NewButton("AC", "OtherButtonAC", 1, 3);

            // Init
            foreach (var btn in Buttons)
                MainGrid.Children.Add(btn);
            MainGrid.Children.Add(AllClear);
        }
        Button NewButton(string content, string name, int row, int col)
        {
            Button button = new Button() { Name = name, Content = content };
            button.SetValue(Grid.RowProperty, row);
            button.SetValue(Grid.ColumnProperty, col);
            return button;
        }
        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Window window = (Window)sender;
            for (
                int fontSize = 95, windowHeight = 1000;
                windowHeight > 50;
                fontSize -= 3, windowHeight -= 25
                )
                if (fontSize > 5 && window.Height < windowHeight)
                    window.FontSize = fontSize;
        }
    }
}
