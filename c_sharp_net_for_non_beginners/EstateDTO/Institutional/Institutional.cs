using Newtonsoft.Json;

namespace RealEstateDTO
{
    /// <summary>
    /// Abstract class for institutional estates
    /// </summary>
    public abstract class Institutional : Estate
    {
        private InstitutionType _instType;
        private int _numberOfStaff;

        [JsonProperty("InstType")]
        public InstitutionType InstType { get => _instType; set => _instType = value; }

        [JsonProperty("NumberOfStaff")]
        public int NumberOfStaff { get => _numberOfStaff; set => _numberOfStaff = value; }

        public Institutional(InstitutionType institutionType, int numberOfStaff)
        {
            _instType = institutionType;
            _numberOfStaff = numberOfStaff;
        }
    }
}