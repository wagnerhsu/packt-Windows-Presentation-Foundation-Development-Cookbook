using NLog;
using System.Windows;

namespace CH04.DependencyPropertyDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static ILogger Logger = LogManager.GetCurrentClassLogger();
        public string Department => "Software Engineering";

        public string PersonName
        {
            get { return (string)GetValue(PersonNameProperty); }
            set { SetValue(PersonNameProperty, value); }
        }

        public static readonly DependencyProperty PersonNameProperty =
            DependencyProperty.Register("PersonName", typeof(string), typeof(MainWindow), new PropertyMetadata(string.Empty,OnPropertyChangedCallback));

        private static void OnPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Logger.Info(d.GetValue(PersonNameProperty));
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnSubmit(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hello " + PersonName);
        }

        private void OnReset(object sender, RoutedEventArgs e)
        {
            PersonName = string.Empty;
        }
    }
}