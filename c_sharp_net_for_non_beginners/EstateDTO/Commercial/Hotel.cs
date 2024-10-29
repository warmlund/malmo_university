namespace RealEstateDTO
{
    /// <summary>
    /// Hotel estate class inheriting from the commercial abstract class
    /// </summary>
    /// 
    public class Hotel : Commercial
    {
        private int _numberOfRooms;
        public int NumberOfRooms { get => _numberOfRooms; set => _numberOfRooms = value; }

        public Hotel(double propertySize, int numberOfRooms) : base(propertySize)
        {
            _numberOfRooms = numberOfRooms;
        }

    }
}