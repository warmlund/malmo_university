using Microsoft.Win32;
using RealEstateBLL;
using RealEstateDTO;
using RealEstatePL.Commands;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media.Imaging;

namespace RealEstatePL
{
    public class ViewModel : NotifyPropertyChanged
    {
        #region Base variables
        private ObservableCollection<Estate> _estates;
        private Estate _selectedEstate;
        private Estate _currentEstate;
        private CancellationTokenSource _tokenSource;
        private List<EstateTypes> _types;
        private EstateTypes _selectedType;
        private LegalForm _form;
        private List<LegalForm> _legalforms;
        private string _street;
        private string _city;
        private Country _country;
        private List<Country> _countries;
        private int _zipcode;
        private int _selectedIndex;
        private BitmapImage _image;
        private bool _isEditing;
        private bool _isEditingCancelled;
        private bool _isAdding;
        private IREstateBLL _realEstateBLL;
        #endregion

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
        private List<InstitutionType> _institutionTypes;
        private SchoolType _schoolType;
        private List<SchoolType> _schoolTypes;
        private int _numberOfStaff;
        private int _numberOfFaculties;
        private bool _hasEmergencyDepartment;
        private bool _isHospital;
        private bool _isSchool;
        private bool _isUniversity;
        private bool _isInst;
        #endregion

        #region commercial variables
        private double _propertySize;
        private double _retailArea;
        private double _storageArea;
        private FactoryType _factoryType;
        private List<FactoryType> _facTypes;
        private int _numberOfHotelRooms;
        private bool _isFactory;
        private bool _isHotel;
        private bool _isShop;
        private bool _isWarehouse;
        private bool _isCom;
        #endregion

        #region command variables
        public AsyncCommand AddEstate { get; private set; }
        public Command RemoveEstate { get; private set; }
        public AsyncCommand ReplaceEstate { get; private set; }
        public AsyncCommand EditEstate { get; private set; }
        public Command FinishEditEstate { get; private set; }
        public Command CancelEdit { get; private set; }
        public Command LoadImage { get; private set; }
        #endregion

        #region Base Properties
        public ObservableCollection<Estate> Estates { get { return _estates; } set { if (_estates != value) { _estates = value; OnPropertyChanged(nameof(Estates)); } } }
        public Estate SelectedEstate { get { return _selectedEstate; } set { if (_selectedEstate != value) { _selectedEstate = value; OnPropertyChanged(nameof(SelectedEstate)); } } }
        public int SelectedIndex { get { return _selectedIndex; } set { if (_selectedIndex != value) { _selectedIndex = value; OnPropertyChanged(nameof(SelectedIndex)); } } }
        public Estate CurrentEstate { get { return _currentEstate; } set { if (_currentEstate != value) { _currentEstate = value; OnPropertyChanged(nameof(CurrentEstate)); } } }
        public List<EstateTypes> Types { get { return _types; } set { if (_types != value) { _types = value; OnPropertyChanged(nameof(Types)); } } }
        public EstateTypes SelectedType { get { return _selectedType; } set { if (_selectedType != value) { _selectedType = value; OnPropertyChanged(nameof(SelectedType)); } } }
        public List<LegalForm> LegalForms { get { return _legalforms; } set { if (_legalforms != value) { _legalforms = value; OnPropertyChanged(nameof(LegalForms)); } } }
        public LegalForm SelectedLegalForm { get { return _form; } set { if (_form != value) { _form = value; OnPropertyChanged(nameof(SelectedLegalForm)); CheckRentalOrTenement(); } } }
        public BitmapImage EstateImage { get { return _image; } set { if (_image != value) { _image = value; OnPropertyChanged(nameof(EstateImage)); } } }
        public string City { get { return _city; } set { if (_city != value) { _city = value; OnPropertyChanged(nameof(City)); } } }
        public string Street { get { return _street; } set { if (_street != value) { _street = value; OnPropertyChanged(nameof(Street)); } } }
        public int ZipCode { get { return _zipcode; } set { if (_zipcode != value) { _zipcode = value; OnPropertyChanged(nameof(ZipCode)); } } }
        public Country SelectedCountry { get { return _country; } set { if (_country != value) { _country = value; OnPropertyChanged(nameof(SelectedCountry)); } } }
        public List<Country> Countries { get { return _countries; } set { if (_countries != value) { _countries = value; OnPropertyChanged(nameof(Countries)); } } }

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
        public InstitutionType SelectedInstitutionType { get { return _institutionType; } set { if (_institutionType != value) { _institutionType = value; OnPropertyChanged(nameof(SelectedInstitutionType)); } } }
        public List<InstitutionType> InstitutionTypes { get { return _institutionTypes; } set { if (_institutionTypes != value) { _institutionTypes = value; OnPropertyChanged(nameof(InstitutionTypes)); } } }
        public SchoolType SelectedSchoolType { get { return _schoolType; } set { if (_schoolType != value) { _schoolType = value; OnPropertyChanged(nameof(SelectedSchoolType)); } } }
        public List<SchoolType> SchoolTypes { get { return _schoolTypes; } set { if (_schoolTypes != value) { _schoolTypes = value; OnPropertyChanged(nameof(SchoolTypes)); } } }
        public int NumberOfStaff { get { return _numberOfStaff; } set { if (_numberOfStaff != value) { _numberOfStaff = value; OnPropertyChanged(nameof(NumberOfStaff)); } } }
        public int NumberOfFacs { get { return _numberOfFaculties; } set { if (_numberOfFaculties != value) { _numberOfFaculties = value; OnPropertyChanged(nameof(NumberOfFacs)); } } }
        public bool HasEmergencyDept { get { return _hasEmergencyDepartment; } set { if (_hasEmergencyDepartment != value) { _hasEmergencyDepartment = value; OnPropertyChanged(nameof(HasEmergencyDept)); } } }

