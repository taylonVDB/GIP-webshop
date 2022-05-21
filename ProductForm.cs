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
using System.IO;

namespace Presentation
{
    public partial class ProductForm : Form
    {
        Product _product;
        ProductOverzichtDA _productOverzichtDA;
        WinkelkarDA _winkelkarDA;
        System.Windows.Forms.Panel _formulierladerPanel;

        public ProductForm(Product product, System.Windows.Forms.Panel formulierladerPanel)
        {
            InitializeComponent();
            _product = product;
            _productOverzichtDA = new ProductOverzichtDA();
            _winkelkarDA = new WinkelkarDA();
            _formulierladerPanel = formulierladerPanel;
            toonInfo();
        }

        private void toonInfo()
        {
            productnaamTextBox.Text = _product.Naam;
            beschrijvingTextBox.Text = _product.Omschrijving;
            productnummerTextBox.Text = _product.Productnr.ToString();
            jaarTextBox.Text = _product.Productiejaar.ToString();
            kmstandTextBox.Text = _product.Kilomterstand.ToString();
            if(_product.Voorraad == true)
            {
                voorraadTextBox.Text = "Ja";
            }
            else
            {
                voorraadTextBox.Text = "Nee";
            }
            //voorraadTextBox.Text = _product.Voorraad.ToString();
            prijsTextBox.Text = _product.Prijs.ToString("C");

            //Aangepaste code om het categorienummer te koppelen aan de categorienaam
            int groepsnummer = _product.Groepsnummer;
            groepsnaamTextBox.Text = _productOverzichtDA.categorieNaam(groepsnummer);





            fotoPicturebox.Visible = false;                    
                //Hier heb ik via een SQL-query de plaats van de foto opgezocht
                //aan de hand van de naam. Wellicht kunnen jullie dit doen door
                //een bepaalde eigenschap van je object op te vragen.
                string fotoPlaats = _product.Foto;
                //ter controle: 
                //fotoPlaatsLabel.Text = fotoPlaats;

                //De foto, als deze er is, tonen in de fotoPicturebox
                if (!string.IsNullOrWhiteSpace(fotoPlaats))
                {
                    //om dit Path te kunnen gebruiken moet je using System.IO toevoegen 
                    //aan je code!
                    string path = Path.Combine(Properties.Settings.Default.afbeeldingenFolder, fotoPlaats);
                    if (File.Exists(path))
                    {
                        fotoPicturebox.Image = Image.FromFile(path);
                        fotoPicturebox.Visible = true;
                    }
                }            
        }

        private void bestelButton_Click(object sender, EventArgs e)
        {

            //Ga na of de voorraad hoog genoeg is om besteld te worden en geef een boodschap.
            if (_product.Voorraad == true)
            {
                _winkelkarDA.voegProductToeAanWinkelkar(_product);
                _product.Voorraad = false;    //Het getoonde product aanpassen
                toonInfo();
                bestelBoodschapLabel.Text = "Je product is goed besteld.";
            }
            else
            {
                bestelBoodschapLabel.Text = "Je product is NIET besteld.";
            }
            
        }

        private void sluitenButton_Click(object sender, EventArgs e)
        {
            Close();
            _formulierladerPanel.Controls.Clear();
            ProductOverzicht productoverzicht = new ProductOverzicht(_formulierladerPanel) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };    //************GEWIJZIGD !!!!!!!!!!!!!!!!!!!!!!!!!
            productoverzicht.FormBorderStyle = FormBorderStyle.None;
            _formulierladerPanel.Controls.Add(productoverzicht);
            productoverzicht.Show();
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {

        }
    }
}
