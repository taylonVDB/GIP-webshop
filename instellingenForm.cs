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
    public partial class instellingenForm : Form
    {
        KlantenDA _klantenDA;
        private System.Windows.Forms.Label _klantLabel;
        private System.Windows.Forms.Button _werknemerbutton;

        public instellingenForm(System.Windows.Forms.Label klantLabel, System.Windows.Forms.Button werknemerbutton)
        {
            InitializeComponent();
            _klantenDA = new KlantenDA();
            _klantLabel = klantLabel;
            _werknemerbutton = werknemerbutton;
            toonInfo();
        }
        private void toonInfo()
        {
            if(_klantLabel.Text != "Niet aangemeld")
            {
                inlogButton.Enabled = false;
                _klantLabel.Text = gebruikersnaamTextBox.Text;
                aanmeldenButton.Visible = false;
                werknemersButton.Visible = true;
                label4.Visible = true;
                werknemerscodeTextBox.Visible = true;
            }
            werknemersButton.Visible = false;
            label4.Visible = false;
            werknemerscodeTextBox.Visible = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AanmeldenForm aanmeldenform = new AanmeldenForm();
            aanmeldenform.Show();
        }

        private void infoBestelButton_Click(object sender, EventArgs e)
        {            
            if(_klantenDA.CheckLogin(gebruikersnaamTextBox.Text, wachtwoordTextBox.Text) == true)
            {
                inlogBoodschapLabel.Text = "Je bent succesvol ingelogd.";
                inlogButton.Enabled = false;
                _klantLabel.Text = gebruikersnaamTextBox.Text;
                aanmeldenButton.Visible = false;
                werknemersButton.Visible = true;
                label4.Visible = true;
                werknemerscodeTextBox.Visible = true;
                _klantenDA.isWerknemer(gebruikersnaamTextBox.Text);
                if (_klantenDA.isWerknemer(_klantLabel.Text) == true)
                {
                    _werknemerbutton.Visible = true;
                }
                else
                {
                    _werknemerbutton.Visible = false;
                }
                gebruikersnaamTextBox.Text = String.Empty;
                wachtwoordTextBox.Text = String.Empty;
            }
            else
            {
                inlogBoodschapLabel.Text = "Gebruikersnaam/wachtwoord is onjuist.";
            }
        }

        private void inlogBoodschapLabel_Click(object sender, EventArgs e)
        {

        }

        private void instellingenForm_Load(object sender, EventArgs e)
        {

        }

        private void werknemersButton_Click(object sender, EventArgs e)
        {
            if(werknemerscodeTextBox.Text == "GIP_Taylon")
            {
                _klantenDA.WerknemerToevoegen(_klantLabel.Text);
                werknemersLabel.Text = "Je bent succesvol als werknemer ingelogd.";
                _werknemerbutton.Visible = true;
            }
            else
            {
                werknemersLabel.Text = "Verkeerde code!";
            }
        }
    }
}