        #endregion

        #region commercial properties
        public double PropertySize { get { return _propertySize; } set { if (_propertySize != value) { _propertySize = value; OnPropertyChanged(nameof(PropertySize)); } } }
        public double RetailArea { get { return _retailArea; } set { if (_retailArea != value) { _retailArea = value; OnPropertyChanged(nameof(RetailArea)); } } }
        public double StorageArea { get { return _storageArea; } set { if (_storageArea != value) { _storageArea = value; OnPropertyChanged(nameof(StorageArea)); } } }
        public FactoryType SelectedFactoryType { get { return _factoryType; } set { if (_factoryType != value) { _factoryType = value; OnPropertyChanged(nameof(SelectedFactoryType)); } } }
        public List<FactoryType> FactoryTypes { get { return _facTypes; } set { if (_facTypes != value) { _facTypes = value; OnPropertyChanged(nameof(FactoryTypes)); } } }
        public int NumberOfHotelRooms { get { return _numberOfHotelRooms; } set { if (_numberOfHotelRooms != value) { _numberOfHotelRooms = value; OnPropertyChanged(nameof(NumberOfHotelRooms)); } } }
        #endregion

        #region Visibility properties
        public bool IsResident { get { return _isResident; } set { if (_isResident != value) { _isResident = value; OnPropertyChanged(nameof(IsResident)); } } }
        public bool IsCommercial { get { return _isCom; } set { if (_isCom != value) { _isCom = value; OnPropertyChanged(nameof(IsCommercial)); } } }
        public bool IsInstitutional { get { return _isInst; } set { if (_isInst != value) { _isInst = value; OnPropertyChanged(nameof(IsInstitutional)); } } }
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
        public bool IsEditing { get { return _isEditing; } set { if (_isEditing != value) { _isEditing = value; OnPropertyChanged(nameof(IsEditing)); LoadImage.RaiseCanExecuteChanged(); } } }
        public bool IsAdding { get { return _isAdding; } set { if (_isAdding != value) { _isAdding = value; OnPropertyChanged(nameof(IsAdding)); } } }
        #endregion

