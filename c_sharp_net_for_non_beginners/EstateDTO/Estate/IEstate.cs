namespace RealEstateDTO
{
    /// <summary>
    /// Interface for estate objects
    /// </summary>
    public interface IEstate
    {
        int Id { get; set; }
        EstateTypes EstateType { get; set; }
        Address EstateAddress { get; set; }
        LegalForm LegalForm { get; set; }
        string EstateImage { get; set; }
    }
}