using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using Business;

namespace DataAccess
{
    public class StartFormDA
    {
        private string _connString;
        private OleDbConnection _oleDbConnection;

        public StartFormDA()
        {
            _connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\databanken\\bavaria.mdb";
            _oleDbConnection = new OleDbConnection(_connString);
        }


        public int aantalAutosvoorraad()
        {
            int aantal;
            string sql = "SELECT COUNT(*) FROM tblAutos WHERE(Voorraad = true);";
            OleDbCommand oleDbCommand = new OleDbCommand(sql, _oleDbConnection);
            _oleDbConnection.Open();
            aantal = (int)oleDbCommand.ExecuteScalar();
            _oleDbConnection.Close();
            return aantal;
        }

        public bool isWinkelwagenLeeg()
        {
            int aantal;
            string sql = "SELECT COUNT(*) FROM tblWinkelkar;";
            OleDbCommand oleDbCommand = new OleDbCommand(sql, _oleDbConnection);
            _oleDbConnection.Open();
            aantal = (int)oleDbCommand.ExecuteScalar();
            _oleDbConnection.Close();
            if(aantal == 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public decimal totaalWaardeWagens()
        {
            decimal totaal;
            string sql = "SELECT SUM(Prijs) FROM tblWinkelkar;";
            OleDbCommand oleDbCommand = new OleDbCommand(sql, _oleDbConnection);
            _oleDbConnection.Open();
            totaal = (decimal)oleDbCommand.ExecuteScalar();
            _oleDbConnection.Close();
            return totaal;
        }

        public int aantalAutosUitvoorraad()
        {
            int aantal;
            string sql = "SELECT COUNT(*) FROM tblAutos WHERE(Voorraad = false);";
            OleDbCommand oleDbCommand = new OleDbCommand(sql, _oleDbConnection);
            _oleDbConnection.Open();
            aantal = (int)oleDbCommand.ExecuteScalar();
            _oleDbConnection.Close();
            return aantal;
        }

        public int aantalBesteldeWagens()
        {
            int aantal;
            string sql = "SELECT COUNT(*) FROM tblWinkelkar;";
            OleDbCommand oleDbCommand = new OleDbCommand(sql, _oleDbConnection);
            _oleDbConnection.Open();
            aantal = (int)oleDbCommand.ExecuteScalar();
            _oleDbConnection.Close();
            return aantal;
        }

        public bool isWerknemer(string login)
        {
            Klant klant = null;
            string sql = "SELECT * FROM tblKlanten WHERE Login = @login;";
            OleDbCommand oleDbCommand = new OleDbCommand(sql, _oleDbConnection);
            oleDbCommand.Parameters.AddWithValue("@login", login);
            _oleDbConnection.Open();
            OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
            while (oleDbDataReader.Read() == true)
            {
                klant = new Klant((int)oleDbDataReader["Klantnummer"],
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
            }
            _oleDbConnection.Close();

            if (klant.IsWerknemer == true)
            {
                return true;
            }
            else
            {
                return false;
            }            
        }

        public bool BestaatPersoon(string login)
        {
            int aantal;
            string sql = "SELECT COUNT(*) FROM tblKlanten WHERE Login = @login;";
            OleDbCommand oleDbCommand = new OleDbCommand(sql, _oleDbConnection);
            oleDbCommand.Parameters.AddWithValue("@login", login);
            _oleDbConnection.Open();
            aantal = (int)oleDbCommand.ExecuteScalar();
            _oleDbConnection.Close();
            if(aantal != 1)
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