        public ViewModel(IREstateBLL realEstateBLL)
        {
            _realEstateBLL = realEstateBLL;
            //set values for the paroperties bound to comboboxes with respecitve enums
            Types = Enum.GetValues(typeof(EstateTypes)).Cast<EstateTypes>().ToList();
            LegalForms = Enum.GetValues(typeof(LegalForm)).Cast<LegalForm>().ToList();
            FactoryTypes = Enum.GetValues(typeof(FactoryType)).Cast<FactoryType>().ToList();
            SchoolTypes = Enum.GetValues(typeof(SchoolType)).Cast<SchoolType>().ToList();
            InstitutionTypes = Enum.GetValues(typeof(InstitutionType)).Cast<InstitutionType>().ToList();
            Countries = Enum.GetValues(typeof(Country)).Cast<Country>().ToList();

            Street = string.Empty; //set street value to emtpy
            City = string.Empty; //set city value to empty
            EstateImage = null; //set image to null
            IsEditing = false; //set editing to false
            IsAdding = false; //set adding to false

            NotCommercial(); //Setting all boolean values controlling the visibility of all controls for respective estate types to false
            NotInstitutional();
            NotResidential();

            //Creating commands for all buttons and setting moethods to each one
            AddEstate = new AsyncCommand(AddNewEstateAsync, CanAddEstate);
            RemoveEstate = new Command(RemoveCurrentEstate, CanRemoveOrEditEstate);
            EditEstate = new AsyncCommand(EditSelectedEstateAsync, CanRemoveOrEditEstate);
            FinishEditEstate = new Command(FinishEditing, CanFinishEditing);
            CancelEdit = new Command(CancelEditingState, CanCancel);
            LoadImage = new Command(LoadEstateImage, CanLoadImage);
            ReplaceEstate = new AsyncCommand(ReplaceSelectedEstateAsync, CanRemoveOrEditEstate);

            Estates = new ObservableCollection<Estate>(); //Create new observablecollection

        }

        /// <summary>
        /// setting that the cancel command always is enabled
        /// </summary>
        private bool CanCancel() => true;

        /// <summary>
        /// method executed when pressing the cancel button
        /// </summary>
        private void CancelEditingState()
        {
            IsAdding = false;
            IsEditing = false;
            Reset();
        }

        /// <summary>
        /// A method that checks if the user can add an estate or not
        /// </summary>
        private bool CanAddEstate()
        {
            if (IsEditing)
                return false;
            return true;
        }

        /// <summary>
        /// Checks if the user can remove or edit an estate
        /// </summary>
        public bool CanRemoveOrEditEstate()
        {
            if (SelectedEstate != null && IsEditing != true && Estates.Count > 0)
                return true;
            return false;
        }


        /// <summary>
        /// Loops through all selectable estate types and checks if the user has put in all values.
        /// If not, the command is disabled, else, the user can add or update the estate
        /// </summary>
        /// <returns></returns>
        private bool CanFinishEditing()
        {
            if (IsAddressFilled() && SelectedLegalForm != null && SelectedType != null && EstateImage != null)
            {
                if (SelectedType == EstateTypes.Villa || SelectedType == EstateTypes.Townhouse)
                {
                    if (ResidentialArea > 0 && NumberOfRooms > 0 && GardenSize >= 0)
                        return true;
                    return false;
                }

                else if (SelectedType == EstateTypes.Apartment)
                {

                    if (SelectedLegalForm == LegalForm.Rental)
                    {
                        if (ResidentialArea > 0 && NumberOfRooms > 0 && FloorLevel >= 0 && Rent >= 0)
                            return true;
                        return false;
                    }

                    else if (SelectedLegalForm == LegalForm.Tenement)
                    {
                        if (ResidentialArea > 0 && NumberOfRooms > 0 && FloorLevel >= 0 && SalesValue >= 0)
                            return true;
                        return false;
                    }

                    else
                    {
                        if (ResidentialArea > 0 && NumberOfRooms > 0 && FloorLevel >= 0)
                            return true;
                        return false;
                    }
                }

                else if (SelectedType == EstateTypes.Hotel)
                {
                    if (PropertySize > 0 && NumberOfHotelRooms > 0)
                        return true;
                    return false;

                }

                else if (SelectedType == EstateTypes.Shop)
                {
                    if (PropertySize > 0 && RetailArea > 0)
                        return true;
                    return false;
                }

                else if (SelectedType == EstateTypes.Warehouse)
                {
                    if (PropertySize > 0 && StorageArea > 0)
                        return true;
                    return false;
                }

                else if (SelectedType == EstateTypes.Factory)
                {
                    if (PropertySize > 0)
                        return true;
                    return false;
                }

                else if (SelectedType == EstateTypes.Hospital || SelectedType == EstateTypes.School)
                {
                    if (NumberOfStaff > 0)
                        return true;
                    return false;
                }

                else if (SelectedType == EstateTypes.University)
                {
                    if (NumberOfStaff > 0 && NumberOfFacs > 0)
                        return true;
                    return false;
                }

                else
                {
                    return false;
                }

            }

            else
            {
                return false;
            }
        }

