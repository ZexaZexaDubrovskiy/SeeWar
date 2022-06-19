using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeeWarWindowsForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           // mainWindowClass1.CreateShipPlayer();
        }
        private void mainWindowClass1_Click(object sender, EventArgs e)
        {
            mainWindowClass1.ClickPlaceShip(MousePosition);
            
            
            mainWindowClass1.onClickListener(MousePosition);
        }

        private void ShipsBotlace_Click(object sender, EventArgs e)
        {
            mainWindowClass1.ShipPlaceRandom(false);
        }
        private void PlaceShipRangomHuman_Click(object sender, EventArgs e)
        {
            mainWindowClass1.ShipPlaceRandom(true);
        }

        private void StartGame_Click(object sender, EventArgs e)
        {
            mainWindowClass1.StartGame = true;
        }

        private void CreateShipNonRandom_Click(object sender, EventArgs e)
        {
            mainWindowClass1.CreateShipPlayer();
        }
    }
}
