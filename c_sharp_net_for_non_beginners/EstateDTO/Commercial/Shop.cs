namespace RealEstateDTO
{
    /// <summary>
    /// Shop estate class inheriting from the commercial abstract class
    /// </summary>
    public class Shop : Commercial
    {
        private double _retailArea;
        public double RetailArea { get => _retailArea; set => _retailArea = value; }

        public Shop(double propertySize, double retailArea) : base(propertySize)
        {
            _retailArea = retailArea;
        }

    }
}