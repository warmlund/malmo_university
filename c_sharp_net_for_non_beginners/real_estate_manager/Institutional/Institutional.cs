namespace real_estate_manager
{
    public abstract class Institutional : Estate
    {
        private InstitutionType _instType;
        private double _capacity;
        private double _numberOfStaff;

        protected InstitutionType InstType { get => _instType; set => _instType = value; }
        protected double Capacity { get => _capacity; set => _capacity = value; }
        protected double NumberOfStaff { get => _numberOfStaff; set => _numberOfStaff = value; }

        public Institutional(InstitutionType institutionType, double capacity, double numberOfStaff)
        {
            _instType = institutionType;
            _capacity = capacity;
            _numberOfStaff = numberOfStaff;
        }
    }
}