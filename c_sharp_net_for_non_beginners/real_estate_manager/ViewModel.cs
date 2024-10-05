using real_estate_manager.Enum;
using real_estate_manager.HelperClasses;
using System.Collections.ObjectModel;

namespace real_estate_manager
{
    public class ViewModel : NotifyPropertyChanged
    {
        private ObservableCollection<Estate> _estates;
        private Estate _selectedEstate;
        private Estate _currentEstate;
        private CancellationTokenSource _tokenSource;
        private List<EstateTypes> _types;
        private EstateTypes _selectedType;
        private LegalForm _form;
        private List<LegalForm> _legalforms;
        private string _address;

        private double _gardenSize;
        private double _residentialArea;
        private double _salesValue;
        private double _rent;
        private int _numberOfRooms;
        private int _floorLevel;
        private bool _isDetached;
        private bool _hasBalcony;

        private bool _isEditing;
        private bool _isEditingCancelled;
        private bool _isAdding;
        private bool _isVilla;
        private bool _isRentalApartment;
        private bool _isResident;
        private bool _isTenementApartment;
        private bool _isTownHouse;
        private bool _isApartment;

        public AsyncCommand AddEstate { get; private set; }
        public Command RemoveEstate { get; private set; }
        public AsyncCommand EditEstate { get; private set; }
        public Command FinishEditEstate { get; private set; }
        public Command CancelEdit { get; private set; }

        public ObservableCollection<Estate> Estates { get { return _estates; } set { if (_estates != value) { _estates = value; OnPropertyChanged(nameof(Estates)); } } }
        public Estate SelectedEstate { get { return _selectedEstate; } set { if (_selectedEstate != value) { _selectedEstate = value; OnPropertyChanged(nameof(SelectedEstate)); } } }
        public Estate CurrentEstate { get { return _currentEstate; } set { if (_currentEstate != value) { _currentEstate = value; OnPropertyChanged(nameof(CurrentEstate)); } } }
        public List<EstateTypes> Types { get { return _types; } set { if (_types != value) { _types = value; OnPropertyChanged(nameof(Types)); } } }
        public EstateTypes SelectedType { get { return _selectedType; } set { if (_selectedType != value) { _selectedType = value; OnPropertyChanged(nameof(SelectedType)); } } }
        public List<LegalForm> LegalForms { get { return _legalforms; } set { if (_legalforms != value) { _legalforms = value; OnPropertyChanged(nameof(LegalForms)); } } }
        public LegalForm SelectedLegalForm { get { return _form; } set { if (_form != value) { _form = value; OnPropertyChanged(nameof(SelectedLegalForm)); CheckRentalOrTenement(); } } }
        public string Address { get { return _address; } set { if (_address != value) { _address = value; OnPropertyChanged(nameof(Address)); } } }

        #region residential properties
        public double GardenSize { get { return _gardenSize; } set { if (_gardenSize != value) { _gardenSize = value; OnPropertyChanged(nameof(GardenSize)); } } }
        public double ResidentialArea { get { return _residentialArea; } set { if (_residentialArea != value) { _residentialArea = value; OnPropertyChanged(nameof(ResidentialArea)); } } }
        public int NumberOfRooms { get { return _numberOfRooms; } set { if (_numberOfRooms != value) { _numberOfRooms = value; OnPropertyChanged(nameof(NumberOfRooms)); } } }
        public int FloorLevel { get { return _floorLevel; } set { if (_floorLevel != value) { _floorLevel = value; OnPropertyChanged(nameof(FloorLevel)); } } }
        public bool IsDetached { get { return _isDetached; } set { if (_isDetached != value) { _isDetached = value; OnPropertyChanged(nameof(IsDetached)); } } }
        public bool HasBalcony { get { return _hasBalcony; } set { if (_hasBalcony != value) { _hasBalcony = value; OnPropertyChanged(nameof(HasBalcony)); } } }
        public double SalesValue { get { return _salesValue; } set { if (_salesValue != value) { _salesValue = value; OnPropertyChanged(nameof(SalesValue)); } } }
        public double Rent { get { return _rent; } set { if (_rent != value) { _rent = value; OnPropertyChanged(nameof(Rent)); } } }
        public bool IsResident { get { return _isResident; } set { if (_isResident != value) { _isResident = value; OnPropertyChanged(nameof(IsResident)); } } }
        public bool IsVilla { get { return _isVilla; } set { if (_isVilla != value) { _isVilla = value; OnPropertyChanged(nameof(IsVilla)); } } }
        public bool IsApartment { get { return _isApartment; } set { if (_isApartment != value) { _isApartment = value; OnPropertyChanged(nameof(IsApartment)); } } }
        public bool IsRentalApartment { get { return _isRentalApartment; } set { if (_isRentalApartment != value) { _isRentalApartment = value; OnPropertyChanged(nameof(IsRentalApartment)); } } }
        public bool IsTenementApartment { get { return _isTenementApartment; } set { if (_isTenementApartment != value) { _isTenementApartment = value; OnPropertyChanged(nameof(IsTenementApartment)); } } }
        public bool IsTownHouse { get { return _isTownHouse; } set { if (_isTownHouse != value) { _isTownHouse = value; OnPropertyChanged(nameof(IsTownHouse)); } } }
        #endregion

