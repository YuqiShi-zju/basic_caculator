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
        private string _currentInput = string.Empty; //当前输入的字符串


        public MainWindow() //这一步相当于python的__init__方法
        {
            InitializeComponent(); //初始化窗体
            
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button; //将sender转换为Button类型
            if (button != null)
            {
                _currentInput += button.Content.ToString(); //将按钮的内容添加到当前输入字符串中
                DisplayTextBox.Text = _currentInput; //更新显示文本框
            }

            //处理不同的点击
            if (button.Content.ToString() == "=") //如果点击的是等于按钮
            {
                try
                {
                    var result = new DataTable().Compute(_currentInput, null); //计算表达式的结果
                    DisplayTextBox.Text = result.ToString(); //显示结果
                    _currentInput = string.Empty; //清空当前输入
                }
                catch (Exception ex)
                {
                    DisplayTextBox.Text = "Error"; //如果计算出错，显示错误信息
                    _currentInput = string.Empty; //清空当前输入
                }
            }
            else if (button.Content.ToString() == "C") //如果点击的是清除按钮
            {
                _currentInput = string.Empty; //清空当前输入
                DisplayTextBox.Text = string.Empty; //清空显示文本框
            }


        }
    }
}