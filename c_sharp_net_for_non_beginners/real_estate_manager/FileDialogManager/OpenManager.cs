using Microsoft.Win32;
using System.Windows;

namespace RealEstatePL.FileDialogManager
{
    /// <summary>
    /// A class implementing the abstract class FileDialogManager
    /// Used for opening files or playlists
    /// </summary>
    internal class OpenManager : FileDialogManager
    {
        private OpenFileDialog _openFile;

        /// <summary>
        /// Constructor for OpenManager
        /// </summary>
        /// <param name="title">title of the OpenFileDialog</param>
        public OpenManager(string title)
        {
            _openFile = new OpenFileDialog();
            Title = title;
        }

        /// <summary>
        /// Displays the file dialog for opening file or playlist
        /// </summary>
        public override bool ShowDialog()
        {
            _openFile.Title = Title; //Sets the title
            _openFile.Multiselect = true; //set to true so user can select multiple media
            _openFile.Filter = EstateFilter; //Set filter to media filter

            bool result = _openFile.ShowDialog() == true; //show the dialog

            if (result) //if successful
            {
                SelectedFiles = _openFile.FileNames; //store the selected files
            }
            return result;
        }

        public override void AlertUser()
        {
            MessageBox.Show("Failed to load", "Real Estate Manager", MessageBoxButton.OK); //If something fails with the loading, the user is alerted
        }
    }
}