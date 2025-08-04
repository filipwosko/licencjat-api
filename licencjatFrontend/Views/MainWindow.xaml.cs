using licencjatFrontend.ViewModels;
using System.Windows;

namespace licencjatFrontend.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel(); 
        }
    }
}
