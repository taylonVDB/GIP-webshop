using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Categorie
    {
        //private instantievariabelen
        private int _categorieNr;
        private string _categorieNaam;

        //publieke constructor
        public Categorie(int catNr, string catNaam)
        {
            _categorieNr = catNr;
            _categorieNaam = catNaam; 
        }

        //publieke eigenschappen
        public int CategorieNr
        {
            get { return _categorieNr; }
            set { _categorieNr = value; }
        }

        public string CategorieNaam
        {
            get { return _categorieNaam; }
            set { _categorieNaam = value; }
        }

        //methoden
        public override string ToString()
        {
            //return _categorieNr + ". " + _categorieNaam;
            return _categorieNaam;
        }
    }
}
