using System.ComponentModel;
using System.Windows;

namespace CH04.NotificationPropertiesDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public string Department => "Software Engineering";

        private string personName;

        public string PersonName
        {
            get => personName;
            set { personName = value; OnPropertyChanged("PersonName"); }
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

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            //in C# 7.0 and above
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

            //prior to C# 7.0
            //var handler = PropertyChanged;
            //if (handler != null)
            //{
            //    handler(this, new PropertyChangedEventArgs(propertyName));
            //}
        }
    }
}