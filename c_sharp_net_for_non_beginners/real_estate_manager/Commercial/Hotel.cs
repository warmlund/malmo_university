namespace real_estate_manager
{
    public class Hotel : Commercial
    {
        private int _numberOfRooms;

        public Hotel(double propertySize, int numberOfRooms) : base(propertySize)
        {
            _numberOfRooms = numberOfRooms;
        }

    }
}