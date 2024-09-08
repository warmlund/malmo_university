namespace real_estate_manager
{
    public abstract class Institutional(InstitutionType institutionType, double capacity, double numberOfStaff) : Estate
    {
        protected InstitutionType _instType = institutionType;
        protected double _capacity = capacity;
        protected double _numberOfStaff = numberOfStaff;
    }
}