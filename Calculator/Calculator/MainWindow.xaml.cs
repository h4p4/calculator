
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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitButtons();
        }
        void InitButtons()
        {
            // Number buttons
            for (int value = 1, row = 2; row <= 4; row++)
            {
                for (int col = 0; col <= 2; col++)
                {
                    MainGrid.Children.Add(NewButton(value.ToString(), "NumberButton" + value.ToString(), row, col));
                    value++;
                }
            }
            MainGrid.Children.Add(NewButton("0", "NumberButton0", 5, 1));

            // Calculation buttons
            MainGrid.Children.Add(NewButton(".", "CalculationButtonDot", 5, 0));
            MainGrid.Children.Add(NewButton("=", "CalculationButtonEquals", 5, 2));
            MainGrid.Children.Add(NewButton("/", "CalculationButtonDivide", 2, 3));
            MainGrid.Children.Add(NewButton("*", "CalculationButtonMultiply", 3, 3));
            MainGrid.Children.Add(NewButton("-", "CalculationButtonMinus", 4, 3));
            MainGrid.Children.Add(NewButton("+", "CalculationButtonPlus", 5, 3));

            // Other buttons
            MainGrid.Children.Add(NewButton("(", "CalculationButtonOpenBracket", 1, 0));
            MainGrid.Children.Add(NewButton(")", "CalculationButtonCloseBracket", 1, 1));
            MainGrid.Children.Add(NewButton("%", "CalculationButtonPercent", 1, 2));
            MainGrid.Children.Add(NewButton("AC", "CalculationButtonAC", 1, 3));


        }
        Button NewButton(string content, string name, int row, int col)
        {
            Button button = new Button() { Name = name, Content = content };
            button.SetValue(Grid.RowProperty, row);
            button.SetValue(Grid.ColumnProperty, col);
            return button;
        }
    }
}
