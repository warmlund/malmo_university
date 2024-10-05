namespace real_estate_manager
{
    public abstract class Institutional : Estate
    {
        private InstitutionType _instType;
        private int _numberOfStaff;

        public InstitutionType InstType { get => _instType; set => _instType = value; }
        public int NumberOfStaff { get => _numberOfStaff; set => _numberOfStaff = value; }

        public Institutional(InstitutionType institutionType, int numberOfStaff)
        {
            _instType = institutionType;
            _numberOfStaff = numberOfStaff;
        }
    }
}