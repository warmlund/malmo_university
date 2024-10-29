using Newtonsoft.Json;

namespace RealEstateDTO
{
    /// <summary>
    /// Class for estate type villa. inherits abstract class residential
    /// </summary>
    public class Villa : Residential
    {
        private double _gardenSize;

        [JsonProperty("GardenSize")]
        public double GardenSize { get => _gardenSize; set => _gardenSize = value; }

        public Villa(double residentialArea, int numberOfRooms, double gardenSize) : base(residentialArea, numberOfRooms)
        {
            _gardenSize = gardenSize;
        }
    }
}