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
        private bool _isEditing;
        private bool _isEditingCancelled;
        private bool _isAdding;

        #region Residential variables
        private double _gardenSize;
        private double _residentialArea;
        private double _salesValue;
        private double _rent;
        private int _numberOfRooms;
        private int _floorLevel;
        private bool _isDetached;
        private bool _hasBalcony;
        private bool _isVilla;
        private bool _isRentalApartment;
        private bool _isResident;
        private bool _isTenementApartment;
        private bool _isTownHouse;
        private bool _isApartment;
        #endregion

        #region institution variables
        private InstitutionType _institutionType;
        private SchoolType _schoolType;
        private int _numberOfStaff;
        private int _numberOfFaculties;
        private bool _hasEmergencyDepartment;
        private bool _isHospital;
        private bool _isSchool;
        private bool _isUniversity;
        #endregion

        #region commercial variables
        private double _propertySize;
        private double _retailArea;
        private double _storageArea;
        private FactoryType _factoryType;
        private int _numberOfHotelRooms;
        private bool _isFactory;
        private bool _isHotel;
        private bool _isShop;
        private bool _isWarehouse;
        #endregion

        public AsyncCommand AddEstate { get; private set; }
        public Command RemoveEstate { get; private set; }
        public AsyncCommand EditEstate { get; private set; }
        public Command FinishEditEstate { get; private set; }
        public Command CancelEdit { get; private set; }

        #region Base Properties
        public ObservableCollection<Estate> Estates { get { return _estates; } set { if (_estates != value) { _estates = value; OnPropertyChanged(nameof(Estates)); } } }
        public Estate SelectedEstate { get { return _selectedEstate; } set { if (_selectedEstate != value) { _selectedEstate = value; OnPropertyChanged(nameof(SelectedEstate)); } } }
        public Estate CurrentEstate { get { return _currentEstate; } set { if (_currentEstate != value) { _currentEstate = value; OnPropertyChanged(nameof(CurrentEstate)); } } }
        public List<EstateTypes> Types { get { return _types; } set { if (_types != value) { _types = value; OnPropertyChanged(nameof(Types)); } } }
        public EstateTypes SelectedType { get { return _selectedType; } set { if (_selectedType != value) { _selectedType = value; OnPropertyChanged(nameof(SelectedType)); } } }
        public List<LegalForm> LegalForms { get { return _legalforms; } set { if (_legalforms != value) { _legalforms = value; OnPropertyChanged(nameof(LegalForms)); } } }
        public LegalForm SelectedLegalForm { get { return _form; } set { if (_form != value) { _form = value; OnPropertyChanged(nameof(SelectedLegalForm)); CheckRentalOrTenement(); } } }
        public string Address { get { return _address; } set { if (_address != value) { _address = value; OnPropertyChanged(nameof(Address)); } } }
        #endregion

        #region residential properties
        public double GardenSize { get { return _gardenSize; } set { if (_gardenSize != value) { _gardenSize = value; OnPropertyChanged(nameof(GardenSize)); } } }
        public double ResidentialArea { get { return _residentialArea; } set { if (_residentialArea != value) { _residentialArea = value; OnPropertyChanged(nameof(ResidentialArea)); } } }
        public int NumberOfRooms { get { return _numberOfRooms; } set { if (_numberOfRooms != value) { _numberOfRooms = value; OnPropertyChanged(nameof(NumberOfRooms)); } } }
        public int FloorLevel { get { return _floorLevel; } set { if (_floorLevel != value) { _floorLevel = value; OnPropertyChanged(nameof(FloorLevel)); } } }
        public bool IsDetached { get { return _isDetached; } set { if (_isDetached != value) { _isDetached = value; OnPropertyChanged(nameof(IsDetached)); } } }
        public bool HasBalcony { get { return _hasBalcony; } set { if (_hasBalcony != value) { _hasBalcony = value; OnPropertyChanged(nameof(HasBalcony)); } } }
        public double SalesValue { get { return _salesValue; } set { if (_salesValue != value) { _salesValue = value; OnPropertyChanged(nameof(SalesValue)); } } }
        public double Rent { get { return _rent; } set { if (_rent != value) { _rent = value; OnPropertyChanged(nameof(Rent)); } } }
        
        #endregion

        #region institutional properties
        public InstitutionType InstitutionType { get { return _institutionType; } set { if (_institutionType != value) { _institutionType = value; OnPropertyChanged(nameof(InstitutionType)); } } }
        public SchoolType SchoolType { get { return _schoolType; } set { if (_schoolType != value) { _schoolType = value; OnPropertyChanged(nameof(SchoolType)); } } }
        public int NumberOfStaff { get { return _numberOfStaff; } set { if (_numberOfStaff != value) { _numberOfStaff = value; OnPropertyChanged(nameof(NumberOfStaff)); } } }
        public int NumberOfFacs { get { return _numberOfFaculties; } set { if (_numberOfFaculties != value) { _numberOfFaculties = value; OnPropertyChanged(nameof(NumberOfFacs)); } } }
        public bool HasEmergencyDept { get { return _hasEmergencyDepartment; } set { if (_hasEmergencyDepartment != value) { _hasEmergencyDepartment = value; OnPropertyChanged(nameof(HasEmergencyDept)); } } }

        #endregion

        #region commercial properties
        public double PropertySize { get { return _propertySize; } set { if (_propertySize != value) { _propertySize = value; OnPropertyChanged(nameof(PropertySize)); } } }
        public double RetailArea { get { return _retailArea; } set { if (_retailArea != value) { _retailArea = value; OnPropertyChanged(nameof(RetailArea)); } } }
        public double StorageArea { get { return _storageArea; } set { if (_storageArea != value) { _storageArea = value; OnPropertyChanged(nameof(StorageArea)); } } }
        public FactoryType FactoryType { get { return _factoryType; } set { if (_factoryType != value) { _factoryType = value; OnPropertyChanged(nameof(FactoryType)); } } }
        public int NumberOfHotelRooms { get { return _numberOfHotelRooms; } set { if (_numberOfHotelRooms != value) { _numberOfHotelRooms = value; OnPropertyChanged(nameof(NumberOfHotelRooms)); } } }
        #endregion

        #region Visibility properties
        public bool IsResident { get { return _isResident; } set { if (_isResident != value) { _isResident = value; OnPropertyChanged(nameof(IsResident)); } } }
        public bool IsVilla { get { return _isVilla; } set { if (_isVilla != value) { _isVilla = value; OnPropertyChanged(nameof(IsVilla)); } } }
        public bool IsApartment { get { return _isApartment; } set { if (_isApartment != value) { _isApartment = value; OnPropertyChanged(nameof(IsApartment)); } } }
        public bool IsRentalApartment { get { return _isRentalApartment; } set { if (_isRentalApartment != value) { _isRentalApartment = value; OnPropertyChanged(nameof(IsRentalApartment)); } } }
        public bool IsTenementApartment { get { return _isTenementApartment; } set { if (_isTenementApartment != value) { _isTenementApartment = value; OnPropertyChanged(nameof(IsTenementApartment)); } } }
        public bool IsTownHouse { get { return _isTownHouse; } set { if (_isTownHouse != value) { _isTownHouse = value; OnPropertyChanged(nameof(IsTownHouse)); } } }
        public bool IsSchool { get { return _isSchool; } set { if (_isSchool != value) { _isSchool = value; OnPropertyChanged(nameof(IsSchool)); } } }
        public bool IsUniversity { get { return _isUniversity; } set { if (_isUniversity != value) { _isUniversity = value; OnPropertyChanged(nameof(IsUniversity)); } } }
        public bool IsHospital { get { return _isHospital; } set { if (_isHospital != value) { _isHospital = value; OnPropertyChanged(nameof(IsHospital)); } } }
        public bool IsFactory { get { return _isFactory; } set { if (_isFactory != value) { _isFactory = value; OnPropertyChanged(nameof(IsFactory)); } } }
        public bool IsShop { get { return _isShop; } set { if (_isShop != value) { _isShop = value; OnPropertyChanged(nameof(IsShop)); } } }
        public bool IsHotel { get { return _isHotel; } set { if (_isHotel != value) { _isHotel = value; OnPropertyChanged(nameof(IsHotel)); } } }
        public bool IsWarehouse { get { return _isWarehouse; } set { if (_isWarehouse != value) { _isWarehouse = value; OnPropertyChanged(nameof(IsWarehouse)); } } }
        #endregion

        #region editing boolean properties
        public bool IsEditing { get { return _isEditing; } set { if (_isEditing != value) { _isEditing = value; OnPropertyChanged(nameof(IsEditing)); } } }
        public bool IsEditingCancelled { get { return _isEditingCancelled; } set { if (_isEditingCancelled != value) { _isEditingCancelled = value; OnPropertyChanged(nameof(IsEditingCancelled)); } } }
        public bool IsAdding { get { return _isAdding; } set { if (_isAdding != value) { _isAdding = value; OnPropertyChanged(nameof(IsAdding)); } } }
        #endregion

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
                        NotCommercial();
                        NotInstitutional();
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
                        NotCommercial();
                        NotInstitutional();
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
                        NotCommercial();
                        NotInstitutional();
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

                    else if (SelectedType == EstateTypes.Hotel)
                    {
                        NotResidential();
                        NotInstitutional();

                        _currentEstate = new Hotel(PropertySize, NumberOfHotelRooms);

                    }

                    else if (SelectedType == EstateTypes.Shop)
                    {
                        NotResidential();
                        NotInstitutional();

                        _currentEstate = new Shop(PropertySize, RetailArea);
                    }

                    else if (SelectedType == EstateTypes.Warehouse)
                    {
                        NotResidential();
                        NotInstitutional();

                        _currentEstate = new Warehouse(PropertySize, StorageArea);
                    }

                    else if (SelectedType == EstateTypes.Factory)
                    {
                        NotResidential();
                        NotInstitutional();

                        _currentEstate = new Factory(PropertySize, FactoryType);
                    }

                    else if (SelectedType == EstateTypes.Hospital)
                    {
                        NotResidential();
                        NotCommercial();

                        _currentEstate = new Hospital(InstitutionType, NumberOfStaff, HasEmergencyDept);
                    }

                    else if (SelectedType == EstateTypes.School)
                    {
                        NotResidential();
                        NotCommercial();

                        _currentEstate = new School(InstitutionType, NumberOfStaff, SchoolType);
                    }

                    else if (SelectedType == EstateTypes.University)
                    {
                        NotResidential();
                        NotCommercial();

                        _currentEstate = new University(InstitutionType, NumberOfStaff, NumberOfFacs);
                    }
                }


                await Task.Delay(100, _tokenSource.Token);
            }

            OnPropertyChanged(nameof(Estates));
        }

        private void NotResidential()
        {
            IsResident = false;
            IsApartment = false;
            IsVilla = false;
            IsTownHouse = false;
        }

        private void NotCommercial()
        {

        }

        private void NotInstitutional()
        {

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
                _currentEstate.CreateId();  // Set the estate's ID
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
                        IsDetached = townhouse.IsDetached;
                    }
                }
            }

            else if (SelectedEstate is Institutional institutional)
            {
                InstitutionType = institutional.InstType;
                NumberOfStaff = institutional.NumberOfStaff;

                if (institutional is School school)
                {
                    SchoolType = school.Type;
                }

                else if (institutional is University university)
                {
                    NumberOfFacs = university.NumberOfFalculties;
                }

                else if (institutional is Hospital hospital)
                {
                    HasEmergencyDept = hospital.HasEmergencyDepartment;
                }
            }

            else if (SelectedEstate is Commercial commercial)
            {

                if (commercial is Factory factory)
                {
                    FactoryType = factory.FactoryType;
                }

                else if (commercial is Hotel hotel)
                {
                    NumberOfHotelRooms = hotel.NumberOfRooms;
                }

                else if (commercial is Shop shop)
                {
                    RetailArea = shop.RetailArea;
                }

                else if (commercial is Warehouse warehouse)
                {
                    StorageArea = warehouse.StorageArea;
                }
            }

            else
            {
                SelectedEstate = null;
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
