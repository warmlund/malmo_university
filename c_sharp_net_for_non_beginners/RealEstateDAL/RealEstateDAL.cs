using Newtonsoft.Json;
using RealEstateDTO;

namespace RealEstateDAL
{
    public class RealEstateDAL : IRealEstateDAL
    {
        public bool SaveEstate(string path, Estate estate)
        {
            try
            {
                string jsonPlaylist = JsonConvert.SerializeObject(estate, Formatting.Indented); //converts to json 
                File.WriteAllText(path, jsonPlaylist); //write to file

                return true;
            }
            catch
            {
                return false;
            }
        }

        public Estate LoadEstate(string path)
        {
            try
            {
                if (File.Exists(path)) //Checks if file exists
                {
                    string jsonEstate = File.ReadAllText(path); //Reads the json file
                    return JsonConvert.DeserializeObject<Estate>(jsonEstate); //returns the deserialized json file as a playlist
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
