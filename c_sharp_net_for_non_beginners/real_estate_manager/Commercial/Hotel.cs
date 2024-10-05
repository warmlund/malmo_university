namespace real_estate_manager
{
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