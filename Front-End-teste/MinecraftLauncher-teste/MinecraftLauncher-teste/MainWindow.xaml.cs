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


namespace MinecraftLauncher_teste
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary

    public partial class MainWindow : Window
    {
        private readonly Minecraft minecraft = new();
        public MainWindow()
        {
            InitializeComponent();
            CarregarVersoes();
        }


        private async void CarregarVersoes()
        {
            
            var versoes = await minecraft.BuscarVersoes();

            VersaoComboBox.ItemsSource = versoes;
            VersaoComboBox.SelectedIndex = 0;
        }

        private async void Jogar_Click(object sender, RoutedEventArgs e)
        {
            string nick = NickTextBox.Text;
            string versao = VersaoComboBox.SelectedItem.ToString();
            await minecraft.OpenMinecraft(versao, nick);


            BarraProgresso.Value = 10;
            StatusText.Text = "Preparando launcher...";

            await Task.Delay(500);

            BarraProgresso.Value = 35;
            StatusText.Text = "Verificando/baixando Minecraft...";

            await Task.Delay(500);

            BarraProgresso.Value = 70;
            StatusText.Text = "Iniciando Minecraft...";

            await minecraft.OpenMinecraft(versao, nick);

            BarraProgresso.Value = 100;
            StatusText.Text = "Minecraft iniciado!";
        }
    }
}