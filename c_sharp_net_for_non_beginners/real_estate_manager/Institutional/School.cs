using real_estate_manager.Enum;

namespace real_estate_manager
{
    public class School : Institutional
    {
        private SchoolType _type;
        public SchoolType Type { get => _type; set => _type = value; }
        public School(InstitutionType institutionType, int numberOfStaff, SchoolType schoolType) : base(institutionType, numberOfStaff)
        {
            _type = schoolType;
        }
    }
}