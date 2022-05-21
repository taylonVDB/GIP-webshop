using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using Business;

namespace DataAccess
{
    public class ProductOverzichtDA
    {
        private string _connString;
        private OleDbConnection _oleDbConnection;

        public ProductOverzichtDA()
        {
            _connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\databanken\\bavaria.mdb";
            _oleDbConnection = new OleDbConnection(_connString);
        }

        public List<Categorie> alleCategorien()
        {
            List<Categorie> lijst = new List<Categorie>();
            string sql = "SELECT * FROM tblAutogroepen ORDER BY Groepsnummer;";
            OleDbCommand oleDbCommand = new OleDbCommand(sql, _oleDbConnection);    
            _oleDbConnection.Open();
            OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();     
            while (oleDbDataReader.Read() == true)
            {
                Categorie categorie = new Categorie((int)oleDbDataReader["Groepsnummer"],
                        oleDbDataReader["Groepsnaam"].ToString());
                lijst.Add(categorie);
            }
            _oleDbConnection.Close();
            return lijst;
        }

        public List<Product> alleProductenUitCategorie(int categorieNr)
        {
            //Selecteer alle producten die tot een bepaalde categorie behoren.
            List<Product> lijst = new List<Product>();
            string sql = "SELECT * FROM tblAutos WHERE Groepsnummer = @categorienr AND Voorraad = true;";
            OleDbCommand oleDbCommand = new OleDbCommand(sql, _oleDbConnection);
            oleDbCommand.Parameters.AddWithValue("@categorienr", categorieNr);
            _oleDbConnection.Open();
            OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
            while (oleDbDataReader.Read() == true)
            {
                Product product = new Product(oleDbDataReader["Productnummer"].ToString(),
                        oleDbDataReader["Jaar"].ToString(),
                        oleDbDataReader["Naam"].ToString(),
                        oleDbDataReader["Omschrijving"].ToString(),
                        oleDbDataReader["Kilometerstand"].ToString(),
                        oleDbDataReader["Kleur"].ToString(),
                        (int)oleDbDataReader["Groepsnummer"],
                        (bool)oleDbDataReader["Voorraad"],        //type SmallInt in tblWijnen
                        (decimal)oleDbDataReader["Prijs"],
                        oleDbDataReader["Foto"].ToString());        
                lijst.Add(product);
            }
            _oleDbConnection.Close();
            return lijst;
        }

        public string categorieNaam(int categorieNr)
        {
            //Selecteer alle producten die tot een bepaalde categorie behoren.
            string categorienaam;
            string sql = "SELECT Groepsnaam FROM tblAutogroepen WHERE Groepsnummer = @categorienr;";
            OleDbCommand oleDbCommand = new OleDbCommand(sql, _oleDbConnection);
            oleDbCommand.Parameters.AddWithValue("@categorienr", categorieNr);
            _oleDbConnection.Open();
            categorienaam = oleDbCommand.ExecuteScalar().ToString();
            _oleDbConnection.Close();
            return categorienaam;
        }
    }
}
