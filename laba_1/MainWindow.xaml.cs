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

namespace laba_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ICalculator _calculator;

        public MainWindow()
        {
            InitializeComponent();
            _calculator = new Calc_Formul();
        }

        private void b_result_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                float Down_gran = float.Parse(down_integral.Text);
                float Up_gran = float.Parse(up_integral.Text);
                int all_de = int.Parse(all_del.Text);
                int variant = variants.SelectedIndex;

                Func<double, double> Function = x => 322 * x - Math.Log(11 * x) - 2;

                // Проверка области определения для логарифма
                if (Down_gran <= 0 || Up_gran <= 0)
                {
                    MessageBox.Show("Для функции с логарифмом пределы интегрирования должны быть > 0");
                }
                else
                {
                    double result = _calculator.Calculate(Function, Down_gran, Up_gran, all_de, variant);

                    l_result.Content = result.ToString();
                }
                   
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка расчета: {ex.Message}");
            }
        }
    }
}