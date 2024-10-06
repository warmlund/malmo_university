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

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var dataGrid = sender as DataGrid;

            var selectedEstate = dataGrid.SelectedItem as Estate;

            if (selectedEstate != null)
            {
                _viewModel.SelectedEstate = selectedEstate;
                _viewModel.EditEstate.RaiseCanExecuteChanged();
                _viewModel.RemoveEstate.RaiseCanExecuteChanged();
            }
        }

        private void EnableOnlyIntegers(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            foreach (var ch in e.Text)
            {
                if (!char.IsDigit(ch))
                {
                    e.Handled = true;
                    return;
                }
            }
        }

        private void EnableOnlyDoubles(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            foreach (var ch in e.Text)
            {
                if (!char.IsDigit(ch) && ch != '.')
                {
                    e.Handled = true;
                    return;
                }
            }
        }
    }
}