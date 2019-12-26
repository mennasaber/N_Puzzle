using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using N_Puzzle.Forms;
namespace N_Puzzle.UserControls
{
    public partial class matrix_3_userControl : UserControl
    {
        int location;
        Label label;
        int[,] matrix;
        /// <summary>
        /// constructor for mainForm
        /// </summary>
        /// <param name="matrix"></param>
        public matrix_3_userControl(int [,] matrix)
        {
            InitializeComponent();
            this.matrix = matrix;
            load_data(matrix);
        }
        /// <summary>
        /// Constructor for playForm
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="check"></param>
        public matrix_3_userControl(int[,] matrix,int check)
        {
            InitializeComponent();
            this.matrix = matrix;
            load_data(matrix,check);
        }

        /// <summary>
        /// Load data of matrix to playForm UI 
        /// Label don't have listener 
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="check"></param>
        private void load_data(int[,] matrix, int check)
        {
            flowLayoutPanel1.Controls.Clear();

            location = (Convert.ToInt32(Math.Sqrt(matrix.Length) * 40) / 2) - 40;
            this.Size = new Size(Convert.ToInt32(Math.Sqrt(matrix.Length) * 40), Convert.ToInt32(Math.Sqrt(matrix.Length) * 40));
            for (int i = 0; i < Math.Sqrt(matrix.Length); i++)
            {
                for (int j = 0; j < Math.Sqrt(matrix.Length); j++)
                {
                    label = new Label();
                    label.BackColor = System.Drawing.Color.LightGray;
                    label.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                    label.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    label.ForeColor = System.Drawing.Color.Black;
                    label.Location = new System.Drawing.Point(86, 3);
                    label.Size = new System.Drawing.Size(38, 38);
                    label.TabIndex = 19;
                    label.Margin = new Padding(1, 1, 1, 1);
                    label.Text = matrix[i, j].ToString();
                    label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    flowLayoutPanel1.Controls.Add(label);
                }
            }
        }
        /// <summary>
        /// Load data of matrix to mainForm UI
        /// Label has listener to open playForm
        /// </summary>
        /// <param name="matrix"></param>
        private void load_data(int[,] matrix)
        {
        
            flowLayoutPanel1.Controls.Clear();
            
            location = (Convert.ToInt32(Math.Sqrt(matrix.Length) * 40) / 2) - 40;
            this.Size = new Size(Convert.ToInt32( Math.Sqrt(matrix.Length) * 40), Convert.ToInt32( Math.Sqrt(matrix.Length) * 40));
            for (int i = 0;i<Math.Sqrt(matrix.Length);i++)
            {
                for(int j = 0; j < Math.Sqrt(matrix.Length); j++)
                {
                    label = new Label();
                    label.BackColor = System.Drawing.Color.LightGray;
                    label.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                    label.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    label.ForeColor = System.Drawing.Color.Black;
                    label.Location = new System.Drawing.Point(86, 3);
                    label.Size = new System.Drawing.Size(38, 38);
                    label.TabIndex = 19;
                    label.Margin = new Padding(1,1,1,1);
                    label.Text = matrix[i,j].ToString();
                    label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    flowLayoutPanel1.Controls.Add(label);
                    label.Click += new EventHandler(Click_label);
                }
            }
         
        }
        /// <summary>
        /// Click Listener to open playForm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Click_label(object sender, EventArgs e)
        {           
            playForm playForm = new playForm(matrix);
            playForm.Show();
            
        }
    }
}
