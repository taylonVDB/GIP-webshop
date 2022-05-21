using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Business;
using DataAccess;

namespace Presentation
{
    public partial class StartForm : Form
    {

        private StartFormDA _startformDA;
        WinkelkarDA _winkelkarDA;
        
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
            (
                int nLeftRect,
                int nTopRect,
                int nRightRect,
                int nBottomRect,
                int nWidthEllipse,
                int nHeightEllipse
            );


        public StartForm()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            _startformDA = new StartFormDA();
            _winkelkarDA = new WinkelkarDA();
            toonInfo();
        }

        private void toonInfo()
        {
            navigeerPanel.Height = startschermButton.Height;
            navigeerPanel.Top = startschermButton.Top;
            navigeerPanel.Left = startschermButton.Left;
            startschermButton.BackColor = Color.FromArgb(46, 51, 73);
            werknemerButton.Visible = false;

            if(_startformDA.BestaatPersoon(GebruikersnaamLabel.Text) == true)
            {
                if (_startformDA.isWerknemer(GebruikersnaamLabel.Text) == false)
                {
                    werknemerButton.Visible = true;
                }
                else
                {
                    werknemerButton.Visible = false;
                }
            }
            


            titelLabel.Text = "Startscherm";
            this.formulierladerPanel.Controls.Clear();
            StartschermFrom startschermForm = new StartschermFrom() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            startschermForm.FormBorderStyle = FormBorderStyle.None;
            this.formulierladerPanel.Controls.Add(startschermForm);
            startschermForm.Show();
        }

        private void GebruikersnaamLabel_Click(object sender, EventArgs e)
        {

        }

        private void DesignTestForm_Load(object sender, EventArgs e)
        {

        }

        private void startschermButton_Click(object sender, EventArgs e)
        {
            navigeerPanel.Height = startschermButton.Height;
            navigeerPanel.Top = startschermButton.Top;
            navigeerPanel.Left = startschermButton.Left;
            startschermButton.BackColor = Color.FromArgb(46, 51, 73);

            titelLabel.Text = "Startscherm";
            this.formulierladerPanel.Controls.Clear();
            StartschermFrom startschermForm = new StartschermFrom() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            startschermForm.FormBorderStyle = FormBorderStyle.None;
            this.formulierladerPanel.Controls.Add(startschermForm);
            startschermForm.Show();
        }

        private void productoverzichtButton_Click(object sender, EventArgs e)
        {
            navigeerPanel.Height = productoverzichtButton.Height;
            navigeerPanel.Top = productoverzichtButton.Top;
            productoverzichtButton.BackColor = Color.FromArgb(46, 51, 73);

            titelLabel.Text = "Productoverzicht";
            this.formulierladerPanel.Controls.Clear();
            ProductOverzicht productoverzicht = new ProductOverzicht(this.formulierladerPanel) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            productoverzicht.FormBorderStyle = FormBorderStyle.None;
            this.formulierladerPanel.Controls.Add(productoverzicht);
            productoverzicht.Show();
        }

        private void winkelkarButton_Click(object sender, EventArgs e)
        {
            navigeerPanel.Height = winkelkarButton.Height;
            navigeerPanel.Top = winkelkarButton.Top;
            winkelkarButton.BackColor = Color.FromArgb(46, 51, 73);

            if(GebruikersnaamLabel.Text == "Niet aangemeld")
            {
                titelLabel.Text = "Niet aangemeld!";
                this.formulierladerPanel.Controls.Clear();
                NietAangemeldForm nietaangemeldfrom = new NietAangemeldForm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                nietaangemeldfrom.FormBorderStyle = FormBorderStyle.None;
                this.formulierladerPanel.Controls.Add(nietaangemeldfrom);
                nietaangemeldfrom.Show();
            }
            else
            {
                titelLabel.Text = "Winkelkar";
                this.formulierladerPanel.Controls.Clear();
                Winkelkar winkelkar = new Winkelkar(this.GebruikersnaamLabel, this.formulierladerPanel) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                winkelkar.FormBorderStyle = FormBorderStyle.None;
                this.formulierladerPanel.Controls.Add(winkelkar);
                winkelkar.Show();
            }
        }

        private void bestellingenButton_Click(object sender, EventArgs e)
        {
            /*navigeerPanel.Height = bestellingenButton.Height;
            navigeerPanel.Top = bestellingenButton.Top;
            bestellingenButton.BackColor = Color.FromArgb(46, 51, 73);

            if (GebruikersnaamLabel.Text == "Niet aangemeld")
            {
                titelLabel.Text = "Niet aangemeld!";
                this.formulierladerPanel.Controls.Clear();
                NietAangemeldForm nietaangemeldfrom = new NietAangemeldForm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                nietaangemeldfrom.FormBorderStyle = FormBorderStyle.None;
                this.formulierladerPanel.Controls.Add(nietaangemeldfrom);
                nietaangemeldfrom.Show();
            }
            else
            {
                titelLabel.Text = "Bestellingen";
                this.formulierladerPanel.Controls.Clear();
                BestellingenForm bestellingenForm = new BestellingenForm(this.GebruikersnaamLabel) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                bestellingenForm.FormBorderStyle = FormBorderStyle.None;
                this.formulierladerPanel.Controls.Add(bestellingenForm);
                bestellingenForm.Show();
            }*/
        }

        private void instellingenButton_Click(object sender, EventArgs e)
        {
            navigeerPanel.Height = instellingenButton.Height;
            navigeerPanel.Top = instellingenButton.Top;
            instellingenButton.BackColor = Color.FromArgb(46, 51, 73);

            titelLabel.Text = "Instellingen";
            this.formulierladerPanel.Controls.Clear();
            instellingenForm instellingsform = new instellingenForm(this.GebruikersnaamLabel, this.werknemerButton) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            instellingsform.FormBorderStyle = FormBorderStyle.None;
            this.formulierladerPanel.Controls.Add(instellingsform);
            instellingsform.Show();
        }

        private void startschermButton_Leave(object sender, EventArgs e)
        {
            startschermButton.BackColor = Color.FromArgb(24, 30 , 54);
        }

        private void productoverzichtButton_Leave(object sender, EventArgs e)
        {
            productoverzichtButton.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void winkelkarButton_Leave(object sender, EventArgs e)
        {
            winkelkarButton.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void bestellingenButton_Leave(object sender, EventArgs e)
        {
            //bestellingenButton.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void instellingenButton_Leave(object sender, EventArgs e)
        {
            instellingenButton.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            _winkelkarDA.maakWinkelkarLeeg();
            Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void formulierladerPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void infoBestelButton_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            navigeerPanel.Height = werknemerButton.Height;
            navigeerPanel.Top = werknemerButton.Top;
            werknemerButton.BackColor = Color.FromArgb(46, 51, 73);

            titelLabel.Text = "Werknemersmenu";
            this.formulierladerPanel.Controls.Clear();
            Werknemersmenu werknemersform = new Werknemersmenu(this.formulierladerPanel) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            werknemersform.FormBorderStyle = FormBorderStyle.None;
            this.formulierladerPanel.Controls.Add(werknemersform);
            werknemersform.Show();
        }
    }
}
