using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccess;
using Business;

namespace Presentation
{
    public partial class StartschermFrom : Form
    {
        StartFormDA _startformDA;
        public StartschermFrom()
        {
            InitializeComponent();
            _startformDA = new StartFormDA();
            toonInfo();
        }


        private void toonInfo()
        {
            wagensopvoorraadLabel.Text = _startformDA.aantalAutosvoorraad().ToString();
            if (_startformDA.isWinkelwagenLeeg() == true)
            {
                totaalwinkelwagenLabel.Text = "€ 0,00";
            }
            else
            {
                totaalwinkelwagenLabel.Text = _startformDA.totaalWaardeWagens().ToString("C");
            }
            //totaalwinkelwagenLabel.Text = _startformDA.totaalWaardeWagens().ToString("C");
            uitvoorraadLabel.Text = _startformDA.aantalAutosUitvoorraad().ToString();
            aantalwagenswinkelkarLabel.Text = _startformDA.aantalBesteldeWagens().ToString();

        }
    
    }
}
