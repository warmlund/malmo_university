using Newtonsoft.Json;

namespace RealEstateDTO
{
    /// <summary>
    /// Shop estate class inheriting from the commercial abstract class
    /// </summary>
    public class Shop : Commercial
    {
        private double _retailArea;

        [JsonProperty("RetailArea")]
        public double RetailArea { get => _retailArea; set => _retailArea = value; }

        public Shop(double propertySize, double retailArea) : base(propertySize)
        {
            _retailArea = retailArea;
        }

    }
}