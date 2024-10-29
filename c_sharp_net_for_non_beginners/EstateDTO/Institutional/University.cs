using Newtonsoft.Json;

namespace RealEstateDTO
{
    /// <summary>
    /// Unoversity estate class inheriting from the commercial abstract class
    /// </summary>
    /// 
    public class University : Institutional
    {
        private int _numberOfFalculties;

        [JsonProperty("NumberOfFaculties")]
        public int NumberOfFalculties { get => _numberOfFalculties; set => _numberOfFalculties = value; }

        public University(InstitutionType institutionType, int numberOfStaff, int faculties) : base(institutionType, numberOfStaff)
        {
            _numberOfFalculties = faculties;
        }

    }
}