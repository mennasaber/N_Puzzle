using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace N_Puzzle.UserControls
{
    public partial class containerUserControl : UserControl
    {
        /// <summary>
        /// Constructor for mainForm
        /// </summary>
        /// <param name="matrix"></param>
        public containerUserControl(int [,] matrix)
        {
            InitializeComponent();
            matrix_3_userControl m = new matrix_3_userControl(matrix);
            flowLayoutPanel.Controls.Add(m);
        }

        /// <summary>
        /// Constructor for playForm
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="check"></param>
        public containerUserControl(int[,] matrix,int check)
        {
            InitializeComponent();
            matrix_3_userControl m = new matrix_3_userControl(matrix,1);
            flowLayoutPanel.Controls.Add(m);
        }

        /// <summary>
        /// Constructor for initialization
        /// </summary>
        public containerUserControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Add matrix to mainForm UI
        /// </summary>
        /// <param name="matrix"></param>
        public void addMatrix(int[,] matrix)
        {
            matrix_3_userControl m = new matrix_3_userControl(matrix);
            flowLayoutPanel.Controls.Add(m);
        }

        /// <summary>
        /// Add matrix to playForm UI
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="check"></param>
        public void addMatrix(int[,] matrix,int check)
        {
            matrix_3_userControl m = new matrix_3_userControl(matrix,check);
            flowLayoutPanel.Controls.Add(m);
        }
        private void flowLayoutPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
