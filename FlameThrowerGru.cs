using System;
using System.Windows.Forms;

namespace RockysTicTacToeGame
{
    public partial class FlameThrowerGru : Form
    {
        public FlameThrowerGru()
        {
            InitializeComponent();
            this.Dock = DockStyle.Top;
        }

        private void closeTimer_Tick(object sender, EventArgs e)
        {
            closeTimer.Stop();
            Close();
        }
    }
}
