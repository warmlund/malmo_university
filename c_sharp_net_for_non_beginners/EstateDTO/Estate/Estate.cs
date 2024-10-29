
using Newtonsoft.Json;

namespace RealEstateDTO
{
    /// <summary>
    /// Abstract class for estate objects inheriting from the interface
    /// </summary>
    public abstract class Estate : IEstate
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("EstateType")]
        public EstateTypes EstateType { get; set; }

        [JsonProperty("EstateAddress")]
        public Address EstateAddress { get; set; }

        [JsonProperty("LegalForm")]
        public LegalForm LegalForm { get; set; }

        [JsonProperty("EstateImage")]
        public string EstateImage { get; set; }
    }
}