        public bool IsEditing { get { return _isEditing; } set { if (_isEditing != value) { _isEditing = value; OnPropertyChanged(nameof(IsEditing)); } } }
        public bool IsEditingCancelled { get { return _isEditingCancelled; } set { if (_isEditingCancelled != value) { _isEditingCancelled = value; OnPropertyChanged(nameof(IsEditingCancelled)); } } }
        public bool IsAdding { get { return _isAdding; } set { if (_isAdding != value) { _isAdding = value; OnPropertyChanged(nameof(IsAdding)); } } }


        public ViewModel()
        {
            Types = EstateTypes.GetValues(typeof(EstateTypes)).Cast<EstateTypes>().ToList();
            LegalForms = LegalForm.GetValues(typeof(LegalForm)).Cast<LegalForm>().ToList();
            Types.Sort();
            LegalForms.Sort();

            SelectedType = Types[0];
            SelectedLegalForm = LegalForms[0];
            Estates = new ObservableCollection<Estate>();
            IsEditing = false;
            IsEditingCancelled = false;

            Address = string.Empty;
            IsVilla = false;
            IsDetached = false;
            IsRentalApartment = false;
            IsResident = false;
            IsApartment = false;
            IsTenementApartment = false;
            IsTownHouse = false;
            HasBalcony = false;
            Rent = 0;
            SalesValue = 0;
            GardenSize = 0;
            FloorLevel = 0;
            ResidentialArea = 0;
            NumberOfRooms = 0;

            AddEstate = new AsyncCommand(AddNewEstate, CanAddEstate);
            RemoveEstate = new Command(RemoveCurrentEstate, CanRemoveEstate);
            EditEstate = new AsyncCommand(EditSelectedEstate, CanEditestate);
            FinishEditEstate = new Command(FinishEditing, CanFinishEditing);
            CancelEdit = new Command(CancelEditingState, CanCancel);
        }

        private bool CanCancel()
        {
            return true;
        }

        private void CancelEditingState()
        {
            IsEditing = false;
            ResetInput();
        }

        private bool CanAddEstate()
        {
            return true;
        }

        public bool CanRemoveEstate()
        {
            if (SelectedEstate == null)
                return false;
            return true;
        }

        private bool CanEditestate()
        {
            if (CanRemoveEstate() && IsEditing == false)
            {
                return true;
            }
            return false;
        }

        private bool CanFinishEditing()
        {
            return true;
        }

        private async Task AddNewEstate()
        {
            CurrentEstate = null;
            await AddCurrentOrNewEstate();
        }

        private async Task AddCurrentOrNewEstate()
        {
            IsEditing = true;
            _tokenSource = new CancellationTokenSource();

            while (IsEditing)
            {
                if (_tokenSource.IsCancellationRequested)
                {
                    IsEditing = false;
                    break;
                }

                if (Types != null)
                {
                    if (SelectedType == EstateTypes.Villa)
                    {
                        IsResident = true;
                        IsVilla = true;
                        IsTownHouse = false;
                        IsApartment = false;
                        IsTenementApartment = false;
                        IsRentalApartment = false;

                        _currentEstate = new Villa(ResidentialArea, NumberOfRooms, GardenSize);

                    }

                    else if (SelectedType == EstateTypes.Townhouse)
                    {
                        IsResident = true;
                        IsTownHouse = true;
                        IsVilla = true;
                        IsApartment = false;
                        IsTenementApartment = false;
                        IsRentalApartment = false;

                        _currentEstate = new Townhouse(ResidentialArea, NumberOfRooms, GardenSize, IsDetached);
                    }

                    else if (SelectedType == EstateTypes.Apartment)
                    {
                        IsResident = true;
                        IsApartment = true;
                        IsVilla = false;
                        IsTownHouse = false;

                        if (SelectedLegalForm == LegalForm.Rental)
                        {
                            _currentEstate = new Rental(ResidentialArea, NumberOfRooms, FloorLevel, HasBalcony, Rent);
                        }

                        else if (SelectedLegalForm == LegalForm.Tenement)
                        {
                            _currentEstate = new Tenement(ResidentialArea, NumberOfRooms, FloorLevel, HasBalcony, SalesValue);
                        }

                        else
                        {
                            _currentEstate = new Apartment(ResidentialArea, NumberOfRooms, FloorLevel, HasBalcony);
                        }
                    }
                }

                await Task.Delay(100, _tokenSource.Token);
            }

            OnPropertyChanged(nameof(Estates));
        }

