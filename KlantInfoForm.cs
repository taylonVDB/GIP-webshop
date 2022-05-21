using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business;
using DataAccess;

namespace Presentation
{
    public partial class KlantInfoForm : Form
    {
        private System.Windows.Forms.Panel _formulierladerPanel;
        Klant _klant;
        WerknemerDA _werknemerDA;

        public KlantInfoForm(Klant klant, System.Windows.Forms.Panel formulierladerPanel)
        {
            InitializeComponent();
            _formulierladerPanel = formulierladerPanel;
            _klant = klant;
            /*_klant = new Klant(klant.KlantNr, klant.Voornaam, klant.Achternaam, klant.Straat, klant.Huisnr,
                               klant.Postcode, klant.BtwNr, klant.Type, klant.Opmerking, 
                               klant.Gebruikersnaam, klant.Wachtwoord, klant.IsWerknemer);*/
            _werknemerDA = new WerknemerDA();
            toonInfo();
        }

        private void toonInfo()
        {
            if(BTWnrTextBox.ToString() == String.Empty)
            {
                BTWnrTextBox.Text = "";
            }
            if (opmerkingTextBox.ToString() == String.Empty)
            {
                opmerkingTextBox.Text = "";
            }
            KlantenNummerTextBox.Text = _klant.KlantNr.ToString();
            VoornaamTextBox.Text = _klant.Voornaam;
            achternaamTextBox.Text = _klant.Achternaam;
            straatTextBox.Text = _klant.Straat;
            huisnrTextBox.Text = _klant.Huisnr;
            postcodeTextBox.Text = _klant.Postcode;
            BTWnrTextBox.Text = _klant.BtwNr;
            typeTextBox.Text = _klant.Type;
            opmerkingTextBox.Text = _klant.Opmerking;
            loginTextBox.Text = _klant.Gebruikersnaam;
            wwTextBox.Text = _klant.Wachtwoord;
        }

        private void bestelButton_Click(object sender, EventArgs e)
        {
            _werknemerDA.UpdateKlant(Convert.ToInt32(KlantenNummerTextBox.Text), VoornaamTextBox.Text, achternaamTextBox.Text, straatTextBox.Text,
                                     huisnrTextBox.Text, postcodeTextBox.Text, BTWnrTextBox.Text, typeTextBox.Text, opmerkingTextBox.Text);
            bestelBoodschapLabel.Text = "Uw klant is gewijzigd.";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(wwTextBox.PasswordChar == '*')
            {
                wwTextBox.UseSystemPasswordChar = false;
            }
            else
            {
                wwTextBox.UseSystemPasswordChar = true;
            }
        }

        private void sluitenButton_Click(object sender, EventArgs e)
        {
            Close();
            _formulierladerPanel.Controls.Clear();
            Werknemersmenu werknemersnemu = new Werknemersmenu(_formulierladerPanel) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };   
            werknemersnemu.FormBorderStyle = FormBorderStyle.None;
            _formulierladerPanel.Controls.Add(werknemersnemu);
            werknemersnemu.Show();
        }
    }
}
