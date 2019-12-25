using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using N_Puzzle.UserControls;
namespace N_Puzzle.Forms
{
    public partial class mainForm : MetroFramework.Forms.MetroForm
    {
        public mainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Read all files and load data to UI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainForm_Load(object sender, EventArgs e)
        {
            containerUserControl container=new containerUserControl();
            for (int n = 7; n >0; n--)
            {
                string[] lines = System.IO.File.ReadAllLines(@"" + n+".txt");


                int m = Int32.Parse(lines[0]);
                int[,] arr = new int[m, m];
                string[] str;
                for (int i = 2, j = 0; i < m + 2; i++, j++)
                {
                    str = lines[i].Split(' ');
                    for (int k = 0; k < m; k++)
                    {
                        arr[j, k] = Int32.Parse(str[k]);
                    }

                }
                container.addMatrix(arr);

            }
            panel1.Controls.Add(container);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