        /// <summary>
        /// Checks if user can add an image or not
        /// </summary>
        /// <returns></returns>
        private bool CanLoadImage()
        {
            if (IsEditing == true)
                return true;
            return false;
        }

        /// <summary>
        /// A method for loading an image for the estate while adding or editing
        /// Uses an openfiledialog
        /// </summary>
        private void LoadEstateImage()
        {
            try
            {
                EstateImage = LoadDialogEstateImage();
                //OnPropertyChanged(nameof(CurrentEstate));
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Load failed, {ex.Message}");
            }
        }

        /// <summary>
        /// A method for adding new estates
        /// </summary>
        private async Task AddNewEstateAsync()
        {
            IsAdding = true;
            await AddCurrentOrNewEstateAsync();
        }

        /// <summary>
        /// a method for editing existing estates. 
        /// </summary>
        private async Task EditSelectedEstateAsync()
        {
            IsAdding = false;
            _currentEstate = SelectedEstate;
            SetExistingInputValues();
            OnPropertyChanged(nameof(CurrentEstate));
            await AddCurrentOrNewEstateAsync();
        }

        /// <summary>
        /// a method for replacing the selected estate with a new estate
        /// </summary>
        private async Task ReplaceSelectedEstateAsync()
        {
            IsAdding = false;
            SelectedEstate = _currentEstate;
            OnPropertyChanged(nameof(CurrentEstate));
            await AddCurrentOrNewEstateAsync();
        }

        /// <summary>
        /// A async method that while the user is in editing mode, checks which estate type is selected
        /// and creates that estate type. It is called when both editing of adding a new estate
        /// It also controls the visibility of the proper input control through booleans
        /// The method is async as to not block the ui thread
        /// </summary>
        /// <returns></returns>

        private async Task AddCurrentOrNewEstateAsync()
        {
            IsEditing = true;
            _tokenSource = new CancellationTokenSource();
            AddEstate.RaiseCanExecuteChanged();
            RemoveEstate.RaiseCanExecuteChanged();
            EditEstate.RaiseCanExecuteChanged();

            while (IsEditing)
            {
                if (_tokenSource.IsCancellationRequested)
                {
                    IsEditing = false;
                    break;
                }

                if (Types != null)
                {
                    var parameters = new EstateParameters
                    {
                        ResidentialArea = ResidentialArea,
                        NumberOfRooms = NumberOfRooms,
                        GardenSize = GardenSize,
                        IsDetached = IsDetached,
                        PropertySize = PropertySize,
                        NumberOfHotelRooms = NumberOfHotelRooms,
                        RetailArea = RetailArea,
                        StorageArea = StorageArea,
                        SelectedFactoryType = SelectedFactoryType,
                        SelectedInstitutionType = SelectedInstitutionType,
                        NumberOfStaff = NumberOfStaff,
                        HasEmergencyDept = HasEmergencyDept,
                        SelectedSchoolType = SelectedSchoolType,
                        NumberOfFacs = NumberOfFacs,
                        SelectedLegalForm = SelectedLegalForm,
                        FloorLevel = FloorLevel,
                        HasBalcony = HasBalcony,
                        Rent = Rent,
                        SalesValue = SalesValue
                    };

                    _currentEstate = _realEstateBLL.CreateEstate(SelectedType, parameters);
                    UpdateEstateBooleans(SelectedType);
                }

                FinishEditEstate.RaiseCanExecuteChanged();
                await Task.Delay(100, _tokenSource.Token);
            }
        }

