using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using Business;

namespace DataAccess
{
    public class KlantenDA
    {
        private string _connString;
        private OleDbConnection _oleDbConnection;

        public KlantenDA()
        {
            _connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\databanken\\bavaria.mdb";
            _oleDbConnection = new OleDbConnection(_connString);
        }

        public bool CheckLogin(string login, string paswoord)
        {
            int aantal;
            string sql = "SELECT COUNT(*) FROM tblKlanten WHERE Login = @login and Paswoord = @paswoord;";
            OleDbCommand oleDbCommand = new OleDbCommand(sql, _oleDbConnection);
            oleDbCommand.Parameters.AddWithValue("@login", login);
            oleDbCommand.Parameters.AddWithValue("@paswoord", paswoord);
            _oleDbConnection.Open();
            aantal = (int)oleDbCommand.ExecuteScalar();
            _oleDbConnection.Close();
            if (aantal == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void WerknemerToevoegen(string login)
        {
            string sql = "UPDATE tblKlanten SET IsWerknemer = true WHERE Login = @login;";
            OleDbCommand oleDbCommand = new OleDbCommand(sql, _oleDbConnection);
            oleDbCommand.Parameters.AddWithValue("@login", login);
            _oleDbConnection.Open();
            oleDbCommand.ExecuteNonQuery();
            _oleDbConnection.Close();
        }

        public bool CheckGegevens(string login)
        {
            int aantal;
            string sql = "SELECT COUNT(*) FROM tblKlanten WHERE Login = @login;";
            OleDbCommand oleDbCommand = new OleDbCommand(sql, _oleDbConnection);
            oleDbCommand.Parameters.AddWithValue("@login", login);
            _oleDbConnection.Open();
            aantal = (int)oleDbCommand.ExecuteScalar();
            _oleDbConnection.Close();
            if (aantal == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        public void NieuweKlant(Klant klant)
        {
            string sql = "INSERT INTO tblKlanten(Voornaam, Achternaam, Straat, Huisnr, Postcode, BTWnr, Type, Login, Paswoord) VALUES(@Vooraam, @Achternaam, @Straat, @Huisnr, @Postcode, @BTWnr, @Type, @Login, @Paswoord);";
            OleDbCommand oleDbCommand = new OleDbCommand(sql, _oleDbConnection);
            oleDbCommand.Parameters.AddWithValue("@Vooraam", klant.Voornaam);
            oleDbCommand.Parameters.AddWithValue("@Achternaam", klant.Achternaam);
            oleDbCommand.Parameters.AddWithValue("@Straat", klant.Straat);
            oleDbCommand.Parameters.AddWithValue("@Huisnr", klant.Huisnr);
            oleDbCommand.Parameters.AddWithValue("@Postcode", klant.Postcode);
            oleDbCommand.Parameters.AddWithValue("@BTWnr", klant.BtwNr);
            oleDbCommand.Parameters.AddWithValue("@Type", klant.Type);
            oleDbCommand.Parameters.AddWithValue("@Login", klant.Gebruikersnaam);
            oleDbCommand.Parameters.AddWithValue("@Paswoord", klant.Wachtwoord);
            _oleDbConnection.Open();
            oleDbCommand.ExecuteNonQuery();
            _oleDbConnection.Close();
        }

        public List<Postcode> allePostcodes()
        {
            List<Postcode> lijst = new List<Postcode>();
            string sql = "SELECT * FROM tblPostcodes ORDER BY Postcode;";
            OleDbCommand oleDbCommand = new OleDbCommand(sql, _oleDbConnection);
            _oleDbConnection.Open();
            OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
            while (oleDbDataReader.Read() == true)
            {
                Postcode postcode = new Postcode(oleDbDataReader["Postcode"].ToString(),
                        oleDbDataReader["Gemeente"].ToString());
                lijst.Add(postcode);
            }
            _oleDbConnection.Close();
            return lijst;
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



    }
}
