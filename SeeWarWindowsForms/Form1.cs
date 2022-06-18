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
        }

        private void mainWindowClass1_Click(object sender, EventArgs e)
        {
            mainWindowClass1.onClickListener(MousePosition);
        }

        private void ShipsBotlace_Click(object sender, EventArgs e)
        {
            mainWindowClass1.updateArray();
            mainWindowClass1.ShipPlaceRandom();
            //mainWindowClass1.click();
            //mainWindowClass1.ShipPlaceRandom();
        }
    }
}
