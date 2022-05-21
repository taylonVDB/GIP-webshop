using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using Business;

namespace DataAccess
{
    public class WerknemerDA
    {
        private string _connString;
        private OleDbConnection _oleDbConnection;

        public WerknemerDA()
        {
            _connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\databanken\\bavaria.mdb";
            _oleDbConnection = new OleDbConnection(_connString);
        }

        public List<Klant> alleKlanten()
        {
            List<Klant> lijst = new List<Klant>();
            string sql = "SELECT * FROM tblKlanten WHERE IsWerknemer = false ORDER BY Klantnummer;";
            OleDbCommand oleDbCommand = new OleDbCommand(sql, _oleDbConnection);
            _oleDbConnection.Open();
            OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
            while (oleDbDataReader.Read() == true)
            {
                Klant klant = new Klant((int)oleDbDataReader["Klantnummer"],
                        oleDbDataReader["Voornaam"].ToString(),
                        oleDbDataReader["Achternaam"].ToString(),
                        oleDbDataReader["Straat"].ToString(),
                        oleDbDataReader["Huisnr"].ToString(),
                        oleDbDataReader["Postcode"].ToString(),
                        oleDbDataReader["BTWnr"].ToString(),
                        oleDbDataReader["Type"].ToString(),
                        oleDbDataReader["Opmerking"].ToString(),
                        oleDbDataReader["Login"].ToString(),
                        oleDbDataReader["Paswoord"].ToString(),
                        (bool)oleDbDataReader["IsWerknemer"]);
                lijst.Add(klant);
            }
            _oleDbConnection.Close();
            return lijst;
        }

        public void voegProductToeAanVoorraad(Product product)
        {
            string sql2 = "UPDATE tblAutos SET Voorraad = true WHERE(Productnummer=@Productnummer);";
            OleDbCommand oleDbCommand2 = new OleDbCommand(sql2, _oleDbConnection);
            oleDbCommand2.Parameters.AddWithValue("@Productnummer", product.Productnr);
            _oleDbConnection.Open();
            oleDbCommand2.ExecuteNonQuery();
            _oleDbConnection.Close();
        }

        public List<Product> alleProductenUitVoorraad()
        {
            //Selecteer alle producten die tot een bepaalde categorie behoren.
            List<Product> lijst = new List<Product>();
            string sql = "SELECT * FROM tblAutos WHERE  Voorraad = false;";
            OleDbCommand oleDbCommand = new OleDbCommand(sql, _oleDbConnection);
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

        public void UpdateKlant(int klantnr, string Voornaam, string Achternaam, string Straat, string Huisnr, string Postcode, string BTWnr, string Type, string opmerking)
        {
            //moet nog update worden
            string sql = "UPDATE tblKlanten SET Voornaam = @Voornaam, Achternaam = @Achternaam, Straat = @Straat, Huisnr = @Huisnr, Postcode = @Postcode, BTWnr = @BTWnr, Type = @Type, Opmerking = @Opmerking WHERE (Klantnummer = @Klantnummer);";
            OleDbCommand oleDbCommand = new OleDbCommand(sql, _oleDbConnection);
            oleDbCommand.Parameters.AddWithValue("@Vooraam", Voornaam);
            oleDbCommand.Parameters.AddWithValue("@Achternaam", Achternaam);
            oleDbCommand.Parameters.AddWithValue("@Straat", Straat);
            oleDbCommand.Parameters.AddWithValue("@Huisnr", Huisnr);
            oleDbCommand.Parameters.AddWithValue("@Postcode", Postcode);
            oleDbCommand.Parameters.AddWithValue("@BTWnr", BTWnr);
            oleDbCommand.Parameters.AddWithValue("@Type", Type);
            oleDbCommand.Parameters.AddWithValue("@Opmerking", opmerking);
            oleDbCommand.Parameters.AddWithValue("@Klantnummer", klantnr);
            _oleDbConnection.Open();
            oleDbCommand.ExecuteNonQuery();
            _oleDbConnection.Close();
        }
    }
}
