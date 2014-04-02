using System.Windows;

namespace ExtractMe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MyButton_Click(object sender, RoutedEventArgs e)
        {
            ((MyViewModel) DataContext).Footer = MyTextBox.Text;
            FirstContentControl.Content = MyTextBox.Text;
        }
    }
}
