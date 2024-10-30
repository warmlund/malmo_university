using RealEstateBLL;
using RealEstateDTO;
using RealEstatePL;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
            var realEstateBLL = new REstateBLL();
            _viewModel = new ViewModel(realEstateBLL); //create instance of viewmodel
            DataContext = _viewModel; //set datacontext to viewmodel
            InitializeComponent();
        }

        /// <summary>
        /// An eventhandler for checking if the selection in the datagridview has changed
        /// </summary>
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var dataGrid = sender as DataGrid;

            var selectedEstate = dataGrid.SelectedItem as Estate;
            int selectedIndex = dataGrid.SelectedIndex;

            if (selectedIndex != -1)
            {
                _viewModel.SelectedIndex = selectedIndex;
            }

            if (selectedEstate != null)
            {
                _viewModel.SelectedEstate = selectedEstate;
                _viewModel.EditEstate.RaiseCanExecuteChanged();
                _viewModel.RemoveEstate.RaiseCanExecuteChanged();
                _viewModel.ReplaceEstate.RaiseCanExecuteChanged();
            }
        }

        /// <summary>
        /// An eventhandler that only accepts whole or decimal values
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EnableOnlyDoubles(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            var currentText = textBox.Text;

            foreach (var ch in e.Text)
            {
                // Check if the character is not a digit and is not a dot
                if (!char.IsDigit(ch) && ch != '.' && char.IsWhiteSpace(ch))
                {
                    e.Handled = true;
                    return;
                }

                // Prevent more than one dot in the text
                if (ch == '.' && currentText.Contains("."))
                {
                    e.Handled = true;
                    return;
                }
            }
        }
        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            // Prevent space key press
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }
    }
}