        private void UpdateEstateBooleans(EstateTypes selectedType)
        {
            if (SelectedType == EstateTypes.Villa)
            {
                IsResident = true;
                IsVilla = true;
                IsTownHouse = false;
                IsApartment = false;
                IsTenementApartment = false;
                IsRentalApartment = false;

                NotCommercial();
                NotInstitutional();
            }

            else if (SelectedType == EstateTypes.Townhouse)
            {
                IsResident = true;
                IsTownHouse = true;
                IsVilla = true;
                IsApartment = false;
                IsTenementApartment = false;
                IsRentalApartment = false;

                NotCommercial();
                NotInstitutional();
            }

            else if (SelectedType == EstateTypes.Apartment)
            {
                IsResident = true;
                IsApartment = true;
                IsVilla = false;
                IsTownHouse = false;

                NotCommercial();
                NotInstitutional();
            }

            else if (SelectedType == EstateTypes.Hotel)
            {
                IsCommercial = true;
                IsHotel = true;
                IsShop = false;
                IsWarehouse = false;
                IsFactory = false;

                NotResidential();
                NotInstitutional();
            }

            else if (SelectedType == EstateTypes.Shop)
            {
                IsCommercial = true;
                IsHotel = false;
                IsShop = true;
                IsWarehouse = false;
                IsFactory = false;

                NotResidential();
                NotInstitutional();
            }

            else if (SelectedType == EstateTypes.Warehouse)
            {
                IsCommercial = true;
                IsHotel = false;
                IsShop = false;
                IsWarehouse = true;
                IsFactory = false;

                NotResidential();
                NotInstitutional();
            }

            else if (SelectedType == EstateTypes.Factory)
            {
                IsCommercial = true;
                IsHotel = false;
                IsShop = false;
                IsWarehouse = false;
                IsFactory = true;

                NotResidential();
                NotInstitutional();
            }

            else if (SelectedType == EstateTypes.Hospital)
            {
                IsInstitutional = true;
                IsHospital = true;
                IsSchool = false;
                IsUniversity = false;

                NotResidential();
                NotCommercial();
            }

            else if (SelectedType == EstateTypes.School)
            {
                IsInstitutional = true;
                IsHospital = false;
                IsSchool = true;
                IsUniversity = false;

                NotResidential();
                NotCommercial();
            }

            else if (SelectedType == EstateTypes.University)
            {
                IsInstitutional = true;
                IsHospital = false;
                IsSchool = false;
                IsUniversity = true;

                NotResidential();
                NotCommercial();
            }
        }


        /// <summary>
        /// A method that removes the selected estate from the collection
        /// </summary>
        private void RemoveCurrentEstate()
        {
            if (SelectedEstate == null)
                return;
            else
            {
                _realEstateBLL.RemoveEstate(SelectedIndex);
                OnPropertyChanged(nameof(SelectedEstate));
                UpdateObservableCollection();
            }
        }

        /// <summary>
        /// A method for setting the base properties all estates have
        /// If the user is adding a new estate, it is added to the collection
        /// if not, the selected estate that is edited is set with all the values insted and
        /// no new estate is added
        /// </summary>
        private void FinishEditing()
        {
            NotCommercial();
            NotInstitutional();
            NotResidential();

            if (_currentEstate != null)
            {
                _currentEstate.EstateAddress = _realEstateBLL.CreateAddress(Street, ZipCode, City, SelectedCountry);
                _currentEstate.LegalForm = SelectedLegalForm;
                _currentEstate.EstateType = SelectedType;
                _currentEstate.EstateImage = EstateImage.UriSource.AbsolutePath;
                _realEstateBLL.CreateId(_currentEstate);

                if (IsAdding)
                {
                    _realEstateBLL.AddEstate(_currentEstate);
                }

                else
                {
                    _realEstateBLL.ReplaceEstate(_currentEstate, SelectedIndex);
                    OnPropertyChanged(nameof(SelectedEstate));
                }
            }

            else
            {
                _currentEstate = null;
            }

            UpdateObservableCollection();
            Reset();
        }

        /// <summary>
        /// A method for checking if the apartment is a rental or tenement
        /// </summary>
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

