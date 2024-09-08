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
        public Address Address { get; set; }
        public LegalForm LegalForm { get; set; }
        public Image EstateImage { get; set; }


        public virtual void UpdateEstateDetails(int id, Address address, LegalForm legalForm, Image estateImage)
        {
            Id = id;
            Address = address;
            LegalForm = legalForm;
            EstateImage = estateImage;
        }

    }
}