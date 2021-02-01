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

namespace The_Calculater
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class CalculatorWindow : Window
    {
        private double _operand1;
        private double _operand2;
        public CalculatorWindow()
        {
            InitializeComponent();
        }
        //
        //validate
        //
        private bool ValidInputs(out string userFeedback)
        {
            bool validInputs = true;
            userFeedback = "";

            if (!double.TryParse(textBox_Operand1.Text, out _operand1))
            {
                validInputs = false;
                userFeedback += "Operand 1 must be a double.\n";
            }

            if (!double.TryParse(textBox_Operand2.Text, out _operand2))
            {
                validInputs = false;
                userFeedback += "Operand 2 must be a double.\n";
            }
            return validInputs;
        }
        //
        //Calculate Total
        //
        private void Button_Calculate_Click(object sender, RoutedEventArgs e)
        {
            string userFeedback = "";
            string operation = comboBox_Operation.SelectionBoxItem as string;
            double total;
            if (ValidInputs(out userFeedback))
            {
                switch (operation)
                {
                    case "+":
                        total = (_operand1 + _operand2);
                        break;
                    case "-":
                        total = (_operand1 - _operand2);
                        break;
                    case "*":
                        total = (_operand1 * _operand2);
                        break;
                    case "/":
                        total = (_operand1 / _operand2);
                        break;

                    default:
                        total = 0;
                        break;
                }
                Label_Total.Content = total.ToString();
            }
            else
            {
                MessageBox.Show(userFeedback);
            }   
        }
        //
        //Display Help Window
        //
        private void Button_Help_Click(object sender, RoutedEventArgs e)
        {
            HelpWindow helpScreen = new HelpWindow();
            helpScreen.ShowDialog();
        }
        //
        //Close Application
        //
        private void Button_Close_MainWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
