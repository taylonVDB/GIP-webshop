using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Postcode
    {
        //private instantievariabelen
        private string _postCode;
        private string _gemeente;

        //publieke constructor
        public Postcode(string postcode, string gemeente)
        {
            _postCode = postcode;
            _gemeente = gemeente;
        }

        //publieke eigenschappen
        public string Postcodes
        {
            get { return _postCode; }
            set { _postCode = value; }
        }

        public string Gemeente  
        {
            get { return _gemeente; }
            set { _gemeente = value; }
        }

        //methoden
        public override string ToString()
        {
            return _postCode + " - " + _gemeente;
        }
    }
}
