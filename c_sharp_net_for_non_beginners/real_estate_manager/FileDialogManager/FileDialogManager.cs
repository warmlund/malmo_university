namespace RealEstatePL.FileDialogManager
{
    /// <summary>
    /// An abstract class for handling filedialogs
    /// Implements the IFileDialogManager interface
    /// </summary>
    public abstract class FileDialogManager : IFileDialogManager
    {
        //Properties 
        public string Title { get; protected set; }
        public string FilePath { get; protected set; }
        public string Extension { get; protected set; }
        public string[] SelectedFiles { get; protected set; }

        //Filters for what files should be able to be opened
        public string EstateFilter { get; protected set; } = "JSON Files (*.json)|*.json";

        /// <summary>
        /// Shows file dialog, returns true if successful
        /// </summary>
        /// <returns></returns>
        public abstract bool ShowDialog();

        /// <summary>
        /// Alerts user if something went wrong
        /// </summary>
        public abstract void AlertUser();

    }
}
