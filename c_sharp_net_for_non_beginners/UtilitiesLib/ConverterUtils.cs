using System.Globalization;
using System.Text.RegularExpressions;

namespace UtilitiesLib
{
    public class ConverterUtils
    {
        public bool StringToIntConverter(string str, out int number)
        {
            bool result = int.TryParse(str, out number);

            if (result)
                return true;
            return false;
        }

        public bool StringToIntConverter(string str, out int number, int lowLimit=0, int highLimit = 100)
        {
            bool result = int.TryParse(str, out number);

            if (result)
            {
                if (number > lowLimit && number < highLimit)
                    return true;
            }

            return false;
        }
        public bool StringToDouble(string str, out double number)
        {
            bool result = double.TryParse(str, out number);

            if (result)
                return true;
            return false;
        }

        public bool StringToDouble(string str, out double number, double lowLimit = 0, double highLimit = 100)
        {

            bool result = double.TryParse(str, out number);

            if (result)
            {
                if (number > lowLimit && number < highLimit)
                    return true;
            }
            return false;
        }
    }
}
