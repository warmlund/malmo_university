using real_estate_manager.Enum;

namespace real_estate_manager
{
    public class School : Institutional
    {
        private SchoolType _type;

        public School(InstitutionType institutionType, int capacity, int numberOfStaff, SchoolType schoolType) : base(institutionType, capacity, numberOfStaff)
        {
            _type = schoolType;
        }
    }
}