        /// <summary>
        /// Method for setting all parameters bound to input
        /// controls to values from the estate that is to be edited
        /// </summary>
        private void SetExistingInputValues()
        {
            City = SelectedEstate.EstateAddress.City;
            Street = SelectedEstate.EstateAddress.Street;
            ZipCode = SelectedEstate.EstateAddress.Zipcode;

            SelectedLegalForm = SelectedEstate.LegalForm;
            SelectedType = SelectedEstate.EstateType;
            EstateImage = CreateEstateImage(SelectedEstate.EstateImage);

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
                SelectedInstitutionType = institutional.InstType;
                NumberOfStaff = institutional.NumberOfStaff;

                if (institutional is School school)
                {
                    SelectedSchoolType = school.Type;
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
                PropertySize = commercial.PropertySize;

                if (commercial is Factory factory)
                {
                    SelectedFactoryType = factory.FactoryType;
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

            FinishEditEstate.RaiseCanExecuteChanged();
        }

        /// <summary>
        /// Method for creating a bitmap image fomr a filename
        /// </summary>
        public BitmapImage LoadDialogEstateImage()
        {
            BitmapImage image = null;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            bool result;
            Loadimage(openFileDialog, out result);

            if (result)
            {
                image = CreateEstateImage(openFileDialog.FileName);
            }

            else
            {
                image = null;
            }

            return image;
        }

        public void Loadimage(OpenFileDialog openFileDialog, out bool result)
        {
            openFileDialog.Filter = "Image Files (*.jpg, *.jpeg, *.png, *.bmp, *.gif, *.tiff, *.ico)|*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.tiff;*.ico";
            openFileDialog.Title = "Load Image";
            openFileDialog.Multiselect = false;
            result = (bool)openFileDialog.ShowDialog();
        }

        public BitmapImage CreateEstateImage(string filePath)
        {
            var image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(filePath, UriKind.Absolute);
            image.CacheOption = BitmapCacheOption.OnLoad;
            image.EndInit();
            image.Freeze();
            return image;
        }


        /// <summary>
        /// Update bound observablecollection with the estates in the estatemanager
        /// </summary>
        private void UpdateObservableCollection()
        {
            Estates.Clear();

            foreach (Estate estate in _realEstateBLL.GetAllEstates())
            {
                Estates.Add(estate);
            }

            OnPropertyChanged(nameof(Estates));
        }

        /// <summary>
        /// Methods for resetting all properties bound to input controls
        /// </summary>
        private void Reset()
        {
            IsEditing = false;
            IsAdding = false;
            AddEstate.RaiseCanExecuteChanged();
            RemoveEstate.RaiseCanExecuteChanged();
            EditEstate.RaiseCanExecuteChanged();

            NotCommercial();
            NotInstitutional();
            NotResidential();

            ResetInput();
        }

        private void ResetInput()
        {
            EstateImage = null;
            Street = string.Empty;
            City = string.Empty;
            ZipCode = 0;
            HasBalcony = false;
            Rent = 0;
            SalesValue = 0;
            GardenSize = 0;
            FloorLevel = 0;
            ResidentialArea = 0;
            NumberOfRooms = 0;
            NumberOfFacs = 0;
            NumberOfHotelRooms = 0;
            NumberOfStaff = 0;
            PropertySize = 0;
            RetailArea = 0;
            StorageArea = 0;
            HasEmergencyDept = false;
        }

        /// <summary>
        /// 
        /// </summary>
        private void NotResidential()
        {
            IsResident = false;
            IsApartment = false;
            IsVilla = false;
            IsTownHouse = false;
            IsRentalApartment = false;
            IsTenementApartment = false;
        }
        private void NotCommercial()
        {
            IsCommercial = false;
            IsHotel = false;
            IsShop = false;
            IsWarehouse = false;
            IsFactory = false;
        }
        private void NotInstitutional()
        {
            IsInstitutional = false;
            IsHospital = false;
            IsUniversity = false;
            IsSchool = false;
        }

        /// <summary>
        ///A method checking if all input for the address has been filled in by the user
        /// </summary>
        /// <returns>false if not, true if all is filled in</returns>
        private bool IsAddressFilled()
        {
            if (Street.Length > 0 && City.Length > 0 && SelectedCountry != null)
            {
                return true;
            }
            return false;
        }
    }
}
