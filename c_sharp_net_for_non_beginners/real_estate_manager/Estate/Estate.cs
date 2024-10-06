using real_estate_manager.Enum;
using real_estate_manager.HelperClasses;
using System.ComponentModel;
using System.Windows.Media.Imaging;

namespace real_estate_manager
{
    /// <summary>
    /// Abstract class for estate objects inheriting from the interface
    /// </summary>
    public abstract class Estate : NotifyPropertyChanged, IEstate
    {
        private int _id;
        private EstateTypes _estateType;
        private Address _estateAddress;
        private LegalForm _legalForm;
        private BitmapImage _estateImage;

        public int Id { get => _id; set { if (_id != value) { _id = value; OnPropertyChanged(nameof(Id)); } } }
        public EstateTypes EstateType { get => _estateType; set { if (_estateType != value) { _estateType = value; OnPropertyChanged(nameof(EstateType)); } } }
        public Address EstateAddress { get => _estateAddress; set { if (_estateAddress != value) { _estateAddress = value; OnPropertyChanged(nameof(EstateAddress)); } } }
        public LegalForm LegalForm { get => _legalForm; set { if (_legalForm != value) { _legalForm = value; OnPropertyChanged(nameof(LegalForm)); } } }
        public BitmapImage EstateImage{get => _estateImage; set{if (_estateImage != value){ _estateImage = value;OnPropertyChanged(nameof(EstateImage));}}}

        /// <summary>
        /// A method for creating a unique Id 
        /// </summary>
        public virtual void CreateId(List<Estate> estates)
        {
            if (estates == null || estates.Count == 0)
            {
                Id = 1;
                return;
            }

            HashSet<int> existingIds = new HashSet<int>(estates.Select(e => e.Id));

            int newId = 1;

            while (existingIds.Contains(newId))
            {
                newId++;
            }

            Id = newId;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}