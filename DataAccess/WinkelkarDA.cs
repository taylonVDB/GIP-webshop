using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using Business;

namespace DataAccess
{
    public class WinkelkarDA
    {
        private string _connString;
        private OleDbConnection _oleDbConnection;

        public WinkelkarDA()
        {
            _connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\databanken\\bavaria.mdb";
            _oleDbConnection = new OleDbConnection(_connString);
        }

        public void voegProductToeAanWinkelkar(Product product)
        {
            //Voeg het bestelde product (tijdelijk) toe aan tblWinkelkar
            string sql1 = "INSERT INTO tblWinkelkar(Productnummer, Prijs) VALUES(@Productnummer, @Prijs);";
            OleDbCommand oleDbCommand1 = new OleDbCommand(sql1, _oleDbConnection);   //***
            oleDbCommand1.Parameters.AddWithValue("@Productnummer", product.Productnr);
            oleDbCommand1.Parameters.AddWithValue("@Prijs", product.Prijs);
            _oleDbConnection.Open();
            oleDbCommand1.ExecuteNonQuery();
            _oleDbConnection.Close();

            //De voorraad van het product aanpassen in de databank, tabel tblWijnen.
            string sql2 = "UPDATE tblAutos SET Voorraad = @Voorraad WHERE(Productnummer=@Productnummer);";
            OleDbCommand oleDbCommand2 = new OleDbCommand(sql2, _oleDbConnection);
            oleDbCommand2.Parameters.AddWithValue("@Voorraad", product.Voorraad = false);
            oleDbCommand2.Parameters.AddWithValue("@Productnummer", product.Productnr);
            _oleDbConnection.Open();
            oleDbCommand2.ExecuteNonQuery();
            _oleDbConnection.Close();
        }

        public int klantNr(string gebruikersnaam)
        {
            int klantnr;
            string sql = "SELECT Klantnummer FROM tblKlanten where (Login = @login);";
            OleDbCommand oleDbCommand = new OleDbCommand(sql, _oleDbConnection);
            oleDbCommand.Parameters.AddWithValue("@login", gebruikersnaam);
            _oleDbConnection.Open();
            klantnr = (int)oleDbCommand.ExecuteScalar();
            _oleDbConnection.Close();
            return klantnr;
        }

        public int aantalBesteldeProducten()
        {
            int aantal;
            string sql = "SELECT COUNT(*) FROM tblWinkelkar;";
            OleDbCommand oleDbCommand = new OleDbCommand(sql, _oleDbConnection);
            _oleDbConnection.Open();
            aantal = (int)oleDbCommand.ExecuteScalar();
            _oleDbConnection.Close();
            return aantal;
        }

        private string productNaam(string productNr)
        {
            //Koppel de bijhorende naam aan het productnummer
            string productnaam;
            string sql = "SELECT Naam FROM tblAutos WHERE Productnummer = @productnr;";
            OleDbCommand oleDbCommand = new OleDbCommand(sql, _oleDbConnection);
            oleDbCommand.Parameters.AddWithValue("@productnr", productNr);
            //_oleDbConnection.Open();
            productnaam = oleDbCommand.ExecuteScalar().ToString();
            //_oleDbConnection.Close();
            return productnaam;
        }

        public decimal totaalbedragWinkelkar()
        {
            decimal totaalbedrag = 0;
            if (aantalBesteldeProducten() != 0)
            {
                string sql = "SELECT SUM(Prijs) FROM tblWinkelkar;";
                OleDbCommand oleDbCommand = new OleDbCommand(sql, _oleDbConnection);
                _oleDbConnection.Open();
                totaalbedrag = (decimal)oleDbCommand.ExecuteScalar();
                _oleDbConnection.Close();
            }
            return totaalbedrag;
        }

        public List<string> alleBesteldeProducten()
        {
            List<string> lijst = new List<string>();
            string besteldProduct;
            string sql = "SELECT * FROM tblWinkelkar;";
            OleDbCommand oleDbCommand = new OleDbCommand(sql, _oleDbConnection);
            _oleDbConnection.Open();
            OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
            while (oleDbDataReader.Read() == true)
            {
                string productnaam = productNaam(oleDbDataReader["Productnummer"].ToString());
                besteldProduct = productnaam + "    -    prijs: " + ((decimal)oleDbDataReader["Prijs"]).ToString("C") + "    -    productnummer: " + (int)oleDbDataReader["Productnummer"];
                lijst.Add(besteldProduct);
            }
            _oleDbConnection.Close();
            return lijst;
        }



        public int plaatsBestelling(int klantnr)
        {
            //Voeg alle producten uit tblWinkelkar toe aan tblBestellingen en tblBestellijnen.

            //1) Maak een bestelling voor deze klant in tblBestellingen
            string sql1 = "INSERT INTO tblBestellingen(Klantnummer, Besteldatum) VALUES(@Klantnr, @Besteldatum);";
            OleDbCommand oleDbCommand1 = new OleDbCommand(sql1, _oleDbConnection);
            oleDbCommand1.Parameters.AddWithValue("@Klantnr", klantnr);
            oleDbCommand1.Parameters.AddWithValue("@Besteldatum", DateTime.Today);
            _oleDbConnection.Open();
            oleDbCommand1.ExecuteNonQuery();
            _oleDbConnection.Close();

            //2) Vraag het bestelnummer op van deze laatste bestelling (autonummering in tblBestellingen)
            int bestelnr; 
            string sql2 = "SELECT Max(Bestelnummer) FROM tblBestellingen;";
            OleDbCommand oleDbCommand2 = new OleDbCommand(sql2, _oleDbConnection);
            _oleDbConnection.Open();
            bestelnr = (int)oleDbCommand2.ExecuteScalar();
            _oleDbConnection.Close();

            //3) Overloop alle bestelde producten uit de winkelkar (=sql3)
            string sql3 = "SELECT * FROM tblWinkelkar";
            OleDbCommand oleDbCommand3 = new OleDbCommand(sql3, _oleDbConnection);
            _oleDbConnection.Open();
            OleDbDataReader oleDbDataReader = oleDbCommand3.ExecuteReader();
            while (oleDbDataReader.Read() == true)
            {
                //Voeg elk product toe aan tblBestellijnen (=sql4)
                string productnr = oleDbDataReader["Productnummer"].ToString();
                //int aantal = (int)oleDbDataReader["Aantal"];
                decimal prijs = (decimal)oleDbDataReader["Prijs"];
                string sql4 = "INSERT INTO tblBestellijnen(Bestelnummer, Productnummer, Prijs) VALUES(@Bestelnr, @Productnr, @Prijs);";
                OleDbCommand oleDbCommand4 = new OleDbCommand(sql4, _oleDbConnection);
                oleDbCommand4.Parameters.AddWithValue("@Bestelnr", bestelnr);
                oleDbCommand4.Parameters.AddWithValue("@Productnr", productnr);
                //oleDbCommand4.Parameters.AddWithValue("@Aantal", aantal);
                oleDbCommand4.Parameters.AddWithValue("@Prijs", prijs);
                oleDbCommand4.ExecuteNonQuery();
            }
            _oleDbConnection.Close();

            //Het bestelnummer van deze bestelling geven we door aan het BedanktForm.
            return bestelnr;
        }

        public void maakWinkelkarLeeg()
        {
            string sql = "DELETE FROM tblWinkelkar;";
            OleDbCommand oleDbCommand = new OleDbCommand(sql, _oleDbConnection);
            _oleDbConnection.Open();
            oleDbCommand.ExecuteNonQuery();
            _oleDbConnection.Close();
        }
    }
}
