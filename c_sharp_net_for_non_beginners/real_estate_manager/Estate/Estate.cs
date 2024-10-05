using real_estate_manager.Enum;
using real_estate_manager.HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace real_estate_manager
{
    public abstract class Estate : IEstate
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public LegalForm LegalForm { get; set; }
        public Image EstateImage { get; set; }

        public EstateTypes EstateType { get; set; }


        public virtual void UpdateEstateDetails(int id, EstateTypes estateTypes, string address, LegalForm legalForm, Image estateImage)
        {
            Id = id;
            Address = address;
            LegalForm = legalForm;
            EstateImage = estateImage;
            EstateType = estateTypes;
        }

    }
}