        private void RemoveCurrentEstate()
        {
            if (SelectedEstate == null)
                return;
            else
            {
                _estates.Remove(SelectedEstate);
                OnPropertyChanged(nameof(SelectedEstate));
                OnPropertyChanged(nameof(Estates));
            }
        }

        private async Task EditSelectedEstate()
        {
            _currentEstate = SelectedEstate;
            SetExistingInputValues();
            OnPropertyChanged(nameof(CurrentEstate));

            await AddCurrentOrNewEstate();
        }

        private void FinishEditing()
        {
            IsEditing = false;
            IsApartment = false;
            IsResident = false;
            IsVilla = false;
            IsTownHouse = false;

            if (_currentEstate != null)
            {
                _currentEstate.Address = Address;
                _currentEstate.LegalForm = SelectedLegalForm;
                _currentEstate.EstateType = SelectedType;
                _currentEstate.Id = Estates.IndexOf(_currentEstate);  // Set the estate's ID
                Estates.Add(_currentEstate);
                OnPropertyChanged(nameof(Estates));  // Ensure the collection is updated in the UI
            }

            else
            {
                _currentEstate = null;
            }

            ResetInput();

        }

        private void CheckRentalOrTenement()
        {

            if (SelectedLegalForm == LegalForm.Tenement && SelectedType == EstateTypes.Apartment)
            {
                IsTenementApartment = true;
                IsRentalApartment = false;
            }

            else if (SelectedLegalForm == LegalForm.Rental && SelectedType == EstateTypes.Apartment)
            {
                IsRentalApartment = true;
                IsTenementApartment = false;
            }

            else
            {
                IsRentalApartment = false;
                IsTenementApartment = false;
            }

        }

        private void SetExistingInputValues()
        {
            Address = SelectedEstate.Address;
            SelectedLegalForm = SelectedEstate.LegalForm;
            SelectedType = SelectedEstate.EstateType;

            if (SelectedEstate is Residential residential)
            {
                ResidentialArea = residential.ResidentialArea;
                NumberOfRooms = residential.NumberOfRooms;

                if (SelectedEstate is Apartment selectedApartment)
                {
                    HasBalcony = selectedApartment.HasBalcony;
                    FloorLevel = selectedApartment.FloorLevel;

                    if (selectedApartment is Rental rentalApartment)
                    {
                        Rent = rentalApartment.Rent;
                    }


                    else if (selectedApartment is Tenement tenementApartment)
                    {
                        SalesValue = tenementApartment.SalesValue;
                    }

                }

                else if (residential is Villa villa)
                {
                    GardenSize = villa.GardenSize;

                     if (villa is Townhouse townhouse)
                    {
                        IsDetached=townhouse.IsDetached;
                    }
                }
            }

            else if (SelectedEstate is Institutional institutional)
            {

            }

            else if (SelectedEstate.EstateType == EstateTypes.School)
            {

            }

            else if (SelectedEstate.EstateType == EstateTypes.University)
            {

            }

            else if (SelectedEstate.EstateType == EstateTypes.Factory)
            {

            }

            else if (SelectedEstate.EstateType == EstateTypes.Hotel)
            {

            }

            else if (SelectedEstate.EstateType == EstateTypes.Shop)
            {

            }

            else if (SelectedEstate.EstateType == EstateTypes.Warehouse)
            {

            }

            else
            {

            }

        }

        private void ResetInput()
        {
            Address = string.Empty;
            IsVilla = false;
            IsDetached = false;
            IsRentalApartment = false;
            IsResident = false;
            IsApartment = false;
            IsTenementApartment = false;
            IsTownHouse = false;
            HasBalcony = false;
            Rent = 0;
            SalesValue = 0;
            GardenSize = 0;
            FloorLevel = 0;
            ResidentialArea = 0;
            NumberOfRooms = 0;
        }
    }
}
