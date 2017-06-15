using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projekt
{
    public partial class Form1 : Form
    {
        bool turn = true; // true = X turn,false = Y turn
        int turn_count = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void informacjeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Gra strategiczna dla dwóch graczy. Gracze obejmują pola na przemian i dążą do objęcia trzech pól w jednej linii. Przeciwnik uniemożliwia mu to.", "Zasady gry");
        }

        private void wyjdżToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn)
                b.Text = "X";
            else
                b.Text = "O";
            turn = !turn;
            b.Enabled = false;
            turn_count++;

            wyborzwyciezcy();
        }
        private void wyborzwyciezcy()
        { bool zwyciezca= false;

            //poziomo
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text)&&(!A1.Enabled))
                zwyciezca = true;
           else if ((B1.Text == B2.Text) && (B2.Text == B3.Text)&&(!B1.Enabled))
                zwyciezca = true;
           else if ((C1.Text == C2.Text) && (C2.Text == C3.Text)&&(!C1.Enabled))
                zwyciezca = true;
            //pionowo
          else if((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
                zwyciezca = true;
           else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
                zwyciezca = true;
            else if ((A3.Text ==B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
                zwyciezca = true;
            //poprzecznie 
            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
                zwyciezca = true;
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!A3.Enabled))
                zwyciezca = true;


            if (zwyciezca)
            {
                disableButtons();

                String wygrany = "";
                if (turn)
                {
                    wygrany = "O";
                    wygrane_o.Text = (Int32.Parse(wygrane_o.Text) + 1).ToString();
                }
                else
                {
                    wygrany = "X";
                    wygrane_x.Text = (Int32.Parse(wygrane_x.Text) + 1).ToString();
                }
                    MessageBox.Show(wygrany + " WYGRANA!!!");
                
            }
            else
            {
                if (turn_count == 9)
                {

                    remis.Text = (Int32.Parse(remis.Text) + 1).ToString();
                    MessageBox.Show("Spróbuj jeszcze raz!");
                }

            }
        }
        private void disableButtons()
        {
            try
            {

                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }
            }
            catch { }
        }

        private void nowaGraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true;
            turn_count = 0;


            foreach (Control c in Controls)
            {
                try
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                }

                catch { }
            }
        }

        private void button_enter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
            {

                if (turn)
                    b.Text = "X";
                else
                    b.Text = "O";
            }
        }

        private void button_leave(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
            {
                b.Text = "";
                
            }
        }

        private void resestujWyświetlanieWygranychToolStripMenuItem_Click(object sender, EventArgs e)
        {
            wygrane_o.Text = "0";
            wygrane_x.Text = "0";
            remis.Text = "0";
        }
    }
}
