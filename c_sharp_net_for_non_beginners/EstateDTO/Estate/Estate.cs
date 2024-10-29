
namespace RealEstateDTO
{
    /// <summary>
    /// Abstract class for estate objects inheriting from the interface
    /// </summary>
    public abstract class Estate : IEstate
    {
        public int Id { get; set; }
        public EstateTypes EstateType { get; set; }
        public Address EstateAddress { get; set; }
        public LegalForm LegalForm { get; set; }
        public string EstateImage { get; set; }
    }
}