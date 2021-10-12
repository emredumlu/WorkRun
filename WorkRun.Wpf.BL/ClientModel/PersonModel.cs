using System;

namespace WorkRun.Client.BL
{
    public class PersonModel : BaseClientModel
    {
        public Guid Id { get; set; }

        private string _idn;
        public string Idn
        {
            get => _idn;
            set
            {
                _idn = value;
                RaisePropertyChanged();
            }
        }

        private string _taxNumber;
        public string TaxNumber
        {
            get => _taxNumber;
            set
            {
                _taxNumber = value;
                RaisePropertyChanged();
            }
        }

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                RaisePropertyChanged();
            }
        }

        private string _surName;
        public string SurName
        {
            get => _surName;
            set
            {
                _surName = value;
                RaisePropertyChanged();
            }
        }
    }
}
