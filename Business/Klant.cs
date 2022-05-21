using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Klant
    {
        //private instantievariabelen
        private int _klantNr;
        private string _voornaam;
        private string _achternaam;
        private string _straat;
        private string _huisnr;
        private string _postcode;
        private string _btwNr;
        private string _type;
        private string _opmerking;
        private string _gebruikersnaam;
        private string _wachtwoord;
        private bool _isWerknemer;

        //publieke constructor
        public Klant(int klantNr, string voornaam, string achternaam, string straat, string huisnr, string postcode, string btwnr, 
                     string type, string opmerking, string gebruikersnaam, string wachtwoord, bool isWerknemer)
        {
            _klantNr = klantNr;
            _voornaam = voornaam;
            _achternaam = achternaam;
            _straat = straat;
            _huisnr = huisnr;
            _postcode = postcode;
            _btwNr = btwnr;
            _type = type;
            _opmerking = opmerking;
            _gebruikersnaam = gebruikersnaam;
            _wachtwoord = wachtwoord;
            _isWerknemer = isWerknemer;
        }

        //publieke eigenschappen
        public int KlantNr
        {
            get { return _klantNr; }
            set { _klantNr = value; }
        }

        public string Voornaam
        {
            get { return _voornaam; }
            set { _voornaam = value; }
        }

        public string Achternaam
        {
            get { return _achternaam; }
            set { _achternaam = value; }
        }

        public string Straat
        {
            get { return _straat; }
            set { _straat = value; }
        }

        public string Huisnr
        {
            get { return _huisnr; }
            set { _huisnr = value; }
        }

        public string Postcode
        {
            get { return _postcode; }
            set { _postcode = value; }
        }

        public string BtwNr
        {
            get { return _btwNr; }
            set { _btwNr = value; }
        }

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public string Opmerking
        {
            get { return _opmerking; }
            set { _opmerking = value; }
        }

        public string Gebruikersnaam
        {
            get { return _gebruikersnaam; }
            set { _gebruikersnaam = value; }
        }

        public string Wachtwoord
        {
            get { return _wachtwoord; }
            set { _wachtwoord = value; }
        }

        public bool IsWerknemer
        {
            get { return _isWerknemer; }
            set { _isWerknemer = value; }
        }

        //methoden
        public override string ToString()
        {
            return "klantnummer " + _klantNr + " - " + _voornaam + " " + _achternaam + " - " + _opmerking;
        }

    }
}
