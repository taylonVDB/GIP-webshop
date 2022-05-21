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
    public partial class ProductOverzicht : Form
    {
        private ProductOverzichtDA _productOverzichtDA;
        private WinkelkarDA _winkelkarDA;
        private List<Categorie> _categorieLijst;
        private List<Product> _productenlijst;
        private System.Windows.Forms.Panel _formulierladerPanel;

        public ProductOverzicht(System.Windows.Forms.Panel formulierladerPanel)
        {
            InitializeComponent();
            _categorieLijst = new List<Categorie>();
            _productenlijst = new List<Product>();
            _productOverzichtDA = new ProductOverzichtDA();
            _winkelkarDA = new WinkelkarDA();
            _formulierladerPanel = formulierladerPanel;
            toonInfo();
        }

        private void toonInfo()
        {
            _categorieLijst = _productOverzichtDA.alleCategorien();
            categorieComboBox.DataSource = null;
            categorieComboBox.DataSource = _categorieLijst;
            //Aantal bestelde producten in het label plaatsen.
            aantalBesteldeProductenLabel.Text = _winkelkarDA.aantalBesteldeProducten().ToString();
            //Hiervoor in de DA-klasse een ExecuteScalar die het aantal record in tblWinkelkar telt.
            if (productenListbox.Items.Count == 0)
            {
                infoBestelButton.Enabled = false;
            }
            else
            {
                infoBestelButton.Enabled = true;
            }
        }

        private void categorieComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Categorie categorie = (Categorie) categorieComboBox.SelectedItem;
            if (categorie != null)
            {
                int categorieNr = categorie.CategorieNr;
                _productenlijst = _productOverzichtDA.alleProductenUitCategorie(categorieNr);
                productenListbox.DataSource = null;
                productenListbox.DataSource = _productenlijst;
                //productenListbox.SelectedIndex = 0;
            }
            if (productenListbox.Items.Count == 0)
            {
                infoBestelButton.Enabled = false;
            }
            else
            {
                infoBestelButton.Enabled = true;
            }
        }

        private void infoBestelButton_Click(object sender, EventArgs e)
        {
            Product product = (Product)productenListbox.SelectedItem;

            if (product != null)
            {
                _formulierladerPanel.Controls.Clear();
                ProductForm infoForm = new ProductForm(product, _formulierladerPanel) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                infoForm.FormBorderStyle = FormBorderStyle.None;
                _formulierladerPanel.Controls.Add(infoForm);
                infoForm.Show();
            }
            toonInfo();               
        }

        private void gaNaarWinkelkarButton_Click(object sender, EventArgs e)
        {

        }

        private void productenListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            fotoPicturebox.Visible = false;
            if((Product)productenListbox.SelectedItem != null)
            {
                Product product = (Product)productenListbox.SelectedItem;

                //Hier heb ik via een SQL-query de plaats van de foto opgezocht
                //aan de hand van de naam. Wellicht kunnen jullie dit doen door
                //een bepaalde eigenschap van je object op te vragen.
                string fotoPlaats = product.Foto;
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
            

        }
    }
}
