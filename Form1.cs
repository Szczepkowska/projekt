﻿using System;
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
            MessageBox.Show("Ewa", "o kółko i krzyżyk");
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
            wyborzwyciezcy();
        }
        private void wyborzwyciezcy()
        { bool zwyciezca= false;

            //poziomo
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text))
                zwyciezca = true;
           else if ((B1.Text == B2.Text) && (B2.Text == B3.Text))
                zwyciezca = true;
           else if ((C1.Text == C2.Text) && (C2.Text == C3.Text))
                zwyciezca = true;

            if (zwyciezca) {
                String wygrany = "";
                if (turn)
                    wygrany = "O";
                else
                    wygrany = "X";
                MessageBox.Show(wygrany + "WYGRANA");
                    }
        }
    }
}
