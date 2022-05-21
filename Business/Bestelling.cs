using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    //Door deze klasse op te bouwen kunnen in een latere toepassing
    //alle gedane bestellingen getoond worden in een ListBox 
    //en per bestelling een overzicht gegeven worden van de bestelde product(nummers).
    //(cfr categorielijst, productenlijst, ... 
    //==een eventuele UITBREIDING: zit niet in deze opdracht vervat!

    public class Bestelling
    {
        //private instantievariabelen
        private int _bestelnummer;
        private int _klantnummer;
        private DateTime _besteldatum;

        //publieke constructor
        public Bestelling(int bestelnummer, int klantnummer, DateTime besteldatum)
        {
            _bestelnummer = bestelnummer;
            _klantnummer = klantnummer;
            _besteldatum = besteldatum;
        }

        //publieke eigenschappen
        public int Bestelnummer
        {
            get { return _bestelnummer; }
            set { _bestelnummer = value; }
        }

        public int Klantnummer
        {
            get { return _klantnummer; }
            set { _klantnummer = value; }
        }

        public DateTime Besteldatum
        {
            get { return _besteldatum; }
            set { _besteldatum = value; }
        }

        //methode
        public override string ToString()
        {
            return "Bestelling: " + _bestelnummer + " geplaatst op " + _besteldatum;
        }
    }
}
