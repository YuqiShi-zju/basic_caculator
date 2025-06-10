using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace basic_caculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string currentInput = "0";
        private double currentValue = 0;
        private string currentOperation = "";
        private bool newInput = true;

        public MainWindow() //这一步相当于python的__init__方法
        {
            InitializeComponent(); //初始化窗体

            foreach (var child in ((Grid)Content).Children)
            {
                if (child is Button button)
                {
                    button.Click += Button_Click;
                }
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string content = button.Content.ToString();

            // 处理不同类型的按钮点击
            switch (content)
            {
                case "0":
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                    HandleNumber(content);
                    break;

                case ".":
                    HandleDecimalPoint();
                    break;

                case "+":
                case "-":
                case "*":
                case "/":
                    HandleOperation(content);
                    break;

                case "=":
                    CalculateResult();
                    break;

                case "C":
                    ClearAll();
                    break;

                case "CE":
                    ClearEntry();
                    break;

                case "←":
                    Backspace();
                    break;
            }
        }
        private void HandleNumber(string number)
        {
            if (newInput || currentInput == "0")
            {
                currentInput = number;
                newInput = false;
            }
            else
            {
                currentInput += number;
            }
            DisplayTextBox.Text = currentInput;
        }

        private void HandleDecimalPoint()
        {
            if (!currentInput.Contains("."))
            {
                currentInput += ".";
                DisplayTextBox.Text = currentInput;
                newInput = false;
            }
        }

        private void HandleOperation(string operation)
        {
            if (!newInput)
            {
                CalculateResult();
            }

            currentValue = double.Parse(currentInput);
            currentOperation = operation;
            newInput = true;
        }

        private void CalculateResult()
        {
            if (string.IsNullOrEmpty(currentOperation)) return;

            double newValue = double.Parse(currentInput);

            switch (currentOperation)
            {
                case "+":
                    currentValue += newValue;
                    break;
                case "-":
                    currentValue -= newValue;
                    break;
                case "*":
                    currentValue *= newValue;
                    break;
                case "/":
                    if (newValue != 0)
                        currentValue /= newValue;
                    else
                        currentInput = "Error";
                    break;
            }

            if (currentInput != "Error")
            {
                currentInput = currentValue.ToString();
                DisplayTextBox.Text = currentInput;
            }

            newInput = true;
            currentOperation = "";
        }

        private void ClearAll()
        {
            currentInput = "0";
            currentValue = 0;
            currentOperation = "";
            newInput = true;
            DisplayTextBox.Text = currentInput;
        }

        private void ClearEntry()
        {
            currentInput = "0";
            newInput = true;
            DisplayTextBox.Text = currentInput;
        }

        private void Backspace()
        {
            if (currentInput.Length > 1)
            {
                currentInput = currentInput.Substring(0, currentInput.Length - 1);
            }
            else
            {
                currentInput = "0";
                newInput = true;
            }
            DisplayTextBox.Text = currentInput;
        }

    }
}