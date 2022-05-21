using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Product
    {
        //We beperken ons tot de hoofdkenmerken.
        //LET OP: bekijk de gegevenstypes in je databank!!
        //Bv. hier is jaar een string en geen int (zie tblWijnen).
        private string _productnr;
        private string _productiejaar;
        private string _naam;
        private string _omschrijving;
        private string _kilometerstand;
        private string _kleur;
        private int _groepsnummer;
        private bool _voorraad;
        private decimal _prijs;
        private string _foto;

        //publieke constructor
        public Product(string prodNr, string productiejaar, string naam, string omschrijving, string kilometerstand, 
                       string kleur, int groepsnr, bool voorraad, decimal prijs, string foto)
        {
            _productnr = prodNr;
            _productiejaar = productiejaar;
            _naam = naam;
            _omschrijving = omschrijving;
            _kilometerstand = kilometerstand;
            _kleur = kleur;
            _groepsnummer = groepsnr;
            _voorraad = voorraad;
            _prijs = prijs;
            _foto = foto;
        }

        //publieke eigenschappen
        public string Productnr
        {
            get { return _productnr; }
            set { _productnr = value; }
        }

        public string Productiejaar
        {
            get { return _productiejaar; }
            set { _productiejaar = value; }
        }

        public string Naam
        {
            get { return _naam; }
            set { _naam = value; }
        }

        public string Omschrijving
        {
            get { return _omschrijving; }
            set { _omschrijving = value; }
        }

        public string Kilomterstand
        {
            get { return _kilometerstand; }
            set { _kilometerstand = value; }
        }

        public string Kleur
        {
            get { return _kleur; }
            set { _kleur = value; }
        }

        public int Groepsnummer
        {
            get { return _groepsnummer; }
            set { _groepsnummer = value; }
        }

        public bool Voorraad
        {
            get { return _voorraad; }
            set { _voorraad = value; }
        }

        public decimal Prijs
        {
            get { return _prijs; }
            set { _prijs = value; }
        }

        public string Foto
        {
            get { return _foto; }
            set { _foto = value; }
        }

        //methoden
        public override string ToString()
        {
            return _productiejaar + " - " + _naam + " - " + _kilometerstand + " km";
        }

        public bool isAutoAanwezig()
        {
            if(_voorraad == false)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
