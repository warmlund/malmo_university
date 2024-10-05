using System.Windows;
using System.Windows.Controls;

namespace real_estate_manager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ViewModel _viewModel;
        public MainWindow()
        {
            _viewModel = new ViewModel();
            DataContext = _viewModel;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var dataGrid = sender as DataGrid;

            // Get the selected item (of type Estate, or whatever your data type is)
            var selectedEstate = dataGrid.SelectedItem as Estate;

            // Set it in the ViewModel
            if (selectedEstate != null)
            {
                _viewModel.SelectedEstate = selectedEstate;
                _viewModel.EditEstate.RaiseCanExecuteChanged();
                _viewModel.RemoveEstate.RaiseCanExecuteChanged();
            }
        }
    }
}