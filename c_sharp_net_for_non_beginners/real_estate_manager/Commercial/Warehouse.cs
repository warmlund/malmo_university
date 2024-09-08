namespace real_estate_manager
{
    public class Warehouse : Commercial
    {
        private double _storageArea;

        public Warehouse(double propertySize, double storageArea): base(propertySize)
        {
            _storageArea = storageArea;
        }
    }
}