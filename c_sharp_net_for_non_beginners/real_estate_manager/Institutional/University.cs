namespace real_estate_manager
{
    public class University : Institutional
    {
        private int _numberOfFalculties;
        public int NumberOfFalculties { get => _numberOfFalculties; set => _numberOfFalculties = value; }

        public University(InstitutionType institutionType, int capacity, int numberOfStaff, int faculties) : base(institutionType, capacity, numberOfStaff)
        {
            _numberOfFalculties = faculties;
        }

    }
}