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

namespace Weddeberekening_2
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

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder result = new StringBuilder();
            string name = employeeTextBox.Text;
            double hours = double.Parse(hoursTextBox.Text);
            double wage = double.Parse(wageTextBox.Text);
            double bruto = (wage * hours);
            double belasting = 0;
            double jaarborg = bruto;
            double netto = 0;

            if(jaarborg > 50000)
            {
                belasting = ((jaarborg - 50000) * 0.5);
                jaarborg = 50000;
            }
            if(jaarborg > 25000)
            {
                belasting = belasting + ((jaarborg - 25000) * 0.4);
                jaarborg = 25000;
            }
            if(jaarborg > 15000)
            {
                belasting = belasting + ((jaarborg - 15000) * 0.3);
                jaarborg = 15000;
            }
            if(jaarborg > 10000)
            {
                belasting = belasting + ((jaarborg - 10000) * 0.2);
                jaarborg = 10000;
            }
            if(jaarborg == 10000)
            {
                netto = bruto - belasting;
            }
            if(jaarborg < 10000)
            {
                netto = jaarborg;
            }

            result.AppendLine($"Loonfishe van {name}.");
            result.AppendLine();
            result.AppendLine($"Aantal werkuren : {hours}.");
            result.AppendLine($"Uurloon: {wage}.");
            result.AppendLine($"Brutojaarwedde: {bruto}.");
            result.AppendLine($"Belasting: {belasting}.");
            result.AppendLine($"Nettojaarwedde: {netto}.");
            
            resultTextBox.Text = result.ToString();
        }

        private void eraseButton_Click(object sender, RoutedEventArgs e)
        {
            employeeTextBox.Clear();
            hoursTextBox.Clear();
            wageTextBox.Clear();
            resultTextBox.Clear();
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}