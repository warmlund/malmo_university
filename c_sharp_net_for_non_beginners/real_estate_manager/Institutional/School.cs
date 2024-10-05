using real_estate_manager.Enum;

namespace real_estate_manager
{
    public class School : Institutional
    {
        private SchoolType _type;
        public SchoolType Type { get => _type; set => _type = value; }
        public School(InstitutionType institutionType, int capacity, int numberOfStaff, SchoolType schoolType) : base(institutionType, capacity, numberOfStaff)
        {
            _type = schoolType;
        }
    }
}