﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RockysTicTacToeGame
{
    public partial class GruEatenBySharkForm : Form
    {
        public GruEatenBySharkForm()
        {
            InitializeComponent();
            this.Dock = DockStyle.Top;

        }

        private void stopTimer_Tick(object sender, EventArgs e)
        {
            stopTimer.Stop();
            Close();
        }
    }
}
