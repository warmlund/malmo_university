﻿namespace RealEstatePL.FileDialogManager
{

    /// <summary>
    /// Interface for filedialog management
    /// </summary>
    public interface IFileDialogManager
    {
        bool ShowDialog();
        void AlertUser();
        string FilePath { get; }
        string Extension { get; }
        string EstateFilter { get; }
        string[] SelectedFiles { get; }
    }
}
