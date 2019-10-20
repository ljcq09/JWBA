using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace sunshield
{
    class Moneda
    {
        private PictureBox moneda = new PictureBox(); 
        public Moneda() {

            moneda.Width = 10;
            moneda.Height = 10;
            moneda.BackColor = Color.Blue;
        }

        public void drawTo(Form f) {
            f.Controls.Add(moneda);
                }
    }
}
