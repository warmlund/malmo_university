using real_estate_manager.Enum;

namespace real_estate_manager
{
    /// <summary>
    /// Factory estate class inheriting from the commercial abstract class
    /// </summary>
    public class Factory : Commercial
    {
        private FactoryType _factoryType;
        public FactoryType FactoryType { get => _factoryType; set => _factoryType = value; }
        public Factory(double propertySize, FactoryType factoryType) : base(propertySize)
        {
            _factoryType = factoryType;
        }
    }
}