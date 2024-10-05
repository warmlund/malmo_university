namespace real_estate_manager
{
    public class Villa : Residential
    {
        private double _gardenSize;
        public double GardenSize { get => _gardenSize; set => _gardenSize = value; }

        public Villa(double residentialArea, int numberOfRooms, double gardenSize) : base(residentialArea, numberOfRooms)
        {
            _gardenSize = gardenSize;
        }
    }
}